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
    /// Interaction logic for CreateGroup.xaml
    /// </summary>
    public partial class CreateGroup : Window
    {
        private Thesis Thesis;
        private Student Student;
        public CreateGroup(Thesis thesis, Student student)
        {
            InitializeComponent();
            Thesis = thesis;
            Student = student;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            Group newGroup = new Group();
                newGroup.Name = inputTextBox.Text.Trim();
            GroupEntity entity = new GroupEntity();
          bool success =  entity.AddGroup(newGroup, Thesis);
            if(success)
            {
                this.Close();
                RegisterThesis registerThesis  = new RegisterThesis(Thesis, Student);
                registerThesis.Show();
            } else
            {
                this.Close();
            }
        }  
        
    }
}
