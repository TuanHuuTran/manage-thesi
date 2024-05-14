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
    /// Interaction logic for CreateProject.xaml
    /// </summary>
    public partial class CreateProject : Window
    {
        private Teacher Teacher;
        public CreateProject( Teacher teacher)
        {
            InitializeComponent();
            Teacher = teacher;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

            ManageThesis manageThesis = new ManageThesis(Teacher);
            this.Close();
            manageThesis.Show();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thesis newThesis = new Thesis();

            newThesis.Title = txtTitle.Text;
            ComboBoxItem selectedStudentsItem = (ComboBoxItem)cmbNumberOfStudentsList.SelectedItem;
            newThesis.NumberofStudent = Convert.ToInt32(selectedStudentsItem.Content);
            newThesis.Description = txtDescription.Text;
            ComboBoxItem selectedGenreItem = (ComboBoxItem)cmbGener.SelectedItem;
            newThesis.Gener = selectedGenreItem.Content.ToString();
            newThesis.Teachnology = txtTechnology.Text;
            newThesis.Requirement = txtRequirements.Text;

            ThesisEntity thesisentity = new ThesisEntity();
            bool success = thesisentity.AddThesis(newThesis, Teacher);

            if (success)
            {
               ManageThesis manageThesis = new ManageThesis(Teacher);
                this.Close();
                manageThesis.Show();
            }
            else
            {
                Console.WriteLine("Failed to add thesis.");
            }
        }
        private void cmbNumberOfStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void cmbGener_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}

