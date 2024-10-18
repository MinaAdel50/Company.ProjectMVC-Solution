using Company.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Interfaces
{
    public interface IDepartmentRepository
    {

        IEnumerable <Dpartment> GetAll();

       Dpartment Get(int? id);

        int Add(Dpartment entity);
        int Update(Dpartment entity);
        int Delete(Dpartment entity);


    }
}
