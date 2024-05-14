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

namespace ManageThesis_Project.Views
{
    /// <summary>
    /// Interaction logic for ManageTask.xaml
    /// </summary>
    public partial class ManageTask : Window
    {
        ThesisEntity entity = new ThesisEntity();
        private Teacher Teacher;
        public ManageTask(Teacher teacher)
        {
            InitializeComponent();
            Teacher = teacher;
            LoadThesisData();
            
        }

        private void LoadThesisData()
        {
            List<Thesis> theses = entity.LoadThesesByTeacherId(Teacher.TeacherId);
            thesisDataGrid.ItemsSource = theses;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

            TeacherView teacherForm = new TeacherView(Teacher);
            teacherForm.Show();
            this.Close();
        }

        private void ManageTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (thesisDataGrid.SelectedItem != null)
            {
                Thesis selectedThesis = (Thesis)thesisDataGrid.SelectedItem;

                TaskByThesis taskByThesis = new TaskByThesis(selectedThesis, Teacher);
                this.Close();
                taskByThesis.Show();
            }
            else
            {
                MessageBox.Show("Please select a thesis to task.");
            }

        }

        private void CreateTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (thesisDataGrid.SelectedItem != null)
            {
                Thesis selectedThesis = (Thesis)thesisDataGrid.SelectedItem;
                CreateTask createTask = new CreateTask(selectedThesis, Teacher);
                createTask.Show();
            }
            else
            {
                MessageBox.Show("Please select a thesis to task.");
            }

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
        private void thesisDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
    }
}
