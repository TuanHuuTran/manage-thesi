using ManageThesis_Project.Entity;
using ManageThesis_Project.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TaskModal = ManageThesis_Project.Modal.Task;

namespace ManageThesis_Project.Views
{
    /// <summary>
    /// Interaction logic for MyMission.xaml
    /// </summary>
    public partial class MyMission : Window
    {
        private Student Student;
        private Thesis Thesis;
        TaskEntity TaskEntity = new TaskEntity();
        public MyMission(Student student, Thesis thesis)
        {
            InitializeComponent();
            Student = student;
            LoadTaskData();
            Thesis = thesis;
        }
        private void LoadTaskData()
        {
            List<TaskModal> ListTask = TaskEntity.GetTasksByStudentGroupId(Student);
            TaskDataGrid.ItemsSource = ListTask;

           
        }

        private void TaskDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TaskDataGrid.SelectedItem != null)
            {
                TaskModal selectedTask = (TaskModal)TaskDataGrid.SelectedItem;
                double sliderValue = progressSlider.Value;
                string sliderValueString = string.Format("{0}%.", sliderValue);


                bool check =  TaskEntity.UpdateTaskByStudent(selectedTask.TaskId, sliderValueString);
                if(check)
                {
                    MessageBox.Show("Successful progress update");
                    LoadTaskData();
                } else
                {
                    MessageBox.Show("failed progress update");
                }
            }
            else
            {
                MessageBox.Show("Please select a task to update progress");
            }
        }


        private void chatButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskDataGrid.SelectedItem != null)
            {
                TaskModal selectedTask = (TaskModal)TaskDataGrid.SelectedItem;
                Communicate communicate = new Communicate(Thesis, Student);
                communicate.Show();
            }
            else
            {
                MessageBox.Show("Please choose task!");
            }
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            HomeStudent homeStudent = new HomeStudent(Student);
            this.Close();
            homeStudent.Show();
        }

        private void progressSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double sliderValue = progressSlider.Value;
           
        }
    }
}
