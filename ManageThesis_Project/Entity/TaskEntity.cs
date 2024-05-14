using ManageThesis_Project.Modal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaskModal = ManageThesis_Project.Modal.Task;

namespace ManageThesis_Project.Entity
{
    public class TaskEntity
    {
        private readonly MyDbContext dbContext;

        public TaskEntity()
        {
            dbContext = new MyDbContext();
        }

        public bool AddTask(TaskModal newTask, int thesisId, int groupId )
        {
            try
            {
                newTask.ThesisId = thesisId;
                newTask.GroupId = groupId;
                dbContext.Tasks.Add(newTask);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public List<TaskModal> LoadTaskByThesisId(int thesisId)
        {
            try
            {
                List<TaskModal> task = dbContext.Tasks
                     .Where(t => t.ThesisId == thesisId)
                    .ToList();
                return task;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }


        public bool DeleteTask(int taskId)
        {
            try
            {
                var task = dbContext.Tasks.FirstOrDefault(t => t.TaskId == taskId);
                if (task != null)
                {
                    dbContext.Tasks.Remove(task);
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine("Task not found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
 
        public bool UpdateTaskByStudent(int taskId, string newStatus)
        {
            try
            {
                var task = dbContext.Tasks.FirstOrDefault(t => t.TaskId == taskId);
                if (task != null)
                {
                    task.Status = newStatus;
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    MessageBox.Show("Task not found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }


        public List<TaskModal> GetTasksByStudentGroupId(Student student)
        {
            try
            {
                Student foundStudent = dbContext.Students.FirstOrDefault(s => s.StudentId == student.StudentId);
                if (foundStudent != null)
                {
                    List<TaskModal> tasks = dbContext.Tasks
                        .Where(t => t.ThesisId == foundStudent.ThesisId)
                        .ToList();
                    return tasks;
                }
                else
                {
                    Console.WriteLine("Student not found.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }


        public bool UpdateTask(int taskId, TaskModal updateTask)
        {
            try
            {
                var task = dbContext.Tasks.FirstOrDefault(t => t.TaskId == taskId);
                if (task != null)
                {
                    task.Title = updateTask.Title;
                    task.Description = updateTask.Description;
                    task.Start_Date = updateTask.Start_Date;
                    task.End_Date = updateTask.End_Date;
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine("Task not found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }


        public TaskModal GetTask(int taskid)
        {
            try
            {
                TaskModal task = dbContext.Tasks
                .Include(t => t.Group)
                    .FirstOrDefault(t => t.TaskId == taskid);

                return task;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }



        public bool UpdateTaskByTeacher(int taskId, int point)
        {
            try
            {
                var task = dbContext.Tasks.FirstOrDefault(t => t.TaskId == taskId);
                if (task != null)
                {
                    task.TaskPoint = point;
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    MessageBox.Show("Task not found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public float CalculateAverageTaskPointsByThesisId(int thesisId)
        {
            try
            {
                List<TaskModal> tasks = dbContext.Tasks
                    .Where(t => t.ThesisId == thesisId)
                    .ToList();

                double? averageTaskPoints = tasks.Average(t => t.TaskPoint);
                return (float)averageTaskPoints.GetValueOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return 0f;
            }
        }
    }
}
