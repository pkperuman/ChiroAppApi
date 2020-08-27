using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChiroDataAccess;

namespace ChiroApp.Controllers
{
    public class PatientRegisterController : ApiController
    {
        ChiroAppEntities db = new ChiroAppEntities();

        [Route("NewPatient")]
        public IHttpActionResult PostNewPatient(int id,string firstname,string middlename,string lastname,string phonenumber,string email,string city,string state,string zip,byte[] image)
        {
            Patients pa = new Patients();

            try
            {
                pa.FirstName = firstname;
                pa.MiddleName = middlename;
                pa.LastName = lastname;
                pa.PhoneNumber = phonenumber;
                pa.Email = email;
                pa.City = city;
                pa.State = state;
                pa.Zip = zip;
                pa.Image = image;

                db.Patients.Add(pa);

                return Ok(pa.PatientId);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }



        }
    }
}
