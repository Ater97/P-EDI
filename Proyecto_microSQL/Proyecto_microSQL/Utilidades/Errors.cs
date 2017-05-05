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
            errores = new string[45];
            errores[1] = "Error[1]: El texto ingresado es incoherente. \nPor favor reviselo y haga las correcciones correspondientes.";
            errores[2] = "Error[2]: No se encontro el comando 'GO' para la función.\nRecuerde que no pueden ir funciones dentro de otras funciones, sin antes haberlas finalizados con el comando GO. \nPor favor revise la sintaxis.";
            errores[3] = "Error[3]: No se encontro el simbolo '(' de apertura. \nPor favor verifique su codigo";
            errores[4] = "Error[4]: No se encontro el simbolo ')' de cierre. \nPor favor verifique su codigo.";
            errores[5] = "Error[5]: No se encontro ningun comando de alguna función, verifique su codigo.";
            errores[6] = "Error[6]: No se pueden procesar las funciones WHERE/FROM/VALUES sin antes tener una funcion donde aplicarlo.\nEjemplo: \nSELECT \n <NombreColumna> \nFROM \n. . . \nPor favor verifique su codigo.";
            errores[7] = "Error[7]: No se encuentran datos requeridos para funcionar. \nVerifique su codigo.";
            errores[8] = "Error[8]: No se encontro el INT PRIMARY KEY correspondiente a la tabla. \nPor favor verifique su codigo.";
            errores[9] = "Error[9]: Recuerde que los nombres de las variables y nombres de las tablas no contienen espacios en blanco. \nPor favor verifique su codigo.";
            errores[10] = "Error[10]: No se encontro un nombre para la variable deseada. \nPor favor verifique su codigo.";
            errores[11] = "Error[11]: Tipo de dato no valido, recuerde que solo pueden ser INT, VARCHAR Y DATETIME.";
            errores[12] = "Error[12]: Solo puede existir una INT PRIMARY KEY. \nPor favor verifique su codigo";
            errores[13] = "Error[13]: Se han sobrepasado la cantidad maxima {3} de variables con el mismo tipo de dato. \nPor favor verifique su codigo.";
            errores[14] = "Error[14]: No se encuentra el comando 'VALUES'. \nPor favor verifique su codigo";
            errores[15] = "Error[15]: Se encontraron mas de dos comandos del tipo 'VALUES'. \nPor favor verifique su codigo.";
            errores[16] = "Error[16]: Los comandos WHERE/FROM no corresponden a la funcion INSERT INTO. \nPor favor verifique su codigo.";
            errores[17] = "Error[17]: Los valores insertados son menores o han sobrepasado la cantidad de columnas que posee la tabla. \nRecuerde que no debe dejar campos nullos. \nPor favor verifique su codigo";
            errores[18] = "Error[18]: La tabla buscada no existe. \nPor favor verifique el nombre de la tabla, de no existir cree una nueva tabla.";
            errores[19] = "Error[19]: Verifique los nombres de las columnas ingresadas, no concuerdan con los de la tabla.";
            errores[20] = "Error[20]: El texto ingresado no concuerda con el tipo de dato, recuerde que VARCHAR(100) utiliza ' ' para su texto.";
            errores[21] = "Error[21]: Recuerde que el tipo de dato DATETIME utiliza ' ' para su texto.";
            errores[22] = "Error[22]: El elemento ingresado no es un numero, por favor verifique su código.";
            errores[23] = "Error[23]: El formato de entrada DATETIME no es valido, por favor guiese por el siguiente ejemplo. \nEjemplo: \n 'Dia/Mes/Año' \n '01/02/1999' \nEs importante recordar las comillas simples y las diagonales. \nTome en cuenta que solo se aceptan numeros y cuando sea un numero de 1 digito se debe agregar el 0 a la izquierda correspondiente.";
            errores[24] = "Error[24]: [DATETIME] Recuerde que el número máximo de dias de un mes es de 31 y no puede ser 0 ni negativo. \nPor favor verifique su codigo.";
            errores[25] = "Error[25]: [DATETIME] Recuerde que el número máximo de meses de un año es de 12 y no puede ser 0 ni negativo. \nPor favor verifique su codigo.";
            errores[26] = "Error[26]: [DATETIME] Recuerde que un año no puede ser cero o negativo. \nPor favor verifique su codigo.";
            errores[27] = "Error[27]: La tabla que desea crear ya existe. \nPor favor verifique su codigo.";
            errores[28] = "Error[28]: No se ha encontrado la INT PRIMARY KEY, recuerde que es necesario este tipo de dato como primer variable en la creación de tablas, tambien recuerde que el nombre de la INT PRIMARY KEY debe ser ID. \nPor favor verifique su codigo.";
            errores[29] = "Error[29]: La INT PRIMARY KEY 'ID' no puede ser negativa, ni cero. \nPor favor verifique su codigo.";
            errores[30] = "Error[30]: No se ha encontrado el comando 'FROM', este indica donde debe realizarse la seleccion, por lo que es de suma importancia. \nPor favor verifique su codigo.";
            errores[31] = "Error[31]: Texto incoherente. Recuerde que los nombres de la tabla no poseen espacios. \nPor favor verifique su codigo";
            errores[32] = "Error[32]: El comando VALUES no corresponde a la función SELECT. \nPor favor verifique su codigo";
            errores[33] = "Error[33]: Se encontraron mas de dos comandos de los tipos 'WHERE'/'FROM'. \nPor favor verifique su codigo.";
            errores[34] = "Error[34]: Nombre de columnas invalidos o no existen en la tabla indicada. \nPor favor verifique su codigo.";
            errores[35] = "Error[35]: Se sobrepaso la cantidad de columnas que posee la tabla. \nPor favor verifique su codigo";
            errores[36] = "Error[36]: Actualmente solo se pueden hacer filtros en la ID, en futuras actualizaciones se implementaran mas filtros. \nPor favor verifique su codigo.";
            errores[37] = "Error[37]: Error al ingresar el filtro, recuerde que solamente puede hacer esto con el ID, por lo que el valor ingresado debe ser un entero no negativo y diferente de cero. \nPor favor verifique su codigo.";
            errores[38] = "Error[38]: Error al ingresar el filtro, texto incoherente verefique su codigo.";
            errores[39] = "Error[39]: Error al ingresar el filtro, recuerde que debe asignarse un numero entero no negativo y diferente de cero. \nPor favor verifique su codigo";
            errores[40] = "Error[40]: Los nombre de tablas no contienen espacios. \n Verifique su codigo.";
            errores[41] = "Error[41]: Los comandos WHERE/FROM/VALUES no corresponden a la funcion DROP TABLE. \nPor favor verifique su codigo.";
        }

        public string Errores(int numeroDeError)
        {
            return errores[numeroDeError];
        }
    }
}
