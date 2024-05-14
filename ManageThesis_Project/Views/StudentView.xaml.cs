using ManageThesis_Project.Entity;
using ManageThesis_Project.Modal;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class StudentView : Window
    {
        ThesisEntity thesisEntity = new ThesisEntity();
        private Student Student;
        private ICollectionView thesesView;
        private readonly MyDbContext dbContext;
        public StudentView(Student student)
        {
            InitializeComponent();
            Student = student;
            LoadThesisData();
        }
    

        public StudentView() { }

        private void LoadThesisData()
        {
            List<Thesis> ListThesis = thesisEntity.LoadAllTheses();       
            allthesisDataGrid.ItemsSource = ListThesis;
            thesesView = CollectionViewSource.GetDefaultView(ListThesis);
            thesesView.Filter = FilterThesisBySearchText;
        }

        private bool FilterThesisBySearchText(object item)
        {
            if (string.IsNullOrEmpty(SearchTextBox.Text))
                return true;

            Thesis thesis = (Thesis)item;
            string searchText = SearchTextBox.Text.ToUpper();

            return thesis.Teachnology.ToUpper().Contains(searchText) ||
                   thesis.Gener.ToUpper().Contains(searchText) ||
                   thesis.Teacher.Name.ToUpper().Contains(searchText);
        }

        private void SearchTextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                thesesView.Refresh();
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            thesesView.Refresh();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (allthesisDataGrid.SelectedItem != null)
            {
                Thesis selectedThesis = (Thesis)allthesisDataGrid.SelectedItem;
              
                RegisterThesis register = new RegisterThesis(selectedThesis, Student);
                this.Close();
                register.Show();


            } else
            {
                MessageBox.Show("Please choose thesis you want to register.Thank!");
            }
        }

        private void MyThesisButton_Click(object sender, RoutedEventArgs e)
        {
            HomeStudent homeStudent = new HomeStudent(Student);
            this.Close();
            homeStudent.Show();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
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
    }
}
