using System;
using System.Collections.Generic;
using System.Text;

namespace Rangos
{
    class Linea
    {
        int inicio;
        int fin;

        public Linea(int inicio, int fin)
        {
            this.Inicio = inicio;
            this.Fin = fin;
        }

        public int Inicio { get => inicio; set => inicio = value; }
        public int Fin { get => fin; set => fin = value; }

        public override string ToString()
        {
            return $"inicio: {inicio} fin: {fin}";
        }
    }
}
