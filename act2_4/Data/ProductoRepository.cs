using act2_4.Domain;

namespace act2_4.Data
{
    public interface IProductoRepository
    {
        List<Producto> GetAll();
        void AddProduct(Producto producto);
        void EditProduct(Producto producto);
        bool DeleteProduct(int id);
        Producto GetById(int id);

    }
    public class ProductoRepository : IProductoRepository
    {
        private static readonly List<Producto> _products = new List<Producto>();
        public ProductoRepository() { }

        public List<Producto> GetAll()
        {
            return _products;
        }
        public Producto GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);

        }
        public void AddProduct(Producto producto)
        {
            _products.Add(producto);
        }
        public void EditProduct(Producto producto)
        {
            //var prod = _products.FirstOrDefault(p => p.Id == producto.Id);
            //prod.Nombre = producto.Nombre;
            //prod.Precio = producto.Precio;
            /////////////
            var index = _products.FindIndex(p => p.Id == producto.Id);
            _products[index] = producto;



        }
        public bool DeleteProduct(int id)
        {
            var index = _products.FindIndex(p => p.Id == id);
            _products.RemoveAt(index);
            /////
            // var prod = _products.FirstOrDefault(p => p.Id == id);
            //_products.Remove(prod);
            return true;

        }
    }
}


////

//// web => api
///cliente / servidor
/// ------/ controller <=> service <=> repository <=> DataHelper / ProjectDbContext (base de datos)


///1.crear factura y obtener el id en el FacturaRepository inician la transaccion => try&catch
///2.Una vez que tiene el id, van a llamar a detalleRepository, addDetalle(List<DetalleFactura> df,int facturaId)
///3. detalleRepository.addDetalle iteren cada detalle y le asignel la facturaId, tambien agregar un try&catch
///4.Guardan como siempre

//////
///

