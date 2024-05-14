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
    /// Interaction logic for ManageThesis.xaml
    /// </summary>
    public partial class ManageThesis : Window
    {
        ThesisEntity entity = new ThesisEntity();
        Teacher Teacher;
        public ManageThesis(Teacher teacher)
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
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var newproject = new CreateProject(Teacher);
            newproject.Closed += (s, args) => this.Close();
            newproject.Show();

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TeacherView teacherForm = new TeacherView(Teacher);
            this.Close();
            teacherForm.Show();
        }


        private void thesisDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (thesisDataGrid.SelectedItem != null)
            {
                Thesis selectedThesis = (Thesis)thesisDataGrid.SelectedItem;
               
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this thesis?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                  entity.DeleteThesis(selectedThesis.ThesisId);
                    LoadThesisData();
                }
                else
                {
                }
            }
            else
            {
                MessageBox.Show("Please select a thesis to delete.");
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (thesisDataGrid.SelectedItem != null)
            {
                Thesis selectedThesis = (Thesis)thesisDataGrid.SelectedItem;

                UpdateThesis updateThesis = new UpdateThesis(selectedThesis, Teacher);
                updateThesis.Show();
            }
            else
            {
                MessageBox.Show("Please select a thesis to update.");
            }

        }


        private void btnEvaluate_Click(object sender, RoutedEventArgs e)
        {
            if (thesisDataGrid.SelectedItem != null)
            {
                Thesis selectedThesis = (Thesis)thesisDataGrid.SelectedItem;
                EvaluateView evaluate = new EvaluateView(selectedThesis);
                evaluate.Show();
            }
            else
            {
                MessageBox.Show("Please select a thesis to update.");
            }

        }


        
    }


}
