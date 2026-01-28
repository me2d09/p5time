/*
 * Sample code demonstrating how to generate Excel spreadsheets on the server using 
 * Office Open XML and the ExcelPackage wrapper classes.
 * 
 * ExcelPackage provides server-side generation of Excel 2007 spreadsheets.
 * See http://www.codeplex.com/ExcelPackage for details.
 * 
 * Sample 3: Creates a workbook based on a template and populates using the database data.
 * 
 * Copyright 2007 © Dr John Tunnicliffe 
 * mailto:dr.john.tunnicliffe@btinternet.com
 * All rights reserved.
 * 
 * All code and executables are provided "as is" with no warranty either express or implied. 
 * The author accepts no liability for any damage or loss of business that this product may cause.
 */
using System;
using System.IO;
using System.Xml;
using OfficeOpenXml;
using System.Data.SqlClient;

namespace ExcelPackageSamples
{
	class Sample3
	{
		/// <summary>
		/// Sample 3 - creates a workbook based on a template and 
		/// populates using data from the AdventureWorks database
		/// This sample requires the AdventureWorks database.  
		/// </summary>
		/// <param name="outputDir">The output directory</param>
		/// <param name="templateDir">The location of the sample template</param>
		/// <param name="connectionString">The connection string to your copy of the AdventureWorks database</param>
		public static string RunSample3(DirectoryInfo outputDir, DirectoryInfo templateDir, string connectionString)
		{
			
			// just check nobody is been an idiot here!
			//if (connectionString.IndexOf("YourServerName") > 0)
			//	throw new Exception("You must edit the connection string to reference the correct server name!");
			FileInfo newFile = new FileInfo(outputDir.FullName + @"\sample3.xlsx");
			FileInfo template = new FileInfo(templateDir.FullName + @"\sample3template.xlsx");
			if (!template.Exists) throw new Exception("Template file does not exist! i.e. sample3template.xlsx");


			// ok, we can run the real code of the sample now
			using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
			{
				// uncomment this line if you want the XML written out to the outputDir
				//xlPackage.DebugMode = true; 

				// get handle to the existing worksheet
				ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets["Sales"];
				if (worksheet != null)
				{
					ExcelCell cell;
					const int startRow = 5;
					int row = startRow;
                    worksheet.Cell(1, 1).Value = "TEEST";
					// lets connect to the AdventureWorks sample database for some data
					
					/* 
					 * The data we just inserted is between startRow and row.
					 * Now we need to apply the same styles and common formula for all these rows.
					 * 
					 * First copy the styles from startRow to the new rows.     */
					for (int iCol = 1; iCol <= 7; iCol++)
					{
						cell = worksheet.Cell(startRow, iCol);
						for (int iRow = startRow; iRow <= row; iRow++)
						{
							worksheet.Cell(iRow, iCol).StyleID = cell.StyleID;
						}
					}
					// style the first row as they are the top achiever
					worksheet.Cell(startRow, 6).Style = "Good";
					// style the last row as they are the worst performer
					worksheet.Cell(row, 6).Style = "Bad";

					// now create a *shared* formula based on the formula in the startRow column 5 and 7
					worksheet.CreateSharedFormula(worksheet.Cell(startRow, 5), worksheet.Cell(row, 5));
					worksheet.CreateSharedFormula(worksheet.Cell(startRow, 7), worksheet.Cell(row, 7));

					// to force Excel to re-calculate the formulas in the total line, 
					// we must remove the values currently in the cells
					worksheet.Cell(row + 1, 5).RemoveValue();
					worksheet.Cell(row + 1, 6).RemoveValue();
					worksheet.Cell(row + 1, 7).RemoveValue();
					
					// lets set the header text 
					worksheet.HeaderFooter.oddHeader.CenteredText = "AdventureWorks Inc. Sales Report";
					// add the page number to the footer plus the total number of pages
					worksheet.HeaderFooter.oddFooter.RightAlignedText =
						string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
					// add the sheet name to the footer
					worksheet.HeaderFooter.oddFooter.CenteredText = ExcelHeaderFooter.SheetName;
					// add the file path to the footer
					worksheet.HeaderFooter.oddFooter.LeftAlignedText = ExcelHeaderFooter.FilePath + ExcelHeaderFooter.FileName;
				}
				// we had better add some document properties to the spreadsheet 

				// set some core property values
				xlPackage.Workbook.Properties.Title = "Sample 3";
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
				
				// save the new spreadsheet
				xlPackage.Save();
			}

			// if you want to take a look at the XML created in the package, simply uncomment the following lines
			// These copy the output file and give it a zip extension so you can open it and take a look!
			//FileInfo zipFile = new FileInfo(outputDir.FullName + @"\sample3.zip");
			//if (zipFile.Exists) zipFile.Delete();
			//newFile.CopyTo(zipFile.FullName);

			return newFile.FullName;
		}
	}
}
