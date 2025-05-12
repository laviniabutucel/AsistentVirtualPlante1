namespace InterfataUtilizator_WindowsForms
{
    partial class Form1
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
        /// Method required for Designer support – do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnCautaPlanta = new Button();
            btnAdauga = new Button();
            btnRefresh = new Button();
            txtNumePlanta = new TextBox();
            txtCautaPlanta = new TextBox();
            lblEroare = new Label();
            rbNisipos = new RadioButton();
            rbCernoziom = new RadioButton();
            rbArgilos = new RadioButton();
            groupBox1 = new GroupBox();
            cbMedicinala = new CheckBox();
            cbAromatica = new CheckBox();
            cbDecorativa = new CheckBox();
            cbCarnivora = new CheckBox();
            cbNiciuna = new CheckBox();
            cmbNevoieApa = new ComboBox();
            cmbNevoieLumina = new ComboBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Nume";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 154);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 1;
            label2.Text = "Tip sol";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 58);
            label3.Name = "label3";
            label3.Size = new Size(106, 20);
            label3.TabIndex = 2;
            label3.Text = "Nevoie de apa";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 111);
            label4.Name = "label4";
            label4.Size = new Size(126, 20);
            label4.TabIndex = 3;
            label4.Text = "Nevoie de lumina";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 210);
            label5.Name = "label5";
            label5.Size = new Size(94, 20);
            label5.TabIndex = 4;
            label5.Text = "Caracteristici";
            // 
            // btnCautaPlanta
            // 
            btnCautaPlanta.BackColor = Color.Ivory;
            btnCautaPlanta.Location = new Point(12, 260);
            btnCautaPlanta.Name = "btnCautaPlanta";
            btnCautaPlanta.Size = new Size(94, 29);
            btnCautaPlanta.TabIndex = 5;
            btnCautaPlanta.Text = "Caută";
            btnCautaPlanta.UseVisualStyleBackColor = false;
            btnCautaPlanta.Click += btnCauta_Click;
            // 
            // btnAdauga
            // 
            btnAdauga.BackColor = Color.Ivory;
            btnAdauga.Location = new Point(12, 319);
            btnAdauga.Name = "btnAdauga";
            btnAdauga.Size = new Size(94, 29);
            btnAdauga.TabIndex = 6;
            btnAdauga.Text = "Adaugă";
            btnAdauga.UseVisualStyleBackColor = false;
            btnAdauga.Click += btnAdauga_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Ivory;
            btnRefresh.Location = new Point(159, 319);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // txtNumePlanta
            // 
            txtNumePlanta.BackColor = Color.Ivory;
            txtNumePlanta.Location = new Point(159, 7);
            txtNumePlanta.Name = "txtNumePlanta";
            txtNumePlanta.Size = new Size(151, 27);
            txtNumePlanta.TabIndex = 9;
            // 
            // txtCautaPlanta
            // 
            txtCautaPlanta.BackColor = Color.Ivory;
            txtCautaPlanta.Location = new Point(159, 261);
            txtCautaPlanta.Name = "txtCautaPlanta";
            txtCautaPlanta.Size = new Size(151, 27);
            txtCautaPlanta.TabIndex = 12;
            // 
            // lblEroare
            // 
            lblEroare.AutoSize = true;
            lblEroare.Location = new Point(15, 382);
            lblEroare.Name = "lblEroare";
            lblEroare.Size = new Size(52, 20);
            lblEroare.TabIndex = 15;
            lblEroare.Text = "Eroare";
            // 
            // rbNisipos
            // 
            rbNisipos.AutoSize = true;
            rbNisipos.Location = new Point(6, 13);
            rbNisipos.Name = "rbNisipos";
            rbNisipos.Size = new Size(79, 24);
            rbNisipos.TabIndex = 16;
            rbNisipos.TabStop = true;
            rbNisipos.Text = "Nisipos";
            rbNisipos.UseVisualStyleBackColor = true;
            // 
            // rbCernoziom
            // 
            rbCernoziom.AutoSize = true;
            rbCernoziom.Location = new Point(196, 13);
            rbCernoziom.Name = "rbCernoziom";
            rbCernoziom.Size = new Size(102, 24);
            rbCernoziom.TabIndex = 17;
            rbCernoziom.TabStop = true;
            rbCernoziom.Text = "Cernoziom";
            rbCernoziom.UseVisualStyleBackColor = true;
            // 
            // rbArgilos
            // 
            rbArgilos.AutoSize = true;
            rbArgilos.Location = new Point(101, 13);
            rbArgilos.Name = "rbArgilos";
            rbArgilos.Size = new Size(77, 24);
            rbArgilos.TabIndex = 18;
            rbArgilos.TabStop = true;
            rbArgilos.Text = "Argilos";
            rbArgilos.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(rbArgilos);
            groupBox1.Controls.Add(rbCernoziom);
            groupBox1.Controls.Add(rbNisipos);
            groupBox1.Location = new Point(159, 141);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(310, 43);
            groupBox1.TabIndex = 19;
            groupBox1.TabStop = false;
            // 
            // cbMedicinala
            // 
            cbMedicinala.AutoSize = true;
            cbMedicinala.BackColor = Color.Transparent;
            cbMedicinala.Location = new Point(166, 215);
            cbMedicinala.Name = "cbMedicinala";
            cbMedicinala.Size = new Size(104, 24);
            cbMedicinala.TabIndex = 20;
            cbMedicinala.Text = "Medicinala";
            cbMedicinala.UseVisualStyleBackColor = false;
            // 
            // cbAromatica
            // 
            cbAromatica.AutoSize = true;
            cbAromatica.BackColor = Color.Transparent;
            cbAromatica.Location = new Point(272, 216);
            cbAromatica.Name = "cbAromatica";
            cbAromatica.Size = new Size(100, 24);
            cbAromatica.TabIndex = 21;
            cbAromatica.Text = "Aromatica";
            cbAromatica.UseVisualStyleBackColor = false;
            // 
            // cbDecorativa
            // 
            cbDecorativa.AutoSize = true;
            cbDecorativa.BackColor = Color.Transparent;
            cbDecorativa.Location = new Point(379, 215);
            cbDecorativa.Name = "cbDecorativa";
            cbDecorativa.Size = new Size(103, 24);
            cbDecorativa.TabIndex = 22;
            cbDecorativa.Text = "Decorativa";
            cbDecorativa.UseVisualStyleBackColor = false;
            // 
            // cbCarnivora
            // 
            cbCarnivora.AutoSize = true;
            cbCarnivora.BackColor = Color.Transparent;
            cbCarnivora.Location = new Point(485, 215);
            cbCarnivora.Name = "cbCarnivora";
            cbCarnivora.Size = new Size(94, 24);
            cbCarnivora.TabIndex = 23;
            cbCarnivora.Text = "Carnivora";
            cbCarnivora.UseVisualStyleBackColor = false;
            // 
            // cbNiciuna
            // 
            cbNiciuna.AutoSize = true;
            cbNiciuna.BackColor = Color.Transparent;
            cbNiciuna.Location = new Point(592, 216);
            cbNiciuna.Name = "cbNiciuna";
            cbNiciuna.Size = new Size(81, 24);
            cbNiciuna.TabIndex = 24;
            cbNiciuna.Text = "Niciuna";
            cbNiciuna.UseVisualStyleBackColor = false;
            // 
            // cmbNevoieApa
            // 
            cmbNevoieApa.BackColor = Color.Ivory;
            cmbNevoieApa.FormattingEnabled = true;
            cmbNevoieApa.Items.AddRange(new object[] { "2", "4", "7", "10" });
            cmbNevoieApa.Location = new Point(159, 55);
            cmbNevoieApa.Name = "cmbNevoieApa";
            cmbNevoieApa.Size = new Size(151, 28);
            cmbNevoieApa.TabIndex = 25;
            // 
            // cmbNevoieLumina
            // 
            cmbNevoieLumina.BackColor = Color.Ivory;
            cmbNevoieLumina.FormattingEnabled = true;
            cmbNevoieLumina.Items.AddRange(new object[] { "3", "6", "9" });
            cmbNevoieLumina.Location = new Point(159, 111);
            cmbNevoieLumina.Name = "cmbNevoieLumina";
            cmbNevoieLumina.Size = new Size(151, 28);
            cmbNevoieLumina.TabIndex = 26;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSeaGreen;
            ClientSize = new Size(800, 562);
            Controls.Add(cmbNevoieLumina);
            Controls.Add(cmbNevoieApa);
            Controls.Add(cbNiciuna);
            Controls.Add(cbCarnivora);
            Controls.Add(cbDecorativa);
            Controls.Add(cbAromatica);
            Controls.Add(cbMedicinala);
            Controls.Add(groupBox1);
            Controls.Add(lblEroare);
            Controls.Add(txtCautaPlanta);
            Controls.Add(txtNumePlanta);
            Controls.Add(btnRefresh);
            Controls.Add(btnAdauga);
            Controls.Add(btnCautaPlanta);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = Color.DarkGreen;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnCautaPlanta;
        private Button btnAdauga;
        private Button btnRefresh;
        private TextBox txtNumePlanta;
        private TextBox txtCautaPlanta;
        private ComboBox cmbTipSol;
        private Label lblEroare;
        private RadioButton rbNisipos;
        private RadioButton rbCernoziom;
        private RadioButton rbArgilos;
        private GroupBox groupBox1;
        private CheckBox cbMedicinala;
        private CheckBox cbAromatica;
        private CheckBox cbDecorativa;
        private CheckBox cbCarnivora;
        private CheckBox cbNiciuna;
        private ComboBox cmbNevoieApa;
        private ComboBox cmbNevoieLumina;
    }
}
