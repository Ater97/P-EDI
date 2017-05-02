using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_microSQL.Utilidades
{
    public class InsertInto
    {
        string tableName;
        List<string> columns;
        List<string> values;
        List<string> types;

        public InsertInto()
        {
            tableName = string.Empty;
            columns = new List<string>();
            values = new List<string>();
            types = new List<string>();
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

        public List<string> Values
        {
            get
            {
                return values;
            }

            set
            {
                values = value;
            }
        }

        public List<string> Types
        {
            get
            {
                return types;
            }
            
            set
            {
                types = value;
            }
        }


    }
}
