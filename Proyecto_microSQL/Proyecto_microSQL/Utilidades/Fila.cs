using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_microSQL.Utilidades
{
    public class Fila : IComparable<Fila>
    {
        List<string> values;
        string format;
        int id;

        public Fila( List<string> Values)
        {
            format = string.Empty;
            values = Values;
            id = int.Parse(values[0]);
            values.RemoveAt(0);
            Formato();         
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        private void Formato()
        {
            for(int i = 0; i < this.values.Count; i++)
            {
                if(i == values.Count - 1)
                {
                    format += values[i];
                }
                else
                {
                    format += values[i] + "_";
                }
                
            }
        }

        public override string ToString()
        {
            return string.Format(format);
        }

        public int CompareTo(Fila other)
        {
            return format.CompareTo(other.format);
        }

    }
}
