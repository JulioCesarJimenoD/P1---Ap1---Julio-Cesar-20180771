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
using P1___Ap1___Julio_Cesar_20180771.Entidades;
using P1___Ap1___Julio_Cesar_20180771.BLL;

namespace P1___Ap1___Julio_Cesar_20180771.UI.Registro
{
    /// <summary>
    /// Interaction logic for rRegistroAportes.xaml
    /// </summary>
    public partial class rRegistroAportes : Window
    {
        public rRegistroAportes()
        {
            InitializeComponent();
        }
        private Aportes aportes = new Aportes();
        private void Limpiar()
        {
            this.aportes = new Aportes();
            this.DataContext = aportes;
        }

        public class DateFormat : System.Windows.Data.IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value == null) return null;

                return ((DateTime)value).ToString("dd/MM/yyyy");
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        private bool Validar()
        {
            bool valido = true;

            if (AporteIDTextBox.Text.Length == 0)
            {
                valido = false;
                MessageBox.Show("Campos vacios. Ingrese Id.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            if (FechaDate.Text.Length == 0)
            {
                valido = false;
                MessageBox.Show("Campos vacios. Selecione una fecha.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            if (PersonaTextBox.Text.Length == 0)
            {
                valido = false;
                MessageBox.Show("Campos vacios. Ingrese una Persona.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            if (ConceptoTextBox.Text.Length == 0)
            {
                valido = false;
                MessageBox.Show("Campos vacios. Ingrese un concepto.", "Error",MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            if (MontoTextBox.Text.Length == 0)
            {
                valido = false;
                MessageBox.Show("Campos vacios. Ingrese un monto.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            return valido;
        }

            private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var aporte = AporteBLL.Buscar(UtilidadesBLL.ToInt(AporteIDTextBox.Text));
            if (aporte != null)
            {
                this.aportes = aporte;
            }
            else
            {
                this.aportes = new Aportes();
                MessageBox.Show("No se ha Encontrado", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            this.DataContext = this.aportes;
        }

        private void NuevoButto_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (AporteBLL.Eliminar(UtilidadesBLL.ToInt(AporteIDTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;
            var paso = AporteBLL.Guardar(aportes);
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
