using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_microSQL.Utilidades
{
    public class Selection
    {
        string tableName;
        List<string> columns;
        string filtro;
  
        public Selection()
        {
            tableName = string.Empty;
            columns = new List<string>();
            filtro = string.Empty;
        }

        public string Filtro
        {
            get
            {
                return filtro;
            }
            set
            {
                filtro = value;
            }
        }

        public string TableName
        {
            get
            {
                return tableName;
            }

            set
            {
                tableName = value;
            }
        }

        public List<string> Columns
        {
            get
            {
                return columns;
            }

            set
            {
                columns = value;
            }
        }
    }
}
