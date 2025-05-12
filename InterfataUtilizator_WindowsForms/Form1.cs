using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LibrarieModele;          // Clasa Planta și enum-urile TipSol, CaracteristiciPlanta
using NivelStocareDate;        // AdministrarePlante_FisierText

namespace InterfataUtilizator_WindowsForms
{
    public partial class Form1 : Form
    {
        private AdministrarePlante_FisierText adminPlante;

        public Form1()
        {
            InitializeComponent();


            // Setările generale ale ferestrei (acestea pot fi configurate și prin Designer)
            this.Text = "Gestionare Plante";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.DarkSeaGreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Size = new Size(800, 600);

            // Inițializarea clasei care gestionează fișierul "plante.txt"
            adminPlante = new AdministrarePlante_FisierText("plante.txt");
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            lblEroare.Text = string.Empty;

            // Declararea variabilelor pentru TipSol și Caracteristici
            string tipSol = "";
            string caracteristiciText = "";
            string numePlanta = string.IsNullOrWhiteSpace(txtNumePlanta.Text) ? "Necunoscut" : txtNumePlanta.Text.Trim();
            string nevoieApa = cmbNevoieApa.SelectedItem?.ToString() ?? "0"; // Evită null
            string nevoieLumina = cmbNevoieLumina.SelectedItem?.ToString() ?? "0"; // Evită null


            if (ValidareDate(out string mesajEroare))
            {
                // Verificăm ce Tip Sol este selectat (RadioButton)
                if (rbNisipos.Checked) tipSol = "Nisipos";
                if (rbArgilos.Checked) tipSol = "Argilos";
                if (rbCernoziom.Checked) tipSol = "Cernoziom";

                // Verificăm ce caracteristici sunt bifate (CheckBox-uri)
                List<string> caracteristici = new List<string>();
                if (cbMedicinala.Checked) caracteristici.Add("Medicinală");
                if (cbAromatica.Checked) caracteristici.Add("Aromatică");
                if (cbDecorativa.Checked) caracteristici.Add("Decorativă");
                if (cbCarnivora.Checked) caracteristici.Add("Carnivoră");
                if (cbNiciuna.Checked) caracteristici.Add("Niciuna");
                caracteristiciText = string.Join(", ", caracteristici);


                //Console.WriteLine($"Salvare: {numePlanta}, {nevoieApa}, {nevoieLumina}, {tipSol}, {caracteristiciText}");
                using (StreamWriter writer = new StreamWriter("plante.txt", true)) // 'true' -> adăugare la fișier
                {
                    writer.WriteLine($"{numePlanta},{nevoieApa},{nevoieLumina},{tipSol},{caracteristiciText}");
                }



                // Creăm instanța plantei și salvăm
                Planta planta = new Planta(
                    txtNumePlanta.Text,
                    int.Parse(cmbNevoieApa.SelectedItem.ToString()),
                    int.Parse(cmbNevoieLumina.SelectedItem.ToString()),
                    (TipSol)Enum.Parse(typeof(TipSol), tipSol), caracteristiciText);

                adminPlante.AddPlanta(planta);
                MessageBox.Show("Planta a fost adăugată cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetareCampuri();
            }
            else
            {
                lblEroare.Text = mesajEroare;
            }

        }




        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!File.Exists("plante.txt"))
            {
                MessageBox.Show("Fișierul plante.txt nu există!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] linii = File.ReadAllLines("plante.txt");

            if (linii.Length == 0)
            {
                MessageBox.Show("Nu au fost înregistrate plante.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string[] ultimaPlanta = linii.Last().Split(',');
            if (ultimaPlanta.Length == 5)
            {
                MessageBox.Show($"Ultima plantă adăugată:\n\n" +
                    $"Nume: {ultimaPlanta[0]}\n" +
                    $"Nevoie de Apă: {ultimaPlanta[1]} zile\n" +
                    $"Nevoie de Lumină: {ultimaPlanta[2]} ore/zi\n" +
                    $"Tip Sol: {ultimaPlanta[3]}\n" +
                    $"Caracteristici: {ultimaPlanta[4]}",
                    "Informații Plantă",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Format incorect al fișierului! Verifică plante.txt.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCauta_Click(object sender, EventArgs e)
        {
            string numeCautat = txtCautaPlanta.Text.Trim();

            if (string.IsNullOrEmpty(numeCautat))
            {
                MessageBox.Show("Introduceți numele plantei pentru căutare.", "Avertisment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists("plante.txt"))
            {
                MessageBox.Show("Fișierul plante.txt nu există!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] linii = File.ReadAllLines("plante.txt");
            foreach (string linie in linii)
            {
                string[] campuri = linie.Split(',');

                if (campuri.Length >= 5 && campuri[0].Trim().Equals(numeCautat, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Planta găsită:\n\n" +
                        $"Nume: {campuri[0]}\n" +
                        $"Nevoie de Apă: {campuri[1]} zile\n" +
                        $"Nevoie de Lumină: {campuri[2]} ore/zi\n" +
                        $"Tip Sol: {campuri[3]}\n" +
                        $"Caracteristici: {campuri[4]}",
                        "Rezultat Căutare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            MessageBox.Show("Planta nu a fost găsită.", "Rezultat Căutare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        private bool ValidareDate(out string mesajEroare)
        {
            mesajEroare = string.Empty;

            if (string.IsNullOrWhiteSpace(txtNumePlanta.Text) || txtNumePlanta.Text.Length > 15)
            {
                mesajEroare = "Numele plantei este invalid (maxim 15 caractere).";
                return false;
            }
            if (!int.TryParse(cmbNevoieApa.Text, out int nevoieApa) || nevoieApa <= 0)
            {
                mesajEroare = "Nevoia de apă trebuie să fie un număr pozitiv.";
                return false;
            }
            if (!int.TryParse(cmbNevoieLumina.Text, out int nevoieLumina) || nevoieLumina <= 0)
            {
                mesajEroare = "Nevoia de lumină trebuie să fie un număr pozitiv.";
                return false;
            }
            if (!rbNisipos.Checked && !rbArgilos.Checked && !rbCernoziom.Checked)
            {
                mesajEroare = "Selectați un tip de sol!";
                return false;
            }
            return true;
        }


        // Resetare câmpuri după adăugarea unei plante
        private void ResetareCampuri()
        {
            txtNumePlanta.Clear();
            cmbNevoieApa.SelectedIndex = -1;
            cmbNevoieLumina.SelectedIndex = -1;

            // Resetare RadioButton-uri pentru Tip Sol
            rbNisipos.Checked = false;
            rbArgilos.Checked = false;
            rbCernoziom.Checked = false;

            // Resetare CheckBox-uri pentru Caracteristici
            cbMedicinala.Checked = false;
            cbAromatica.Checked = false;
            cbDecorativa.Checked = false;
            cbCarnivora.Checked = false;
            cbNiciuna.Checked = false;

            txtCautaPlanta.Clear();
        }

    }
}
