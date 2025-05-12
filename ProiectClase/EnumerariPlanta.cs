using System;

namespace LibrarieModele
{
    [Flags]
    public enum CaracteristiciPlanta
    {
        Niciuna = 0,
        Carnivoră = 1,
        Decorativă = 2,
        Medicinală = 4,
        Aromatică = 8
    }

    public enum TipSol
    {
        Nisipos = 1,
        Cernoziom = 2,
        Argilos = 3
    }
}
