namespace P5Time
{
    partial class frmNewOsoba
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJmeno = new System.Windows.Forms.TextBox();
            this.txtRocnik = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrijmeni = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbKlub = new System.Windows.Forms.ComboBox();
            this.vklubyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.p5time_svazvodaku_czDataSet1 = new P5Time.p5time_svazvodaku_czDataSet1();
            this.vklubyTableAdapter = new P5Time.p5time_svazvodaku_czDataSet1TableAdapters.vklubyTableAdapter();
            this.chckRozhodci = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.vklubyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p5time_svazvodaku_czDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(194, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Vytvořit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(15, 158);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Storno";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Jméno:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ročník:";
            // 
            // txtJmeno
            // 
            this.txtJmeno.Location = new System.Drawing.Point(73, 12);
            this.txtJmeno.Name = "txtJmeno";
            this.txtJmeno.Size = new System.Drawing.Size(210, 20);
            this.txtJmeno.TabIndex = 1;
            // 
            // txtRocnik
            // 
            this.txtRocnik.Location = new System.Drawing.Point(73, 125);
            this.txtRocnik.Mask = "0000";
            this.txtRocnik.Name = "txtRocnik";
            this.txtRocnik.Size = new System.Drawing.Size(100, 20);
            this.txtRocnik.TabIndex = 0;
            this.txtRocnik.Text = "0";
            this.txtRocnik.Enter += new System.EventHandler(this.txtRocnik_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Příjmení:";
            // 
            // txtPrijmeni
            // 
            this.txtPrijmeni.Location = new System.Drawing.Point(73, 38);
            this.txtPrijmeni.Name = "txtPrijmeni";
            this.txtPrijmeni.Size = new System.Drawing.Size(210, 20);
            this.txtPrijmeni.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Klub:";
            // 
            // cmbKlub
            // 
            this.cmbKlub.DataSource = this.vklubyBindingSource;
            this.cmbKlub.DisplayMember = "nazev";
            this.cmbKlub.FormattingEnabled = true;
            this.cmbKlub.Location = new System.Drawing.Point(73, 64);
            this.cmbKlub.Name = "cmbKlub";
            this.cmbKlub.Size = new System.Drawing.Size(121, 21);
            this.cmbKlub.TabIndex = 3;
            this.cmbKlub.ValueMember = "id";
            // 
            // vklubyBindingSource
            // 
            this.vklubyBindingSource.DataMember = "vkluby";
            this.vklubyBindingSource.DataSource = this.p5time_svazvodaku_czDataSet1;
            // 
            // p5time_svazvodaku_czDataSet1
            // 
            this.p5time_svazvodaku_czDataSet1.DataSetName = "p5time_svazvodaku_czDataSet1";
            this.p5time_svazvodaku_czDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vklubyTableAdapter
            // 
            this.vklubyTableAdapter.ClearBeforeFill = true;
            // 
            // chckRozhodci
            // 
            this.chckRozhodci.AutoSize = true;
            this.chckRozhodci.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chckRozhodci.Location = new System.Drawing.Point(11, 98);
            this.chckRozhodci.Name = "chckRozhodci";
            this.chckRozhodci.Size = new System.Drawing.Size(76, 17);
            this.chckRozhodci.TabIndex = 4;
            this.chckRozhodci.Text = "Rozhodčí:";
            this.chckRozhodci.UseVisualStyleBackColor = true;
            // 
            // frmNewOsoba
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(294, 193);
            this.Controls.Add(this.chckRozhodci);
            this.Controls.Add(this.cmbKlub);
            this.Controls.Add(this.txtRocnik);
            this.Controls.Add(this.txtPrijmeni);
            this.Controls.Add(this.txtJmeno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewOsoba";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Vytvořit nového člena";
            this.Load += new System.EventHandler(this.frmNewPohar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vklubyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p5time_svazvodaku_czDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtJmeno;
        public System.Windows.Forms.MaskedTextBox txtRocnik;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtPrijmeni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbKlub;
        private p5time_svazvodaku_czDataSet1 p5time_svazvodaku_czDataSet1;
        private System.Windows.Forms.BindingSource vklubyBindingSource;
        private P5Time.p5time_svazvodaku_czDataSet1TableAdapters.vklubyTableAdapter vklubyTableAdapter;
        private System.Windows.Forms.CheckBox chckRozhodci;
    }
}