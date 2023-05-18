using StudentManagment.DataAccessLayer.Data;
using StudentManagment.DataAccessLayer.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment.DataAccessLayer.Infrastructure.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        public ApplicationDbContext _context;

        public ICategoryRepository Category { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
