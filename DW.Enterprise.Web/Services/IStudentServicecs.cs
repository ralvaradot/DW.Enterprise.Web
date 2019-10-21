using DW.EnterpriseAPI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DW.Enterprise.Web.Services
{
    public interface IStudentServicecs
    {
        Task<List<Student>> GetAll();
        Task<Student> Get(int id);
        Task<List<Student>> StudentList();
        Task<Student> Add(Student model);
        Task<Student> Update(Student model);
        Task<Student> Delete(int id);

    }
}
