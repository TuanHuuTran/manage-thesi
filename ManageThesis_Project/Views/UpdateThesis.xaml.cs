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
    /// Interaction logic for UpdateThesis.xaml
    /// </summary>
    public partial class UpdateThesis : Window
    {
        private Thesis Thesis;
        private Teacher Teacher;
        public UpdateThesis(Thesis thesis, Teacher teacher)
        {
            InitializeComponent();
            Teacher = teacher;
            Thesis = thesis;
            txtTitle.Text = Thesis.Title;
            txtDescription.Text = Thesis.Description;
            txtTechnology.Text = Thesis.Teachnology;
            txtRequirement.Text = Thesis.Requirement;
            txtNumberOfStudent.Text = Thesis.NumberofStudent.ToString();
            txtGenre.Text = Thesis.Gener;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string title = txtTitle.Text;
            string description = txtDescription.Text;
            string technology = txtTechnology.Text;
            string requirement = txtRequirement.Text;
            string numberOfStudentStr = txtNumberOfStudent.Text;
            int numberOfStudents = int.Parse(numberOfStudentStr);
            string genre = txtGenre.Text;

            Thesis updatedThesis = new Thesis
            {
                Title = title,
                Description = description,
                Teachnology = technology,
                Requirement = requirement,
                NumberofStudent = numberOfStudents,
                Gener = genre
            };

            ThesisEntity thesisEntity = new ThesisEntity();
            thesisEntity.UpdateThesis(Thesis.ThesisId, updatedThesis);
            MessageBox.Show("Update successful!");
            ManageThesis manage = new ManageThesis(Teacher);
            this.Close();
            manage.Show();

        }
    }
}
