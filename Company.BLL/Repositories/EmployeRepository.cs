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
    public class EmployeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeRepository(AppDbContext context)
        {

            _context = context;

        }
        public IEnumerable<Employee> GetAll()
        {
           return _context.Employees.ToList();
        }
        public Employee Get(int? id)
        {
            return _context.Employees.Find(id);     
        }
        public int Add(Employee entity)
        {
            _context.Employees.Add(entity);
            return _context.SaveChanges();
        }
        public int Update(Employee entity)
        {
            _context.Employees.Update(entity);
            return _context.SaveChanges();
        }
        public int Delete(Employee entity)
        {
            _context.Employees.Remove(entity);
            return _context.SaveChanges();
        }

        public IEnumerable<Employee> GetByName(string name)
        {
          return _context.Employees.Where(E => E.Name.ToLower().Contains(name.ToLower()));
        }
    }
}
