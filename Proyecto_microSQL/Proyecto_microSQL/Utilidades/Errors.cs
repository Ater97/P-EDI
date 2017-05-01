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
            errores = new string[8];
            errores[1] = "Error[1]: El texto ingresado es incoherente. \nPor favor reviselo y haga las correcciones correspondientes.";
            errores[2] = "Error[2]: No se encontro el comando 'GO' para la función.\nRecuerde que no pueden ir funciones dentro de otras funciones, sin antes haberlas finalizados con el comando GO. \nPor favor revise la sintaxis.";
            errores[3] = "Error[3]: No se encontro el simbolo '{' de apertura. \nPor favor verifique su codigo";
            errores[4] = "Error[4]: No se encontro el simbolo '}' de cierre. \nPor favor verifique su codigo.";
            errores[5] = "Error[5]: No se encontro ningun comando de alguna función, verifique su codigo.";
            errores[6] = "Error[6]: No se pueden procesar las funciones WHERE/FROM/VALUES sin antes tener una funcion donde aplicarlo.\nEjemplo: \nSELECT \n <NombreColumna> \nFROM \n. . . \nPor favor verifique su codigo.";
            errores[7] = "Error[7]: No se encuentran datos requeridos para funcionar. \n Verifique su codigo.";
        }

        public string Errores(int numeroDeError)
        {
            return errores[numeroDeError];
        }
    }
}
