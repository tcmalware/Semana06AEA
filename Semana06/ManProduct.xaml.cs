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
    /// Lógica de interacción para ManProduct.xaml
    /// </summary>
    public partial class ManProduct : Window
    {
        public int id { get; set; }
        public ManProduct(int id)
        {
            InitializeComponent();
            btnBorrar.Visibility = Visibility.Hidden;
            id = id;
            if (id > 0)
            {
                btnBorrar.Visibility = Visibility.Visible;
                BProduct bProduct = new BProduct();
                List<Product> product = new List<Product>();
                product = bProduct.Listar(id);
                if (product.Count > 0)
                {
                    lblID.Content = product[0].id.ToString();
                    txtNombre.Text = product[0].nombre;
                    txtPrecio.Text = product[0].precio.ToString();
                }
            }
        }

        private void BtnGrabar_Click(object sender, RoutedEventArgs e)
        {
            BProduct Bproduct = null;
            bool result = true;
            try
            {
                Bproduct = new BProduct();
                if (id > 0)
                    result = Bproduct.Actualizar(new Product { id = id, nombre = txtNombre.Text, precio = Convert.ToDouble(txtPrecio.Text) });
                else
                    result = Bproduct.Insertar(new Product { nombre = txtNombre.Text, precio = Convert.ToDouble(txtPrecio.Text) });

                if (!result)
                    MessageBox.Show("Comunicarse con el Administrador");

                Close();
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

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnBorrar_Click(object sender, RoutedEventArgs e)
        {
            BProduct Bproduct = null;
            bool result = true;
            try
            {
                Bproduct = new BProduct();
                result = Bproduct.Eliminar(id);
                if (!result)
                    MessageBox.Show("Comunicarse con el Administrador");

                Close();
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
    }
}
