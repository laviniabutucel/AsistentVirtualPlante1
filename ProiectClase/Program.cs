using System;
using System.IO;
using NivelStocareDate;
using LibrarieModele;
using AsistentVirtualPlante;
using System.Collections.Generic;

namespace AsistentVirtualPlante
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Inițializează administrarea memoriei și fișierului
            AdministrarePlante_Memorie adminMemorie = new AdministrarePlante_Memorie();
            AdministrarePlante_FisierText adminFisier = new AdministrarePlante_FisierText("plante.txt");

            Console.Write("Câte plante vrei să adaugi? ");
            int nrPlante = int.Parse(Console.ReadLine());

            for (int i = 0; i < nrPlante; i++)
            {
                Console.Write("Introduceți numele plantei: ");
                string nume = Console.ReadLine();

                Console.Write("Introduceți zilele necesare pentru udare: ");
                int nevoieApa = int.Parse(Console.ReadLine());

                Console.Write("Introduceți orele de lumină necesare pe zi: ");
                int nevoieLumina = int.Parse(Console.ReadLine());

                TipSol tipSol;
                while (true)
                {
                    Console.WriteLine("Alegeți tipul de sol: 1 - Nisipos, 2 - Cernoziom, 3 - Argilos");
                    if (Enum.TryParse<TipSol>(Console.ReadLine(), out tipSol) && Enum.IsDefined(typeof(TipSol), tipSol))
                    {
                        break;
                    }
                    Console.WriteLine("Opțiune invalidă. Reîncercați.");
                }

                CaracteristiciPlanta caracteristici = CaracteristiciPlanta.Niciuna;
                while (true)
                {
                    Console.WriteLine("Alegeți caracteristicile plantei (ex: 1,2 pentru Fructiferă și Decorativă):");
                    Console.WriteLine("1 - Fructiferă, 2 - Decorativă, 4 - Medicinală, 8 - Aromatică");

                    string[] optiuni = Console.ReadLine().Split(',');
                    bool validInput = true;

                    foreach (string opt in optiuni)
                    {
                        if (int.TryParse(opt.Trim(), out int valoare) && Enum.IsDefined(typeof(CaracteristiciPlanta), valoare))
                        {
                            caracteristici |= (CaracteristiciPlanta)valoare;
                        }
                        else
                        {
                            Console.WriteLine($"Caracteristica {opt} nu este validă.");
                            validInput = false;
                            break;
                        }
                    }

                    if (validInput)
                        break;
                }

                // Crează planta și adaug-o în memorie și fișier
                Planta planta = new Planta(nume, nevoieApa, nevoieLumina, tipSol, caracteristici);
                adminMemorie.AddPlanta(planta);
                adminFisier.AddPlanta(planta);
            }

            // Afișează plantele din memorie
            Console.WriteLine("\nPlantele înregistrate (din memorie):");
            int nrPlanteMemorie;
            Planta[] planteMemorie = adminMemorie.GetPlante(out nrPlanteMemorie);

            AfiseazaPlante(planteMemorie, nrPlanteMemorie);

            // Afișează plantele din fișier
            Console.WriteLine("\nPlantele înregistrate (din fișier):");
            List<Planta> planteFisier = adminFisier.GetPlante();

            foreach (Planta planta in planteFisier)
            {
                Console.WriteLine(planta.VerificaStarePlanta());
            }

            // Căutare plantă după nume
            Console.Write("\nIntroduceți numele unei plante pentru a o verifica: ");
            string numeCautat = Console.ReadLine();

            Planta plantaGasita = adminMemorie.CautaPlantaDupaNume(numeCautat);

            if (plantaGasita == null)
            {
                plantaGasita = adminFisier.CautaPlantaDupaNume(numeCautat);
            }

            if (plantaGasita != null)
            {
                AsistentVirtual asistent = new AsistentVirtual();
                string rezultatInteracțiune = asistent.InteractioneazaCuUtilizatorul(plantaGasita);
                Console.WriteLine(rezultatInteracțiune);

                // Actualizează fișierul cu datele noi
                adminFisier.ActualizeazaFisier(planteFisier);
            }
            else
            {
                Console.WriteLine("Planta nu a fost găsită.");
            }

            Console.WriteLine("\nAplicația s-a terminat. Apăsați o tastă pentru a ieși.");
            Console.ReadKey();
        }

        // Metodă pentru afișarea plantelor
        private static void AfiseazaPlante(Planta[] plante, int nrPlante)
        {
            for (int i = 0; i < nrPlante; i++)
            {
                if (plante[i] != null)
                {
                    Console.WriteLine(plante[i].VerificaStarePlanta());
                }
            }
        }
    }
}
