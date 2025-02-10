using Application.Data;
using Application.Entites;
using Application.Repositores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public IRepository<User> Users { get; }
        

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new Repository<User>(context);
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
