using Company.BLL.Interfaces;
using Company.DAL.Data.Contexts;
using Company.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private readonly AppDbContext _context;


        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Dpartment> GetAll()
        {
            return _context.dpartments.ToList();
        }
        public Dpartment Get(int? id)
        {
            //return _context.dpartments.FirstOrDefault(D => D.Id==id);
            return _context.dpartments.Find(id);

        }
        public int Add(Dpartment entity)
        {
             _context.dpartments.Add(entity);
             return _context.SaveChanges();
        }
        public int Update(Dpartment entity)
        {
            _context.dpartments.Update(entity);
            return _context.SaveChanges();
        }

        public int Delete(Dpartment entity)
        {
            _context.dpartments.Remove(entity);
            return _context.SaveChanges();
        }

       
    }
}
