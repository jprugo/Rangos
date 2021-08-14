using System;
using System.Collections.Generic;

namespace Rangos
{
    public class Service
    {
        List<Line> lines = new List<Line> {
            new Line(-2, 10), new Line(5, 50), new Line(-10, 0) , new Line(4, 8) , new Line (100, 200)
        };

        public Service() { }

        public void PrintLines() => lines.ForEach(e => Console.WriteLine(e.ToString()));

        public List<Line> MergeLines()
        {
            var newLines = new List<Line>(lines);

            // order newList is not necessary

            loop: for (int i = 0; i < newLines.Count - 1; i++)
                {
                    Line linea = newLines[i];
                    for (int j = i + 1; j < newLines.Count; j++)
                    {
                        Line lineb = newLines[j];
                        //Console.WriteLine($"********** Evaluando linea {linea} con la linea {lineb} ****************");

                        int result = linea.Compare(lineb);
                        if (result != -22)
                        {
                            linea.Start = Math.Min(linea.Start, lineb.Start);
                            linea.End = Math.Max(linea.End, lineb.End);
                            newLines.Remove(lineb);
                            goto loop;
                        }
                    }
                }

            return newLines;
        }

    }
}
