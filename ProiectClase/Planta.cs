using System;

namespace LibrarieModele
{
    public class Planta
    {
        public string Nume { get; set; }
        public int NevoieApa { get; set; }
        public int NevoieLumina { get; set; }
        public TipSol TipSol { get; set; }
        public string Caracteristici { get; set; } // Caracteristici rămâne string

        public Planta(string nume, int nevoieApa, int nevoieLumina, TipSol tipSol, string caracteristici)
        {
            Nume = nume;
            NevoieApa = nevoieApa;
            NevoieLumina = nevoieLumina;
            TipSol = tipSol;
            Caracteristici = caracteristici;
        }





        // Metoda care verifică starea plantei
        public string VerificaStarePlanta()
        {
            return $"Nume: {Nume}, Nevoie de apă: {NevoieApa} zile, Nevoie de lumină: {NevoieLumina} ore/zi, Tip sol: {TipSol}, Caracteristici: {Caracteristici}";
        }

        // Metoda pentru udarea plantei
        public string UdaPlanta()
        {
            NevoieApa = Limiteaza(NevoieApa - 1, 1, 10); // Reducem nevoia de apă
            return $"{Nume} a fost udată. Nevoia de apă este acum {NevoieApa} zile.";
        }

        // Metoda pentru mutarea plantei într-un loc mai luminos
        public string MutaPlantaLocMaiLuminos()
        {
            NevoieLumina = Limiteaza(NevoieLumina - 1, 1, 10); // Reducem nevoia de lumină
            return $"{Nume} a fost mutată într-un loc mai luminos. Nevoia de lumină este acum {NevoieLumina} ore/zi.";
        }

        // Funcția care limitează valorile între minim și maxim
        private int Limiteaza(int valoare, int minim, int maxim)
        {
            if (valoare < minim)
                return minim;
            if (valoare > maxim)
                return maxim;
            return valoare;
        }

        // Metoda pentru salvarea datelor în formatul necesar fișierului
        public string ConversieLaSir_PentruFisier()
        {
            return $"{Nume},{NevoieApa},{NevoieLumina},{TipSol},{Caracteristici}";
        }
    }
}
