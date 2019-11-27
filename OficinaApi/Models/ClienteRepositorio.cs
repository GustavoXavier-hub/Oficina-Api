using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OficinaApi.Models
{
    public class ClienteRepositorio : IRepositorio<Cliente>
    {
        public void Delete(Cliente item)
        {
            ClienteDAL.DeleteCliente(item.Id);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return ClienteDAL.GetClientes();
        }

        public Cliente GetById(int? id)
        {
            return ClienteDAL.GetCliente(id);
        }

        public void Insert(Cliente item)
        {
            ClienteDAL.InsertCliente(item);
        }

        public void Update(Cliente item)
        {
            ClienteDAL.UpdateCliente(item);
        }
    }
}