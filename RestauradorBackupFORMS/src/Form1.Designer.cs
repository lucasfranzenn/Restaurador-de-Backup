namespace RestauradorBackupFORMS
{
    partial class form
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form));
            this.box_porta = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bttn_3306 = new System.Windows.Forms.RadioButton();
            this.bttn_3307 = new System.Windows.Forms.RadioButton();
            this.lbl_status = new System.Windows.Forms.Label();
            this.lbl_statusCon = new System.Windows.Forms.Label();
            this.gb_backup = new System.Windows.Forms.GroupBox();
            this.bttn_configini = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_restauraBackup = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cb_pwdsupervisor = new System.Windows.Forms.CheckBox();
            this.cb_excluir = new System.Windows.Forms.CheckBox();
            this.cb_atualizadb = new System.Windows.Forms.CheckBox();
            this.cb_pwd1 = new System.Windows.Forms.CheckBox();
            this.cb_createDb = new System.Windows.Forms.CheckBox();
            this.bttn_fileSearch = new System.Windows.Forms.Button();
            this.text_nomeBackup = new System.Windows.Forms.TextBox();
            this.lbl_nomeBackup = new System.Windows.Forms.Label();
            this.text_nomeBanco = new System.Windows.Forms.TextBox();
            this.lbl_nomeBanco = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lbl_credit = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_IP = new System.Windows.Forms.Label();
            this.bttn_220 = new System.Windows.Forms.RadioButton();
            this.bttn_outro = new System.Windows.Forms.RadioButton();
            this.text_host = new System.Windows.Forms.TextBox();
            this.lbl_Host = new System.Windows.Forms.Label();
            this.lbl_porta = new System.Windows.Forms.Label();
            this.text_porta = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.box_porta.SuspendLayout();
            this.gb_backup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // box_porta
            // 
            this.box_porta.Controls.Add(this.label1);
            this.box_porta.Controls.Add(this.bttn_3306);
            this.box_porta.Controls.Add(this.bttn_3307);
            resources.ApplyResources(this.box_porta, "box_porta");
            this.box_porta.Name = "box_porta";
            this.box_porta.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // bttn_3306
            // 
            resources.ApplyResources(this.bttn_3306, "bttn_3306");
            this.bttn_3306.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttn_3306.Name = "bttn_3306";
            this.bttn_3306.UseVisualStyleBackColor = true;
            this.bttn_3306.CheckedChanged += new System.EventHandler(this.bttn_3306_CheckedChanged);
            // 
            // bttn_3307
            // 
            resources.ApplyResources(this.bttn_3307, "bttn_3307");
            this.bttn_3307.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttn_3307.Name = "bttn_3307";
            this.bttn_3307.UseVisualStyleBackColor = true;
            this.bttn_3307.CheckedChanged += new System.EventHandler(this.bttn_3307_CheckedChanged);
            // 
            // lbl_status
            // 
            resources.ApplyResources(this.lbl_status, "lbl_status");
            this.lbl_status.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_status.Name = "lbl_status";
            // 
            // lbl_statusCon
            // 
            resources.ApplyResources(this.lbl_statusCon, "lbl_statusCon");
            this.lbl_statusCon.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lbl_statusCon.Name = "lbl_statusCon";
            // 
            // gb_backup
            // 
            this.gb_backup.Controls.Add(this.bttn_configini);
            this.gb_backup.Controls.Add(this.label4);
            this.gb_backup.Controls.Add(this.label3);
            this.gb_backup.Controls.Add(this.cb_restauraBackup);
            this.gb_backup.Controls.Add(this.button1);
            this.gb_backup.Controls.Add(this.cb_pwdsupervisor);
            this.gb_backup.Controls.Add(this.cb_excluir);
            this.gb_backup.Controls.Add(this.cb_atualizadb);
            this.gb_backup.Controls.Add(this.cb_pwd1);
            this.gb_backup.Controls.Add(this.cb_createDb);
            this.gb_backup.Controls.Add(this.bttn_fileSearch);
            this.gb_backup.Controls.Add(this.text_nomeBackup);
            this.gb_backup.Controls.Add(this.lbl_nomeBackup);
            this.gb_backup.Controls.Add(this.text_nomeBanco);
            this.gb_backup.Controls.Add(this.lbl_nomeBanco);
            resources.ApplyResources(this.gb_backup, "gb_backup");
            this.gb_backup.Name = "gb_backup";
            this.gb_backup.TabStop = false;
            // 
            // bttn_configini
            // 
            this.bttn_configini.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.bttn_configini.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.bttn_configini, "bttn_configini");
            this.bttn_configini.Name = "bttn_configini";
            this.bttn_configini.UseVisualStyleBackColor = true;
            this.bttn_configini.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Name = "label4";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cb_restauraBackup
            // 
            resources.ApplyResources(this.cb_restauraBackup, "cb_restauraBackup");
            this.cb_restauraBackup.Checked = true;
            this.cb_restauraBackup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_restauraBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_restauraBackup.Name = "cb_restauraBackup";
            this.cb_restauraBackup.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cb_pwdsupervisor
            // 
            resources.ApplyResources(this.cb_pwdsupervisor, "cb_pwdsupervisor");
            this.cb_pwdsupervisor.Checked = true;
            this.cb_pwdsupervisor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_pwdsupervisor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_pwdsupervisor.Name = "cb_pwdsupervisor";
            this.cb_pwdsupervisor.UseVisualStyleBackColor = true;
            // 
            // cb_excluir
            // 
            resources.ApplyResources(this.cb_excluir, "cb_excluir");
            this.cb_excluir.Checked = true;
            this.cb_excluir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_excluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_excluir.Name = "cb_excluir";
            this.cb_excluir.UseVisualStyleBackColor = true;
            // 
            // cb_atualizadb
            // 
            resources.ApplyResources(this.cb_atualizadb, "cb_atualizadb");
            this.cb_atualizadb.Checked = true;
            this.cb_atualizadb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_atualizadb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_atualizadb.Name = "cb_atualizadb";
            this.cb_atualizadb.UseVisualStyleBackColor = true;
            // 
            // cb_pwd1
            // 
            resources.ApplyResources(this.cb_pwd1, "cb_pwd1");
            this.cb_pwd1.Checked = true;
            this.cb_pwd1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_pwd1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_pwd1.Name = "cb_pwd1";
            this.cb_pwd1.UseVisualStyleBackColor = true;
            // 
            // cb_createDb
            // 
            resources.ApplyResources(this.cb_createDb, "cb_createDb");
            this.cb_createDb.Checked = true;
            this.cb_createDb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_createDb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_createDb.Name = "cb_createDb";
            this.cb_createDb.UseVisualStyleBackColor = true;
            // 
            // bttn_fileSearch
            // 
            this.bttn_fileSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.bttn_fileSearch, "bttn_fileSearch");
            this.bttn_fileSearch.Name = "bttn_fileSearch";
            this.bttn_fileSearch.UseVisualStyleBackColor = true;
            this.bttn_fileSearch.Click += new System.EventHandler(this.bttn_fileSearch_Click);
            // 
            // text_nomeBackup
            // 
            this.text_nomeBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.text_nomeBackup, "text_nomeBackup");
            this.text_nomeBackup.Name = "text_nomeBackup";
            this.text_nomeBackup.ReadOnly = true;
            this.text_nomeBackup.MouseLeave += new System.EventHandler(this.text_nomeBackup_MouseLeave);
            // 
            // lbl_nomeBackup
            // 
            resources.ApplyResources(this.lbl_nomeBackup, "lbl_nomeBackup");
            this.lbl_nomeBackup.Name = "lbl_nomeBackup";
            // 
            // text_nomeBanco
            // 
            this.text_nomeBanco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.text_nomeBanco, "text_nomeBanco");
            this.text_nomeBanco.Name = "text_nomeBanco";
            this.text_nomeBanco.Leave += new System.EventHandler(this.text_nomeBanco_Leave);
            // 
            // lbl_nomeBanco
            // 
            resources.ApplyResources(this.lbl_nomeBanco, "lbl_nomeBanco");
            this.lbl_nomeBanco.Name = "lbl_nomeBanco";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lbl_credit
            // 
            resources.ApplyResources(this.lbl_credit, "lbl_credit");
            this.lbl_credit.Name = "lbl_credit";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.imageList1, "imageList1");
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_IP);
            this.groupBox1.Controls.Add(this.bttn_220);
            this.groupBox1.Controls.Add(this.bttn_outro);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // lbl_IP
            // 
            resources.ApplyResources(this.lbl_IP, "lbl_IP");
            this.lbl_IP.Name = "lbl_IP";
            // 
            // bttn_220
            // 
            resources.ApplyResources(this.bttn_220, "bttn_220");
            this.bttn_220.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttn_220.Name = "bttn_220";
            this.bttn_220.UseVisualStyleBackColor = true;
            this.bttn_220.CheckedChanged += new System.EventHandler(this.bttn_220_CheckedChanged);
            // 
            // bttn_outro
            // 
            resources.ApplyResources(this.bttn_outro, "bttn_outro");
            this.bttn_outro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttn_outro.Name = "bttn_outro";
            this.bttn_outro.UseVisualStyleBackColor = true;
            this.bttn_outro.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // text_host
            // 
            this.text_host.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_host.Cursor = System.Windows.Forms.Cursors.IBeam;
            resources.ApplyResources(this.text_host, "text_host");
            this.text_host.Name = "text_host";
            this.text_host.Leave += new System.EventHandler(this.text_host_Leave);
            // 
            // lbl_Host
            // 
            resources.ApplyResources(this.lbl_Host, "lbl_Host");
            this.lbl_Host.Name = "lbl_Host";
            // 
            // lbl_porta
            // 
            resources.ApplyResources(this.lbl_porta, "lbl_porta");
            this.lbl_porta.Name = "lbl_porta";
            // 
            // text_porta
            // 
            this.text_porta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.text_porta, "text_porta");
            this.text_porta.Name = "text_porta";
            this.text_porta.Leave += new System.EventHandler(this.text_porta_Leave);
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // form
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lbl_porta);
            this.Controls.Add(this.text_porta);
            this.Controls.Add(this.lbl_Host);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_credit);
            this.Controls.Add(this.text_host);
            this.Controls.Add(this.gb_backup);
            this.Controls.Add(this.lbl_statusCon);
            this.Controls.Add(this.lbl_status);
            this.Controls.Add(this.box_porta);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "form";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Load += new System.EventHandler(this.form_Load);
            this.box_porta.ResumeLayout(false);
            this.box_porta.PerformLayout();
            this.gb_backup.ResumeLayout(false);
            this.gb_backup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox box_porta;
        private System.Windows.Forms.RadioButton bttn_3306;
        private System.Windows.Forms.RadioButton bttn_3307;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_status;
        private System.Windows.Forms.Label lbl_statusCon;
        private System.Windows.Forms.GroupBox gb_backup;
        private System.Windows.Forms.Label lbl_nomeBanco;
        private System.Windows.Forms.TextBox text_nomeBanco;
        private System.Windows.Forms.TextBox text_nomeBackup;
        private System.Windows.Forms.Label lbl_nomeBackup;
        private System.Windows.Forms.Button bttn_fileSearch;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lbl_credit;
        private System.Windows.Forms.CheckBox cb_pwd1;
        private System.Windows.Forms.CheckBox cb_createDb;
        private System.Windows.Forms.CheckBox cb_pwdsupervisor;
        private System.Windows.Forms.CheckBox cb_excluir;
        private System.Windows.Forms.CheckBox cb_atualizadb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cb_restauraBackup;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_IP;
        private System.Windows.Forms.RadioButton bttn_220;
        private System.Windows.Forms.RadioButton bttn_outro;
        private System.Windows.Forms.TextBox text_host;
        private System.Windows.Forms.Label lbl_Host;
        private System.Windows.Forms.Label lbl_porta;
        private System.Windows.Forms.TextBox text_porta;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bttn_configini;
    }
}

