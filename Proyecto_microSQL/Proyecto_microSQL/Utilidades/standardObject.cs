using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_microSQL.Utilidades
{
    class standardObject : IComparable<standardObject>
    {
        public int ID { get; set; }

        public int MyProperty_int1 { get; set; }
        public int MyProperty_int2 { get; set; }
        public int MyProperty_int3 { get; set; }

        public DateTime MyProperty_dt1 { get; set; }
        public DateTime MyProperty_dt2 { get; set; }
        public DateTime MyProperty_dt3 { get; set; }

        public string MyProperty_vchar1 { get; set; }
        public string MyProperty_vchar2 { get; set; }
        public string MyProperty_vchar3 { get; set; }

        public int CompareTo(standardObject other)
        {
            return ID.CompareTo(other.ID);
        }

        
    }
}
