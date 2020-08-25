using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using ChiroApp.Models;
using ChiroDataAccess;
using System.Web.UI.WebControls; 

namespace ChiroApp.Controllers
{
    [Authorize]
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
            //PersonDetails pa = new PersonDetails();

            //pa.LastName = lastName;
            //pa.FirstName= lastName;
            //pa.City = "";

            //db.PersonDetails.Add(pa);

            //return Ok(pa.PatientId);

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
