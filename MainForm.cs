using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PrintDataGrid
{
    public partial class MainForm : Form
    {
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Declare dataBase variables
            string cnStr, cmdText;
            cnStr = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                    "Data Source= Persons.mdb";
            OleDbConnection cn = new OleDbConnection(cnStr);
            OleDbCommand cmd;
            OleDbDataReader dr;
            DataTable dt = new DataTable("Persons");
            try
            {
                cn.Open();

                // Load Data into DataGridView
                cmdText = "SELECT * FROM Persons";
                cmd = new OleDbCommand(cmdText, cn);
                dr = cmd.ExecuteReader();
                if (dr.HasRows) dt.Load(dr);
                dr.Close();

                dgv.DataSource = dt;

                // Initialize DataGridView Columns
                dgv.RowHeadersVisible = false;
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    col.ReadOnly = true;
                    if (col.GetType().Name == "DataGridViewImageColumn") 
                    {
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (row.IsNewRow) continue;
                            row.Height = row.Cells["image"].ContentBounds.Height + 6;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.Close();
                cn = null;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Calling DataGridView Printing
            PrintDGV.Print_DataGridView(dgv);
        }
    }
}