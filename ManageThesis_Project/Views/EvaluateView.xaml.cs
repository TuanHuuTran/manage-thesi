using ManageThesis_Project.Entity;
using ManageThesis_Project.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging; 
using System.Windows.Shapes;
using PointModal = ManageThesis_Project.Modal.Point;


namespace ManageThesis_Project.Views
{
    /// <summary>
    /// Interaction logic for EvaluateView.xaml
    /// </summary>
    public partial class EvaluateView : Window
    {
        TaskEntity taskEntity = new TaskEntity();
        PointEntity pointEntity = new PointEntity();
        ThesisEntity thesisEntity = new ThesisEntity(); 
        private float? scores;
        private Thesis Thesis;
        public EvaluateView(Thesis thesis)
        {
            InitializeComponent();
            Thesis = thesis;
            loadThesis();
            scores = Evaluate();
            txtScores.Text = scores.ToString();
            lblTotalScore.Content = "Total score across Tasks: " + scores.ToString();

        }

        public void loadThesis()
        {
            Thesis = thesisEntity.GetThesis(Thesis.ThesisId);
            List<Thesis> listthesis = new List<Thesis>();
            if (Thesis != null)
            {
                listthesis.Add(Thesis);
            }
            ItemsControl1.ItemsSource = listthesis;

        }

        public float Evaluate() {
            scores = 0;
            if (Thesis != null)
            {
                scores = taskEntity.CalculateAverageTaskPointsByThesisId(Thesis.ThesisId);
            }
            return scores.GetValueOrDefault();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageTextBox.Text;
           
            if (scores.HasValue)
            {
                float value = scores.Value;
                PointModal point = new PointModal
                {
                    Scores = value,
                    Result = message,
                    ThesisId = Thesis.ThesisId
                };
                pointEntity.AddPoint(point);
                MessageTextBox.Text = "";
            }
            else
            {
                return;
            }

            MessageTextBox.Text = "";
            this.Close();
        }

       
    }
}
