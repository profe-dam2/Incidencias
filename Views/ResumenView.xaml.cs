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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Incidencias.Views
{
    /// <summary>
    /// Lógica de interacción para ResumenView.xaml
    /// </summary>
    public partial class ResumenView : UserControl
    {
        public ResumenView()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Fecha1.Visibility = Visibility.Visible;
            Fecha2.Visibility = Visibility.Visible;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Fecha1.Visibility = Visibility.Collapsed;
            Fecha2.Visibility = Visibility.Collapsed;
        }
    }
}
