using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace P5Time
{
    public partial class frmNewOsoba : Form
    {
        public frmNewOsoba()
        {
            InitializeComponent();
        }
        private int idKlubu = 0;
        public frmNewOsoba(string CeleJmeno, int IdKlubu)
        {
            InitializeComponent();
            string[] j = CeleJmeno.Split(new char[] {' '}, 2);
            txtPrijmeni.Text = j[0];
            if (j.Length == 2) txtJmeno.Text = j[1];
            idKlubu = IdKlubu;
        }

        private void frmNewPohar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'p5time_svazvodaku_czDataSet1.vkluby' table. You can move, or remove it, as needed.
            this.vklubyTableAdapter.Fill(this.p5time_svazvodaku_czDataSet1.vkluby);
            if (idKlubu != 0)
            {
                cmbKlub.SelectedValue = idKlubu;
            }
        }

        public string Jmeno
        {
            get { return txtJmeno.Text; }
        }
        public string Prijmeni
        {
            get { return txtPrijmeni.Text; }
        }
        public int Klub
        {
            get { return int.Parse(cmbKlub.SelectedValue.ToString()); }
        }
        public int Rocnik
        {
            get { return int.Parse(txtRocnik.Text); }
        }
        public bool Rozhodci
        {
            get { return chckRozhodci.Checked; }
        }

        private void txtRocnik_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke(new SetMaskedTextBoxSelectAllDelegate(SetMaskedTextBoxSelectAll), new object[] { (MaskedTextBox)sender });

        }

        private delegate void SetMaskedTextBoxSelectAllDelegate(MaskedTextBox txtbox);

        private void SetMaskedTextBoxSelectAll(MaskedTextBox txtbox)
        {
            txtRocnik.SelectAll();
        }


    }
}
