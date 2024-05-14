using ManageThesis_Project.Modal;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace ManageThesis_Project.Entity
{
    public class ThesisEntity
    {
        private readonly MyDbContext dbContext;
        public ThesisEntity()
        {
            dbContext = new MyDbContext();
        }

        public bool AddThesis(Thesis newThesis , Teacher teacher)
        {
            try
            {
                newThesis.TeacherId = teacher.TeacherId;
                dbContext.Thesess.Add(newThesis);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public List<Thesis> LoadThesesByTeacherId(int teacherId)
        {
            try
            {
                List<Thesis> theses = dbContext.Thesess
                    .Where(t => t.TeacherId == teacherId)
                    .ToList();

                return theses;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        public Thesis LoadThesesByStudent(int? inputId)
        {
            try
            {
                Thesis thesis = dbContext.Thesess
                    .Include(t => t.Teacher)
                    .FirstOrDefault(t => t.ThesisId == inputId);
                    
                return thesis;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        public bool DeleteThesis(int thesisId)
        {
            try
            {
                var thesis = dbContext.Thesess.FirstOrDefault(t => t.ThesisId == thesisId);
                if (thesis != null)
                {
                    dbContext.Thesess.Remove(thesis);
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine("Thesis not found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool UpdateThesis(int thesisId, Thesis updatedThesis)
        {
            try
            {
                var thesis = dbContext.Thesess.FirstOrDefault(t => t.ThesisId == thesisId);
                if (thesis != null)
                {
                    thesis.Title = updatedThesis.Title;
                    thesis.Gener = updatedThesis.Gener;
                    thesis.Description = updatedThesis.Description;
                    thesis.Teachnology = updatedThesis.Teachnology;
                    thesis.Requirement = updatedThesis.Requirement;
                    thesis.NumberofStudent = updatedThesis.NumberofStudent;

                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine("Thesis not found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }


        public List<Thesis> LoadAllTheses()
        {
            try
            {
                List<Thesis> theses = dbContext.Thesess
                    .Include(t => t.Teacher) 
                    .ToList();

                return theses;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }


        public Thesis GetThesis(int thesisid)
        {
            try
            {
                Thesis thesis = dbContext.Thesess
             
                    .FirstOrDefault(t => t.ThesisId == thesisid);

                return thesis;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }


}



