using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using ChiroApp.Models;
using ChiroDataAccess;
using System.Web.UI.WebControls;
using Microsoft.Owin.Security.Provider;

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

        [HttpGet]
        [Route("PatientLogin")]
        public IHttpActionResult Login(int id)
        {
            string phoneNumber = "";
            int patientID = 0;
            if(id.ToString().Length < 5 || id.ToString().Length > 5)
            {
                return BadRequest("Invalid ID");
            }

            if(id.ToString().Length == 10)
            {
                phoneNumber = id.ToString();
            }
            else
            {
                patientID = id;
            }

            if(phoneNumber != "")
            {
                var user = db.Users.Where(i => i.PhoneNumber == phoneNumber).FirstOrDefault();
                if (user != null && user.RoleID == 1)
                {
                    var patient = db.Patients.Where(i => i.PatientId == user.UserID).FirstOrDefault();

                    if(patient != null)
                    {
                        return Ok(patient);
                    }
                    else
                    {
                        return BadRequest("User does not exist!");
                    }
                }
                else
                {
                    return BadRequest("User does not exist!");
                }

            }
            else if(patientID != 0)
            {
                var user = db.Users.Where(i => i.UserID == patientID).FirstOrDefault();
                if (user != null && user.RoleID == 1)
                {
                    var patient = db.Patients.Where(i => i.PatientId == user.UserID).FirstOrDefault();

                    if (patient != null)
                    {
                        return Ok(patient);
                    }
                    else
                    {
                        return BadRequest("User does not exist!");
                    }
                }
                else
                {
                    return BadRequest("User does not exist!");
                }
            }

            return InternalServerError();
        }

        [Route("VerifyOTP")]
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
