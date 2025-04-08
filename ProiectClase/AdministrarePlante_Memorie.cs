using LibrarieModele;
using System;
using System.Collections.Generic;

namespace NivelStocareDate
{
    public class AdministrarePlante_Memorie
    {
        private const int NR_MAX_PLANTE = 50;
        private List<Planta> plante;

        public AdministrarePlante_Memorie()
        {
            plante = new List<Planta>();
        }

        public void AddPlanta(Planta planta)
        {
            if (plante.Count < NR_MAX_PLANTE)
            {
                plante.Add(planta);
            }
        }

        public Planta[] GetPlante(out int nrPlante)
        {
            nrPlante = plante.Count;
            return plante.ToArray();
        }

        public Planta CautaPlantaDupaNume(string numeCautat)
        {
            return plante.Find(planta => planta.Nume.Equals(numeCautat, StringComparison.OrdinalIgnoreCase));
        }
    }
}
