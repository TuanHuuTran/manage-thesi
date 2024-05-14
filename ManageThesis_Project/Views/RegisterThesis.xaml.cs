using ManageThesis_Project.Entity;
using ManageThesis_Project.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
    /// Interaction logic for RegisterThesis.xaml
    /// </summary>
    public partial class RegisterThesis : Window
    {
        private Thesis Thesis;
        private Student Student;
        GroupEntity groupEntity = new GroupEntity();
        public RegisterThesis(Thesis thesis, Student student)
        {
            InitializeComponent();
            Thesis = thesis;
            Student = student;
            LoadData();
            LoadinforGroup();


        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        public void LoadData()
        {
            List<Thesis> theses = new List<Thesis>();
            theses.Add(Thesis);

            thesisDataGrid.ItemsSource = theses;

        }



        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

            StudentView student = new StudentView(Student);
            this.Close();
            student.Show();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        private void LoadinforGroup()
        {
            var groupList = groupEntity.LoadGroupsByThesisId(Thesis.ThesisId);
            groupDataGrid.DataContext = groupList;
            groupDataGrid.ItemsSource = groupList;

        }

        private void JoinGroup_Click(object sender, RoutedEventArgs e)
        {
            if (groupDataGrid.SelectedItem != null)
            {
                Group selectedGroup = (Group)groupDataGrid.SelectedItem;
                MessageBoxResult result = MessageBox.Show("Are you sure you want join this thesis?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    groupEntity.AddStudentToGroup(Student.StudentId, selectedGroup.GroupId, Thesis.ThesisId);
                    LoadinforGroup();
                }
            }
            else
            {
                MessageBox.Show("Please select a group to join.");
            }


        }
        private void CreateGroup_Click(object sender, RoutedEventArgs e)
        {
            CreateGroup register = new CreateGroup(Thesis, Student);
            register.ShowDialog();
        }
    }
}
