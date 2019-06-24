using ApiDemo.DAL;
using ApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace ApiDemo.Controllers
{
    public class AccountController : ApiController
    {
        private readonly ApiDemoContext db;

        public AccountController()
        {
            db = new ApiDemoContext();
        }

        [HttpPost]
        public IHttpActionResult Login([FromBody] LoginModel login)
        {
            string token = "";

            if (string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
            {
                return BadRequest();
            }

            User userInDB = db.Users.FirstOrDefault(u=>u.Email == login.Email);
            if (userInDB != null)
            {
                if (Crypto.VerifyHashedPassword(userInDB.Password, login.Password))
                {
                    token = Crypto.HashPassword(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                    userInDB.Token = token;
                    db.SaveChanges();

                    return Ok(token);
                }
            }
            return BadRequest("Email veya Password sehvdir");
        }


        [Route("api/hash/{pass}")]
        [HttpGet]
        public IHttpActionResult Hash(string pass)
        {
            string passHash = Crypto.HashPassword(pass);
            return Ok(passHash);
        }
       
        
    }
}
