using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports
{
    public interface ICompanyPersistenceRepository
    {
        Task<Company> Create(Company model);
        Task<Company> Update(Company model);
        bool Delete(Guid id);

    }
    public interface ICompanyReaderRepository
    {
        Task<Company> Get(Guid id);
        Task<IEnumerable<Company>> List();
    }
}
