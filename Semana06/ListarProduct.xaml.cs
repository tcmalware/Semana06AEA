using Business;
using Entity;
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

namespace Semana06
{
    /// <summary>
    /// Lógica de interacción para ListarProduct.xaml
    /// </summary>
    public partial class ListarProduct : Window
    {
        public ListarProduct()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            Cargar();
        }
        private void Cargar()
        {
            BProduct Bproduct = null;
            try
            {
                Bproduct = new BProduct();
                if (txtId.Text == "")
                    dgvProducto.ItemsSource = Bproduct.Listar(0);
                else
                    dgvProducto.ItemsSource = Bproduct.Listar(Convert.ToInt32(txtId.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Comunicarse con el Administrador" + ex);
            }
            finally
            {
                Bproduct = null;
            }
        }
        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            ManProduct manProduct = new ManProduct(0);
            manProduct.ShowDialog();
            Cargar();
        }

        private void DgvProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id;
            var item = (Product)dgvProducto.SelectedItem;
            if (null == item) return;
            id = Convert.ToInt32(item.id);
            ManProduct manProduct = new ManProduct(id);
            manProduct.ShowDialog();
            Cargar();
        }
    }
}
