using System;
using System.Collections.Generic;

namespace Rangos
{
    public static class Program
    {
        private static List<Linea> lista;

        private static void Main(string[] args)
        {
            lista = new List<Linea>();
            Console.WriteLine("Digite el numero de lineas");
            int.TryParse(Console.ReadLine(), out var lineas);
            while (lineas != 0) {
                Console.WriteLine($"Digite un valor para de la linea recta {lineas}");
                int.TryParse(Console.ReadLine(), out var v1);

                Console.WriteLine($"Digite el fin de la linea recta {lineas}");
                int.TryParse(Console.ReadLine(), out var v2);
                var l = new Linea(inicio: Math.Min(v1,v2), fin: Math.Max(v1,v2));
                lista.Add(l);
                lineas--;
            }
            ImprimirLista();
            GenerarRangos();
            //GenerarRangosR(lista.Count-1);
            Console.WriteLine("Final:");
            ImprimirLista();
        }

        private static void GenerarRangos()
        {
            main: for (var i = 0; i < lista.Count-1; i++) {
                var l1=lista[i];
                for (var j = i+1; j < lista.Count; j++) {
                    var l2=lista[j];
                    //Console.WriteLine($" (L1) {l1.Inicio}<-->{l1.Fin} (L2) {l2.Inicio}<-->{l2.Fin}");
                    if ((l2.Inicio < l1.Inicio || l2.Inicio > l1.Fin) && (l2.Fin < l1.Inicio || l2.Fin > l1.Fin) && (l2.Inicio > l1.Inicio || l2.Fin < l1.Fin)) continue;
                    var newLine = new Linea(Math.Min(l1.Inicio,l2.Inicio), Math.Max(l1.Fin, l2.Fin));
                    lista[i] = (newLine);
                    lista.RemoveAt(j);
                    goto main;


                }
            }
        }
        private static void GenerarRangosR(int m)
        {
            //Que el recursivo sea el outer for
            if (m < 0) return;
            
            for (var i = m+1; i < lista.Count; i++) {
                var l1=lista[i];
                var l2=lista[m];
                //Console.WriteLine($" (L1) {l1.Inicio}<-->{l1.Fin} (L2) {l2.Inicio}<-->{l2.Fin}");
                if ((l2.Inicio < l1.Inicio || l2.Inicio > l1.Fin) && (l2.Fin < l1.Inicio || l2.Fin > l1.Fin) &&
                    (l2.Inicio > l1.Inicio || l2.Fin < l1.Fin)) continue;
                var newLine = new Linea(Math.Min(l1.Inicio,l2.Inicio), Math.Max(l1.Fin, l2.Fin));
                lista[i] = (newLine);
                lista.RemoveAt(m);
                
            }
            GenerarRangosR(m-1);
        }
        private static void ImprimirLista() {

            foreach (var l in lista)
            {
                Console.WriteLine($"{l.Inicio}<----->{l.Fin}");
            }
        }

        
    }
}
