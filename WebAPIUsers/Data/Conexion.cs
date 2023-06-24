using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIUsers.Models;

namespace WebAPIUsers.Data
{
    public class Conexion
    {
        //Se conecta local
        //public static string ConexionId = "Data Source=.;Initial Catalog=Pruebas;User ID=sa; password=sa";



        //Se conecta a Azure mayo
        //public static string ConexionId = "Data Source=sqldb-jonathanporrasmiranda-1.database.windows.net;Initial Catalog=Users;User ID=sa-jonathanporras; password=Nuevo123*-"; 

        //Ultima a Azure, junio
        public static string ConexionId = "Data Source=webappserverjpm.database.windows.net,1433;Initial Catalog = Pruebas; Persist Security Info=False;User ID = porrasmj; Password=Pruebas123*-; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";
}
}