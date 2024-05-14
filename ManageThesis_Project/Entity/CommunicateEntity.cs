using ManageThesis_Project.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ManageThesis_Project.Entity
{
    public class CommunicateEntity
    {
        private readonly MyDbContext dbContext;

        public CommunicateEntity()
        {
            dbContext = new MyDbContext();
        }

        public bool AddCommunicate(Communication communication)
        {
            try
            {
                dbContext.Communications.Add(communication);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public List<Communication> GetCommunicationsByThesisId(int thesisId)
        {
            try
            {
                List<Communication> communications = dbContext.Communications
                    .Include(c => c.Teacher)
                    .Include(c => c.Student)
                    .Where(c => c.ThesisId == thesisId)
                    .ToList();

                return communications;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }
}
