using AngularGridTestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularGridTestApp.Controllers
{
    public class UsersController : ApiController
    {
        ApplicationContext db = new ApplicationContext();
        // GET: api/Users
        public IHttpActionResult Get()
        {
            return Ok(db.Users.ToList());
        }

        // GET: api/Users/5
        public IHttpActionResult Get(int id)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
                return Ok(user);

            return NotFound();
        }

        // POST: api/Users
        public IHttpActionResult Post([FromBody]User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return Ok(user);
        }

        // PUT: api/Users/5
        public IHttpActionResult Put(int id, [FromBody]User user)
        {
            User u = db.Users.Find(id);
            if(u!=null)
            {
                u.Name = user.Name;
                u.Age = user.Age;
                db.Entry(u).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Ok(u);
            }
            return NotFound();
        }

        // DELETE: api/Users/5
        public IHttpActionResult Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
                return Ok(user);
            }

            return NotFound();

        }
    }
}
