/*
 * Sample code demonstrating how to generate Excel spreadsheets on the server using 
 * Office Open XML and the ExcelPackage wrapper classes.
 * 
 * ExcelPackage provides server-side generation of Excel 2007 spreadsheets.
 * See http://www.codeplex.com/ExcelPackage for details.
 * 
 * Sample 1: Creates a basic workbook from scratch.
 * 
 * Copyright 2007 © Dr John Tunnicliffe 
 * mailto:dr.john.tunnicliffe@btinternet.com
 * All rights reserved.
 * 
 * All code and executables are provided "as is" with no warranty either express or implied. 
 * The author accepts no liability for any damage or loss of business that this product may cause.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using OfficeOpenXml;
using System.Xml;

namespace ExcelPackageSamples
{
	class Sample1
	{
		/// <summary>
		/// Sample 1 - simply creates a new workbook from scratch.
		/// The workbook contains one worksheet which adds a few numbers together.
		/// Not very exciting, but it demonstrates the power of the ExcelPackage assembly.
		/// </summary>
		public static string RunSample1(DirectoryInfo outputDir)
		{
			FileInfo newFile = new FileInfo(outputDir.FullName + @"\sample1.xlsx");
			if (newFile.Exists)
			{
				newFile.Delete();  // ensures we create a new workbook
				newFile = new FileInfo(outputDir.FullName + @"\sample1.xlsx");
			}
			using (ExcelPackage xlPackage = new ExcelPackage(newFile))
			{
				// this will cause the assembly to output the raw XML files in the outputDir
				// for debug purposes.  You will see to sub-folders called 'xl' and 'docProps'.
				xlPackage.DebugMode = true;

				// add a new worksheet to the empty workbook
				ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.Add("Tinned Goods");
				// write some strings into column 1
				worksheet.Cell(1, 1).Value = "Product";
				worksheet.Cell(2, 1).Value = "Broad Beans";
				worksheet.Cell(3, 1).Value = "Carrots";
				worksheet.Cell(4, 1).Value = "Peas";
				worksheet.Cell(5, 1).Value = "Total";

				// increase the width of column one as these strings will be too wide to display
				worksheet.Column(1).Width = 15;

				// write some values into column 2
				worksheet.Cell(1, 2).Value = "Tins Sold";

				ExcelCell cell = worksheet.Cell(2, 2);
				cell.Value = "15"; // tins of Beans sold
				string calcStartAddress = cell.CellAddress;  // we want this for the formula

				worksheet.Cell(3, 2).Value = "32";  // tins Carrots sold

				cell = worksheet.Cell(4, 2);
				cell.Value = "65";  // tins of Peas sold
				string calcEndAddress = cell.CellAddress;  // we want this for the formula

				// now add a formula to show the total number of tins sold
				// This actually adds "SUM(B2:B4)" as the formula
				worksheet.Cell(5, 2).Formula = string.Format("SUM({0}:{1})", calcStartAddress, calcEndAddress);

				// Ah, but we forgot to add a line for String Beans!
				// Note that InsertRow automatically updates all the formulas in the sheet
				// to reference the correct cell range.
				worksheet.InsertRow(3);

				// now add the String Beans line
				worksheet.Cell(3, 1).Value = "String Beans";
				worksheet.Cell(3, 2).Value = "3";

				// set the row height of the total row to be a bit bigger
				worksheet.Row(6).Height = 20;

				// lets set the header text 
				worksheet.HeaderFooter.oddHeader.CenteredText = "Tinned Goods Sales";
				// add the page number to the footer plus the total number of pages
				worksheet.HeaderFooter.oddFooter.RightAlignedText =
					string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
				// add the sheet name to the footer
				worksheet.HeaderFooter.oddFooter.CenteredText = ExcelHeaderFooter.SheetName;
				// add the file path to the footer
				worksheet.HeaderFooter.oddFooter.LeftAlignedText = ExcelHeaderFooter.FilePath + ExcelHeaderFooter.FileName;

				// change the sheet view to show it in page layout mode
				worksheet.View.PageLayoutView = true;

				// we had better add some document properties to the spreadsheet 

				// set some core property values
				xlPackage.Workbook.Properties.Title = "Sample 1";
				xlPackage.Workbook.Properties.Author = "John Tunnicliffe";
				xlPackage.Workbook.Properties.Subject = "ExcelPackage Samples";
				xlPackage.Workbook.Properties.Keywords = "Office Open XML";
				xlPackage.Workbook.Properties.Category = "ExcelPackage Samples";
				xlPackage.Workbook.Properties.Comments = "This sample demonstrates how to create an Excel 2007 file from scratch using the Packaging API and Office Open XML";

				// set some extended property values
				xlPackage.Workbook.Properties.Company = "AdventureWorks Inc.";
				xlPackage.Workbook.Properties.HyperlinkBase = new Uri("http://www.linkedin.com/pub/0/277/8a5");

				// set some custom property values
				xlPackage.Workbook.Properties.SetCustomPropertyValue("Checked by", "John Tunnicliffe");
				xlPackage.Workbook.Properties.SetCustomPropertyValue("EmployeeID", "1147");
				xlPackage.Workbook.Properties.SetCustomPropertyValue("AssemblyName", "ExcelPackage");

				// save our new workbook and we are done!
				xlPackage.Save();

			}

			// if you want to take a look at the XML created in the package, simply uncomment the following lines
			// These copy the output file and give it a zip extension so you can open it and take a look!
			//FileInfo zipFile = new FileInfo(outputDir.FullName + @"\sample1.zip");
			//if (zipFile.Exists) zipFile.Delete();
			//newFile.CopyTo(zipFile.FullName);
			return newFile.FullName;
		}
	}
}
