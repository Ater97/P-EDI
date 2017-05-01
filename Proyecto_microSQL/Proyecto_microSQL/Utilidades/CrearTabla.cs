using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_microSQL.Utilidades
{
    public class CrearTabla
    {
        string id;
        string tableName;
        List<string> names;
        List<string> types;

        public CrearTabla()
        {
            id = string.Empty;
            tableName = string.Empty;
            names = new List<string>();
            types = new List<string>();
        }

        public string Id
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

        public List<string> Names
        {
            get
            {
                return names;
            }

            set
            {
                names = value;
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
