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

using P1___Ap1___Julio_Cesar_20180771.UI.Consultas;
using P1___Ap1___Julio_Cesar_20180771.UI.Registro;

namespace P1___Ap1___Julio_Cesar_20180771
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
      

        private void AportesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rRegistroAportes aportes = new rRegistroAportes();
            aportes.Show();
        }

        private void ConsultaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cAportes aportes = new cAportes();
            aportes.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
