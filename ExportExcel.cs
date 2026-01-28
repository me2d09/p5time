using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using OfficeOpenXml;
using System.IO;


namespace P5Time
{
    class ExportExcel
    {
        //export výsledků ve formátu xlsx, předávám datatable
        public static void Excel(DataTable src, string Category, string toFile)
        {
            FileInfo newFile = new FileInfo(toFile);
            FileInfo template = new FileInfo(Common.ExcelTemplate);
            using (ExcelPackage xlPackage = new ExcelPackage(newFile, template))
            {
                List<Disciplina> discs = new List<Disciplina>();
                ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets["Kategorie"];
                
                int lastcol = 0;
                if (worksheet != null)
                {
                   
                    for (int i = 0; i < src.Columns.Count; i++)
                    {
                        if (src.Columns[i].ColumnName.StartsWith("body "))
                        {
                            if (src.Columns[i].ColumnName.Substring(5) == "celkem")
                            {
                                lastcol = i;
                                break;
                            }
                            Disciplina d = new Disciplina();
                            d.Name = src.Columns[i].ColumnName.Substring(5);
                            d.ShowName = d.Name.Substring(0, 1).ToUpper() + d.Name.Substring(1);
                            if (src.Columns[i - 2].ColumnName.Contains("kolo"))
                            {
                                d.Sloupec = i - 3;
                                d.PocetKol = 2;
                            }
                            else
                            {
                                d.PocetKol = 1;
                                d.Sloupec = i - 1;
                            }
                            discs.Add(d);
                        }
                    }
                    //ok, mam seznam disciplin
                    int col = 6;
                    //discs.Clear();
                    foreach (Disciplina d in discs)
                    {
                        if (d.PocetKol == 1)
                        {
                            worksheet.Cell(1, col).Value = d.ShowName;
                            worksheet.Cell(2, col).Value = "výsledný čas";
                            worksheet.Cell(2, col + 1).Value = "body";
                            worksheet.MergeCells(worksheet.Cell(1, col), 0, 1);
                            worksheet.Cell(1, col).Style = "DiscHorni";
                            worksheet.Cell(1, col + 1).Style = "DiscHorni";
                            worksheet.Cell(2, col).Style = "DiscLeft";
                            worksheet.Cell(2, col + 1).Style = "DiscRight";

                            col = col + 2;
                        }
                        if (d.PocetKol == 2)
                        {
                            worksheet.Cell(1, col).Value = d.ShowName;
                            worksheet.Cell(2, col).Value = "1. kolo";
                            worksheet.Cell(2, col + 1).Value = "2. kolo";
                            worksheet.Cell(2, col + 2).Value = "výsledný čas";
                            worksheet.Cell(2, col + 3).Value = "body";
                            worksheet.MergeCells(worksheet.Cell(1, col), 0, 3);
                            worksheet.Cell(1, col).Style = "DiscHorni";
                            worksheet.Cell(1, col + 1).Style = "DiscHorni";
                            worksheet.Cell(1, col + 2).Style = "DiscHorni";
                            worksheet.Cell(1, col + 3).Style = "DiscHorni";
                            worksheet.Cell(2, col).Style = "DiscLeft";
                            worksheet.Cell(2, col + 1).Style = "DiscMiddle";
                            worksheet.Cell(2, col + 2).Style = "DiscMiddle";
                            worksheet.Cell(2, col + 3).Style = "DiscRight";

                            col = col + 4;
                        }
                    }
                    //posledni sloupec
                    worksheet.Cell(1, col).Value = "Body";
                    worksheet.MergeCells(worksheet.Cell(1, col), 1, 0);
                    worksheet.Cell(1, col).Style = "BodyHorni";
                    worksheet.Cell(2, col).Style = "BodyHorni";

                    int row = 3;
                    //a ted jdu vlozit vysledky
                    foreach (DataRow r in src.Rows)
                    {
                        if (row > 3)
                        {
                            worksheet.InsertRow(row);
                            worksheet.InsertRow(row);
                            worksheet.InsertRow(row);
                            worksheet.InsertRow(row);
                        }
                        //jdu na posadku
                        worksheet.Cell(row, 1).Value = r["poradi"].ToString();
                        worksheet.Cell(row, 2).Value = r["cislo"].ToString();
                        worksheet.Cell(row, 3).Value = r["oddil"].ToString();
                        worksheet.Cell(row, 4).Value = r["jmena"].ToString();
                        worksheet.Cell(row, 5).Value = r["narozeni"].ToString();
                        //merguju bunky
                        for (int i = 1; i <= 5; i++)
                        {
                            worksheet.MergeCells(worksheet.Cell(row, i), 3, 0);
                        }
                        //styluju
                        if (row > 3)
                        {
                            for (int i = 1; i <= 5; i++)
                            {
                                for (int j = 0; j < 4; j++)
                                {
                                    worksheet.Cell(row + j, i).StyleID = worksheet.Cell(row - 4 + j, i).StyleID;
                                }
                            }
                        }
                        string jmena = r["jmena"].ToString();
                        int k = 0;
                        int l = 0;
                        while (k + 1 < jmena.Length && 0 <= (k = jmena.IndexOf("\r\n", k + 1))) l++;
                        l = l - 3;
                        if (l > 0)
                        {
                            worksheet.Row(row + 3).Height = 15 + l * 13;
                        }
                        

                        //jdu po disciplinach
                        col = 6;
                        foreach (Disciplina d in discs)
                        {
                            if (d.PocetKol == 1)
                            {
                                Vysl v = ParseCasy(r[d.Sloupec].ToString());
                                worksheet.Cell(row, col).Value = v.Start;
                                worksheet.Cell(row + 1, col).Value = v.Fin;
                                if (v.Pen != 0) worksheet.Cell(row + 2, col).Value = v.Pen.ToString();
                                worksheet.Cell(row + 3, col).Value = v.Time;

                                worksheet.Cell(row, col + 1).Value = r[d.Sloupec + 1].ToString();
                                worksheet.MergeCells(worksheet.Cell(row, col + 1), 3, 0);
                                worksheet.Cell(row, col).Style = "time";
                                worksheet.Cell(row + 1, col).Style = "time";
                                worksheet.Cell(row + 2, col).Style = "time";
                                worksheet.Cell(row + 3, col).Style = "timeBest";

                                worksheet.Cell(row, col + 1).Style = "Body";
                                worksheet.Cell(row + 1, col + 1).Style = "Body";
                                worksheet.Cell(row + 2, col + 1).Style = "Body";
                                worksheet.Cell(row + 3, col + 1).Style = "Body";

                                col = col + 2;
                            }
                            if (d.PocetKol == 2)
                            {
                                Vysl v1 = ParseCasy(r[d.Sloupec].ToString());
                                Vysl v2 = ParseCasy(r[d.Sloupec + 1].ToString());

                                worksheet.Cell(row, col).Value = v1.Start;
                                worksheet.Cell(row + 1, col).Value = v1.Fin;
                                if (v1.Pen != 0) worksheet.Cell(row + 2, col).Value = v1.Pen.ToString();
                                worksheet.Cell(row + 3, col).Value = v1.Time;

                                worksheet.Cell(row, col + 1).Value = v2.Start;
                                worksheet.Cell(row + 1, col + 1).Value = v2.Fin;
                                if (v2.Pen != 0) worksheet.Cell(row + 2, col + 1).Value = v2.Pen.ToString();
                                worksheet.Cell(row + 3, col + 1).Value = v2.Time;

                                worksheet.Cell(row, col + 2).Value = r[d.Sloupec + 2].ToString(); //besttime
                                worksheet.MergeCells(worksheet.Cell(row, col + 2), 3, 0);

                                worksheet.Cell(row, col + 3).Value = r[d.Sloupec + 3].ToString(); //body
                                worksheet.MergeCells(worksheet.Cell(row, col + 3), 3, 0);

                                worksheet.Cell(row, col).Style = "time";
                                worksheet.Cell(row + 1, col).Style = "time";
                                worksheet.Cell(row + 2, col).Style = "time";
                                worksheet.Cell(row + 3, col).Style = "time2";

                                worksheet.Cell(row, col + 1).Style = "time";
                                worksheet.Cell(row + 1, col + 1).Style = "time";
                                worksheet.Cell(row + 2, col + 1).Style = "time";
                                worksheet.Cell(row + 3, col + 1).Style = "time2";

                                worksheet.Cell(row, col + 2).Style = "timeBest";
                                worksheet.Cell(row + 1, col + 2).Style = "timeBest";
                                worksheet.Cell(row + 2, col + 2).Style = "timeBest";
                                worksheet.Cell(row + 3, col + 2).Style = "timeBest";

                                worksheet.Cell(row, col + 3).Style = "Body";
                                worksheet.Cell(row + 1, col + 3).Style = "Body";
                                worksheet.Cell(row + 2, col + 3).Style = "Body";
                                worksheet.Cell(row + 3, col + 3).Style = "Body";

                                col = col + 4;
                            }
                        }
                        //mam discipliny
                        worksheet.Cell(row, col).Value = r[lastcol].ToString();
                        worksheet.MergeCells(worksheet.Cell(row, col), 3, 0);
                        worksheet.Cell(row, col).Style = "BodySum";
                        worksheet.Cell(row + 1, col).Style = "BodySum";
                        worksheet.Cell(row + 2, col).Style = "BodySum";
                        worksheet.Cell(row + 3, col).Style = "BodySum";
                        //a mam souct bodu

                        row = row + 4;
                    }
                    worksheet.DeleteRow(row + 12, true);
                }
                
                // nastavim tagy
                xlPackage.Workbook.Properties.Title = "Výsledky závodu pramic P5";
                xlPackage.Workbook.Properties.Subject = "Závody pramic P5";
                xlPackage.Workbook.Properties.Keywords = "SVoČR; výsledky; pramice";
                xlPackage.Workbook.Properties.Category = "Výsledky";
                xlPackage.Workbook.Properties.Comments = "Dokument byl automaticky vygenerován aplikací P5TIME, (c) Petr Čermák";

                // ulozim
                xlPackage.Save();
                

            }
        }


        //export jen prvních třech na diplomy
        public static void Diplomy(DataTable src, string toFile)
        {
            FileInfo newFile = new FileInfo(toFile);
            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {
                ExcelWorksheet worksheet = xlPackage.Workbook.Worksheets.Add("NaDiplomy");
                if (worksheet != null)
                {
                    for (int i = 0; i < src.Columns.Count; i++)
                    {
                        worksheet.Cell(1,i+1).Value = src.Columns[i].ColumnName;
                    }
                    //ok, mam table header
                    int row = 2;
                    //a ted jdu vlozit vysledky
                    foreach (DataRow r in src.Rows)
                    {
                        for (int i = 0; i < src.Columns.Count; i++)
                        {
                            worksheet.Cell(row, i + 1).Value = r[i].ToString();
                        }
                       

                        row++;
                    }
                }
                // we had better add some document properties to the spreadsheet 

                // set some core property values
                xlPackage.Workbook.Properties.Title = "Export výsledků na diplomy";

                xlPackage.Workbook.Properties.Subject = "Závody pramic P5";
                xlPackage.Workbook.Properties.Keywords = "SVoČR; výsledky; pramice";
                xlPackage.Workbook.Properties.Category = "Výsledky";
                xlPackage.Workbook.Properties.Comments = "Dokument byl automaticky vygenerován aplikací P5TIME, (c) Petr Čermák";

                // save the new spreadsheet
                xlPackage.Save();


            }
        }



        #region pomocne funkce
        /// <summary>
        /// Tady ty funkce vyuzivam k parsovani casu na text pri exportu
        /// 
        /// </summary>
        /// 

            private static Vysl ParseCasy(string input)
            {
                try
                {
                    string[] pars = input.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    int pen = 0;
                    if (!int.TryParse(pars[2], out pen)) pen = 0;
                    return new Vysl(pars[0], pars[1], pen, pars[3]);
                }
                catch
                {
                    return new Vysl();
                }
            }

            /// <summary>
            /// Pomocne struktury
            /// Vysl - uchovava info o jednom starrtu (start, cil, penalty...
            /// Disciplina - info o jedny discipline, pouzite na generovani sloupcu
            /// </summary>
            /// 
            public class Vysl
            {
                // private members
                string start = "";
                string fin = "";
                int pen;
                string time = "";

                // empty constructor
                public Vysl()
                {
                }

                // full constructor
                public Vysl(string Start, string Fin, int Pen, string Time)
                {
                    this.start = Start;
                    this.fin = Fin;
                    this.pen = Pen;
                    this.time = Time;
                }

                // public accessors
                public string Start
                {
                    get { return start; }
                    set { start = value; }
                }
                public string Fin
                {
                    get { return fin; }
                    set { fin = value; }
                }
                public int Pen
                {
                    get { return pen; }
                    set { pen = value; }
                }
                public string Time
                {
                    get { return time; }
                    set { time = value; }
                }
            }

            public class Disciplina
            {
                // private members
                string name;
                string showName;
                int pocetKol;
                int sloupec;

                // empty constructor
                public Disciplina()
                {
                }

                // full constructor
                public Disciplina(string Name, string ShowName, int PocetKol, int Sloupec)
                {
                    this.name = Name;
                    this.showName = ShowName;
                    this.pocetKol = PocetKol;
                    this.sloupec = Sloupec;
                }

                // public accessors
                public string Name
                {
                    get { return name; }
                    set { name = value; }
                }
                public string ShowName
                {
                    get { return showName; }
                    set { showName = value; }
                }
                public int PocetKol
                {
                    get { return pocetKol; }
                    set { pocetKol = value; }
                }
                public int Sloupec
                {
                    get { return sloupec; }
                    set { sloupec = value; }
                }
            }

        #endregion
        

        
    }
}
