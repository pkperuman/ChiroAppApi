using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChiroDataAccess;
using ChiroApp.Models;

namespace ChiroApp.Controllers
{
    public class PatientRegisterController : ApiController
    {
        ChiroAppEntities db = new ChiroAppEntities();

        [Route("NewPatient")]
        public IHttpActionResult PostNewPatient(int id,string firstname,string middlename,string lastname,string phonenumber,string email,string city,string state,string zip,byte[] image,bool phonenumberverify)
        {
            Patients pa = new Patients();

            pa.FirstName = firstname;
            pa.MiddleName = middlename;
            pa.LastName = lastname;
            pa.PhoneNumber = phonenumber;
            pa.Email = email;
            pa.City = city;
            pa.State = state;
            pa.Zip = zip;
            pa.Image = image;
            pa.PhoneNumberVerify = phonenumberverify;
            

            db.Patients.Add(pa);

            return Ok(pa.PatientId);
        }


        [Route("NewUser")]
        public IHttpActionResult PostAddUser(UserModel u)
        {
            db.AddUser(u.UserID, u.PhoneNumber, u.RoleID, u.patientid);
            db.SaveChanges();
            return Ok(u.ID);



        }
}
