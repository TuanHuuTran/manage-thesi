using ManageThesis_Project.Entity;
using ManageThesis_Project.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    /// Interaction logic for UpdateTask.xaml
    /// </summary>
    public partial class UpdateTask : Window
    {
        private TaskModal TaskModal;
        private Thesis thesis;
        private Teacher Teacher;
        public UpdateTask(TaskModal taskModal, Thesis thesiss, Teacher  teacher)
        {
            InitializeComponent();
            TaskModal = taskModal;
            thesis = thesiss;
            Teacher = teacher;
             txtTitle.Text = taskModal.Title;
             txtDescription.Text = taskModal.Description;
            datePickerStartDay.SelectedDate = taskModal.Start_Date;
            datePickerEndDay.SelectedDate = taskModal.End_Date;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string title = txtTitle.Text;
            string description = txtDescription.Text;
            DateTime startDate = datePickerStartDay.SelectedDate.Value;
            DateTime endDate = datePickerEndDay.SelectedDate.Value;

            TaskModal updataTask = new TaskModal
            {
                Title = title,
                Description = description,
                Start_Date = startDate,
                End_Date = endDate,
              
            };

            TaskEntity entity = new TaskEntity();
            entity.UpdateTask(TaskModal.TaskId, updataTask);
            MessageBox.Show("Update successful!");
            TaskByThesis taskByThesis = new TaskByThesis(thesis, Teacher);
            this.Close();
            taskByThesis.Show();
        }
    }
}
