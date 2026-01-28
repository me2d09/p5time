using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn;
using PrintDataGrid;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Net;

namespace P5Time
{
	/// <summary>
	/// Hlavni okno cele aplikace, obstarava veskere spojeni s DB
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
    {
        

        private int LastColVysledky = -1;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox tables;
        private System.Windows.Forms.Button updateBtn;
        private IContainer components;

		private MySqlConnection	conn;
        private DataTable data;
        private DataTable dataCiselniky; 
        private DataTable dataPosadky;
        private DataTable data2;
        private DataTable dataZavodnici;
        private DataTable dataPosadkyPohar;
        private DataTable dataRozlosovani;
        private DataTable dataStartovka;
        private DataTable dataVysledky;
        private DataTable dataVysledkovka;
        
        private ActualZavod AZ;


        #region private membery tohodle formu - WinformsPrvky
        private DataTable dataDiscipliny;
        private MySqlDataAdapter daDisc;
        private MySqlDataAdapter da;
        private MySqlDataAdapter daCiselniky;
        private MySqlDataAdapter daPosadky;
        private MySqlDataAdapter daPosadkyPohar;
        private MySqlDataAdapter daZavodnici;
        private MySqlDataAdapter daRozlosovani;
        private MySqlDataAdapter daStartovka;
        private MySqlDataAdapter daVysledky;
        private MySqlDataAdapter daVysledkovka;



        private MenuStrip menuStrip1;
        private ToolStripMenuItem souborToolStripMenuItem;
        private ToolStripMenuItem nastaveníToolStripMenuItem;
        private ToolStripMenuItem nápovìdaToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusDB;
        private TabControl tabControl1;
        private TabPage tCiselniky;
        private DataGrid dataGrid;
        private TabPage tWelcome;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripSeparator toolStripSeparator1;
        private TabPage tPosadky;
        private TabPage tVysledky;
        private PictureBox pictureBox1;
        private Label label2;
        private ComboBox cmbSezona;
        private Label label1;
        private Button btnCreatePohar;
        private TabPage tZavody;
        private DataGridView grdZavody;
        private p5time_svazvodaku_czDataSet p5time_svazvodaku_czDataSet;
        private BindingSource vosobyBindingSource;
        private P5Time.p5time_svazvodaku_czDataSetTableAdapters.vosobyTableAdapter vosobyTableAdapter;
        private p5time_svazvodaku_czDataSet1 p5time_svazvodaku_czDataSet1;
        private BindingSource vklubyBindingSource;
        private P5Time.p5time_svazvodaku_czDataSet1TableAdapters.vklubyTableAdapter vklubyTableAdapter;
        private DataGridView grdDiscipliny;
        private p5time_svazvodaku_czDataSet2 p5time_svazvodaku_czDataSet2;
        private BindingSource cisdisciplinBindingSource;
        private P5Time.p5time_svazvodaku_czDataSet2TableAdapters.cis_disciplinTableAdapter cis_disciplinTableAdapter;
        private ToolStripMenuItem konecToolStripMenuItem;
        private Label lblSelected;
        private MySqlCommandBuilder cb;
        private Label label3;
        private Label label5;
        private TextBox txtNewZavodnik;
        private ListBox lstZavodnici;
        private ListBox lstPoharovePosadky;
        private RadioButton chckExistujici;
        private RadioButton chckPoharova;
        private RadioButton chckNova;
        public ComboBox cmbKategorie;
        private ListBox lstPosadky;
        private Label label6;
        private p5time_svazvodaku_czDataSet3 p5time_svazvodaku_czDataSet3;
        private BindingSource ciskategoriiBindingSource;
        private P5Time.p5time_svazvodaku_czDataSet3TableAdapters.cis_kategoriiTableAdapter cis_kategoriiTableAdapter;
        private ListBox lstKluby;
        private TextBox txtNazev;
        private Label label7;
        private Label lblVybranychLidi;
        private Label label8;
        private ListBox lstDisciplinyPosadky;
        private DataGridViewComboBoxColumn cDisciplina;
        private DataGridViewTextBoxColumn cNazevDisc;
        private Button button1;
        private TabPage tRozlosovani;
        private TabPage tStartovka;
        private DataGridView grdRozlosovani;
        private TextBox txtRozlosovaniCisla;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Button button2;
        private Button button3;
        private DataGridViewComboBoxColumn id_kat;
        private DataGridViewTextBoxColumn nazev;
        private DataGridViewComboBoxColumn klub;
        private MaskedTextBoxColumn cislo;
        private ComboBox cmbKatRozlosovani;
        private Label label13;
        private DataGridView grdStartovka;
        private ComboBox cmbStartovkaDiscipliny;
        private Button button4;
        private GroupBox groupBox1;
        private MaskedTextBox txtFromTimeStarts;
        private RadioButton rb2kolo;
        private RadioButton rb1kolo;
        private Label label16;
        private Label label15;
        private Label label14;
        private ComboBox cmbKatStartTimes;
        private MaskedTextBox txtTimeInterval;
        private Button button5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private MaskedTextBoxColumn maskedTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private MaskedTextBoxColumn maskedTextBoxColumn2;
        private MaskedTextBoxColumn maskedTextBoxColumn3;
        private Button button6;
        private CheckBox checkBox1;
        private GroupBox groupBox2;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button button9;
        private ComboBox cmbVysledkyDiscipliny;
        private Label label20;
        private DataGridView grdVysledky;
        private p5time_svazvodaku_czStatusy p5time_svazvodaku_czStatusy;
        private BindingSource cisstatusyBindingSource;
        private P5Time.p5time_svazvodaku_czStatusyTableAdapters.cis_statusyTableAdapter cis_statusyTableAdapter;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private MaskedTextBoxColumn maskedTextBoxColumn4;
        private MaskedTextBoxColumn cCil1;
        private MaskedTextBoxColumn cPenalty1;
        private MaskedTextBoxColumn cTime1;
        private DataGridViewComboBoxColumn cStatus1;
        private MaskedTextBoxColumn maskedTextBoxColumn5;
        private MaskedTextBoxColumn cCil2;
        private MaskedTextBoxColumn cPenalty2;
        private MaskedTextBoxColumn cTime2;
        private DataGridViewComboBoxColumn cStatus2;
        private MaskedTextBoxColumn cFinalTime;
        private DataGridViewComboBoxColumn Status;
        private GroupBox groupBox3;
        private RadioButton rbZavodu;
        private RadioButton rbCilovy;
        private ComboBox cmbKategorieVysledky;
        private Label label17;
        private TabPage tVysledkovka;
        private ComboBox cmbKatVysledkovka;
        private Label label18;
        private DataGridView grdVysledkovka;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private Button button7;
        private Label lblUzavreni;
        private Button btnUzavrit;
        private Button button8;
        private Button button10;
        private Button button11;
        private SaveFileDialog saveFileDialog1;
        private Button button12;
        private DataGridViewTextBoxColumn cisloS;
        private DataGridViewComboBoxColumn kategorieS;
        private DataGridViewTextBoxColumn nazevS;
        private DataGridViewTextBoxColumn posadkaFull;
        private DataGridViewTextBoxColumn cStartovkaClenoce;
        private DataGridViewTextBoxColumn cCk;
        private DataGridViewTextBoxColumn cRocnik;
        private MaskedTextBoxColumn kolo1;
        private MaskedTextBoxColumn kolo2;
        private Button button13;
        private CheckBox checkBox2;
        private Button button14;
        private OpenFileDialog openFileDialog1;
        private Button button15;
        private CheckBox chckOverrideCountZavodniku;
        private TabPage tExport;
        private Button button16;
        private RichTextBox txtExport;
        private Button button17;
        private Label label21;
        private Label label19;
        private TextBox txtPassword;
        private TextBox txtUser;
        private DataGridViewCheckBoxColumn Upravit;
        private DataGridViewTextBoxColumn cNazev;
        private DataGridViewComboBoxColumn cRoz;
        private DataGridViewComboBoxColumn cRed;
        private DataGridViewTextBoxColumn cZast;
        private DataGridViewComboBoxColumn cKlub1;
        private DataGridViewComboBoxColumn cKlub2;
        private DataGridViewTextBoxColumn cOd;
        private Button btnBranky;
        private NumericUpDown numericUpDown1;
        private CheckBox chckPoDvou;
        private DataGridViewTextBoxColumn cDo;


        #endregion


        public Form1()
		{
			InitializeComponent();
            //pripoji se to tam kde to predtim skoncilo
            AZ = new ActualZavod(this);

		}

		/// <summary>
		/// Nic zvlastniho nealokuji, neni treba
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.tables = new System.Windows.Forms.ComboBox();
            this.updateBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.souborToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.konecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nastaveníToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nápovìdaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusDB = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tWelcome = new System.Windows.Forms.TabPage();
            this.btnCreatePohar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSezona = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tZavody = new System.Windows.Forms.TabPage();
            this.grdDiscipliny = new System.Windows.Forms.DataGridView();
            this.cDisciplina = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cisdisciplinBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.p5time_svazvodaku_czDataSet2 = new P5Time.p5time_svazvodaku_czDataSet2();
            this.cNazevDisc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdZavody = new System.Windows.Forms.DataGridView();
            this.Upravit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cNazev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRoz = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.vosobyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.p5time_svazvodaku_czDataSet = new P5Time.p5time_svazvodaku_czDataSet();
            this.cRed = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cZast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cKlub1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.vklubyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.p5time_svazvodaku_czDataSet1 = new P5Time.p5time_svazvodaku_czDataSet1();
            this.cKlub2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cOd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tPosadky = new System.Windows.Forms.TabPage();
            this.chckOverrideCountZavodniku = new System.Windows.Forms.CheckBox();
            this.button15 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lstDisciplinyPosadky = new System.Windows.Forms.ListBox();
            this.lblVybranychLidi = new System.Windows.Forms.Label();
            this.txtNazev = new System.Windows.Forms.TextBox();
            this.lstKluby = new System.Windows.Forms.ListBox();
            this.cmbKategorie = new System.Windows.Forms.ComboBox();
            this.ciskategoriiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.p5time_svazvodaku_czDataSet3 = new P5Time.p5time_svazvodaku_czDataSet3();
            this.lstPosadky = new System.Windows.Forms.ListBox();
            this.lstPoharovePosadky = new System.Windows.Forms.ListBox();
            this.chckExistujici = new System.Windows.Forms.RadioButton();
            this.chckPoharova = new System.Windows.Forms.RadioButton();
            this.chckNova = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNewZavodnik = new System.Windows.Forms.TextBox();
            this.lstZavodnici = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tRozlosovani = new System.Windows.Forms.TabPage();
            this.cmbKatRozlosovani = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtRozlosovaniCisla = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.grdRozlosovani = new System.Windows.Forms.DataGridView();
            this.id_kat = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.nazev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.klub = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cislo = new Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn();
            this.tStartovka = new System.Windows.Forms.TabPage();
            this.button13 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chckPoDvou = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.txtTimeInterval = new System.Windows.Forms.MaskedTextBox();
            this.txtFromTimeStarts = new System.Windows.Forms.MaskedTextBox();
            this.rb2kolo = new System.Windows.Forms.RadioButton();
            this.rb1kolo = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbKatStartTimes = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.cmbStartovkaDiscipliny = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.grdStartovka = new System.Windows.Forms.DataGridView();
            this.cisloS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kategorieS = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.nazevS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posadkaFull = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStartovkaClenoce = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cRocnik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kolo1 = new Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn();
            this.kolo2 = new Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn();
            this.tVysledky = new System.Windows.Forms.TabPage();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnBranky = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbZavodu = new System.Windows.Forms.RadioButton();
            this.rbCilovy = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button9 = new System.Windows.Forms.Button();
            this.cmbKategorieVysledky = new System.Windows.Forms.ComboBox();
            this.cmbVysledkyDiscipliny = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.grdVysledky = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maskedTextBoxColumn4 = new Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn();
            this.cCil1 = new Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn();
            this.cPenalty1 = new Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn();
            this.cTime1 = new Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn();
            this.cStatus1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cisstatusyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.p5time_svazvodaku_czStatusy = new P5Time.p5time_svazvodaku_czStatusy();
            this.maskedTextBoxColumn5 = new Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn();
            this.cCil2 = new Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn();
            this.cPenalty2 = new Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn();
            this.cTime2 = new Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn();
            this.cStatus2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cFinalTime = new Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tVysledkovka = new System.Windows.Forms.TabPage();
            this.btnUzavrit = new System.Windows.Forms.Button();
            this.lblUzavreni = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.cmbKatVysledkovka = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.grdVysledkovka = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tExport = new System.Windows.Forms.TabPage();
            this.button17 = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtExport = new System.Windows.Forms.RichTextBox();
            this.button16 = new System.Windows.Forms.Button();
            this.tCiselniky = new System.Windows.Forms.TabPage();
            this.dataGrid = new System.Windows.Forms.DataGrid();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.vosobyTableAdapter = new P5Time.p5time_svazvodaku_czDataSetTableAdapters.vosobyTableAdapter();
            this.vklubyTableAdapter = new P5Time.p5time_svazvodaku_czDataSet1TableAdapters.vklubyTableAdapter();
            this.cis_disciplinTableAdapter = new P5Time.p5time_svazvodaku_czDataSet2TableAdapters.cis_disciplinTableAdapter();
            this.lblSelected = new System.Windows.Forms.Label();
            this.cis_kategoriiTableAdapter = new P5Time.p5time_svazvodaku_czDataSet3TableAdapters.cis_kategoriiTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maskedTextBoxColumn1 = new Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maskedTextBoxColumn2 = new Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn();
            this.maskedTextBoxColumn3 = new Microsoft.Samples.Windows.Forms.DataGridViewCustomColumn.MaskedTextBoxColumn();
            this.cis_statusyTableAdapter = new P5Time.p5time_svazvodaku_czStatusyTableAdapters.cis_statusyTableAdapter();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tWelcome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tZavody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDiscipliny)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cisdisciplinBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p5time_svazvodaku_czDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZavody)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vosobyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p5time_svazvodaku_czDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vklubyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p5time_svazvodaku_czDataSet1)).BeginInit();
            this.tPosadky.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ciskategoriiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p5time_svazvodaku_czDataSet3)).BeginInit();
            this.tRozlosovani.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRozlosovani)).BeginInit();
            this.tStartovka.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStartovka)).BeginInit();
            this.tVysledky.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVysledky)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cisstatusyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p5time_svazvodaku_czStatusy)).BeginInit();
            this.tVysledkovka.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVysledkovka)).BeginInit();
            this.tExport.SuspendLayout();
            this.tCiselniky.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Èíselníky:";
            // 
            // tables
            // 
            this.tables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tables.Location = new System.Drawing.Point(76, 6);
            this.tables.Name = "tables";
            this.tables.Size = new System.Drawing.Size(751, 21);
            this.tables.TabIndex = 7;
            this.tables.SelectedIndexChanged += new System.EventHandler(this.tables_SelectedIndexChanged);
            // 
            // updateBtn
            // 
            this.updateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updateBtn.Location = new System.Drawing.Point(833, 6);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(105, 23);
            this.updateBtn.TabIndex = 9;
            this.updateBtn.Text = "Uložit zmìny";
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.souborToolStripMenuItem,
            this.nastaveníToolStripMenuItem,
            this.nápovìdaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // souborToolStripMenuItem
            // 
            this.souborToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.konecToolStripMenuItem});
            this.souborToolStripMenuItem.Name = "souborToolStripMenuItem";
            this.souborToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.souborToolStripMenuItem.Text = "Soubor";
            // 
            // konecToolStripMenuItem
            // 
            this.konecToolStripMenuItem.Name = "konecToolStripMenuItem";
            this.konecToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.konecToolStripMenuItem.Text = "Konec";
            this.konecToolStripMenuItem.Click += new System.EventHandler(this.konecToolStripMenuItem_Click);
            // 
            // nastaveníToolStripMenuItem
            // 
            this.nastaveníToolStripMenuItem.Name = "nastaveníToolStripMenuItem";
            this.nastaveníToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.nastaveníToolStripMenuItem.Text = "Nastavení";
            this.nastaveníToolStripMenuItem.Click += new System.EventHandler(this.nastaveníToolStripMenuItem_Click);
            // 
            // nápovìdaToolStripMenuItem
            // 
            this.nápovìdaToolStripMenuItem.Name = "nápovìdaToolStripMenuItem";
            this.nápovìdaToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.nápovìdaToolStripMenuItem.Text = "Nápovìda";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusDB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 602);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusDB
            // 
            this.statusDB.Name = "statusDB";
            this.statusDB.Size = new System.Drawing.Size(71, 17);
            this.statusDB.Text = "nepøipojeno";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tWelcome);
            this.tabControl1.Controls.Add(this.tZavody);
            this.tabControl1.Controls.Add(this.tPosadky);
            this.tabControl1.Controls.Add(this.tRozlosovani);
            this.tabControl1.Controls.Add(this.tStartovka);
            this.tabControl1.Controls.Add(this.tVysledky);
            this.tabControl1.Controls.Add(this.tVysledkovka);
            this.tabControl1.Controls.Add(this.tExport);
            this.tabControl1.Controls.Add(this.tCiselniky);
            this.tabControl1.Enabled = false;
            this.tabControl1.Location = new System.Drawing.Point(12, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(960, 506);
            this.tabControl1.TabIndex = 14;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tWelcome
            // 
            this.tWelcome.Controls.Add(this.btnCreatePohar);
            this.tWelcome.Controls.Add(this.label2);
            this.tWelcome.Controls.Add(this.cmbSezona);
            this.tWelcome.Controls.Add(this.label1);
            this.tWelcome.Controls.Add(this.pictureBox1);
            this.tWelcome.Location = new System.Drawing.Point(4, 22);
            this.tWelcome.Name = "tWelcome";
            this.tWelcome.Padding = new System.Windows.Forms.Padding(3);
            this.tWelcome.Size = new System.Drawing.Size(952, 480);
            this.tWelcome.TabIndex = 1;
            this.tWelcome.Text = "Vítejte";
            this.tWelcome.UseVisualStyleBackColor = true;
            // 
            // btnCreatePohar
            // 
            this.btnCreatePohar.FlatAppearance.BorderSize = 0;
            this.btnCreatePohar.Image = ((System.Drawing.Image)(resources.GetObject("btnCreatePohar.Image")));
            this.btnCreatePohar.Location = new System.Drawing.Point(226, 106);
            this.btnCreatePohar.Name = "btnCreatePohar";
            this.btnCreatePohar.Size = new System.Drawing.Size(26, 26);
            this.btnCreatePohar.TabIndex = 4;
            this.btnCreatePohar.UseVisualStyleBackColor = false;
            this.btnCreatePohar.Click += new System.EventHandler(this.btnCreatePohar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Aktuální sezóna:";
            // 
            // cmbSezona
            // 
            this.cmbSezona.FormattingEnabled = true;
            this.cmbSezona.Location = new System.Drawing.Point(99, 109);
            this.cmbSezona.Name = "cmbSezona";
            this.cmbSezona.Size = new System.Drawing.Size(121, 21);
            this.cmbSezona.TabIndex = 2;
            this.cmbSezona.SelectedIndexChanged += new System.EventHandler(this.cmbSezona_SelectedIndexChanged);
            this.cmbSezona.Validated += new System.EventHandler(this.cmbSezona_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.MaximumSize = new System.Drawing.Size(300, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 78);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vítejte v aplikaci P5Time\r\n\r\naplikace slouží k zadávání výsledkù závodù pramic Sv" +
                "azu vodákù Èeské republiky.\r\nAutoøi: Petr Èermák, Daniel Pánek\r\nVerze: alpha";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(744, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 209);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tZavody
            // 
            this.tZavody.Controls.Add(this.grdDiscipliny);
            this.tZavody.Controls.Add(this.grdZavody);
            this.tZavody.Location = new System.Drawing.Point(4, 22);
            this.tZavody.Name = "tZavody";
            this.tZavody.Padding = new System.Windows.Forms.Padding(3);
            this.tZavody.Size = new System.Drawing.Size(952, 480);
            this.tZavody.TabIndex = 2;
            this.tZavody.Text = "Závod";
            this.tZavody.UseVisualStyleBackColor = true;
            // 
            // grdDiscipliny
            // 
            this.grdDiscipliny.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grdDiscipliny.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDiscipliny.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.grdDiscipliny.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDisciplina,
            this.cNazevDisc});
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdDiscipliny.DefaultCellStyle = dataGridViewCellStyle27;
            this.grdDiscipliny.Location = new System.Drawing.Point(6, 341);
            this.grdDiscipliny.Name = "grdDiscipliny";
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDiscipliny.RowHeadersDefaultCellStyle = dataGridViewCellStyle28;
            this.grdDiscipliny.Size = new System.Drawing.Size(347, 133);
            this.grdDiscipliny.TabIndex = 1;
            this.grdDiscipliny.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDiscipliny_RowValidated);
            // 
            // cDisciplina
            // 
            this.cDisciplina.DataPropertyName = "id_cdis";
            this.cDisciplina.DataSource = this.cisdisciplinBindingSource;
            this.cDisciplina.DisplayMember = "nazev";
            this.cDisciplina.DisplayStyleForCurrentCellOnly = true;
            this.cDisciplina.HeaderText = "disciplína";
            this.cDisciplina.Name = "cDisciplina";
            this.cDisciplina.ValueMember = "id_cdis";
            // 
            // cisdisciplinBindingSource
            // 
            this.cisdisciplinBindingSource.DataMember = "cis_disciplin";
            this.cisdisciplinBindingSource.DataSource = this.p5time_svazvodaku_czDataSet2;
            // 
            // p5time_svazvodaku_czDataSet2
            // 
            this.p5time_svazvodaku_czDataSet2.DataSetName = "p5time_svazvodaku_czDataSet2";
            this.p5time_svazvodaku_czDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cNazevDisc
            // 
            this.cNazevDisc.DataPropertyName = "nazev";
            this.cNazevDisc.HeaderText = "Název";
            this.cNazevDisc.Name = "cNazevDisc";
            // 
            // grdZavody
            // 
            this.grdZavody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdZavody.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.grdZavody.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdZavody.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Upravit,
            this.cNazev,
            this.cRoz,
            this.cRed,
            this.cZast,
            this.cKlub1,
            this.cKlub2,
            this.cOd,
            this.cDo});
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdZavody.DefaultCellStyle = dataGridViewCellStyle30;
            this.grdZavody.Location = new System.Drawing.Point(6, 6);
            this.grdZavody.MultiSelect = false;
            this.grdZavody.Name = "grdZavody";
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdZavody.RowHeadersDefaultCellStyle = dataGridViewCellStyle31;
            this.grdZavody.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdZavody.Size = new System.Drawing.Size(940, 329);
            this.grdZavody.TabIndex = 0;
            this.grdZavody.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdZavody_RowValidated);
            this.grdZavody.SelectionChanged += new System.EventHandler(this.grdZavody_SelectionChanged);
            // 
            // Upravit
            // 
            this.Upravit.DataPropertyName = "dirty";
            this.Upravit.FalseValue = "0";
            this.Upravit.HeaderText = "Mìnit";
            this.Upravit.Name = "Upravit";
            this.Upravit.TrueValue = "1";
            // 
            // cNazev
            // 
            this.cNazev.DataPropertyName = "nazev";
            this.cNazev.HeaderText = "Název";
            this.cNazev.Name = "cNazev";
            // 
            // cRoz
            // 
            this.cRoz.DataPropertyName = "id_hl_roz";
            this.cRoz.DataSource = this.vosobyBindingSource;
            this.cRoz.DisplayMember = "jmeno";
            this.cRoz.HeaderText = "Hl. rozhodèí";
            this.cRoz.Name = "cRoz";
            this.cRoz.ValueMember = "id";
            // 
            // vosobyBindingSource
            // 
            this.vosobyBindingSource.DataMember = "vosoby";
            this.vosobyBindingSource.DataSource = this.p5time_svazvodaku_czDataSet;
            // 
            // p5time_svazvodaku_czDataSet
            // 
            this.p5time_svazvodaku_czDataSet.DataSetName = "p5time_svazvodaku_czDataSet";
            this.p5time_svazvodaku_czDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cRed
            // 
            this.cRed.DataPropertyName = "id_red";
            this.cRed.DataSource = this.vosobyBindingSource;
            this.cRed.DisplayMember = "jmeno";
            this.cRed.HeaderText = "Øeditel";
            this.cRed.Name = "cRed";
            this.cRed.ValueMember = "id";
            // 
            // cZast
            // 
            this.cZast.DataPropertyName = "zastupce";
            this.cZast.HeaderText = "Zástupce svazu";
            this.cZast.Name = "cZast";
            // 
            // cKlub1
            // 
            this.cKlub1.DataPropertyName = "id_klubu";
            this.cKlub1.DataSource = this.vklubyBindingSource;
            this.cKlub1.DisplayMember = "nazev";
            this.cKlub1.HeaderText = "Poøádající klub";
            this.cKlub1.Name = "cKlub1";
            this.cKlub1.ValueMember = "id";
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
            // cKlub2
            // 
            this.cKlub2.DataPropertyName = "id_klubu2";
            this.cKlub2.DataSource = this.vklubyBindingSource;
            this.cKlub2.DisplayMember = "nazev";
            this.cKlub2.HeaderText = "2. poøádající klub";
            this.cKlub2.Name = "cKlub2";
            this.cKlub2.ValueMember = "id";
            // 
            // cOd
            // 
            this.cOd.DataPropertyName = "datum_od";
            this.cOd.HeaderText = "Od";
            this.cOd.Name = "cOd";
            // 
            // cDo
            // 
            this.cDo.DataPropertyName = "datum_do";
            this.cDo.HeaderText = "Do";
            this.cDo.Name = "cDo";
            // 
            // tPosadky
            // 
            this.tPosadky.Controls.Add(this.chckOverrideCountZavodniku);
            this.tPosadky.Controls.Add(this.button15);
            this.tPosadky.Controls.Add(this.button8);
            this.tPosadky.Controls.Add(this.button1);
            this.tPosadky.Controls.Add(this.lstDisciplinyPosadky);
            this.tPosadky.Controls.Add(this.lblVybranychLidi);
            this.tPosadky.Controls.Add(this.txtNazev);
            this.tPosadky.Controls.Add(this.lstKluby);
            this.tPosadky.Controls.Add(this.cmbKategorie);
            this.tPosadky.Controls.Add(this.lstPosadky);
            this.tPosadky.Controls.Add(this.lstPoharovePosadky);
            this.tPosadky.Controls.Add(this.chckExistujici);
            this.tPosadky.Controls.Add(this.chckPoharova);
            this.tPosadky.Controls.Add(this.chckNova);
            this.tPosadky.Controls.Add(this.label5);
            this.tPosadky.Controls.Add(this.txtNewZavodnik);
            this.tPosadky.Controls.Add(this.lstZavodnici);
            this.tPosadky.Controls.Add(this.label7);
            this.tPosadky.Controls.Add(this.label8);
            this.tPosadky.Controls.Add(this.label6);
            this.tPosadky.Controls.Add(this.label3);
            this.tPosadky.Location = new System.Drawing.Point(4, 22);
            this.tPosadky.Name = "tPosadky";
            this.tPosadky.Padding = new System.Windows.Forms.Padding(3);
            this.tPosadky.Size = new System.Drawing.Size(952, 480);
            this.tPosadky.TabIndex = 3;
            this.tPosadky.Text = "Posádky";
            this.tPosadky.UseVisualStyleBackColor = true;
            this.tPosadky.Click += new System.EventHandler(this.tPosadky_Click);
            // 
            // chckOverrideCountZavodniku
            // 
            this.chckOverrideCountZavodniku.AutoSize = true;
            this.chckOverrideCountZavodniku.Location = new System.Drawing.Point(475, 457);
            this.chckOverrideCountZavodniku.Name = "chckOverrideCountZavodniku";
            this.chckOverrideCountZavodniku.Size = new System.Drawing.Size(129, 17);
            this.chckOverrideCountZavodniku.TabIndex = 11;
            this.chckOverrideCountZavodniku.Text = "Ignorovat poèty èlenù";
            this.chckOverrideCountZavodniku.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button15.Location = new System.Drawing.Point(475, 327);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(196, 24);
            this.button15.TabIndex = 8;
            this.button15.Tag = "2";
            this.button15.Text = "Jen aktualizovat pohárovou posádku";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button1_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button8.Location = new System.Drawing.Point(475, 358);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(196, 28);
            this.button8.TabIndex = 8;
            this.button8.Tag = "1";
            this.button8.Text = "Pøidat posádku i do poháru";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(475, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 54);
            this.button1.TabIndex = 7;
            this.button1.Tag = "0";
            this.button1.Text = "Pøidat posádku";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstDisciplinyPosadky
            // 
            this.lstDisciplinyPosadky.FormattingEnabled = true;
            this.lstDisciplinyPosadky.Location = new System.Drawing.Point(3, 403);
            this.lstDisciplinyPosadky.Name = "lstDisciplinyPosadky";
            this.lstDisciplinyPosadky.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstDisciplinyPosadky.Size = new System.Drawing.Size(322, 56);
            this.lstDisciplinyPosadky.TabIndex = 9;
            // 
            // lblVybranychLidi
            // 
            this.lblVybranychLidi.AutoSize = true;
            this.lblVybranychLidi.Location = new System.Drawing.Point(475, 305);
            this.lblVybranychLidi.Name = "lblVybranychLidi";
            this.lblVybranychLidi.Size = new System.Drawing.Size(80, 13);
            this.lblVybranychLidi.TabIndex = 10;
            this.lblVybranychLidi.Text = "nikdo nevybrán";
            // 
            // txtNazev
            // 
            this.txtNazev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtNazev.Location = new System.Drawing.Point(473, 23);
            this.txtNazev.Name = "txtNazev";
            this.txtNazev.Size = new System.Drawing.Size(196, 26);
            this.txtNazev.TabIndex = 5;
            // 
            // lstKluby
            // 
            this.lstKluby.DataSource = this.vklubyBindingSource;
            this.lstKluby.DisplayMember = "nazev";
            this.lstKluby.FormattingEnabled = true;
            this.lstKluby.Location = new System.Drawing.Point(3, 67);
            this.lstKluby.Name = "lstKluby";
            this.lstKluby.Size = new System.Drawing.Size(177, 290);
            this.lstKluby.TabIndex = 1;
            this.lstKluby.ValueMember = "id";
            this.lstKluby.SelectedIndexChanged += new System.EventHandler(this.lstKluby_SelectedIndexChanged_1);
            // 
            // cmbKategorie
            // 
            this.cmbKategorie.DataSource = this.ciskategoriiBindingSource;
            this.cmbKategorie.DisplayMember = "nazev";
            this.cmbKategorie.FormattingEnabled = true;
            this.cmbKategorie.Location = new System.Drawing.Point(6, 22);
            this.cmbKategorie.Name = "cmbKategorie";
            this.cmbKategorie.Size = new System.Drawing.Size(168, 21);
            this.cmbKategorie.TabIndex = 2;
            this.cmbKategorie.ValueMember = "id_kat";
            this.cmbKategorie.SelectedIndexChanged += new System.EventHandler(this.cmbKategorie_SelectedIndexChanged);
            // 
            // ciskategoriiBindingSource
            // 
            this.ciskategoriiBindingSource.DataMember = "cis_kategorii";
            this.ciskategoriiBindingSource.DataSource = this.p5time_svazvodaku_czDataSet3;
            // 
            // p5time_svazvodaku_czDataSet3
            // 
            this.p5time_svazvodaku_czDataSet3.DataSetName = "p5time_svazvodaku_czDataSet3";
            this.p5time_svazvodaku_czDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lstPosadky
            // 
            this.lstPosadky.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstPosadky.FormattingEnabled = true;
            this.lstPosadky.Location = new System.Drawing.Point(241, 249);
            this.lstPosadky.Name = "lstPosadky";
            this.lstPosadky.Size = new System.Drawing.Size(166, 108);
            this.lstPosadky.TabIndex = 4;
            this.lstPosadky.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstPosadky_DrawItem);
            this.lstPosadky.SelectedIndexChanged += new System.EventHandler(this.lstPosadky_SelectedIndexChanged);
            this.lstPosadky.Click += new System.EventHandler(this.lstPosadky_Click);
            // 
            // lstPoharovePosadky
            // 
            this.lstPoharovePosadky.FormattingEnabled = true;
            this.lstPoharovePosadky.Location = new System.Drawing.Point(241, 63);
            this.lstPoharovePosadky.Name = "lstPoharovePosadky";
            this.lstPoharovePosadky.Size = new System.Drawing.Size(166, 160);
            this.lstPoharovePosadky.TabIndex = 4;
            this.lstPoharovePosadky.SelectedIndexChanged += new System.EventHandler(this.lstPoharovePosadky_SelectedIndexChanged);
            this.lstPoharovePosadky.Click += new System.EventHandler(this.lstPoharovePosadky_Click);
            // 
            // chckExistujici
            // 
            this.chckExistujici.AutoSize = true;
            this.chckExistujici.Location = new System.Drawing.Point(241, 229);
            this.chckExistujici.Name = "chckExistujici";
            this.chckExistujici.Size = new System.Drawing.Size(113, 17);
            this.chckExistujici.TabIndex = 3;
            this.chckExistujici.Text = "Existující posádka";
            this.chckExistujici.UseVisualStyleBackColor = true;
            // 
            // chckPoharova
            // 
            this.chckPoharova.AutoSize = true;
            this.chckPoharova.Location = new System.Drawing.Point(241, 45);
            this.chckPoharova.Name = "chckPoharova";
            this.chckPoharova.Size = new System.Drawing.Size(115, 17);
            this.chckPoharova.TabIndex = 3;
            this.chckPoharova.Text = "Pohárová posádka";
            this.chckPoharova.UseVisualStyleBackColor = true;
            // 
            // chckNova
            // 
            this.chckNova.AutoSize = true;
            this.chckNova.Checked = true;
            this.chckNova.Location = new System.Drawing.Point(241, 22);
            this.chckNova.Name = "chckNova";
            this.chckNova.Size = new System.Drawing.Size(95, 17);
            this.chckNova.TabIndex = 3;
            this.chckNova.TabStop = true;
            this.chckNova.Text = "Nová posádka";
            this.chckNova.UseVisualStyleBackColor = true;
            this.chckNova.CheckedChanged += new System.EventHandler(this.chckNova_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(470, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Pøidat závodníka:";
            // 
            // txtNewZavodnik
            // 
            this.txtNewZavodnik.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtNewZavodnik.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNewZavodnik.Location = new System.Drawing.Point(473, 83);
            this.txtNewZavodnik.Name = "txtNewZavodnik";
            this.txtNewZavodnik.Size = new System.Drawing.Size(196, 20);
            this.txtNewZavodnik.TabIndex = 6;
            this.txtNewZavodnik.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtNewZavodnik_PreviewKeyDown);
            // 
            // lstZavodnici
            // 
            this.lstZavodnici.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstZavodnici.FormattingEnabled = true;
            this.lstZavodnici.Location = new System.Drawing.Point(473, 109);
            this.lstZavodnici.Name = "lstZavodnici";
            this.lstZavodnici.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstZavodnici.Size = new System.Drawing.Size(196, 186);
            this.lstZavodnici.TabIndex = 2;
            this.lstZavodnici.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstZavodnici_DrawItem);
            this.lstZavodnici.SelectedIndexChanged += new System.EventHandler(this.lstZavodnici_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(470, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Název posádky:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 386);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(240, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Pro jaké disciplíny nastavit toto složení posádky?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Kategorie:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Klub:";
            // 
            // tRozlosovani
            // 
            this.tRozlosovani.Controls.Add(this.cmbKatRozlosovani);
            this.tRozlosovani.Controls.Add(this.button3);
            this.tRozlosovani.Controls.Add(this.button2);
            this.tRozlosovani.Controls.Add(this.txtRozlosovaniCisla);
            this.tRozlosovani.Controls.Add(this.label12);
            this.tRozlosovani.Controls.Add(this.label11);
            this.tRozlosovani.Controls.Add(this.label10);
            this.tRozlosovani.Controls.Add(this.label9);
            this.tRozlosovani.Controls.Add(this.grdRozlosovani);
            this.tRozlosovani.Location = new System.Drawing.Point(4, 22);
            this.tRozlosovani.Name = "tRozlosovani";
            this.tRozlosovani.Padding = new System.Windows.Forms.Padding(3);
            this.tRozlosovani.Size = new System.Drawing.Size(952, 480);
            this.tRozlosovani.TabIndex = 5;
            this.tRozlosovani.Text = "Rozlosování";
            this.tRozlosovani.UseVisualStyleBackColor = true;
            // 
            // cmbKatRozlosovani
            // 
            this.cmbKatRozlosovani.DataSource = this.ciskategoriiBindingSource;
            this.cmbKatRozlosovani.DisplayMember = "nazev";
            this.cmbKatRozlosovani.FormattingEnabled = true;
            this.cmbKatRozlosovani.Location = new System.Drawing.Point(481, 49);
            this.cmbKatRozlosovani.Name = "cmbKatRozlosovani";
            this.cmbKatRozlosovani.Size = new System.Drawing.Size(121, 21);
            this.cmbKatRozlosovani.TabIndex = 2;
            this.cmbKatRozlosovani.ValueMember = "id_kat";
            this.cmbKatRozlosovani.SelectedIndexChanged += new System.EventHandler(this.cmbKatRozlosovani_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(481, 288);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Uložit rozlosování";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(481, 244);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Rozlosuj";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtRozlosovaniCisla
            // 
            this.txtRozlosovaniCisla.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRozlosovaniCisla.Location = new System.Drawing.Point(480, 102);
            this.txtRozlosovaniCisla.Name = "txtRozlosovaniCisla";
            this.txtRozlosovaniCisla.Size = new System.Drawing.Size(466, 20);
            this.txtRozlosovaniCisla.TabIndex = 3;
            this.txtRozlosovaniCisla.Text = "1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(478, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(214, 104);
            this.label12.TabIndex = 1;
            this.label12.Text = resources.GetString("label12.Text");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(478, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Èísla:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(477, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Pro kategorii:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(478, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Generovat èísla:";
            // 
            // grdRozlosovani
            // 
            this.grdRozlosovani.AllowUserToAddRows = false;
            this.grdRozlosovani.AllowUserToDeleteRows = false;
            this.grdRozlosovani.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdRozlosovani.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRozlosovani.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_kat,
            this.nazev,
            this.klub,
            this.cislo});
            this.grdRozlosovani.Location = new System.Drawing.Point(6, 6);
            this.grdRozlosovani.Name = "grdRozlosovani";
            this.grdRozlosovani.Size = new System.Drawing.Size(466, 468);
            this.grdRozlosovani.TabIndex = 0;
            // 
            // id_kat
            // 
            this.id_kat.DataPropertyName = "id_kat";
            this.id_kat.DataSource = this.ciskategoriiBindingSource;
            this.id_kat.DisplayMember = "nazev";
            this.id_kat.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.id_kat.DisplayStyleForCurrentCellOnly = true;
            this.id_kat.HeaderText = "Kategorie";
            this.id_kat.Name = "id_kat";
            this.id_kat.ReadOnly = true;
            this.id_kat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.id_kat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.id_kat.ValueMember = "id_kat";
            // 
            // nazev
            // 
            this.nazev.DataPropertyName = "nazev";
            this.nazev.HeaderText = "Název";
            this.nazev.Name = "nazev";
            this.nazev.ReadOnly = true;
            // 
            // klub
            // 
            this.klub.DataPropertyName = "id_klubu";
            this.klub.DataSource = this.vklubyBindingSource;
            this.klub.DisplayMember = "nazev";
            this.klub.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.klub.DisplayStyleForCurrentCellOnly = true;
            this.klub.HeaderText = "Klub";
            this.klub.Name = "klub";
            this.klub.ReadOnly = true;
            this.klub.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.klub.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.klub.ValueMember = "id";
            // 
            // cislo
            // 
            this.cislo.DataPropertyName = "startovni_cislo";
            dataGridViewCellStyle32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle32.Format = "N0";
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.Color.Black;
            this.cislo.DefaultCellStyle = dataGridViewCellStyle32;
            this.cislo.FromRight = false;
            this.cislo.HeaderText = "Startovní Èíslo";
            this.cislo.IncludeLiterals = true;
            this.cislo.IncludePrompt = false;
            this.cislo.Mask = "990";
            this.cislo.Name = "cislo";
            this.cislo.PromptChar = '_';
            this.cislo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cislo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cislo.ValidatingType = null;
            // 
            // tStartovka
            // 
            this.tStartovka.Controls.Add(this.button13);
            this.tStartovka.Controls.Add(this.checkBox1);
            this.tStartovka.Controls.Add(this.button6);
            this.tStartovka.Controls.Add(this.groupBox1);
            this.tStartovka.Controls.Add(this.button4);
            this.tStartovka.Controls.Add(this.cmbStartovkaDiscipliny);
            this.tStartovka.Controls.Add(this.label13);
            this.tStartovka.Controls.Add(this.grdStartovka);
            this.tStartovka.Location = new System.Drawing.Point(4, 22);
            this.tStartovka.Name = "tStartovka";
            this.tStartovka.Size = new System.Drawing.Size(952, 480);
            this.tStartovka.TabIndex = 6;
            this.tStartovka.Text = "Startovka";
            this.tStartovka.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(335, 6);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(174, 23);
            this.button13.TabIndex = 7;
            this.button13.Text = "Export pro èasomíru";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(754, 9);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(136, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Zobrazit èleny posádek";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(203, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(114, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "Tisk";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chckPoDvou);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.txtTimeInterval);
            this.groupBox1.Controls.Add(this.txtFromTimeStarts);
            this.groupBox1.Controls.Add(this.rb2kolo);
            this.groupBox1.Controls.Add(this.rb1kolo);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cmbKatStartTimes);
            this.groupBox1.Location = new System.Drawing.Point(744, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 244);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generovat èasy";
            // 
            // chckPoDvou
            // 
            this.chckPoDvou.AutoSize = true;
            this.chckPoDvou.Location = new System.Drawing.Point(7, 187);
            this.chckPoDvou.Name = "chckPoDvou";
            this.chckPoDvou.Size = new System.Drawing.Size(118, 17);
            this.chckPoDvou.TabIndex = 6;
            this.chckPoDvou.Text = "Startuje se po dvou";
            this.chckPoDvou.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(7, 210);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(184, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Generuj!";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtTimeInterval
            // 
            this.txtTimeInterval.Location = new System.Drawing.Point(7, 160);
            this.txtTimeInterval.Mask = "00000";
            this.txtTimeInterval.Name = "txtTimeInterval";
            this.txtTimeInterval.PromptChar = ' ';
            this.txtTimeInterval.Size = new System.Drawing.Size(100, 20);
            this.txtTimeInterval.TabIndex = 4;
            this.txtTimeInterval.Enter += new System.EventHandler(this.txtTimeInterval_Enter);
            // 
            // txtFromTimeStarts
            // 
            this.txtFromTimeStarts.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtFromTimeStarts.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtFromTimeStarts.Location = new System.Drawing.Point(10, 116);
            this.txtFromTimeStarts.Mask = "00:00:00.00";
            this.txtFromTimeStarts.Name = "txtFromTimeStarts";
            this.txtFromTimeStarts.PromptChar = '0';
            this.txtFromTimeStarts.Size = new System.Drawing.Size(100, 20);
            this.txtFromTimeStarts.TabIndex = 3;
            this.txtFromTimeStarts.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // rb2kolo
            // 
            this.rb2kolo.AutoSize = true;
            this.rb2kolo.Location = new System.Drawing.Point(112, 65);
            this.rb2kolo.Name = "rb2kolo";
            this.rb2kolo.Size = new System.Drawing.Size(57, 17);
            this.rb2kolo.TabIndex = 2;
            this.rb2kolo.Text = "2. kolo";
            this.rb2kolo.UseVisualStyleBackColor = true;
            // 
            // rb1kolo
            // 
            this.rb1kolo.AutoSize = true;
            this.rb1kolo.Checked = true;
            this.rb1kolo.Location = new System.Drawing.Point(10, 65);
            this.rb1kolo.Name = "rb1kolo";
            this.rb1kolo.Size = new System.Drawing.Size(57, 17);
            this.rb1kolo.TabIndex = 2;
            this.rb1kolo.TabStop = true;
            this.rb1kolo.Text = "1. kolo";
            this.rb1kolo.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 143);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Interval (sekund):";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 99);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Start prvního:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Kategorie:";
            // 
            // cmbKatStartTimes
            // 
            this.cmbKatStartTimes.DataSource = this.ciskategoriiBindingSource;
            this.cmbKatStartTimes.DisplayMember = "nazev";
            this.cmbKatStartTimes.FormattingEnabled = true;
            this.cmbKatStartTimes.Location = new System.Drawing.Point(7, 37);
            this.cmbKatStartTimes.Name = "cmbKatStartTimes";
            this.cmbKatStartTimes.Size = new System.Drawing.Size(121, 21);
            this.cmbKatStartTimes.TabIndex = 1;
            this.cmbKatStartTimes.ValueMember = "id_kat";
            this.cmbKatStartTimes.SelectedIndexChanged += new System.EventHandler(this.cmbKatStartTimes_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(751, 307);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(190, 22);
            this.button4.TabIndex = 3;
            this.button4.Text = "Uložit ruènì udìlané zmìny";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cmbStartovkaDiscipliny
            // 
            this.cmbStartovkaDiscipliny.FormattingEnabled = true;
            this.cmbStartovkaDiscipliny.Location = new System.Drawing.Point(59, 6);
            this.cmbStartovkaDiscipliny.Name = "cmbStartovkaDiscipliny";
            this.cmbStartovkaDiscipliny.Size = new System.Drawing.Size(121, 21);
            this.cmbStartovkaDiscipliny.TabIndex = 0;
            this.cmbStartovkaDiscipliny.SelectedIndexChanged += new System.EventHandler(this.cmbStartovkaDiscipliny_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Disciplína:";
            // 
            // grdStartovka
            // 
            this.grdStartovka.AllowUserToAddRows = false;
            this.grdStartovka.AllowUserToDeleteRows = false;
            this.grdStartovka.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdStartovka.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdStartovka.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cisloS,
            this.kategorieS,
            this.nazevS,
            this.posadkaFull,
            this.cStartovkaClenoce,
            this.cCk,
            this.cRocnik,
            this.kolo1,
            this.kolo2});
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdStartovka.DefaultCellStyle = dataGridViewCellStyle36;
            this.grdStartovka.Location = new System.Drawing.Point(4, 39);
            this.grdStartovka.Name = "grdStartovka";
            this.grdStartovka.Size = new System.Drawing.Size(733, 438);
            this.grdStartovka.TabIndex = 0;
            // 
            // cisloS
            // 
            this.cisloS.DataPropertyName = "startovni_cislo";
            this.cisloS.HeaderText = "#";
            this.cisloS.Name = "cisloS";
            this.cisloS.ReadOnly = true;
            // 
            // kategorieS
            // 
            this.kategorieS.DataPropertyName = "id_kat";
            this.kategorieS.DataSource = this.ciskategoriiBindingSource;
            this.kategorieS.DisplayMember = "nazev";
            this.kategorieS.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.kategorieS.HeaderText = "Kategorie";
            this.kategorieS.Name = "kategorieS";
            this.kategorieS.ReadOnly = true;
            this.kategorieS.ValueMember = "id_kat";
            // 
            // nazevS
            // 
            this.nazevS.DataPropertyName = "nazev";
            this.nazevS.HeaderText = "Posádka";
            this.nazevS.Name = "nazevS";
            this.nazevS.ReadOnly = true;
            // 
            // posadkaFull
            // 
            this.posadkaFull.DataPropertyName = "nazevfull";
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.posadkaFull.DefaultCellStyle = dataGridViewCellStyle33;
            this.posadkaFull.HeaderText = "Posádka";
            this.posadkaFull.Name = "posadkaFull";
            this.posadkaFull.ReadOnly = true;
            this.posadkaFull.Visible = false;
            // 
            // cStartovkaClenoce
            // 
            this.cStartovkaClenoce.DataPropertyName = "clenove";
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cStartovkaClenoce.DefaultCellStyle = dataGridViewCellStyle34;
            this.cStartovkaClenoce.HeaderText = "Složení";
            this.cStartovkaClenoce.Name = "cStartovkaClenoce";
            this.cStartovkaClenoce.ReadOnly = true;
            this.cStartovkaClenoce.Visible = false;
            // 
            // cCk
            // 
            this.cCk.DataPropertyName = "cisloklubu";
            this.cCk.HeaderText = "È.kl.";
            this.cCk.Name = "cCk";
            this.cCk.ReadOnly = true;
            this.cCk.Visible = false;
            // 
            // cRocnik
            // 
            this.cRocnik.DataPropertyName = "rocniky";
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cRocnik.DefaultCellStyle = dataGridViewCellStyle35;
            this.cRocnik.HeaderText = "Roè";
            this.cRocnik.Name = "cRocnik";
            this.cRocnik.ReadOnly = true;
            this.cRocnik.Visible = false;
            // 
            // kolo1
            // 
            this.kolo1.DataPropertyName = "start1";
            this.kolo1.FromRight = true;
            this.kolo1.HeaderText = "Start 1. kola";
            this.kolo1.IncludeLiterals = true;
            this.kolo1.IncludePrompt = true;
            this.kolo1.Mask = "00:00:00.00";
            this.kolo1.Name = "kolo1";
            this.kolo1.PromptChar = '0';
            this.kolo1.ValidatingType = null;
            // 
            // kolo2
            // 
            this.kolo2.DataPropertyName = "start2";
            this.kolo2.FromRight = true;
            this.kolo2.HeaderText = "Start 2. kola";
            this.kolo2.IncludeLiterals = true;
            this.kolo2.IncludePrompt = true;
            this.kolo2.Mask = "00:00:00.00";
            this.kolo2.Name = "kolo2";
            this.kolo2.PromptChar = '0';
            this.kolo2.ValidatingType = null;
            // 
            // tVysledky
            // 
            this.tVysledky.Controls.Add(this.numericUpDown1);
            this.tVysledky.Controls.Add(this.btnBranky);
            this.tVysledky.Controls.Add(this.button14);
            this.tVysledky.Controls.Add(this.checkBox2);
            this.tVysledky.Controls.Add(this.button10);
            this.tVysledky.Controls.Add(this.groupBox3);
            this.tVysledky.Controls.Add(this.groupBox2);
            this.tVysledky.Controls.Add(this.button9);
            this.tVysledky.Controls.Add(this.cmbKategorieVysledky);
            this.tVysledky.Controls.Add(this.cmbVysledkyDiscipliny);
            this.tVysledky.Controls.Add(this.label17);
            this.tVysledky.Controls.Add(this.label20);
            this.tVysledky.Controls.Add(this.grdVysledky);
            this.tVysledky.Location = new System.Drawing.Point(4, 22);
            this.tVysledky.Name = "tVysledky";
            this.tVysledky.Padding = new System.Windows.Forms.Padding(3);
            this.tVysledky.Size = new System.Drawing.Size(952, 480);
            this.tVysledky.TabIndex = 4;
            this.tVysledky.Text = "Zadání výsledkù";
            this.tVysledky.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(882, 8);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(61, 20);
            this.numericUpDown1.TabIndex = 19;
            this.numericUpDown1.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // btnBranky
            // 
            this.btnBranky.Location = new System.Drawing.Point(753, 6);
            this.btnBranky.Name = "btnBranky";
            this.btnBranky.Size = new System.Drawing.Size(122, 23);
            this.btnBranky.TabIndex = 18;
            this.btnBranky.Text = "Branky";
            this.btnBranky.UseVisualStyleBackColor = true;
            this.btnBranky.Click += new System.EventHandler(this.button18_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(471, 6);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(120, 23);
            this.button14.TabIndex = 17;
            this.button14.Text = "Import z èasomíry";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(384, 9);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(66, 17);
            this.checkBox2.TabIndex = 16;
            this.checkBox2.Text = "všechny";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(615, 6);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(124, 23);
            this.button10.TabIndex = 15;
            this.button10.Text = "Tisk";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.rbZavodu);
            this.groupBox3.Controls.Add(this.rbCilovy);
            this.groupBox3.Location = new System.Drawing.Point(753, 156);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(190, 71);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Druh editace";
            // 
            // rbZavodu
            // 
            this.rbZavodu.AutoSize = true;
            this.rbZavodu.Location = new System.Drawing.Point(6, 42);
            this.rbZavodu.Name = "rbZavodu";
            this.rbZavodu.Size = new System.Drawing.Size(121, 17);
            this.rbZavodu.TabIndex = 0;
            this.rbZavodu.Text = "editovat èas závodu";
            this.rbZavodu.UseVisualStyleBackColor = true;
            this.rbZavodu.CheckedChanged += new System.EventHandler(this.rbCilovy_CheckedChanged);
            // 
            // rbCilovy
            // 
            this.rbCilovy.AutoSize = true;
            this.rbCilovy.Checked = true;
            this.rbCilovy.Location = new System.Drawing.Point(7, 19);
            this.rbCilovy.Name = "rbCilovy";
            this.rbCilovy.Size = new System.Drawing.Size(115, 17);
            this.rbCilovy.TabIndex = 0;
            this.rbCilovy.TabStop = true;
            this.rbCilovy.Text = "editovat cílový èas";
            this.rbCilovy.UseVisualStyleBackColor = true;
            this.rbCilovy.CheckedChanged += new System.EventHandler(this.rbCilovy_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Location = new System.Drawing.Point(753, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(190, 100);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Zobrazit";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 66);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(57, 17);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.Text = "2. kolo";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(7, 43);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(57, 17);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "1. kolo";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(42, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "vše";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.Location = new System.Drawing.Point(784, 280);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(127, 68);
            this.button9.TabIndex = 10;
            this.button9.Text = "Uzavøít výsledky";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // cmbKategorieVysledky
            // 
            this.cmbKategorieVysledky.DataSource = this.ciskategoriiBindingSource;
            this.cmbKategorieVysledky.DisplayMember = "nazev";
            this.cmbKategorieVysledky.FormattingEnabled = true;
            this.cmbKategorieVysledky.Location = new System.Drawing.Point(256, 6);
            this.cmbKategorieVysledky.Name = "cmbKategorieVysledky";
            this.cmbKategorieVysledky.Size = new System.Drawing.Size(121, 21);
            this.cmbKategorieVysledky.TabIndex = 9;
            this.cmbKategorieVysledky.ValueMember = "id_kat";
            this.cmbKategorieVysledky.SelectedIndexChanged += new System.EventHandler(this.cmbVysledkyDiscipliny_SelectedIndexChanged);
            // 
            // cmbVysledkyDiscipliny
            // 
            this.cmbVysledkyDiscipliny.FormattingEnabled = true;
            this.cmbVysledkyDiscipliny.Location = new System.Drawing.Point(61, 5);
            this.cmbVysledkyDiscipliny.Name = "cmbVysledkyDiscipliny";
            this.cmbVysledkyDiscipliny.Size = new System.Drawing.Size(121, 21);
            this.cmbVysledkyDiscipliny.TabIndex = 9;
            this.cmbVysledkyDiscipliny.SelectedIndexChanged += new System.EventHandler(this.cmbVysledkyDiscipliny_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(196, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 13);
            this.label17.TabIndex = 8;
            this.label17.Text = "Kategorie:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 8);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(57, 13);
            this.label20.TabIndex = 8;
            this.label20.Text = "Disciplína:";
            // 
            // grdVysledky
            // 
            this.grdVysledky.AllowUserToAddRows = false;
            this.grdVysledky.AllowUserToDeleteRows = false;
            this.grdVysledky.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdVysledky.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVysledky.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewComboBoxColumn1,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.maskedTextBoxColumn4,
            this.cCil1,
            this.cPenalty1,
            this.cTime1,
            this.cStatus1,
            this.maskedTextBoxColumn5,
            this.cCil2,
            this.cPenalty2,
            this.cTime2,
            this.cStatus2,
            this.cFinalTime,
            this.Status});
            dataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle48.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle48.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle48.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle48.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdVysledky.DefaultCellStyle = dataGridViewCellStyle48;
            this.grdVysledky.Location = new System.Drawing.Point(6, 38);
            this.grdVysledky.Name = "grdVysledky";
            this.grdVysledky.Size = new System.Drawing.Size(733, 438);
            this.grdVysledky.TabIndex = 7;
            this.grdVysledky.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdVysledky_RowEnter);
            this.grdVysledky.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdVysledky_RowValidated);
            this.grdVysledky.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdVysledky_DataBindingComplete);
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "startovni_cislo";
            this.dataGridViewTextBoxColumn9.Frozen = true;
            this.dataGridViewTextBoxColumn9.HeaderText = "#";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataPropertyName = "id_kat";
            this.dataGridViewComboBoxColumn1.DataSource = this.ciskategoriiBindingSource;
            this.dataGridViewComboBoxColumn1.DisplayMember = "nazev";
            this.dataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewComboBoxColumn1.HeaderText = "Kategorie";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.ReadOnly = true;
            this.dataGridViewComboBoxColumn1.ValueMember = "id_kat";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "nazev";
            this.dataGridViewTextBoxColumn10.HeaderText = "Posádka";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "clenove";
            dataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle37;
            this.dataGridViewTextBoxColumn11.HeaderText = "Složení";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // maskedTextBoxColumn4
            // 
            this.maskedTextBoxColumn4.DataPropertyName = "start1";
            this.maskedTextBoxColumn4.FromRight = false;
            this.maskedTextBoxColumn4.HeaderText = "Start 1. kola";
            this.maskedTextBoxColumn4.IncludeLiterals = true;
            this.maskedTextBoxColumn4.IncludePrompt = true;
            this.maskedTextBoxColumn4.Mask = "00:00:00.00";
            this.maskedTextBoxColumn4.Name = "maskedTextBoxColumn4";
            this.maskedTextBoxColumn4.PromptChar = '0';
            this.maskedTextBoxColumn4.ReadOnly = true;
            this.maskedTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.maskedTextBoxColumn4.ValidatingType = null;
            // 
            // cCil1
            // 
            this.cCil1.DataPropertyName = "fin1";
            dataGridViewCellStyle38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle38.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cCil1.DefaultCellStyle = dataGridViewCellStyle38;
            this.cCil1.FromRight = false;
            this.cCil1.HeaderText = "Cíl 1. kola";
            this.cCil1.IncludeLiterals = true;
            this.cCil1.IncludePrompt = true;
            this.cCil1.Mask = "00:00:00.00";
            this.cCil1.Name = "cCil1";
            this.cCil1.PromptChar = '0';
            this.cCil1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cCil1.ValidatingType = null;
            // 
            // cPenalty1
            // 
            this.cPenalty1.DataPropertyName = "penalty1";
            dataGridViewCellStyle39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cPenalty1.DefaultCellStyle = dataGridViewCellStyle39;
            this.cPenalty1.FromRight = false;
            this.cPenalty1.HeaderText = "Penalty 1. k";
            this.cPenalty1.IncludeLiterals = true;
            this.cPenalty1.IncludePrompt = false;
            this.cPenalty1.Mask = "9990";
            this.cPenalty1.Name = "cPenalty1";
            this.cPenalty1.PromptChar = '_';
            this.cPenalty1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cPenalty1.ValidatingType = null;
            // 
            // cTime1
            // 
            this.cTime1.DataPropertyName = "time1";
            dataGridViewCellStyle40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle40.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cTime1.DefaultCellStyle = dataGridViewCellStyle40;
            this.cTime1.FromRight = true;
            this.cTime1.HeaderText = "Èas 1. kola";
            this.cTime1.IncludeLiterals = true;
            this.cTime1.IncludePrompt = true;
            this.cTime1.Mask = "00:00:00.00";
            this.cTime1.Name = "cTime1";
            this.cTime1.PromptChar = '0';
            this.cTime1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cTime1.ValidatingType = null;
            // 
            // cStatus1
            // 
            this.cStatus1.DataPropertyName = "status1";
            this.cStatus1.DataSource = this.cisstatusyBindingSource;
            dataGridViewCellStyle41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle41.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cStatus1.DefaultCellStyle = dataGridViewCellStyle41;
            this.cStatus1.DisplayMember = "nazev";
            this.cStatus1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.cStatus1.HeaderText = "Status 1. k";
            this.cStatus1.Name = "cStatus1";
            this.cStatus1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cStatus1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cStatus1.ValueMember = "id_status";
            // 
            // cisstatusyBindingSource
            // 
            this.cisstatusyBindingSource.DataMember = "cis_statusy";
            this.cisstatusyBindingSource.DataSource = this.p5time_svazvodaku_czStatusy;
            // 
            // p5time_svazvodaku_czStatusy
            // 
            this.p5time_svazvodaku_czStatusy.DataSetName = "p5time_svazvodaku_czStatusy";
            this.p5time_svazvodaku_czStatusy.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // maskedTextBoxColumn5
            // 
            this.maskedTextBoxColumn5.DataPropertyName = "start2";
            this.maskedTextBoxColumn5.FromRight = false;
            this.maskedTextBoxColumn5.HeaderText = "Start 2. kola";
            this.maskedTextBoxColumn5.IncludeLiterals = true;
            this.maskedTextBoxColumn5.IncludePrompt = true;
            this.maskedTextBoxColumn5.Mask = "00:00:00.00";
            this.maskedTextBoxColumn5.Name = "maskedTextBoxColumn5";
            this.maskedTextBoxColumn5.PromptChar = '0';
            this.maskedTextBoxColumn5.ReadOnly = true;
            this.maskedTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.maskedTextBoxColumn5.ValidatingType = null;
            // 
            // cCil2
            // 
            this.cCil2.DataPropertyName = "fin2";
            dataGridViewCellStyle42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle42.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle42.SelectionForeColor = System.Drawing.Color.Black;
            this.cCil2.DefaultCellStyle = dataGridViewCellStyle42;
            this.cCil2.FromRight = false;
            this.cCil2.HeaderText = "Cíl 2. kola";
            this.cCil2.IncludeLiterals = true;
            this.cCil2.IncludePrompt = true;
            this.cCil2.Mask = "00:00:00.00";
            this.cCil2.Name = "cCil2";
            this.cCil2.PromptChar = '0';
            this.cCil2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cCil2.ValidatingType = null;
            // 
            // cPenalty2
            // 
            this.cPenalty2.DataPropertyName = "penalty2";
            dataGridViewCellStyle43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle43.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle43.SelectionForeColor = System.Drawing.Color.Black;
            this.cPenalty2.DefaultCellStyle = dataGridViewCellStyle43;
            this.cPenalty2.FromRight = false;
            this.cPenalty2.HeaderText = "Penalty 2. k";
            this.cPenalty2.IncludeLiterals = true;
            this.cPenalty2.IncludePrompt = false;
            this.cPenalty2.Mask = "9990";
            this.cPenalty2.Name = "cPenalty2";
            this.cPenalty2.PromptChar = '_';
            this.cPenalty2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cPenalty2.ValidatingType = null;
            // 
            // cTime2
            // 
            this.cTime2.DataPropertyName = "time2";
            dataGridViewCellStyle44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle44.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle44.SelectionForeColor = System.Drawing.Color.Black;
            this.cTime2.DefaultCellStyle = dataGridViewCellStyle44;
            this.cTime2.FromRight = true;
            this.cTime2.HeaderText = "Èas 2. kola";
            this.cTime2.IncludeLiterals = true;
            this.cTime2.IncludePrompt = true;
            this.cTime2.Mask = "00:00:00.00";
            this.cTime2.Name = "cTime2";
            this.cTime2.PromptChar = '0';
            this.cTime2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cTime2.ValidatingType = null;
            // 
            // cStatus2
            // 
            this.cStatus2.DataPropertyName = "status2";
            this.cStatus2.DataSource = this.cisstatusyBindingSource;
            dataGridViewCellStyle45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle45.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle45.SelectionForeColor = System.Drawing.Color.Black;
            this.cStatus2.DefaultCellStyle = dataGridViewCellStyle45;
            this.cStatus2.DisplayMember = "nazev";
            this.cStatus2.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.cStatus2.HeaderText = "Status 2. k";
            this.cStatus2.Name = "cStatus2";
            this.cStatus2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cStatus2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cStatus2.ValueMember = "id_status";
            // 
            // cFinalTime
            // 
            this.cFinalTime.DataPropertyName = "best_time";
            dataGridViewCellStyle46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle46.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle46.SelectionForeColor = System.Drawing.Color.Black;
            this.cFinalTime.DefaultCellStyle = dataGridViewCellStyle46;
            this.cFinalTime.FromRight = false;
            this.cFinalTime.HeaderText = "Koneèný èas";
            this.cFinalTime.IncludeLiterals = true;
            this.cFinalTime.IncludePrompt = true;
            this.cFinalTime.Mask = "00:00:00.00";
            this.cFinalTime.Name = "cFinalTime";
            this.cFinalTime.PromptChar = '0';
            this.cFinalTime.ReadOnly = true;
            this.cFinalTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cFinalTime.ValidatingType = null;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "status";
            this.Status.DataSource = this.cisstatusyBindingSource;
            dataGridViewCellStyle47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle47.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle47.SelectionForeColor = System.Drawing.Color.Black;
            this.Status.DefaultCellStyle = dataGridViewCellStyle47;
            this.Status.DisplayMember = "nazev";
            this.Status.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.ValueMember = "id_status";
            // 
            // tVysledkovka
            // 
            this.tVysledkovka.Controls.Add(this.btnUzavrit);
            this.tVysledkovka.Controls.Add(this.lblUzavreni);
            this.tVysledkovka.Controls.Add(this.button12);
            this.tVysledkovka.Controls.Add(this.button11);
            this.tVysledkovka.Controls.Add(this.button7);
            this.tVysledkovka.Controls.Add(this.cmbKatVysledkovka);
            this.tVysledkovka.Controls.Add(this.label18);
            this.tVysledkovka.Controls.Add(this.grdVysledkovka);
            this.tVysledkovka.Location = new System.Drawing.Point(4, 22);
            this.tVysledkovka.Name = "tVysledkovka";
            this.tVysledkovka.Padding = new System.Windows.Forms.Padding(3);
            this.tVysledkovka.Size = new System.Drawing.Size(952, 480);
            this.tVysledkovka.TabIndex = 7;
            this.tVysledkovka.Text = "Výsledkovka";
            this.tVysledkovka.UseVisualStyleBackColor = true;
            // 
            // btnUzavrit
            // 
            this.btnUzavrit.Location = new System.Drawing.Point(506, 6);
            this.btnUzavrit.Name = "btnUzavrit";
            this.btnUzavrit.Size = new System.Drawing.Size(75, 23);
            this.btnUzavrit.TabIndex = 15;
            this.btnUzavrit.Text = "Schválit";
            this.btnUzavrit.UseVisualStyleBackColor = true;
            this.btnUzavrit.Click += new System.EventHandler(this.btnUzavrit_Click);
            // 
            // lblUzavreni
            // 
            this.lblUzavreni.AutoSize = true;
            this.lblUzavreni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUzavreni.Location = new System.Drawing.Point(336, 11);
            this.lblUzavreni.Name = "lblUzavreni";
            this.lblUzavreni.Size = new System.Drawing.Size(164, 13);
            this.lblUzavreni.TabIndex = 14;
            this.lblUzavreni.Text = "Výsledky nejsou schválené!";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(755, 6);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(124, 23);
            this.button12.TabIndex = 13;
            this.button12.Text = "Export - Diplomy";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(609, 6);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(124, 23);
            this.button11.TabIndex = 13;
            this.button11.Text = "Export - Excel";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(199, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(124, 23);
            this.button7.TabIndex = 13;
            this.button7.Text = "Tisk";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // cmbKatVysledkovka
            // 
            this.cmbKatVysledkovka.DataSource = this.ciskategoriiBindingSource;
            this.cmbKatVysledkovka.DisplayMember = "nazev";
            this.cmbKatVysledkovka.FormattingEnabled = true;
            this.cmbKatVysledkovka.Location = new System.Drawing.Point(72, 6);
            this.cmbKatVysledkovka.Name = "cmbKatVysledkovka";
            this.cmbKatVysledkovka.Size = new System.Drawing.Size(121, 21);
            this.cmbKatVysledkovka.TabIndex = 12;
            this.cmbKatVysledkovka.ValueMember = "id_kat";
            this.cmbKatVysledkovka.SelectedIndexChanged += new System.EventHandler(this.cmbKatVysledkovka_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 13);
            this.label18.TabIndex = 11;
            this.label18.Text = "Kategorie:";
            // 
            // grdVysledkovka
            // 
            this.grdVysledkovka.AllowUserToAddRows = false;
            this.grdVysledkovka.AllowUserToDeleteRows = false;
            this.grdVysledkovka.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdVysledkovka.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVysledkovka.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle49.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle49.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle49.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle49.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdVysledkovka.DefaultCellStyle = dataGridViewCellStyle49;
            this.grdVysledkovka.Location = new System.Drawing.Point(6, 39);
            this.grdVysledkovka.Name = "grdVysledkovka";
            this.grdVysledkovka.ReadOnly = true;
            this.grdVysledkovka.Size = new System.Drawing.Size(940, 438);
            this.grdVysledkovka.TabIndex = 10;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "poradi";
            this.Column1.HeaderText = "#";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "cislo";
            this.Column2.HeaderText = "St. è.";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "oddil";
            this.Column3.HeaderText = "Posádka";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "jmena";
            this.Column4.HeaderText = "Èlenové";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "narozeni";
            this.Column5.HeaderText = "Roèník";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // tExport
            // 
            this.tExport.Controls.Add(this.button17);
            this.tExport.Controls.Add(this.label21);
            this.tExport.Controls.Add(this.label19);
            this.tExport.Controls.Add(this.txtPassword);
            this.tExport.Controls.Add(this.txtUser);
            this.tExport.Controls.Add(this.txtExport);
            this.tExport.Controls.Add(this.button16);
            this.tExport.Location = new System.Drawing.Point(4, 22);
            this.tExport.Name = "tExport";
            this.tExport.Padding = new System.Windows.Forms.Padding(3);
            this.tExport.Size = new System.Drawing.Size(952, 480);
            this.tExport.TabIndex = 8;
            this.tExport.Text = "Export na web";
            this.tExport.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(510, 9);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(75, 23);
            this.button17.TabIndex = 4;
            this.button17.Text = "Odeslat";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(343, 14);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 13);
            this.label21.TabIndex = 3;
            this.label21.Text = "Heslo:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(171, 14);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 13);
            this.label19.TabIndex = 3;
            this.label19.Text = "Jméno:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(390, 11);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(214, 11);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 2;
            // 
            // txtExport
            // 
            this.txtExport.Location = new System.Drawing.Point(7, 42);
            this.txtExport.Name = "txtExport";
            this.txtExport.Size = new System.Drawing.Size(939, 432);
            this.txtExport.TabIndex = 0;
            this.txtExport.TabStop = false;
            this.txtExport.Text = "";
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(6, 6);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(144, 29);
            this.button16.TabIndex = 1;
            this.button16.Text = "Exportuj";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // tCiselniky
            // 
            this.tCiselniky.Controls.Add(this.dataGrid);
            this.tCiselniky.Controls.Add(this.tables);
            this.tCiselniky.Controls.Add(this.updateBtn);
            this.tCiselniky.Controls.Add(this.label4);
            this.tCiselniky.Location = new System.Drawing.Point(4, 22);
            this.tCiselniky.Name = "tCiselniky";
            this.tCiselniky.Padding = new System.Windows.Forms.Padding(3);
            this.tCiselniky.Size = new System.Drawing.Size(952, 480);
            this.tCiselniky.TabIndex = 0;
            this.tCiselniky.Text = "Èíselníky";
            this.tCiselniky.UseVisualStyleBackColor = true;
            // 
            // dataGrid
            // 
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.DataMember = "";
            this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid.Location = new System.Drawing.Point(9, 35);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(929, 438);
            this.dataGrid.TabIndex = 9;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(984, 25);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Pøipojit";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Odpojit";
            this.toolStripButton2.Visible = false;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // vosobyTableAdapter
            // 
            this.vosobyTableAdapter.ClearBeforeFill = true;
            // 
            // vklubyTableAdapter
            // 
            this.vklubyTableAdapter.ClearBeforeFill = true;
            // 
            // cis_disciplinTableAdapter
            // 
            this.cis_disciplinTableAdapter.ClearBeforeFill = true;
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblSelected.Location = new System.Drawing.Point(12, 49);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(107, 18);
            this.lblSelected.TabIndex = 16;
            this.lblSelected.Text = "Nepøipojeno";
            // 
            // cis_kategoriiTableAdapter
            // 
            this.cis_kategoriiTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "nazev";
            this.dataGridViewTextBoxColumn1.HeaderText = "Název";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 152;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "nazev";
            this.dataGridViewTextBoxColumn2.HeaderText = "Název";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "zastupce";
            this.dataGridViewTextBoxColumn3.HeaderText = "Zástupce svazu";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "datum_od";
            this.dataGridViewTextBoxColumn4.HeaderText = "Od";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "datum_do";
            this.dataGridViewTextBoxColumn5.HeaderText = "Do";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "nazev";
            this.dataGridViewTextBoxColumn6.HeaderText = "Název";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // maskedTextBoxColumn1
            // 
            this.maskedTextBoxColumn1.DataPropertyName = "startovni_cislo";
            dataGridViewCellStyle50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle50.Format = "N0";
            dataGridViewCellStyle50.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle50.SelectionForeColor = System.Drawing.Color.Black;
            this.maskedTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle50;
            this.maskedTextBoxColumn1.FromRight = false;
            this.maskedTextBoxColumn1.HeaderText = "Startovní Èíslo";
            this.maskedTextBoxColumn1.IncludeLiterals = true;
            this.maskedTextBoxColumn1.IncludePrompt = false;
            this.maskedTextBoxColumn1.Mask = "990";
            this.maskedTextBoxColumn1.Name = "maskedTextBoxColumn1";
            this.maskedTextBoxColumn1.PromptChar = '_';
            this.maskedTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.maskedTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.maskedTextBoxColumn1.ValidatingType = null;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "startovni_cislo";
            this.dataGridViewTextBoxColumn7.HeaderText = "#";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "nazev";
            this.dataGridViewTextBoxColumn8.HeaderText = "Posádka";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // maskedTextBoxColumn2
            // 
            this.maskedTextBoxColumn2.DataPropertyName = "start1";
            this.maskedTextBoxColumn2.FromRight = false;
            this.maskedTextBoxColumn2.HeaderText = "Start 1. kola";
            this.maskedTextBoxColumn2.IncludeLiterals = true;
            this.maskedTextBoxColumn2.IncludePrompt = true;
            this.maskedTextBoxColumn2.Mask = "00:00:00.00";
            this.maskedTextBoxColumn2.Name = "maskedTextBoxColumn2";
            this.maskedTextBoxColumn2.PromptChar = '0';
            this.maskedTextBoxColumn2.ValidatingType = null;
            // 
            // maskedTextBoxColumn3
            // 
            this.maskedTextBoxColumn3.DataPropertyName = "start2";
            this.maskedTextBoxColumn3.FromRight = false;
            this.maskedTextBoxColumn3.HeaderText = "Start 2. kola";
            this.maskedTextBoxColumn3.IncludeLiterals = true;
            this.maskedTextBoxColumn3.IncludePrompt = true;
            this.maskedTextBoxColumn3.Mask = "00:00:00.00";
            this.maskedTextBoxColumn3.Name = "maskedTextBoxColumn3";
            this.maskedTextBoxColumn3.PromptChar = '0';
            this.maskedTextBoxColumn3.ValidatingType = null;
            // 
            // cis_statusyTableAdapter
            // 
            this.cis_statusyTableAdapter.ClearBeforeFill = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xlsx";
            this.saveFileDialog1.Title = "Uložit excel sheet";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Casy startu a cilu.txt";
            this.openFileDialog1.Filter = "soubory èasomíry|*.txt|všechny soubory|*.*";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(984, 624);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(660, 400);
            this.Name = "Form1";
            this.Text = "P5Time";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tWelcome.ResumeLayout(false);
            this.tWelcome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tZavody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDiscipliny)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cisdisciplinBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p5time_svazvodaku_czDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZavody)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vosobyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p5time_svazvodaku_czDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vklubyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p5time_svazvodaku_czDataSet1)).EndInit();
            this.tPosadky.ResumeLayout(false);
            this.tPosadky.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ciskategoriiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p5time_svazvodaku_czDataSet3)).EndInit();
            this.tRozlosovani.ResumeLayout(false);
            this.tRozlosovani.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRozlosovani)).EndInit();
            this.tStartovka.ResumeLayout(false);
            this.tStartovka.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdStartovka)).EndInit();
            this.tVysledky.ResumeLayout(false);
            this.tVysledky.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVysledky)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cisstatusyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p5time_svazvodaku_czStatusy)).EndInit();
            this.tVysledkovka.ResumeLayout(false);
            this.tVysledkovka.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVysledkovka)).EndInit();
            this.tExport.ResumeLayout(false);
            this.tExport.PerformLayout();
            this.tCiselniky.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}



        private void GetTables()
        {
            MySqlDataReader reader = null;

            //conn.ChangeDatabase( databaseList.SelectedItem.ToString() );

            MySqlCommand cmd = new MySqlCommand("SHOW TABLES", conn);
            try
            {
                reader = cmd.ExecuteReader();
                tables.Items.Clear();
                while (reader.Read())
                {
                    tables.Items.Add(reader.GetString(0));
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Failed to populate table list: " + ex.Message);
            }
            finally
            {
                if (reader != null) reader.Close();
            }
        }

        private void GetPohary()
        {
            try
            {
                data = new DataTable();
                da = new MySqlDataAdapter("SELECT id_poharu, nazev FROM cis_poharu", conn);
                cb = new MySqlCommandBuilder(da);
                da.Fill(data);
                cmbSezona.DisplayMember = "nazev";
                cmbSezona.ValueMember = "id_poharu";
                cmbSezona.DataSource = data;
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Failed to get pohary list: " + ex.Message);
            }
            finally
            {
                
            }
            //NactiSezonu z registru
            int? x = Common.GetPohar();
            if (x != null)
            {
                cmbSezona.SelectedValue = x;
                //pokud je, nastavim zavod
                if (Common.LastZavod != 0)
                {
                    GetZavody();
                    tabControl1.SelectedIndex = Common.LastTab;
                }
               
            }
            else
                Common.SetPohar(int.Parse(cmbSezona.SelectedValue.ToString()));
        }

        private void GetZavody()
        {
            int lastrow = 0;
            if (data2 != null)
            {
                foreach (DataRow r in data2.Rows)
                {
                    if (r["id_zavodu"].ToString() == Common.LastZavod.ToString())
                    {
                        lastrow = data2.Rows.IndexOf(r);
                    }
                }
            }
            data2 = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM zavod WHERE id_poharu = ?pohar", conn);
            cmd.Parameters.AddWithValue("pohar", cmbSezona.SelectedValue);
            da = new MySqlDataAdapter(cmd);
            cb = new MySqlCommandBuilder(da);
            da.FillLoadOption = LoadOption.PreserveChanges;
            da.Fill(data2);
            if (lastrow == 0)
            {
                foreach (DataRow r in data2.Rows)
                {
                    if (r["id_zavodu"].ToString() == Common.LastZavod.ToString())
                    {
                        lastrow = data2.Rows.IndexOf(r);
                    }
                }
            }
            data2.Columns["id_poharu"].DefaultValue = cmbSezona.SelectedValue;
            grdZavody.AutoGenerateColumns = false;
            grdZavody.DataSource = data2;
            grdZavody.AutoResizeColumns();
            GetDiscipliny();
            grdZavody.CurrentCell = grdZavody[0, lastrow];
            AZ.Refresh();

        }

        private void GetDiscipliny()
        {
            if (grdZavody.CurrentRow != null)
            {
                if (data2.DefaultView[grdZavody.CurrentRow.Index].IsNew)
                {
                    grdDiscipliny.DataSource = null;
                    grdDiscipliny.Enabled = false;
                }
                else
                {
                    if (data2.GetChanges() == null)  //jestli jsou zmeny, musi se nejdriv aplikovat
                    {
                        dataDiscipliny = new DataTable();
                        int SelectedZavod;
                        if (int.TryParse(data2.DefaultView[grdZavody.CurrentRow.Index]["id_zavodu"].ToString(), out SelectedZavod))
                        {
                            MySqlCommand cmd = new MySqlCommand("SELECT * FROM discipliny_zavodu WHERE id_zavodu = ?zavod", conn);
                            cmd.Parameters.AddWithValue("zavod", SelectedZavod);
                            daDisc = new MySqlDataAdapter(cmd);
                            MySqlCommandBuilder mycb = new MySqlCommandBuilder(daDisc);

                            daDisc.Fill(dataDiscipliny);
                            dataDiscipliny.Columns["id_zavodu"].DefaultValue = SelectedZavod;
                            grdDiscipliny.AutoGenerateColumns = false;
                            grdDiscipliny.DataSource = dataDiscipliny;
                            grdDiscipliny.Enabled = true;
                        }
                        else
                        {

                        }
                    }
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //kdyz je nacteny form, nactu data do comboboxu
            this.cis_statusyTableAdapter.Fill(this.p5time_svazvodaku_czStatusy.cis_statusy);
            this.cis_kategoriiTableAdapter.Fill(this.p5time_svazvodaku_czDataSet3.cis_kategorii);
            if (Common.AutoStart) toolStripButton1_Click(sender, new EventArgs());
        }


        // obsluha cudliku na toolbaru
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (conn != null)
            {
                conn.Close();
                statusDB.Text = "odpojeno";
                tabControl1.Enabled = false;
                toolStripButton1.Visible = true;
                toolStripButton2.Visible = false;
            }
            /*
            Common.ConnectionSettings con = Common.GetServerSettings();

            string connStr = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false",
                con.Server, con.UserId, con.Password, con.Database);*/
            string connStr = ConfigurationManager.ConnectionStrings["P5Time.Properties.Settings.conn"].ConnectionString;
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                statusDB.Text = "pøipojeno";
                tabControl1.Enabled = true;
                toolStripButton1.Visible = false;
                toolStripButton2.Visible = true;
                // TODO: This line of code loads data into the 'p5time_svazvodaku_czDataSet2.cis_disciplin' table. You can move, or remove it, as needed.
                this.cis_disciplinTableAdapter.Fill(this.p5time_svazvodaku_czDataSet2.cis_disciplin);
                // TODO: This line of code loads data into the 'p5time_svazvodaku_czDataSet1.vkluby' table. You can move, or remove it, as needed.
                this.vklubyTableAdapter.Fill(this.p5time_svazvodaku_czDataSet1.vkluby);
                // TODO: This line of code loads data into the 'p5time_svazvodaku_czDataSet.vosoby' table. You can move, or remove it, as needed.
                this.vosobyTableAdapter.Fill(this.p5time_svazvodaku_czDataSet.vosoby);

                GetPohary();

                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error connecting to the server: " + ex.Message);
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            conn.Close();
            statusDB.Text = "odpojeno";
            toolStripButton1.Visible = true;
            toolStripButton2.Visible = false;
            tabControl1.Enabled = false;
        }
        private void konecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void nastaveníToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        /// <summary>
        /// Pri prepnuti tabu to nacte prislusny data z DB a refreshuje to datatable
        /// </summary>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (tabControl1.SelectedTab == tWelcome)
            {

            }
            else if (tabControl1.SelectedTab == tZavody)
            { //zavody
                    GetZavody();
            }
            else if (tabControl1.SelectedTab == tPosadky)
            { //posadky
                    AutoCompleteStringCollection ac = new AutoCompleteStringCollection();
                    foreach (DataRowView dr in vosobyTableAdapter.GetData().DefaultView)
                	{
                        ac.Add(string.Format("{0} |{1}", dr["jmeno"], dr["id"]));
                    }
                    txtNewZavodnik.AutoCompleteCustomSource = ac;

                    RefreshExistingPosadky();

                    
                    lstDisciplinyPosadky.ValueMember = "id_discipliny";
                    lstDisciplinyPosadky.DisplayMember = "nazev";
                    lstDisciplinyPosadky.DataSource = dataDiscipliny;
                    for (int i = 0; i < lstDisciplinyPosadky.Items.Count; i++)
                    {
                        lstDisciplinyPosadky.SetSelected(i, true);               
                    }
                    RefreshZavodnici();
            }
            else if (tabControl1.SelectedTab == tRozlosovani)
            {
                    RefreshRozlosovani();
            }
            else if (tabControl1.SelectedTab == tStartovka)
            { //startovka
                    cmbStartovkaDiscipliny.ValueMember = "id_discipliny";
                    cmbStartovkaDiscipliny.DisplayMember = "nazev";
                    cmbStartovkaDiscipliny.DataSource = dataDiscipliny;
                    RefreshStartovka();
            }
            else if (tabControl1.SelectedTab == tVysledky)
            { //zadávání výsledkù
                    cmbVysledkyDiscipliny.ValueMember = "id_discipliny";
                    cmbVysledkyDiscipliny.DisplayMember = "nazev";
                    cmbVysledkyDiscipliny.DataSource = dataDiscipliny;
                    RefreshVysledky();
                    radioButton1_CheckedChanged(null, new EventArgs());
                    rbCilovy_CheckedChanged(null, new EventArgs());
            }
            else if (tabControl1.SelectedTab == tVysledkovka)
            {//zadávání výsledkù
                    RefreshVysledkovka();
            }
            else if (tabControl1.SelectedTab == tExport)
            {

            }
            else if (tabControl1.SelectedTab == tCiselniky)
            {
                    GetTables();
            }
            Common.LastTab = tabControl1.SelectedIndex;
        }


        #region Refreshovaci funkce na DataTably - vykonavani SQL dotazu
            private void RefreshStartovka()
            {
                //nacti existujici posadky
                MySqlCommand cmd = new MySqlCommand(
    @"SELECT GROUP_CONCAT(O.jmeno ORDER BY Z.id_zavodnik_disciplina SEPARATOR '\r\n') AS clenove, 
    GROUP_CONCAT(CAST(O.rocnik AS char(4)) ORDER BY Z.id_zavodnik_disciplina SEPARATOR '\r\n') AS rocniky, 
    D.id_posadky_discipliny AS id, P.nazev, VK.cisloklubu AS cisloklubu, CONCAT(P.nazev, '\r\n', VK.nazev) AS nazevfull, P.startovni_cislo, timefromint(V.start1) AS start1, timefromint(V.start2) AS start2, P.id_kat
    FROM posadky_zavodu AS P 
    LEFT JOIN posadky_discipliny AS D ON D.id_posadky_zavodu = P.id_posadky_zavodu
    LEFT JOIN zavodnici_discipliny AS Z ON Z.id_posadky_discipliny = D.id_posadky_discipliny
    LEFT JOIN vosoby2 AS O ON O.id = Z.id_zavodnika
    LEFT JOIN vkluby AS VK ON VK.id = P.id_klubu
    LEFT JOIN prubezne_vysledky AS V ON V.id_posadky_discipliny = D.id_posadky_discipliny 
    WHERE P.id_zavodu = ?zavod AND D.id_discipliny = ?disc GROUP BY D.id_posadky_discipliny ORDER BY id_kat, P.startovni_cislo", conn);
                cmd.Parameters.AddWithValue("zavod", AZ.Zavod);
                cmd.Parameters.AddWithValue("disc", cmbStartovkaDiscipliny.SelectedValue);
                dataStartovka = new DataTable();
                daStartovka = new MySqlDataAdapter(cmd);

                // Create the UpdateCommand.
                cmd = new MySqlCommand("ins_start_time", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("?in_id_posadky_discipliny", MySqlDbType.Int32, 11, "id");
                cmd.Parameters.Add("?in_start1", MySqlDbType.VarChar, 20, "start1");
                cmd.Parameters.Add("?in_start2", MySqlDbType.VarChar, 20, "start2");



                daStartovka.UpdateCommand = cmd;

                daStartovka.Fill(dataStartovka);
                grdStartovka.AutoGenerateColumns = false;
                grdStartovka.DataSource = dataStartovka;
                grdStartovka.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                grdStartovka.AutoResizeRows();

            }

            private void RefreshVysledky()
            {
                if (conn != null && cmbKategorieVysledky.SelectedValue != null)
                {
                    //nacti existujici posadky
                    MySqlCommand cmd = new MySqlCommand(
        @"SELECT GROUP_CONCAT(O.jmeno ORDER BY Z.id_zavodnik_disciplina SEPARATOR '\r\n'), D.id_posadky_discipliny AS id,
    P.nazev, P.startovni_cislo, timefromint(V.start1) AS start1, timefromint(V.start2) AS start2, 
    timefromint(V.fin1) AS fin1, timefromint(V.fin2) AS fin2, 
    floor(V.pen1 / 100) AS penalty1, floor(V.pen2 / 100) AS penalty2, 
    timefromint(V.time1) AS time1, timefromint(V.time2) AS time2, 
    timefromint(V.best_time) AS best_time, 
    status1, status2, status, 
    P.id_kat FROM prubezne_vysledky AS V 
    LEFT JOIN posadky_discipliny AS D ON V.id_posadky_discipliny = D.id_posadky_discipliny 
    LEFT JOIN posadky_zavodu AS P  ON D.id_posadky_zavodu = P.id_posadky_zavodu
    LEFT JOIN zavodnici_discipliny AS Z  ON Z.id_posadky_discipliny = D.id_posadky_discipliny
    LEFT JOIN vosoby2 AS O ON O.id = Z.id_zavodnika
    WHERE (?vse = 1 OR P.id_kat = ?kat) AND P.id_zavodu = ?zavod AND D.id_discipliny = ?disc GROUP BY D.id_posadky_discipliny  ORDER BY id_kat, P.startovni_cislo", conn);
                    cmd.Parameters.AddWithValue("zavod", AZ.Zavod);
                    cmd.Parameters.AddWithValue("kat", cmbKategorieVysledky.SelectedValue);
                    cmd.Parameters.AddWithValue("disc", cmbVysledkyDiscipliny.SelectedValue);
                    cmd.Parameters.AddWithValue("vse", checkBox2.Checked ? 1 : 0 );
                    dataVysledky = new DataTable();
                    daVysledky = new MySqlDataAdapter(cmd);

                    // Create the UpdateCommand.
                    cmd = new MySqlCommand("ins_end_time", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("?in_id_posadky_discipliny", MySqlDbType.Int32, 11, "id");
                    cmd.Parameters.Add("?in_fin1", MySqlDbType.VarChar, 20, "fin1");
                    cmd.Parameters.Add("?in_time1", MySqlDbType.VarChar, 20, "time1");
                    cmd.Parameters.Add("?in_pen1", MySqlDbType.Int32, 11, "penalty1");
                    cmd.Parameters.Add("?in_status1", MySqlDbType.Int32, 11, "status1");
                    cmd.Parameters.Add("?in_fin2", MySqlDbType.VarChar, 20, "fin2");
                    cmd.Parameters.Add("?in_time2", MySqlDbType.VarChar, 20, "time2");
                    cmd.Parameters.Add("?in_pen2", MySqlDbType.Int32, 11, "penalty2");
                    cmd.Parameters.Add("?in_status2", MySqlDbType.Int32, 11, "status2");

                    foreach (MySqlParameter par in cmd.Parameters)
                    {
                        par.IsNullable = true;
                        //par.SourceColumnNullMapping = true;
                    }

                    daVysledky.UpdateCommand = cmd;

                    daVysledky.Fill(dataVysledky);
                    grdVysledky.AutoGenerateColumns = false;
                    grdVysledky.DataSource = dataVysledky;
                    grdVysledky.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                    grdVysledky.AutoResizeRows();
                }
            }


            private void RefreshVysledkovka()
            {
                if (conn != null)
                {
                    //nacti existujici posadky
                    MySqlCommand cmd = new MySqlCommand("sp_vysledky_zavodu", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("in_id_zavodu", AZ.Zavod);
                    cmd.Parameters.AddWithValue("in_kat", cmbKatVysledkovka.SelectedValue);
                    cmd.ExecuteNonQuery();

                    //cmd = new MySqlCommand("select * from temp", conn);
                    dataVysledkovka = new DataTable();
                    daVysledkovka = new MySqlDataAdapter(cmd);

                    daVysledkovka.Fill(dataVysledkovka);
                    dataVysledkovka.Columns.Remove("id_posadky_zavodu");
                    grdVysledkovka.DataSource = dataVysledkovka;
                    grdVysledkovka.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                    grdVysledkovka.AutoResizeRows();

                    cmd.CommandText = "SELECT MIN(schvaleno) FROM posadky_zavodu AS P LEFT JOIN posadky_discipliny AS D ON D.id_posadky_zavodu = P.id_posadky_zavodu LEFT JOIN uzavrene_vysledky AS V ON V.id_posadky_discipliny = D.id_posadky_discipliny WHERE P.id_zavodu = ?in_id_zavodu AND P.id_kat = ?in_kat GROUP BY P.id_zavodu";
                    cmd.CommandType = CommandType.Text;
                    object o = cmd.ExecuteScalar();
                    if (o != null && !string.IsNullOrEmpty(o.ToString()) && int.Parse(o.ToString()) > 0)
                    {
                        lblUzavreni.Text = "Výsledky jsou schválené!";
                        btnUzavrit.Visible = false;
                    }
                    else
                    {
                        lblUzavreni.Text = "Výsledky nejsou schválené!";
                        btnUzavrit.Visible = true;
                    }
                }

            }

            private void RefreshExistingPosadky()
            {
                if (conn != null)
                {
                    //nacti existujici posadky
                    MySqlCommand cmd = new MySqlCommand("SELECT P.id_posadky_zavodu, P.nazev, count(distinct D.id_discipliny) AS disciplin FROM posadky_zavodu AS P LEFT JOIN posadky_discipliny AS D ON D.id_posadky_zavodu = P.id_posadky_zavodu WHERE P.id_zavodu = ?zavod and P.id_kat = ?kat and P.id_klubu = ?klub GROUP BY P.id_posadky_zavodu", conn);
                    cmd.Parameters.AddWithValue("zavod", AZ.Zavod);
                    cmd.Parameters.AddWithValue("kat", cmbKategorie.SelectedValue);
                    cmd.Parameters.AddWithValue("klub", lstKluby.SelectedValue);
                    dataPosadky = new DataTable();
                    daPosadky = new MySqlDataAdapter(cmd);
                    cb = new MySqlCommandBuilder(daPosadky);
                    daPosadky.Fill(dataPosadky);
                    lstPosadky.DisplayMember = "nazev";
                    lstPosadky.ValueMember = "id_posadky_zavodu";
                    lstPosadky.DataSource = dataPosadky;
                }
            }


            private void RefreshPoharovePosadky()
            {
                if (conn != null)
                {
                    //nacti existujici posadky
                    MySqlCommand cmd = new MySqlCommand("SELECT id_poharove_posadky AS id, nazev FROM poharove_posadky WHERE id_poharu = ?pohar AND id_kat = ?kat and id_klubu = ?klub", conn);
                    cmd.Parameters.AddWithValue("pohar", AZ.Sezona);
                    cmd.Parameters.AddWithValue("kat", cmbKategorie.SelectedValue);
                    cmd.Parameters.AddWithValue("klub", lstKluby.SelectedValue);
                    dataPosadkyPohar = new DataTable();
                    daPosadkyPohar = new MySqlDataAdapter(cmd);
                    cb = new MySqlCommandBuilder(daPosadkyPohar);
                    daPosadkyPohar.Fill(dataPosadkyPohar);
                    lstPoharovePosadky.DisplayMember = "nazev";
                    lstPoharovePosadky.ValueMember = "id";
                    lstPoharovePosadky.DataSource = dataPosadkyPohar;
                }
            }


            private void RefreshRozlosovani()
            {
                //nacti existujici posadky
                MySqlCommand cmd = new MySqlCommand("select * from posadky_zavodu WHERE id_zavodu=?zavod order by id_kat", conn);
                cmd.Parameters.AddWithValue("zavod", AZ.Zavod);
                dataRozlosovani = new DataTable();
                daRozlosovani = new MySqlDataAdapter(cmd);
                daRozlosovani.FillLoadOption = LoadOption.PreserveChanges;
                cb = new MySqlCommandBuilder(daRozlosovani);
                daRozlosovani.Fill(dataRozlosovani);
                grdRozlosovani.AutoGenerateColumns = false;
                grdRozlosovani.DataSource = dataRozlosovani;
                grdRozlosovani.AutoResizeColumns();
                
            }


            private void RefreshZavodnici()
            {
                //nacti existujici posadky
                dataZavodnici = new DataTable();
                MySqlCommand cmd = null;
                if (chckNova.Checked)
                {
                    txtNazev.Text = "";
                    txtNazev.ReadOnly = false;
                    dataZavodnici.Columns.Add("jmeno");
                    dataZavodnici.Columns.Add("id");
                    dataZavodnici.Columns.Add("barva");
                }
                else
                {
                    bool nic = true;
                    if (chckPoharova.Checked && lstPoharovePosadky.SelectedIndex > -1)
                    {
                        //cmd = new MySqlCommand("SELECT Z.jmeno, Z.id, 'green' as barva FROM poharove_posadky AS P LEFT JOIN vosoby AS Z ON (Z.id = P.zav1 OR Z.id = P.zav2 OR Z.id = P.zav3 OR Z.id = P.zav4 OR Z.id = P.zav5) WHERE P.id_poharove_posadky = ?posadka", conn);
                        cmd = new MySqlCommand("SELECT Z.jmeno, Z.id, 'green' as barva FROM zavodnici_poharu AS D LEFT JOIN poharove_posadky AS P ON D.id_poharove_posadky = P.id_poharove_posadky            LEFT JOIN vosoby AS Z ON Z.id = D.id_zavodnika WHERE P.id_poharove_posadky = ?posadka GROUP BY D.id_zavodnika", conn);
                        cmd.Parameters.AddWithValue("posadka", lstPoharovePosadky.SelectedValue);
                        txtNazev.Text = dataPosadkyPohar.DefaultView[lstPoharovePosadky.SelectedIndex]["nazev"].ToString();
                        txtNazev.ReadOnly = true;
                    }
                    else if (chckExistujici.Checked && lstPosadky.SelectedIndex > -1)
                    {
                        cmd = new MySqlCommand("SELECT Z.jmeno, Z.id, 'black' as barva FROM zavodnici_discipliny AS D LEFT JOIN posadky_discipliny AS P  ON D.id_posadky_discipliny = P.id_posadky_discipliny LEFT JOIN vosoby AS Z ON Z.id = D.id_zavodnika WHERE P.id_posadky_zavodu = ?posadka GROUP BY D.id_zavodnika", conn);
                        cmd.Parameters.AddWithValue("posadka", lstPosadky.SelectedValue);
                        txtNazev.Text = dataPosadky.DefaultView[lstPosadky.SelectedIndex]["nazev"].ToString();
                        txtNazev.ReadOnly = true;
                    }
                    else
                    {
                        nic = false;
                    }
                    if (nic)
                    {
                        daZavodnici = new MySqlDataAdapter(cmd);
                        cb = new MySqlCommandBuilder(daZavodnici);
                        daZavodnici.Fill(dataZavodnici);
                    }
                }
                lstZavodnici.DisplayMember = "jmeno";
                lstZavodnici.ValueMember = "id";
                lstZavodnici.DataSource = dataZavodnici;
            }

        #endregion

    //nasleduji regiony pro jednotlive zalozky

    #region vyber sezony

        private void btnCreatePohar_Click(object sender, EventArgs e)
        {
            frmNewPohar f = new frmNewPohar();
            if (f.ShowDialog() == DialogResult.OK)
            {
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO cis_poharu (nazev, rok) VALUES (@nazev, @rok);";
                cmd.Parameters.AddWithValue("nazev", f.txtNazev.Text);
                cmd.Parameters.AddWithValue("rok", f.txtRocnik.Text);
                cmd.ExecuteNonQuery();
                // cmd.LastInsertedId
            }

        }
        private void cmbSezona_Validated(object sender, EventArgs e)
        {
            Common.SetPohar(int.Parse(cmbSezona.SelectedValue.ToString()));
        }
        #endregion


    #region zadavani zavodu
        //kontrola spravne vyplnenych udaju o zavodu
        private void grdZavody_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                da.Update(data2);
            }
            catch
            {
                MessageBox.Show("Nìkteré pole máte asi vyplnìné špatnì!", "Chyba ukládání záznamu do DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void grdDiscipliny_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (tabControl1.SelectedTab == tZavody)
            {
                daDisc.Update(dataDiscipliny);
            }
        }

   #endregion

    #region zadavani posadek
        //barevne odlisovani v listboxu posadek
        private void lstPosadky_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background of the ListBox control for each item.
            // Create a new Brush and initialize to a Black colored brush
            // by default.
            //
            e.DrawBackground();
            Brush myBrush = Brushes.Black;
            //
            // Determine the color of the brush to draw each item based on 
            // the index of the item to draw.
            //
            if (e.Index >= 0)
            {
                if (int.Parse(dataPosadky.DefaultView[e.Index]["disciplin"].ToString()) < 3)
                {   //TODO: DODELAT pocet disciplin!!
                    myBrush = Brushes.Red;
                }

                //
                // Draw the current item text based on the current 
                // Font and the custom brush settings.
                //
                e.Graphics.DrawString(dataPosadky.DefaultView[e.Index]["nazev"].ToString(),
                    e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            }
            //
            // If the ListBox has focus, draw a focus rectangle 
            // around the selected item.
            //
            e.DrawFocusRectangle();
        }


        //reakce na stisk enteru v zadavani zavodnika - prida ho to do listu
        private void txtNewZavodnik_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string[] casti = txtNewZavodnik.Text.Split(new char[] { '|' });
                int id;
                if (casti.Length == 2 && int.TryParse(casti[1], out id))
                {
                    int[] ind = new int[lstZavodnici.SelectedIndices.Count];
                    lstZavodnici.SelectedIndices.CopyTo(ind, 0);
                    dataZavodnici.Rows.Add(casti[0], id, "black");
                    lstZavodnici.SetSelected(lstZavodnici.Items.Count - 1, true);
                    foreach (int i in ind)
                    {
                        lstZavodnici.SetSelected(i, true);
                    }
                    txtNewZavodnik.Text = "";
                }
                else
                {
                    frmNewOsoba f = new frmNewOsoba(txtNewZavodnik.Text, int.Parse(lstKluby.SelectedValue.ToString()));
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        //prida osobu ddo db
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO cis_osob (jmeno, prijmeni, id_klubu, rocnik, rozhodci) VALUES (?j, ?p, ?k, ?roc, ?roz);", conn);
                        cmd.Parameters.AddWithValue("j", f.Jmeno);
                        cmd.Parameters.AddWithValue("p", f.Prijmeni);
                        cmd.Parameters.AddWithValue("k", f.Klub);
                        cmd.Parameters.AddWithValue("roc", f.Rocnik);
                        cmd.Parameters.AddWithValue("roz", f.Rozhodci ? 1 : 0);
                        cmd.ExecuteNonQuery();
                        int[] ind = new int[lstZavodnici.SelectedIndices.Count];
                        lstZavodnici.SelectedIndices.CopyTo(ind, 0);
                        dataZavodnici.Rows.Add(f.Prijmeni + " " + f.Jmeno, cmd.LastInsertedId, "black");
                        lstZavodnici.SetSelected(lstZavodnici.Items.Count - 1, true);
                        foreach (int i in ind)
                        {
                            lstZavodnici.SetSelected(i, true);
                        }
                        txtNewZavodnik.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Nepovedlo se pøidat osobu - nelze zparsovat ID a nevytvoøili jste novou!", "Chyba pøidání závodníka", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        //scitani poctu vybranych lidi do posadky
        private void lstZavodnici_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = lstZavodnici.SelectedItems.Count;
            lblVybranychLidi.Text = string.Format("Vybráno {0} závodníkù.", i);
            if (i < 4) lblVybranychLidi.ForeColor = Color.Red;
            else if (i > 5) lblVybranychLidi.ForeColor = Color.Red;
            else lblVybranychLidi.ForeColor = Color.Black;
        }
        
        private void tPosadky_Click(object sender, EventArgs e)
        {

        }


        //obsluha posadek a jejich radioboxu - zaskrtavani pri kliku na dany list
        private void lstPosadky_Click(object sender, EventArgs e)
        {
            chckExistujici.Checked = true;
        }

        private void lstPoharovePosadky_Click(object sender, EventArgs e)
        {
            chckPoharova.Checked = true;
        }

        private void chckNova_CheckedChanged(object sender, EventArgs e)
        {
            if (chckNova.Checked) //vyprazdni lidi
                RefreshZavodnici();
        }

        


       //vykresleni posadky v listboxu - zobrazuje je to barevne
        private void lstZavodnici_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background of the ListBox control for each item.
            // Create a new Brush and initialize to a Black colored brush
            // by default.
            //
            e.DrawBackground();
            Brush myBrush = Brushes.Black;
            //
            // Determine the color of the brush to draw each item based on 
            // the index of the item to draw.
            //
            if (e.Index >= 0)
            {
                if (dataZavodnici.DefaultView[e.Index]["barva"].ToString() == "green")
                {   //TODO: DODELAT pocet disciplin!!
                    myBrush = Brushes.Red;
                }

                //
                // Draw the current item text based on the current 
                // Font and the custom brush settings.
                //
                e.Graphics.DrawString(dataZavodnici.DefaultView[e.Index]["jmeno"].ToString(),
                    e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            }
            //
            // If the ListBox has focus, draw a focus rectangle 
            // around the selected item.
            //
            e.DrawFocusRectangle();
        }


        //pridani posadky do zavodu
        private void button1_Click(object sender, EventArgs e)
        {
            if ((lstZavodnici.SelectedItems.Count >= 4 && lstZavodnici.SelectedItems.Count <= 5) || chckOverrideCountZavodniku.Checked)
            {
                if (!string.IsNullOrEmpty(txtNazev.Text))
                {
                    MySqlCommand cmd = null;
                    
                    int i;
                    cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("in_id_zavodu", AZ.Zavod);
                    cmd.Parameters.AddWithValue("in_id_pohar", AZ.Sezona);
                    cmd.Parameters.AddWithValue("in_nazev", txtNazev.Text);
                    cmd.Parameters.AddWithValue("in_id_kat", cmbKategorie.SelectedValue);
                    cmd.Parameters.AddWithValue("in_id_klubu", lstKluby.SelectedValue);
                    cmd.Parameters.AddWithValue("in_id_discipliny", 0);
                    //pøidám závodníky
                    for (i = 0; i < 5; i++)
                    {
                        if (i < lstZavodnici.SelectedItems.Count)
                            cmd.Parameters.AddWithValue(string.Format("in_zav{0}", i + 1), dataZavodnici.DefaultView[lstZavodnici.SelectedIndices[i]]["id"]);
                        else
                            cmd.Parameters.AddWithValue(string.Format("in_zav{0}", i + 1), 0);
                    }

                    if (int.Parse(((Button)sender).Tag.ToString()) < 2)
                    {
                        //pøidávám do závodu
                        cmd.CommandText = "up_posadka_zavodu_ins";
                        cmd.CommandType = CommandType.StoredProcedure;

                        for (i = 0; i < lstDisciplinyPosadky.SelectedItems.Count; i++)
                        {
                            cmd.Parameters["in_id_discipliny"].Value = dataDiscipliny.DefaultView[lstDisciplinyPosadky.SelectedIndices[i]]["id_discipliny"];
                            cmd.ExecuteNonQuery();
                        }
                    }
                    if (int.Parse(((Button)sender).Tag.ToString()) > 0)
                    {
                        //pøidávám do poháru
                        cmd.CommandText = "up_posadka_poharu_ins";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();

                        RefreshPoharovePosadky();
                        MessageBox.Show("Pohárová posádka vytvoøena", "Hlášení", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                    RefreshExistingPosadky();
                    
                }
                else
                {
                    MessageBox.Show("Posádka musí mít název!", "To je proti pravidlùm!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Tolik èlenù nemùže posádka mít", "To je proti pravidlùm!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
   #endregion

    #region rozlosovani

        //vygenerovani startovnich cisel
        private void button2_Click(object sender, EventArgs e)
        {
            //losování
            int max = 0;
            string kat = cmbKatRozlosovani.SelectedValue.ToString();
            foreach (DataRow row in dataRozlosovani.Rows)
                if (row["id_kat"].ToString() == kat) max++;
            string[] strCisla = txtRozlosovaniCisla.Text.Split(new char[] { ',' });
            int[] cisla = new int[max];
            int last = 0;
            int i2 = 0;
            for (int i = 0; i < max; i++)
            {
                if (strCisla.Length > i2)
                {
                    while(!int.TryParse(strCisla[i2], out last))
                    {
                        i2++;
                        if (strCisla.Length == i2) break;
                    }                    
                    i2++;
                }
                else
                {
                    last++;
                }
                cisla[i] = last;
            }
            Randomize(cisla);
            i2 = -1;
            foreach (DataRow row in dataRozlosovani.Rows)
                if (row["id_kat"].ToString() == kat) row["startovni_cislo"] = cisla[++i2];
            //ok, rozlosovano
            button3_Click(sender, e);  //ulozim
            //last++;
            
            txtRozlosovaniCisla.Text = ((Math.Floor((decimal)(last / 10)) + 1) * 10 + 1).ToString();
            txtRozlosovaniCisla.Focus();

            if (cmbKatRozlosovani.SelectedIndex != cmbKatRozlosovani.Items.Count - 1)
            {
                cmbKatRozlosovani.SelectedIndex++;
            }
            
        }


        //rozhazeni listu
        static void Randomize(IList list)
        {
            Random rng = new Random();
            for (int i = list.Count - 1; i > 0; i--)
            {
                int swapIndex = rng.Next(i + 1);
                if (swapIndex != i)
                {
                    object tmp = list[swapIndex];
                    list[swapIndex] = list[i];
                    list[i] = tmp;
                }
            }
        }

        //ulozeni rucnich zmen v rozlosovani
        private void button3_Click(object sender, EventArgs e)
        {
            DataTable changes = dataRozlosovani.GetChanges();
            if (changes != null)
            {
                daRozlosovani.Update(changes);
                dataRozlosovani.AcceptChanges();
            }
        }
    #endregion

    #region startovka
        //ulozeni rucnich zmen ve startovce
        private void button4_Click(object sender, EventArgs e)
        {
            DataTable changes = dataStartovka.GetChanges();
            if (changes != null)
            {
                daStartovka.Update(changes);
                dataStartovka.AcceptChanges();
            }
        }


        //generuje startovku - ze zadaneho intervalu a startu prvni posadky
        private void button5_Click(object sender, EventArgs e)
        {
            int interval = 0;
            if (int.TryParse(txtTimeInterval.Text, out interval))
            {
                bool sudy = false;
                foreach (DataRow row in dataStartovka.Rows)
                {
                    if (row["id_kat"].ToString() == cmbKatStartTimes.SelectedValue.ToString())
                    {
                        //jo, je to ta kategorie kam doplòuju
                        string col = "";
                        if (rb1kolo.Checked)
                            col = "start1";
                        else if (rb2kolo.Checked) 
                            col = "start2";
                        else
                        {
                            MessageBox.Show("Chyba - není zadané, jaké kolo se má generovat!!!");
                            return;
                        }
                        row[col] = txtFromTimeStarts.Text;
                        if (!chckPoDvou.Checked || sudy)
                            txtFromTimeStarts.Text = PridejKCasu(txtFromTimeStarts.Text, interval);
                        sudy = !sudy;
                    }
                }
                if (chckPoDvou.Checked && sudy)
                    txtFromTimeStarts.Text = PridejKCasu(txtFromTimeStarts.Text, interval);
                try
                {
                    cmbKatStartTimes.SelectedIndex++;
                }
                catch {
                    if (rb1kolo.Checked)
                    {
                        rb2kolo.Checked = true;
                        cmbKatStartTimes.SelectedIndex = 0;
                    }
                }
                txtFromTimeStarts.Focus();
                button4_Click(sender, e);             
            }
            else
            {
                MessageBox.Show("Interval musí být zadaný! A musí to být èíslo!!");
            }
        }

        //fce na scitani casu - pouzite pri generovani startovky
        private string PridejKCasu(string kcemu, int vterin)
        {
            int s = int.Parse(kcemu.Substring(0,2)) * 360000 + 
                int.Parse(kcemu.Substring(3,2)) * 6000 + 
                int.Parse(kcemu.Substring(6,2)) * 100 + 
                int.Parse(kcemu.Substring(9,2)) + vterin * 100;
            string ret;
            ret = (s % 100).ToString().PadLeft(2,'0');
            s = s / 100;
            ret = (s % 60).ToString().PadLeft(2, '0') + "." + ret;
            s = s / 60;
            ret = (s % 60).ToString().PadLeft(2, '0') + ":" + ret;
            s = s / 60;
            ret = s.ToString().PadLeft(2, '0') + ":" + ret;

            return ret;
        }

        
        //skryvani sloupcu startovky
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            cStartovkaClenoce.Visible = checkBox1.Checked;
            nazevS.Visible = !checkBox1.Checked;
            posadkaFull.Visible = checkBox1.Checked;
            cRocnik.Visible = checkBox1.Checked;
            cCk.Visible = checkBox1.Checked;

            grdStartovka.AutoResizeRows();
        }
     #endregion

    #region obsluha tabulky zadavani vysledku aby byla user friendly a osetreni updatu po zmene radku
        //logika objevovani sloupecku pri zadavani vysledkovky
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                grdVysledky.Columns["maskedTextBoxColumn4"].Visible = true;
                grdVysledky.Columns["cCil1"].Visible = true;
                grdVysledky.Columns["cPenalty1"].Visible = true;
                grdVysledky.Columns["cTime1"].Visible = true;
                grdVysledky.Columns["cStatus1"].Visible = true;
                grdVysledky.Columns["maskedTextBoxColumn5"].Visible = true;
                grdVysledky.Columns["cCil2"].Visible = true;
                grdVysledky.Columns["cPenalty2"].Visible = true;
                grdVysledky.Columns["cTime2"].Visible = true;
                grdVysledky.Columns["cStatus2"].Visible = true;
            }
            else if (radioButton2.Checked)
            {
                grdVysledky.Columns["maskedTextBoxColumn4"].Visible = true;
                grdVysledky.Columns["cCil1"].Visible = true;
                grdVysledky.Columns["cPenalty1"].Visible = true;
                grdVysledky.Columns["cTime1"].Visible = true;
                grdVysledky.Columns["cStatus1"].Visible = true;
                grdVysledky.Columns["maskedTextBoxColumn5"].Visible = false;
                grdVysledky.Columns["cCil2"].Visible = false;
                grdVysledky.Columns["cPenalty2"].Visible = false;
                grdVysledky.Columns["cTime2"].Visible = false;
                grdVysledky.Columns["cStatus2"].Visible = false;
            }
            else if (radioButton3.Checked)
            {
                grdVysledky.Columns["maskedTextBoxColumn4"].Visible = false;
                grdVysledky.Columns["cCil1"].Visible = false;
                grdVysledky.Columns["cPenalty1"].Visible = false;
                grdVysledky.Columns["cTime1"].Visible = false;
                grdVysledky.Columns["cStatus1"].Visible = false;
                grdVysledky.Columns["maskedTextBoxColumn5"].Visible = true;
                grdVysledky.Columns["cCil2"].Visible = true;
                grdVysledky.Columns["cPenalty2"].Visible = true;
                grdVysledky.Columns["cTime2"].Visible = true;
                grdVysledky.Columns["cStatus2"].Visible = true;
            }
        }

        private void rbCilovy_CheckedChanged(object sender, EventArgs e)
        {
            DataGridViewCellStyle dg1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dg2 = new DataGridViewCellStyle();

            dg1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dg1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));

            dg2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dg2.SelectionBackColor = System.Drawing.Color.Yellow;
            dg2.SelectionForeColor = System.Drawing.Color.Black;

            //zmena z ciloveho na startovni
            if (rbCilovy.Checked)
            {
                grdVysledky.Columns["cCil1"].ReadOnly = false;
                grdVysledky.Columns["cCil1"].DefaultCellStyle = dg1;
                grdVysledky.Columns["cTime1"].ReadOnly = true;
                grdVysledky.Columns["cTime1"].DefaultCellStyle = null;

                grdVysledky.Columns["cCil2"].ReadOnly = false;
                grdVysledky.Columns["cCil2"].DefaultCellStyle = dg2;
                grdVysledky.Columns["cTime2"].ReadOnly = true;
                grdVysledky.Columns["cTime2"].DefaultCellStyle = null;
            }
            else if (rbZavodu.Checked)
            {
                grdVysledky.Columns["cCil1"].ReadOnly = true;
                grdVysledky.Columns["cCil1"].DefaultCellStyle = null;
                grdVysledky.Columns["cTime1"].ReadOnly = false;
                grdVysledky.Columns["cTime1"].DefaultCellStyle = dg1;

                grdVysledky.Columns["cCil2"].ReadOnly = true;
                grdVysledky.Columns["cCil2"].DefaultCellStyle = null;
                grdVysledky.Columns["cTime2"].ReadOnly = false;
                grdVysledky.Columns["cTime2"].DefaultCellStyle = dg2;
            }
        }

        //toto umoznuje aby pri stisku sipky dolu zustal v gridu vybrana stejna bunka i po refreshi dat z db
        private void grdVysledky_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (LastColVysledky >= 0 && grdVysledky.CurrentRow != null)
            {
                foreach (DataGridViewCell cel in grdVysledky.SelectedCells)
                    cel.Selected = false;
                grdVysledky[LastColVysledky, e.RowIndex].Selected = true;
                for (int i = 1; i < LastColVysledky; i++)
                    SendKeys.Send("{tab}");
                LastColVysledky = -1;
            }
        }

        //volani slozitejsiho updatu - dopocitani zbyleho casu a vysledneho casu pri zmene bunky
        private void grdVysledky_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataTable changes = dataVysledky.GetChanges();
            if (changes != null)
            {
                foreach (DataRow row in changes.Rows)
                {
                    if (row.RowState == DataRowState.Modified)
                    {
                        if (grdVysledky.Columns["cTime1"].ReadOnly && row["fin1"] != DBNull.Value) row["time1"] = "00:00:00.00";
                        if (grdVysledky.Columns["cTime2"].ReadOnly && row["fin2"] != DBNull.Value) row["time2"] = "00:00:00.00";
                        if (grdVysledky.Columns["cCil1"].ReadOnly && row["time1"] != DBNull.Value) row["fin1"] = "00:00:00.00";
                        if (grdVysledky.Columns["cCil2"].ReadOnly && row["time2"] != DBNull.Value) row["fin2"] = "00:00:00.00";
                    }
                }
                daVysledky.Update(changes);
                dataVysledky.AcceptChanges();

                MySqlCommand cmd = new MySqlCommand("up_tr_prepocitej_vysledky", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("in_id_zavodu", AZ.Zavod);
                cmd.Parameters.AddWithValue("in_id_discipliny", cmbVysledkyDiscipliny.SelectedValue);
                cmd.Parameters.AddWithValue("in_id_kat", cmbKategorieVysledky.SelectedValue);
                cmd.ExecuteNonQuery();
                if (e != null) //jestli to nevolam ja, ale vola se to samo
                {
                    LastColVysledky = e.ColumnIndex;
                    if (radioButton3.Checked) LastColVysledky -= 5;
                }
                dataVysledky.Clear();
                daVysledky.Fill(dataVysledky);
            }
        }


        private void grdVysledky_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //zatim nepouzito
        }

    #endregion


        //uzavreni vysledku a presun na tab ze zobrazenou vysledkovkou
        private void button9_Click(object sender, EventArgs e)
        {

            MySqlCommand cmd = new MySqlCommand("up_uzavreni_vysledku", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("in_id_zavodu", AZ.Zavod);
            cmd.Parameters.AddWithValue("in_id_discipliny", cmbVysledkyDiscipliny.SelectedValue);
            cmd.Parameters.AddWithValue("in_id_kat", cmbKategorieVysledky.SelectedValue);
            cmd.ExecuteNonQuery();
            tabControl1.SelectedIndex++;
        }

        //uzavre vysledky - pak uz nejdou menit
        private void btnUzavrit_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE posadky_zavodu AS P LEFT JOIN posadky_discipliny AS D ON D.id_posadky_zavodu = P.id_posadky_zavodu LEFT JOIN uzavrene_vysledky AS V ON V.id_posadky_discipliny = D.id_posadky_discipliny SET schvaleno = 1 WHERE P.id_zavodu = ?in_id_zavodu AND P.id_kat = ?in_kat", conn);
            cmd.Parameters.AddWithValue("in_id_zavodu", AZ.Zavod);
            cmd.Parameters.AddWithValue("in_kat", cmbKatVysledkovka.SelectedValue);
            cmd.ExecuteNonQuery();
            RefreshVysledkovka();
        }

    #region ciselniky
        private void tables_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            dataCiselniky = new DataTable();

            daCiselniky = new MySqlDataAdapter("SELECT * FROM " + tables.SelectedItem.ToString(), conn);

            cb = new MySqlCommandBuilder(daCiselniky);

            daCiselniky.Fill(dataCiselniky);

            dataGrid.DataSource = dataCiselniky;
        }



        private void updateBtn_Click(object sender, System.EventArgs e)
        {
            DataTable changes = dataCiselniky.GetChanges();
            daCiselniky.Update(changes);
            dataCiselniky.AcceptChanges();
        }

        #endregion


    #region refreshe tabulek pri zmene radku

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            RefreshVysledky();
        }

        private void cmbSezona_SelectedIndexChanged(object sender, EventArgs e)
        {
            AZ.Refresh();
        }
        private void grdZavody_SelectionChanged(object sender, EventArgs e)
        {
            AZ.Refresh();
            GetDiscipliny();
        }


        private void lstKluby_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            RefreshExistingPosadky();
            RefreshPoharovePosadky();
        }

        private void cmbKategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshExistingPosadky();
            RefreshPoharovePosadky();
        }
        private void lstPosadky_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshZavodnici();
        }

        private void lstPoharovePosadky_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshZavodnici();
        }
        private void cmbKatVysledkovka_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tVysledkovka)
            {
                RefreshVysledkovka();
            }
        }

        private void cmbStartovkaDiscipliny_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tStartovka)
            {
                RefreshStartovka();
            }
        }
        private void cmbVysledkyDiscipliny_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tVysledky)
            {
                RefreshVysledky();
                if (cmbVysledkyDiscipliny.SelectedItem != null)
                {
                    btnBranky.Enabled = ((int)((DataRowView)cmbVysledkyDiscipliny.SelectedItem)["id_cdis"] == 2);
                }
            }
        }
        #endregion



        //vylepsuje chovani textboxu pri focusu
        private void txtTimeInterval_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke(new SetMaskedTextBoxSelectAllDelegate(SetMaskedTextBoxSelectAll), new object[] { (MaskedTextBox)sender });
        }

        //vylepsuje chovani MaskedBoxu pri focusu
        private delegate void SetMaskedTextBoxSelectAllDelegate(MaskedTextBox txtbox);

        private void SetMaskedTextBoxSelectAll(MaskedTextBox txtbox)
        {
            txtTimeInterval.SelectAll();
        }


        #region tisky tabulek
        //tisk vysledku
        private void button10_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(grdVysledky, string.Format("Prùbìžné výsledky - {1} - {2}", AZ.strZavod, cmbVysledkyDiscipliny.Text, cmbKategorieVysledky.Text));
        }

        //tisk vysledku  celkove
        private void button7_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(grdVysledkovka, string.Format("Výsledky závodu {0} - kategorie {1}", AZ.strZavod, cmbKatVysledkovka.Text), true);
        }

        //tisk startovky
        private void button6_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(grdStartovka, string.Format("{0} - startovní listina - {1}", AZ.strZavod, cmbStartovkaDiscipliny.Text), false);
        }
        #endregion


        #region exportovaci funkce do xlsx

        //export vysledku do excelu
            private void button11_Click(object sender, EventArgs e)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    ExportExcel.Excel(dataVysledkovka, cmbKatVysledkovka.Text, saveFileDialog1.FileName);
            }


            //export vysledku na diplomy
            private void button12_Click(object sender, EventArgs e)
            {
                //nacti existujici posadky
                MySqlCommand cmd = new MySqlCommand("sp_vysledky_diplomy", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("in_id_zavodu", AZ.Zavod);
                cmd.ExecuteNonQuery();

                DataTable NaDiplomy = new DataTable();
                MySqlDataAdapter daDiplomy = new MySqlDataAdapter(cmd);

                daDiplomy.Fill(NaDiplomy);
                
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    ExportExcel.Diplomy(NaDiplomy, saveFileDialog1.FileName);
            }

            //export startovni listiny do excelu
            private void button13_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                ExportExcel.Diplomy(dataStartovka, saveFileDialog1.FileName);
        }
        #endregion



        //
        //doplnoove funkce
        //


        //importovani externiho souboru
        private void button14_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo f = new FileInfo(openFileDialog1.FileName);
                StreamReader r = f.OpenText();
                List<Casomira> lc = new List<Casomira>();
                while (!r.EndOfStream)
                {
                    string radka = r.ReadLine();
                    Casomira c = new Casomira(radka);
                    lc.Insert(c.C, c);
                }
                //mam to v lc
                bool penalty = (MessageBox.Show("Jsou to penalty?", "Dotaz", MessageBoxButtons.YesNo) == DialogResult.Yes);
                bool startcil = false;
                if (!penalty)
                    startcil = (MessageBox.Show("Doplnit z èasù start i cíl?", "Dotaz", MessageBoxButtons.YesNo) == DialogResult.Yes);
                string postfix = "";
                if (radioButton2.Checked) //prvni kolo
                {
                    postfix = "1";
                }
                else if (radioButton3.Checked) //druhe kolo
                {
                    postfix = "2";
                }
                else //obe kola
                {
                    throw new Exception();
                }
                //a jdu to doplnit
                foreach (DataRow row in dataVysledky.Rows)
                {
                    Casomira c = lc[int.Parse(row["startovni_cislo"].ToString())];
                    if (c != null)
                    {
                       
                        if (penalty)
                        {
                            row["penalty" + postfix] = int.Parse(c.Cas2);
                        }
                        else //jsou to casy
                        {
                            if (startcil)
                            {
                                row["start" + postfix] = c.Cas1;
                                row["fin" + postfix] = c.Cas2;
                            }
                            else
                            {
                                row["time" + postfix] = c.Cas2;
                            }
                        }


                    }
                }

                //grdVysledky_RowValidated(sender, null);
                daVysledky.Update(dataVysledky);
               
                
            }
        }

        //export provedenych zmeny - pomoci volani externi aplikace mysqldump
        private void button16_Click(object sender, EventArgs e)
        {

            // Application path and command line arguments
            string[] tables = new string[] 
            { 
                "zavodnici_poharu -w \"id_poharove_posadky in (SELECT id_poharove_posadky FROM poharove_posadky WHERE dirty = 1)\"",
                "poharove_posadky -w \"dirty = 1\"",
                "cis_klubu -w \"dirty = 1\"",
                "cis_osob -w \"dirty = 1\"",
                "cis_poharu -w \"dirty = 1\"",

                "zavod -w \"dirty = 1\"",
                "discipliny_zavodu -w \"id_zavodu in (SELECT id_zavodu FROM zavod WHERE dirty = 1)\"",
                "posadky_zavodu -w \"id_zavodu in (SELECT id_zavodu FROM zavod WHERE dirty = 1)\"",
                "posadky_discipliny -w \"id_posadky_zavodu in (SELECT id_posadky_zavodu FROM posadky_zavodu AS P LEFT JOIN zavod AS Z ON Z.id_zavodu = P.id_zavodu WHERE Z.dirty = 1)\"",
                "uzavrene_vysledky -w \"id_posadky_discipliny in (SELECT id_posadky_discipliny FROM posadky_discipliny AS D LEFT JOIN posadky_zavodu AS P ON P.id_posadky_zavodu = D.id_posadky_zavodu LEFT JOIN zavod AS Z ON Z.id_zavodu = P.id_zavodu WHERE Z.dirty = 1)\"",
                "zavodnici_discipliny -w \"id_posadky_discipliny in (SELECT id_posadky_discipliny FROM posadky_discipliny AS D LEFT JOIN posadky_zavodu AS P ON P.id_posadky_zavodu = D.id_posadky_zavodu LEFT JOIN zavod AS Z ON Z.id_zavodu = P.id_zavodu WHERE Z.dirty = 1)\""
            };
            string ApplicationPath = Common.MysqldumpPath;
            string[] parseCS = conn.ConnectionString.Split(new char[] { ';' });
            string user = "";
            string pass = "";
            foreach (string s in parseCS)
            {
                if      (s.ToLower().StartsWith("user id=")) user = s.Substring(8).Trim(new char[] {'"'});
                else if (s.ToLower().StartsWith("password=")) pass = s.Substring(9).Trim(new char[] { '"' });
            }
            string ApplicationArguments = conn.Database + " --u " + user + " -p\"" + pass + "\" --table {0} -t -O lock-tables=FALSE -O add-locks=FALSE -O disable-keys=FALSE --compact --replace --skip-triggers";
            //ApplicationArguments = conn.Database + " --u " + user + " -p\"" + pass + "\" --table zavodnici_poharu --compact -t -O lock-tables=FALSE -O add-locks=FALSE -O disable-keys=FALSE";

            string Result = "";
            // Create a new process object
            Process ProcessObj = new Process();

            // StartInfo contains the startup information of
            // the new process
            
            //ProcessObj.StartInfo.Arguments = ApplicationArguments;
            ProcessObj.StartInfo.FileName = ApplicationPath;

            // These two optional flags ensure that no DOS window
            // appears
            ProcessObj.StartInfo.UseShellExecute = false;
            ProcessObj.StartInfo.CreateNoWindow = true;

            // If this option is set the DOS window appears again :-/
            // ProcessObj.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            // This ensures that you get the output from the DOS application
            ProcessObj.StartInfo.RedirectStandardOutput = true;

            // Start the process
            foreach (string t in tables)
            {
                ProcessObj.StartInfo.Arguments = string.Format(ApplicationArguments, t);
                ProcessObj.Start();
                while (!ProcessObj.StandardOutput.EndOfStream)
                {
                    Result += ProcessObj.StandardOutput.ReadLine() + "\n";
                }
                // Wait that the process exits
                ProcessObj.WaitForExit();
            }
            

            // Now read the output of the DOS application
            //string Result = ProcessObj.StandardOutput.ReadToEnd();
            txtExport.Text = Encoding.UTF8.GetString(Encoding.Default.GetBytes(Result));

            MySqlCommand cmd = new MySqlCommand("sp_set_clean", conn);
            cmd.CommandType = CommandType.StoredProcedure; 
            cmd.ExecuteNonQuery();
            
        }


        //exportovani dat na web - komunikace pres WebRequest
        private void button17_Click(object sender, EventArgs e)
        {
            string strName = txtUser.Text;
            string strPass = txtPassword.Text;

            ASCIIEncoding encoding = new ASCIIEncoding();
            string postData = "userid=" + strName;
            postData += ("&pass=" + strPass);
            postData += ("&sql=" + System.Web.HttpUtility.UrlEncode(txtExport.Text));
            byte[] data = encoding.GetBytes(postData);

            // Prepare web request...
            HttpWebRequest myRequest =
              (HttpWebRequest)WebRequest.Create("http://www.svazvodaku.cz/import.php");
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            WebResponse resp = myRequest.GetResponse();
            StreamReader rdr =
            new StreamReader(resp.GetResponseStream(),  Encoding.UTF8);
            string lcHtml = rdr.ReadToEnd();
            rdr.Close();

            MessageBox.Show(lcHtml);
        }





        //
        //       pouzite tridy a struktury
        //


        //struktura pouzita k ulozeni prave aktivniho zavodu
        public class ActualZavod
        {
            private int sezona = 0;
            private int zavod = 0;
            private bool enable = false;
            public string strZavod;
            public string strSezona;

            public Form1 f;

            public ActualZavod(Form1 InitialForm)
            {
                f = InitialForm;
            }

            public void Refresh()
            {
                sezona = int.Parse(f.cmbSezona.SelectedValue.ToString());
                strSezona = f.data.DefaultView[f.cmbSezona.SelectedIndex]["nazev"].ToString();

                if (f.grdZavody.CurrentRow != null)
                {
                    if (f.data2.DefaultView[f.grdZavody.CurrentRow.Index].IsNew)
                    {
                        zavod = 0;
                    }
                    else
                    {
                        if (!int.TryParse(f.data2.DefaultView[f.grdZavody.CurrentRow.Index]["id_zavodu"].ToString(), out zavod))
                        {
                            zavod = 0;
                        }
                    }
                }
                else
                {
                    zavod = 0;
                }

                if (zavod != 0)
                {
                    strZavod = f.data2.DefaultView[f.grdZavody.CurrentRow.Index]["nazev"].ToString();
                    enable = int.Parse(f.data2.DefaultView[f.grdZavody.CurrentRow.Index]["dirty"].ToString()) == 1;

                    f.GetDiscipliny();
                }

                Common.LastZavod = zavod;
                SetHeader();


            }

            private void SetHeader()
            {
                f.lblSelected.Text = string.Format("{0} -> {1}", strSezona, strZavod);
                if (enable)
                {
                    if (!f.tabControl1.TabPages.Contains(f.tPosadky))
                    {
                        //neobsahuje zadny
                        f.tabControl1.TabPages.Remove(f.tExport);
                        f.tabControl1.TabPages.Remove(f.tCiselniky);
                        f.tabControl1.TabPages.Add(f.tPosadky);
                        f.tabControl1.TabPages.Add(f.tRozlosovani);
                        f.tabControl1.TabPages.Add(f.tStartovka);
                        f.tabControl1.TabPages.Add(f.tVysledky);
                        f.tabControl1.TabPages.Add(f.tVysledkovka);
                        f.tabControl1.TabPages.Add(f.tExport);
                        f.tabControl1.TabPages.Add(f.tCiselniky);
                    }
                }
                else //maj bejt skryty
                {
                    if (f.tabControl1.TabPages.Contains(f.tPosadky))
                    {
                        //neobsahuje zadny
                        f.tabControl1.TabPages.Remove(f.tPosadky);
                        f.tabControl1.TabPages.Remove(f.tRozlosovani);
                        f.tabControl1.TabPages.Remove(f.tStartovka);
                        f.tabControl1.TabPages.Remove(f.tVysledky);
                        f.tabControl1.TabPages.Remove(f.tVysledkovka);

                    }
                }
            }


            public int Sezona
            {
                get { return sezona; }
            }

            public int Zavod
            {
                get { return zavod; }
            }

            public bool EnabledAllTabs
            {
                get { return enable; }
            }

        }

        //pomocna struktura na parsovani dat z externiho textaku
        private class Casomira
        {
            private int c1;
            private int c2;
            private string cas1;
            private string cas2;

            public Casomira(string radka)
            {
                string[] p = radka.Split(new char[] { '\t' });
                c1 = int.Parse(p[0]);
                c2 = int.Parse(p[2]);
                cas1 = p[1].Replace(",", ".");
                cas2 = p[3].Replace(",", ".");
                if (c1 != c2) throw new Exception();
            }

            public int C
            {
                get { return c1; }
            }


            public string Cas1
            {
                get { return cas1; }
            }

            public string Cas2
            {
                get { return cas2; }
            }


        }

        private void button18_Click(object sender, EventArgs e)
        {
            frmBranky f = new frmBranky(grdVysledky, (int)numericUpDown1.Value);
            f.ShowDialog();
        }

        private void cmbKatStartTimes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbKatRozlosovani_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


	}
}
