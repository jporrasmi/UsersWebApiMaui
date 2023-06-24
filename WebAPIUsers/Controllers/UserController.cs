using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIUsers.Models;
using WebAPIUsers.Data;

namespace WebAPIUsers.Controllers
{

    //https://www.youtube.com/watch?v=-rhIFSDgFjk
        
    public class UserController : ApiController
    {
        //// GET api/<controller>
        public List<User> Get()
        {
            System.Diagnostics.EventLog.WriteEntry("Application", "Va a listar todos los usuarios");
            return UserData.ListUser();
        }

        // GET api/<controller>/5
        public User Get(String codUser)
        {
            System.Diagnostics.EventLog.WriteEntry("Application", "va a obtener al usuario: " + codUser);
            return UserData.GetUser(codUser);
        }

        // POST api/<controller>
        public bool Post([FromBody] User usuario)
        {
            System.Diagnostics.EventLog.WriteEntry("Application", "Llego al post " + usuario.CodUser);
            return UserData.AddUser(usuario);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] User usuario)
        {
            System.Diagnostics.EventLog.WriteEntry("Application", "Llego al put " + usuario.CodUser);
            return UserData.ModifyUser(usuario);
        }

        // DELETE api/<controller>/5
        public bool Delete(String codUser)
        {
            System.Diagnostics.EventLog.WriteEntry("Application", "Llego al delete " + codUser);
            return UserData.DeleteUser(codUser);
        }
    }
}