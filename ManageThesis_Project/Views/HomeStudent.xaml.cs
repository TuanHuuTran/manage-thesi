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
    /// Interaction logic for HomeStudent.xaml
    /// </summary>
    public partial class HomeStudent : Window
    {
        private Student Student;
        private Thesis Thesis;
        ThesisEntity ThesisEntity = new ThesisEntity();
        public HomeStudent(Student student)
        {
            InitializeComponent();
            Student = student;
            loadThesis();
        }
        public void loadThesis()
        {
            int inputId = Student.ThesisId ?? 0; 
             Thesis = ThesisEntity.LoadThesesByStudent(inputId);

            List<Thesis> thesisList = new List<Thesis>();
            if (Thesis != null)
            {
                thesisList.Add(Thesis);
            }

            ItemsControl1.ItemsSource = thesisList;

        }

        private void MissionButton_Click(object sender, RoutedEventArgs e)
        {
            MyMission myMission = new MyMission(Student, Thesis);
            this.Close();
            myMission.ShowDialog();

        }
        private void CommunicateButton_Click(object sender, RoutedEventArgs e)
        {
            Communicate communicate = new Communicate(Thesis, Student);
            communicate.Show();
        }


        private void checkpointButton_Click(object sender, RoutedEventArgs e)
        {
          checkingPoint checkingPoint = new checkingPoint(Thesis);
            checkingPoint.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            StudentView studentView = new StudentView(Student);
            this.Close();
            studentView.Show();
        }
    }
}
