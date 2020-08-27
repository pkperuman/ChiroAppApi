using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using ChiroApp.Models;
using ChiroDataAccess;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Web.UI.WebControls; 

namespace ChiroApp.Controllers
{
    //[Authorize]
    public class LoginController : ApiController
    {
        ChiroAppEntities db = new ChiroAppEntities();

        
        [HttpGet]
        [Route("GetAllUsers")]
        public IEnumerable<Patients> GetAllUsers()
        {
                return db.Patients.ToList();
        }


        [Route("Login")]
        public void Login(int id)
        {
            //check if id is 5 digit or 10 digit. 
            //if 5 digits then do below
            // lookup userid in user table get matching phone number send OTP - if userid not found then through id not found error.
            // else if 10 digits then lookup phone number in user table and sent otp - if userid not found then through id not found error.
            // else through id not found error.
            Patients p = new Patients();

            if(p.PatientId==5 || p.PhoneNumber.Length==10)
            {
                

            }

 
        }

        [Route("Login")]
        public void VerifyOTP(string code, int id)
        {
         //verify otp and return success/failed
        }

        [Route("GetPatient")]
        public Patients GetPatient(int id)
        {
             

                return db.Patients.Where(i => i.PatientId == id).FirstOrDefault();
        }

        [Route("GetPhysician")]
        public Patients GetPhysician(int id)
        {


            return db.Patients.Where(i => i.PatientId == id).FirstOrDefault();
        }

        [Route("GetNurse")]
        public IHttpActionResult GetNurse(int id)
        {
            

            try
            {
                return Ok(db.Patients.Where(i => i.PatientId == id).FirstOrDefault());
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }


        }
    }
}
