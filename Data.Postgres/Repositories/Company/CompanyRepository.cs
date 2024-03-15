using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Postgres.Repositories.Company
{
    public class CompanyRepository : ICompanyPersistenceRepository
    {
        private EcomerceContext _context { get; set; }
        public CompanyRepository(EcomerceContext context)
        {
            _context = context;
        }
        public async Task<Domain.Entities.Company> Create(Domain.Entities.Company model)
        {
            await _context.Companies.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Company> Update(Domain.Entities.Company model)
        {
            throw new NotImplementedException();
        }
    }
}
