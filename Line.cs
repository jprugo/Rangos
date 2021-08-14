using System;
using System.Collections.Generic;
using System.Linq;


namespace Rangos
{
    public class Line : LineComparer
    {

        public Line(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }

        public int Start { get; set; }
        public int End { get; set; }

        public override string ToString()
        {
            return $"({Start}) -> [{End}]";
        }

        public int Count => Start - End;

        public int Compare(Line y)
        {
            var enumerable = Enumerable.Range(this.Start, this.End);

            if (enumerable.Contains(y.Start) && enumerable.Contains(y.End))
            {
                // 0 REPRESENTA QUE UNA LINEA CONTIENE A LA OTRA
                return 0;
            }
            else if (enumerable.Contains(y.End))
            {
                // -1 REPRESENTA QUE SE INTERSECTAN POR IZQUIERDA
                return -1;
            }
            else // 1 REPRESENTA POR IZQUIERDA
                return enumerable.Contains(y.Start) ? 1 : -22;
        }
    }

    public class LineComparer : Comparer<Line>
    {
        public override int Compare(Line x, Line y)
        {
            int sum1 = Enumerable.Range(x.Start, x.End - 1).Sum();
            int sum2 = Enumerable.Range(y.Start, y.End - 1).Sum();
            return sum1 - sum2;
        }
    }
}
