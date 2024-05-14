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
    public partial class TaskByThesis : Window
    {
        TaskEntity taskEntity = new TaskEntity();
        private Thesis Thesis;
        private Teacher Teacher;
        public TaskByThesis(Thesis thesis, Teacher teacher)
        {
            InitializeComponent();
            Thesis = thesis;
            Teacher = teacher;
            LoadTaskData();
           
        }

        private void LoadTaskData()
        {
            List<TaskModal> tasks = taskEntity.LoadTaskByThesisId(Thesis.ThesisId);
            taskDataGrid.ItemsSource = tasks;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ManageTask manageTask = new ManageTask(Teacher);
            this.Close();
            manageTask.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (taskDataGrid.SelectedItem != null)
            {
                TaskModal selectedTask = (TaskModal)taskDataGrid.SelectedItem;

                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this Task?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    taskEntity.DeleteTask(selectedTask.TaskId);
                    LoadTaskData();
                }
                else
                {
                }
            }
            else
            {
                MessageBox.Show("Please select a task to delete.");
            }
        }

        private void UpdataButton_Click(object sender, RoutedEventArgs e)
        {
            if (taskDataGrid.SelectedItem != null)
            {
                TaskModal selectedTask = (TaskModal)taskDataGrid.SelectedItem;

                MessageBoxResult result = MessageBox.Show("Are you sure you want to Update this Task?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    UpdateTask updateTask = new UpdateTask(selectedTask, Thesis, Teacher);
                   
                    updateTask.Show();
                }
                else
                {
                }
            }
            else
            {
                MessageBox.Show("Please select a task to update.");
            }

        }

        private void ChoosePointButton_Click(object sender, RoutedEventArgs e)
        {
            if (taskDataGrid.SelectedItem != null)
            {
                TaskModal selectedTask = (TaskModal)taskDataGrid.SelectedItem;

                if (selectedTask != null)
                {
                    ChoosePoint choosePoint = new ChoosePoint(selectedTask);
                    choosePoint.Show();
                }
                else
                {
                }
            }
            else
            {
                MessageBox.Show("Please select a task to checking point.");
            }

        }

        
        private void ComunicationButton_Click(object sender, RoutedEventArgs e)
        {
            Communicate communicate = new Communicate(Thesis, Teacher);
            communicate.Show();
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void TaskDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



    }
}
