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
    /// Interaction logic for ChoosePoint.xaml
    /// </summary>
    public partial class ChoosePoint : Window
    {
        private TaskModal TaskModal;
        TaskEntity taskEntity = new TaskEntity();
        public ChoosePoint(TaskModal taskModal)
        {
            InitializeComponent();
            TaskModal = taskModal;
            loadTask();
        }

        public void loadTask()
        {

            TaskModal = taskEntity.GetTask(TaskModal.TaskId);
            List<TaskModal> listTask = new List<TaskModal>();
            if (TaskModal != null)
            {
                listTask.Add(TaskModal);
            }

            ItemsControl1.ItemsSource = listTask;

        }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                string message = MessageTextBox.Text;
                int  numberpoint = int.Parse(message);
                taskEntity.UpdateTaskByTeacher(TaskModal.TaskId, numberpoint);
                MessageBox.Show("Submit successed!");
                MessageTextBox.Text = "";
                this.Close();
        }
    }
}
