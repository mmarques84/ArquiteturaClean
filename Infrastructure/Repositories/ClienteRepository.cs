using Domain.Models;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : Repository<Cliente>
    {
        public ClienteRepository(DBContext context) : base(context)
        { }
        public override Cliente GetById(int id)
        {
            var query = _context.Set<Cliente>().Where(e => e.Id == id);

            if (query.Any())
                return query.First();

            return null;
        }

        public override IEnumerable<Cliente> GetAll()
        {
            var query = _context.Set<Cliente>();

            return query.Any() ? query.ToList() : new List<Cliente>();
        }
        public  Cliente GetDocumento( int doc)
        {
            var query = _context.Set<Cliente>().Where(e => e.Documento == doc);

            if (query.Any())
                return query.First();

            return null;
        }
    }
}
