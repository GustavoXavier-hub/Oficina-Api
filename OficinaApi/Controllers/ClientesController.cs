using OficinaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OficinaApi.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly ClienteRepositorio _ClienteRepositorio;
        // GET: Clientes
        public ClientesController()
        {
            _ClienteRepositorio = new ClienteRepositorio();
        }

        // GET: api/Clientes
       [System.Web.Http.HttpGet]
        public IEnumerable<Cliente> List()
        {
            return _ClienteRepositorio.GetAll();
        }

        // GET: api/Clientes/5
        public Cliente GetCliente(int id)
        {
            var Cliente = _ClienteRepositorio.GetById(id);


            return Cliente;
        }

        // POST: api/Clientes   
        [System.Web.Http.HttpPost()]
        public void Post([FromBody]Cliente Cliente)
        {
            _ClienteRepositorio.Insert(Cliente);
        }

        // PUT: api/Clientes/5
        [System.Web.Http.HttpPut()]
        public void Put([FromBody]Cliente Cliente)
        {
            _ClienteRepositorio.Update(Cliente);
        }

        // DELETE: api/Clientes/5
        [System.Web.Http.HttpDelete()]
        public void Delete(int id)
        {
            Cliente c = new Cliente();
            c.Id = id;
            _ClienteRepositorio.Delete(c);
        }

    }
}