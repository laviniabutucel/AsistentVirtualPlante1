using System;
using System.Collections.Generic;
using System.IO;
using LibrarieModele;

namespace NivelStocareDate
{
    public class AdministrarePlante_FisierText
    {
        private string numeFisier;

        public AdministrarePlante_FisierText(string numeFisierInitial)
        {
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = Path.Combine(locatieFisierSolutie, numeFisierInitial);
            this.numeFisier = caleCompletaFisier;

            if (!File.Exists(this.numeFisier))
            {
                using (Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate))
                {
                }
            }
        }

        public void AddPlanta(Planta planta)
        {
            using (StreamWriter streamWriter = new StreamWriter(numeFisier, true, System.Text.Encoding.UTF8))
            {
                streamWriter.WriteLine(planta.ConversieLaSir_PentruFisier());
            }
        }

        public List<Planta> GetPlante()
        {
            List<Planta> plante = new List<Planta>();

            if (!File.Exists("plante.txt"))
            {
                return plante; // Returnează listă goală dacă fișierul nu există
            }

            string[] linii = File.ReadAllLines("plante.txt");
            foreach (string linie in linii)
            {
                string[] campuri = linie.Split(',');

                if (campuri.Length == 5)
                {
                    Planta planta = new Planta(campuri[0], int.Parse(campuri[1]), int.Parse(campuri[2]), (TipSol)Enum.Parse(typeof(TipSol), campuri[3]), campuri[4]);
                    plante.Add(planta);
                }
            }

            return plante;
        }


        public void ActualizeazaFisier(List<Planta> plante)
        {
            using (StreamWriter streamWriter = new StreamWriter(numeFisier, false, System.Text.Encoding.UTF8))
            {
                foreach (Planta planta in plante)
                {
                    if (planta != null)
                    {
                        streamWriter.WriteLine(planta.ConversieLaSir_PentruFisier());
                    }
                }
            }
        }

        public Planta CautaPlantaDupaNume(string numePlanta)
        {
            List<Planta> plante = GetPlante();
            return plante.Find(planta => planta.Nume.Equals(numePlanta, StringComparison.OrdinalIgnoreCase));
        }
    }
}
