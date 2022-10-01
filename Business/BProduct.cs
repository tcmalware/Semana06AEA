using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;

namespace Business
{
    public class BProduct
    {
        private DProduct DProduct = null;
        public List<Product> Listar(int id)
        {
            List<Product> product = null;
            try
            {
                DProduct = new DProduct();
                product = DProduct.Listar(new Product { id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return product;
        }
        public bool Insertar(Product product)
        {
            bool result = true;
            try
            {
                DProduct = new DProduct();
                DProduct.Insertar(product);
            }
            catch (Exception ex)
            {
                throw ex;
                result = false;
            }
            return result;
        }
        public bool Actualizar(Product product)
        {
            bool result = true;
            try
            {
                DProduct = new DProduct();
                DProduct.Actualizar(product);
            }
            catch (Exception ex)
            {
                throw ex;
                result = false;
            }
            return result;
        }
        public bool Eliminar(int id)
        {
            bool result = true;
            try
            {
                DProduct = new DProduct();
                DProduct.Eliminar(id);
            }
            catch (Exception ex)
            {
                throw ex;
                result = false;
            }
            return result;
        }
    }
}
