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
using PointModal = ManageThesis_Project.Modal.Point;

namespace ManageThesis_Project.Views
{
    /// <summary>
    /// Interaction logic for checkingPoint.xaml
    /// </summary>
    public partial class checkingPoint : Window
    {
        private Thesis Thesis;
        private PointModal PointModal;
        public checkingPoint(Thesis thesis)
        {
            InitializeComponent();
            Thesis = thesis;
            loadPoint();
        }
        public void loadPoint()
        {
            PointEntity entity = new PointEntity();
            PointModal = entity.GetPoint(Thesis.ThesisId);

            List<PointModal> listpoint = new List<PointModal>();
            if (PointModal != null)
            {
                listpoint.Add(PointModal);
            }

            ItemsControl1.ItemsSource = listpoint;
        }


    }
}
