using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_microSQL.Utilidades
{
    public class Errors
    {
        private string[] errores;

        public Errors()
        {
            errores = new string[15];
            errores[1] = "Error[1]: El texto ingresado es incoherente. \nPor favor reviselo y haga las correcciones correspondientes.";
            errores[2] = "Error[2]: No se encontro el comando 'GO' para la función.\nRecuerde que no pueden ir funciones dentro de otras funciones, sin antes haberlas finalizados con el comando GO. \nPor favor revise la sintaxis.";
            errores[3] = "Error[3]: No se encontro el simbolo '{' de apertura. \nPor favor verifique su codigo";
            errores[4] = "Error[4]: No se encontro el simbolo '}' de cierre. \nPor favor verifique su codigo.";
            errores[5] = "Error[5]: No se encontro ningun comando de alguna función, verifique su codigo.";
            errores[6] = "Error[6]: No se pueden procesar las funciones WHERE/FROM/VALUES sin antes tener una funcion donde aplicarlo.\nEjemplo: \nSELECT \n <NombreColumna> \nFROM \n. . . \nPor favor verifique su codigo.";
            errores[7] = "Error[7]: No se encuentran datos requeridos para funcionar. \nVerifique su codigo.";
            errores[8] = "Error[8]: No se encontro el INT PRIMARY KEY correspondiente a la tabla. \nPor favor verifique su codigo.";
            errores[9] = "Error[9]: Recuerde que los nombres de las variables y nombres de las tablas no contienen espacios en blanco. \nPor favor verifique su codigo.";
            errores[10] = "Error[10]: No se encontro un nombre para la variable deseada. \nPor favor verifique su codigo.";
            errores[11] = "Error[11]: Tipo de dato no valido, recuerde que solo pueden ser INT, VARCHAR Y DATETIME.";
            errores[12] = "Error[12]: Solo puede existir una INT PRIMARY KEY. \nPor favor verifique su codigo";
            errores[13] = "Error[13]: Se han sobrepasado la cantidad maxima {3} de variables con el mismo tipo de dato. \nPor favor verifique su codigo.";
        }

        public string Errores(int numeroDeError)
        {
            return errores[numeroDeError];
        }
    }
}
