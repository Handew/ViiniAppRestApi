using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViiniAppRestAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ViiniAppRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViiniController : ControllerBase
    {
        private ViiniDbContext db = new ViiniDbContext();

        // GET: api/<ViiniController>
        [HttpGet]
        [Route("")]
        public List<Viinit> GetAll()
        {
            List<Viinit> viinit = db.Viinits.ToList();
            return viinit;
        }

        // GET api/<ViiniController>/5
        [HttpGet]
        [Route("{id}")]
        public Viinit GetSingle(int id)
        {
            Viinit viini = db.Viinits.Find(id);
            return viini;
        }

        // POST api/<ViiniController>
        [HttpPost]
        [Route("")]
        public int Post([FromBody] Viinit viini)
        {
            db.Viinits.Add(viini);
            db.SaveChanges();

            return viini.ViiniId;
        }

        // PUT api/<ViiniController>/5
        [HttpPut]
        [Route("{id}")]
        public string Put(int id, [FromBody] Viinit newData)
        {
            Viinit viini = db.Viinits.Find(id);

            if(viini != null)
            {
                viini.ViiniNimi = newData.ViiniNimi;
                viini.Maa = newData.Maa;
                viini.Rypale = newData.Rypale;
                viini.Hinta = newData.Hinta;

                db.SaveChanges();
                return "OK";
            }
            return "NOT FOUND";
        }

        // DELETE api/<ViiniController>/5
        [HttpDelete]
        [Route("{id}")]
        public string Delete(int id)
        {
            Viinit viini = db.Viinits.Find(id);

            if (viini != null)
            {
                db.Viinits.Remove(viini);
                db.SaveChanges();
                return ("DELETED");
            }
            return "NOT FOUND";
        }
    }
}
