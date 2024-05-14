using ManageThesis_Project.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageThesis_Project.Entity
{
    public class User
    {
        public object Authenticate(string username, string password)
        {
            using (var dbContext = new MyDbContext())
            {
                var student = dbContext.Students.FirstOrDefault(s => s.Email == username && s.Password == password);
                if (student != null)
                {
                    return student;
                }

                var teacher = dbContext.Teachers.FirstOrDefault(t => t.Email == username && t.Password == password);
                if (teacher != null)
                {
                    return teacher;
                }
                return null;
            }
        }

    }
}
