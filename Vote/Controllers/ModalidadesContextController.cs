using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vote.DAO;

namespace Vote.Controllers
{
    public class ModalidadesContextController : ApiBaseController
    {
        // GET api/<controller>
        public IEnumerable<Modalidade> Get()
        {
            return db.Modalidades.ToList();
        }

        // GET api/<controller>/5
        public Modalidade Get(int id)
        {
            return db.Modalidades.Find(id);
        }

        // POST api/<controller>
        public void Post([FromBody]Modalidade value)
        {
            throw new UnauthorizedAccessException();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Modalidade value)
        {
            throw new UnauthorizedAccessException();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            throw new UnauthorizedAccessException();
        }
    }
}