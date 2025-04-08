using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LibrarieModele; // Clasa Planta
using NivelStocareDate; // AdministrarePlante_FisierText

namespace InterfataUtilizator_WindowsForms
{
    public partial class Form1 : Form
    {
        private TextBox txtNumePlanta;
        private TextBox txtNevoieApa;
        private TextBox txtNevoieLumina; // TextBox pentru "Nevoie de Lumină"
        private ComboBox cmbTipSol;
        private Label lblEroare;
        private AdministrarePlante_FisierText adminPlante;

        public Form1()
        {
            InitializeComponent();

            // Configurare generală a ferestrei
            this.Text = "Gestionare Plante";
            this.BackColor = Color.LightGreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = true;
            this.Size = new Size(800, 600);

            // Inițializează clasa pentru gestionarea fișierului
            adminPlante = new AdministrarePlante_FisierText("plante.txt");

            AdaugaControale();
        }

        private void AdaugaControale()
        {
            // Label și TextBox pentru Nume Plantă
            Label lblNumePlanta = new Label
            {
                Text = "Nume Plantă:",
                Font = new Font("Arial", 12),
                AutoSize = true,
                Top = 20,
                Left = 20
            };
            this.Controls.Add(lblNumePlanta);

            txtNumePlanta = new TextBox
            {
                Font = new Font("Arial", 12),
                Width = 200,
                Top = lblNumePlanta.Top,
                Left = lblNumePlanta.Left + 150
            };
            this.Controls.Add(txtNumePlanta);

            // Label și TextBox pentru Nevoie de Apă
            Label lblNevoieApa = new Label
            {
                Text = "Nevoie de Apă (zile):",
                Font = new Font("Arial", 12),
                AutoSize = true,
                Top = lblNumePlanta.Top + 40,
                Left = 20
            };
            this.Controls.Add(lblNevoieApa);

            txtNevoieApa = new TextBox
            {
                Font = new Font("Arial", 12),
                Width = 200,
                Top = lblNevoieApa.Top,
                Left = lblNevoieApa.Left + 200
            };
            this.Controls.Add(txtNevoieApa);

            // Label și TextBox pentru Nevoie de Lumină
            Label lblNevoieLumina = new Label
            {
                Text = "Nevoie de Lumină (ore/zi):",
                Font = new Font("Arial", 12),
                AutoSize = true,
                Top = lblNevoieApa.Top + 40,
                Left = 20
            };
            this.Controls.Add(lblNevoieLumina);

            txtNevoieLumina = new TextBox
            {
                Font = new Font("Arial", 12),
                Width = 200,
                Top = lblNevoieLumina.Top,
                Left = lblNevoieLumina.Left + 250
            };
            this.Controls.Add(txtNevoieLumina);

            // Label și ComboBox pentru Tip Sol
            Label lblTipSol = new Label
            {
                Text = "Tip Sol:",
                Font = new Font("Arial", 12),
                AutoSize = true,
                Top = lblNevoieLumina.Top + 40,
                Left = 20
            };
            this.Controls.Add(lblTipSol);

            cmbTipSol = new ComboBox
            {
                Font = new Font("Arial", 12),
                Width = 200,
                Top = lblTipSol.Top,
                Left = lblTipSol.Left + 80,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbTipSol.Items.AddRange(new string[] { "Nisipos", "Argilos", "Cernoziom" });
            this.Controls.Add(cmbTipSol);

            // Etichetă pentru afișarea erorilor
            lblEroare = new Label
            {
                Text = "",
                Font = new Font("Arial", 10),
                ForeColor = Color.Red,
                AutoSize = true,
                Top = lblTipSol.Top + 40,
                Left = 20
            };
            this.Controls.Add(lblEroare);

            // Buton Adaugă
            Button btnAdauga = new Button
            {
                Text = "Adaugă",
                Font = new Font("Arial", 12),
                AutoSize = true,
                Top = lblEroare.Top + 40,
                Left = 20
            };
            btnAdauga.Click += BtnAdauga_Click;
            this.Controls.Add(btnAdauga);

            // Buton Refresh
            Button btnRefresh = new Button
            {
                Text = "Refresh",
                Font = new Font("Arial", 12),
                AutoSize = true,
                Top = btnAdauga.Top,
                Left = btnAdauga.Left + 150
            };
            btnRefresh.Click += BtnRefresh_Click;
            this.Controls.Add(btnRefresh);
        }

        private void BtnAdauga_Click(object sender, EventArgs e)
        {
            lblEroare.Text = ""; // Resetează mesajul de eroare

            if (ValidareDate(out string mesajEroare))
            {
                // Creare și salvare plantă
                Planta planta = new Planta(
                    txtNumePlanta.Text,
                    int.Parse(txtNevoieApa.Text),
                    int.Parse(txtNevoieLumina.Text),
                    (TipSol)Enum.Parse(typeof(TipSol), cmbTipSol.SelectedItem.ToString()),
                    CaracteristiciPlanta.Niciuna // Exemplu generic
                );
                adminPlante.AddPlanta(planta);

                MessageBox.Show("Planta a fost adăugată cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Resetare câmpuri
                txtNumePlanta.Text = txtNevoieApa.Text = txtNevoieLumina.Text = "";
                cmbTipSol.SelectedIndex = -1;
            }
            else
            {
                lblEroare.Text = mesajEroare; // Afișează mesajul de eroare
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            List<Planta> plante = adminPlante.GetPlante();

            if (plante.Count > 0)
            {
                Planta ultimaPlanta = plante[^1]; // Ultima plantă din listă
                MessageBox.Show(ultimaPlanta.VerificaStarePlanta(), "Ultima Plantă Adăugată", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Nu există plante înregistrate.", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidareDate(out string mesajEroare)
        {
            mesajEroare = "";

            if (string.IsNullOrWhiteSpace(txtNumePlanta.Text) || txtNumePlanta.Text.Length > 15)
            {
                mesajEroare = "Numele plantei este invalid (maxim 15 caractere).";
                return false;
            }

            if (!int.TryParse(txtNevoieApa.Text, out int nevoieApa) || nevoieApa <= 0)
            {
                mesajEroare = "Nevoia de apă trebuie să fie un număr pozitiv.";
                return false;
            }

            if (!int.TryParse(txtNevoieLumina.Text, out int nevoieLumina) || nevoieLumina <= 0)
            {
                mesajEroare = "Nevoia de lumină trebuie să fie un număr pozitiv.";
                return false;
            }

            if (cmbTipSol.SelectedIndex == -1)
            {
                mesajEroare = "Selectați un tip de sol.";
                return false;
            }

            return true;
        }
    }
}
