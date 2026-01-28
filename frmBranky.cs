using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn;

namespace P5Time
{
    public partial class frmBranky : Form
    {
        private DataGridView gv;
        public frmBranky(DataGridView grdVysledky, int branek)
        {
            InitializeComponent();
            bool kolo = grdVysledky.Columns[6].Visible;
            foreach (DataGridViewRow r in grdVysledky.Rows)
            {
                if (kolo)
                    dataGridView1.Rows.Add(r.Cells[0].Value, r.Cells[2].Value, r.Cells[6].Value);
                else
                    dataGridView1.Rows.Add(r.Cells[0].Value, r.Cells[2].Value, r.Cells[11].Value);
            }
            numericUpDown1.Value = branek;
            gv = grdVysledky;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            while (dataGridView1.Columns.Count - 4 < numericUpDown1.Value)
            {
                int cisloBranky = dataGridView1.Columns.Count - 3;

                PenaltyTextBoxColumn c = new PenaltyTextBoxColumn();
                c.Name = "branka" + cisloBranky;
                c.HeaderText = cisloBranky + ".";
                dataGridView1.Columns.Add(c);
                dataGridView1.Columns["branka" + cisloBranky].Width = 45;
            }
            while (dataGridView1.Columns.Count-4 > numericUpDown1.Value)
            {
                int cisloBranky = dataGridView1.Columns.Count - 4;
                dataGridView1.Columns.Remove("branka" + cisloBranky);
            }
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            int suma = 0;
            for (int i = 4; i < dataGridView1.Columns.Count; i++)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[i].Value != null)
                {
                    suma += int.Parse(dataGridView1.Rows[e.RowIndex].Cells[i].Value.ToString());
                }
            }
            dataGridView1.Rows[e.RowIndex].Cells["NewPenalty"].Value = suma;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool kolo = gv.Columns[6].Visible;
            foreach (DataGridViewRow r in gv.Rows)
            {
                if (kolo)
                    r.Cells[6].Value = dataGridView1.Rows[r.Index].Cells[3].Value;
                else
                    r.Cells[11].Value = dataGridView1.Rows[r.Index].Cells[3].Value;
            }
            this.Close();
        }
    }
}
