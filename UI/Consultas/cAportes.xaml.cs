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
using P1___Ap1___Julio_Cesar_20180771.BLL;
using P1___Ap1___Julio_Cesar_20180771.Entidades;

namespace P1___Ap1___Julio_Cesar_20180771.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cAportes.xaml
    /// </summary>
    public partial class cAportes : Window
    {
        public cAportes()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Aportes>();
            if (BusquedaTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = AporteBLL.GetList(e => e.Persona.ToLower().Contains(BusquedaTextBox.Text.ToLower()));
                        break;
                    case 1:
                        listado = AporteBLL.GetList(e => e.Concepto.ToLower().Contains(BusquedaTextBox.Text.ToLower()));
                        break;

                }
            }
            else
            {
                listado = AporteBLL.GetList(c => true);
            }

            if (FechaDesdeDatePicker.SelectedDate != null)
                listado = AporteBLL.GetList(c => c.Fecha.Date >= FechaDesdeDatePicker.SelectedDate);

            if (FechaHastaDatePicker.SelectedDate != null)
                listado = AporteBLL.GetList(c => c.Fecha.Date <= FechaHastaDatePicker.SelectedDate);

            var monto = listado.Sum(x => x.Monto);

            var conteo = listado.Count();

            TotalTextBlock.Text = monto.ToString();

            MontoTextBlock.Text = conteo.ToString();

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
