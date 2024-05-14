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
    /// Interaction logic for TeacherView.xaml
    /// </summary>
    public partial class TeacherView : Window
    {
        private Teacher Teacher;
        public TeacherView(Teacher teacher)
        {
            InitializeComponent();
            Teacher = teacher;
            loadName();

        }

        public void loadName()
        {
            ItemsControlName.ItemsSource = new List<Teacher> { Teacher };
        }



        private void GradeButton_Click(object sender, RoutedEventArgs e)
        {
           ManageThesis manageThesis = new ManageThesis(Teacher);
            this.Close();
            manageThesis.Show();
        }

        private void CheckProgressButton_Click(object sender, RoutedEventArgs e)
        {
            ManageTask thesisTask = new ManageTask(Teacher);
            this.Close();
            thesisTask.Show();

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

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
        }
    }
}

      