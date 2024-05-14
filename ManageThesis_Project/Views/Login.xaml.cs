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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private Teacher Teacher { get; set; }
        private Student student { get; set; }
        public Login()
        {
            InitializeComponent();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            User userController = new User();
            var authenticatedUser = userController.Authenticate(username, password);

            if (authenticatedUser is Student)
            {
                Student student = (Student)authenticatedUser;
                StudentView studenView = new StudentView(student);
                studenView.Show();
                this.Close();
            }
            else if (authenticatedUser is Teacher)
            {
                Teacher teacher = (Teacher)authenticatedUser;
                TeacherView teacherView = new TeacherView(teacher);
                teacherView.Show();
                this.Close();

            }
        }



        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
