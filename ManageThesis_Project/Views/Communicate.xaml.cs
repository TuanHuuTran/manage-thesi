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
    /// Interaction logic for Communicate.xaml
    /// </summary>
    public partial class Communicate : Window
    {
        private Teacher Teacher;
        private Student Student;
        private Thesis Thesis;
     
        CommunicateEntity CommunicateEntity = new CommunicateEntity();

        public Communicate(Thesis thesis, Teacher teacher)
        {
            InitializeComponent();
            Thesis = thesis;
            Teacher = teacher;
            LoadCommunication();
        }

        public Communicate(Thesis thesis, Student student)
        {
            InitializeComponent();
            Thesis = thesis;
            Student = student;
            LoadCommunication();
        }
        public void LoadCommunication()
        {
            List<Communication> communications = CommunicateEntity.GetCommunicationsByThesisId(Thesis.ThesisId);
                ItemsControl1.ItemsSource = communications;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageTextBox.Text;
            DateTime timestampe = DateTime.Now;
            Communication communication = new Communication
            {
                Message = message,
                Timestamp = timestampe,
                TeacherId = Teacher?.TeacherId,
                StudentId = Student?.StudentId,
                ThesisId = Thesis.ThesisId
            };
            CommunicateEntity.AddCommunicate(communication);
            MessageTextBox.Text = "";
            LoadCommunication();
        }
    }
}
