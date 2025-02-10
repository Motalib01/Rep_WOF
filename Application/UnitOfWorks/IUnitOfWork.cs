using Application.Entites;
using Application.Repositores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitOfWorks
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<User> Users { get; }
        Task<int> SaveChangesAsync();
    }
}
