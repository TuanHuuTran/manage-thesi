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
using GroupModal = ManageThesis_Project.Modal.Group;
namespace ManageThesis_Project.Views
{
    /// <summary>
    /// Interaction logic for CreateTask.xaml
    /// </summary>
    public partial class CreateTask : Window
    {
        private Thesis Thesis;
        private Teacher Teacher;
        GroupEntity groupEntity = new GroupEntity();
        public Group SelectedcbItem { get; set; }
        public CreateTask( Thesis thesis, Teacher teacher)
        {
            InitializeComponent();
            Thesis = thesis;
            Teacher = teacher;
            LoadStudents();
        }

        private void LoadStudents()
        {
            var groupList = groupEntity.LoadGroupsByThesisId(Thesis.ThesisId);
            cmbStudent.ItemsSource = groupList;
            cmbStudent.SelectedItem = SelectedcbItem;
        }

        private void txtDescription_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            TaskModal newTask = new TaskModal();

            newTask.Title = txtTitle.Text;
            newTask.Description = txtDescription.Text;
            newTask.Start_Date= datePickerStartDay.SelectedDate ?? DateTime.MinValue;
            newTask.End_Date = datePickerEndDay.SelectedDate ?? DateTime.MinValue;
            Group selectedGroup = cmbStudent.SelectedItem as Group;
            newTask.Status = txtStatus.Text;

           TaskEntity entity = new TaskEntity();
            entity.AddTask(newTask, Thesis.ThesisId, selectedGroup.GroupId);
            TaskByThesis taskByThesis = new TaskByThesis(Thesis, Teacher);
            this.Close();
            taskByThesis.Show();
        }
    }
}
