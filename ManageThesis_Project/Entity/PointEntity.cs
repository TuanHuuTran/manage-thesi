using ManageThesis_Project.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace ManageThesis_Project.Entity
{
    public class PointEntity
    {
        private readonly MyDbContext dbContext;

        public PointEntity()
        {
            dbContext = new MyDbContext();
        }


        public bool AddPoint(Point point)
        {
            try
            {
                dbContext.Points.Add(point);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public Point GetPoint(int thesisId)
        {
            try
            {
                Point point = dbContext.Points
                .Include(p => p.Thesis)
                .FirstOrDefault(p => p.ThesisId == thesisId);
              
                return point;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }
}
