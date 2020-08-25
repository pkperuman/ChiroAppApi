using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.EntityFrameworkCore;
using ChiroApp.Models;
using ChiroDataAccess;
using System.Web.UI.WebControls;

namespace ChiroApp.Controllers
{
    
    public class LoginController : ApiController
    {
        [HttpGet]

        public IEnumerable<PersonDetails> Get()
        {
            using(ChiroAppEntities entities = new ChiroAppEntities())
            {
                return entities.PersonDetails.ToList();
            }
        }

        public PersonDetails Get(int id)
        {
            using(ChiroAppEntities entities = new ChiroAppEntities())
            {
                return entities.PersonDetails.FirstOrDefault();
            }
        }
    }
}
