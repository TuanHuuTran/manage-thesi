using ManageThesis_Project.Modal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using GroupModal = ManageThesis_Project.Modal.Group;

namespace ManageThesis_Project.Entity
{
    public class GroupEntity
    {

        private readonly MyDbContext dbContext;

        public GroupEntity()
        {
            dbContext = new MyDbContext();
        }

      
        public bool AddGroup(GroupModal newGroup, Thesis thesis )
        {
            try
            {
                var group = dbContext.Groups.FirstOrDefault(g => g.ThesisId == thesis.ThesisId);

                if (group != null)
                {
                    MessageBox.Show("Group already exists!");
                    return false;
                }

                var studentExistsInOtherGroup = dbContext.Students.FirstOrDefault(s => s.GroupId == null);

                if (studentExistsInOtherGroup == null)
                {
                    MessageBox.Show("Error: You are already in another group!");
                    return false;
                }

                newGroup.StudentSlot = thesis.NumberofStudent - 1;
                newGroup.ThesisId = thesis.ThesisId;

                dbContext.Groups.Add(newGroup);
                dbContext.SaveChanges();

                List<Student> students = dbContext.Students.Where(s => s.GroupId == null).ToList();

                foreach (var student in students)
                {
                    student.GroupId = newGroup.GroupId;
                    student.ThesisId = thesis.ThesisId;
                }

                dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }


        public List<GroupModal> LoadGroupsByThesisId(int thesisId)
        {
            List<GroupModal> groups = dbContext.Groups
                .Include(g => g.Students) 
                .Where(g => g.ThesisId == thesisId)
                .ToList();
            foreach (var group in groups)
            {
                Console.WriteLine($"Group Name: {group.Name}, Student Slot: {group.StudentSlot}");
                foreach (var student in group.Students)
                {
                    Console.WriteLine($"Student Name: {student.Name}, Student Code: {student.StudentCode}");
                }
            }
            return groups;
           
        }


        
        public bool AddStudentToGroup(int studentId, int groupId, int thesisId)
        {
            try
            {
                var group = dbContext.Groups.FirstOrDefault(g => g.GroupId == groupId);
                if (group == null)
                {
                    MessageBox.Show("Error: Group does not exist.");
                    return false;
                }

                if (group.StudentSlot <= 0)
                {
                    MessageBox.Show("Error: Group is already full. Cannot add new student.");
                    return false;
                }

                var student = dbContext.Students.FirstOrDefault(s => s.StudentId == studentId);

                if (student == null)
                {
                    MessageBox.Show("Error: Student does not exist.");
                    return false;
                }

                if (student.GroupId != null)
                {
                    MessageBox.Show("Error:You are already in another group!.");
                    return false;
                }

                var newGroup = new GroupModal
                {
                    Name = group.Name,
                    ThesisId = group.ThesisId,
                    StudentSlot = group.StudentSlot - 1
                };
                dbContext.Groups.Add(newGroup);
                student.GroupId = newGroup.GroupId;
                student.ThesisId = thesisId;
                dbContext.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationError in ex.EntityValidationErrors.SelectMany(validationResult => validationResult.ValidationErrors))
                {
                    Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                }
                return false;
            }
        }

    }
}
