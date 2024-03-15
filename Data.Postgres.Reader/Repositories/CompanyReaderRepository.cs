using Dapper;
using Domain.Entities;
using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Postgres.Reader.Repositories
{
    public class CompanyReaderRepository : ICompanyReaderRepository
    {
        private readonly IDbConnection _connection; 
        public CompanyReaderRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task<Company> Get(Guid id)
        {
            return await _connection.QueryFirstAsync<Company>("SELECT   c.\"Id\" as id, " +
                                                                        "c.\"Name\" as name " +
                                                                "FROM public.\"Companies\" as c " +
                                                                "WHERE c.\"Id\" = @id", new {id});
        }

        public async Task<IEnumerable<Company>> List()
        {
            return await _connection.QueryAsync<Company>("SELECT c.\"Id\" as id, " +
                                                                "c.\"Name\" as name " +
                                                        "FROM public.\"Companies\" as c " +
                                                        "WHERE c.\"Deleted\" = false");
        }
    }
}
