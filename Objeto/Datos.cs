using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Objeto
{
    public class Datos
    {
        Conexión conec = new Conexión();
        //lista de productos
        public DataTable  ProductosListar()
        {
            using (SqlDataAdapter da = new SqlDataAdapter
                ("Usp_ListaProductos", conec.LeerDatos()))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                using (DataTable dt = new DataTable())
                {
                    da.Fill(dt);
                    return dt;
                }
            }
        }


        public void CargarLista(ComboBox cboprov, ComboBox cbocat)
        {
            SqlDataAdapter dap = new SqlDataAdapter("Usp_Proveedores",conec.LeerDatos());
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable tb = new DataTable();
            dap.Fill(tb);
            cboprov.DataSource = tb;
            cboprov.DisplayMember = "NombreCompañia";
            cboprov.ValueMember = "IdProveedor";

            dap.SelectCommand.CommandText = "usp_Categorias";
            DataTable tb1 = new DataTable();
            dap.Fill(tb1);
            cbocat.DataSource = tb1;
            cbocat.DisplayMember = "NombreCategoria";
            cbocat.ValueMember = "IdCategoria";
        }

        public void ProductoRegistrar(Productos reg)
        {
            SqlCommand cmd = new SqlCommand("UspInsertarProducto");
            cmd.Connection = conec.LeerDatos();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", reg.Nombre);
            cmd.Parameters.AddWithValue("@proveedor", reg.IdProveedor);
            cmd.Parameters.AddWithValue("@categoria", reg.IdCategoria);
            cmd.Parameters.AddWithValue("@precio", reg.Precio);
            cmd.Parameters.AddWithValue("@stock", reg.Cantidad);
            cmd.Parameters.AddWithValue("@activo", reg.Activo);
            cmd.Parameters.Add("@idcodigo", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
            reg.codigo = Convert.ToInt32(cmd.Parameters["@idcodigo"].Value);
        }

        public void ActualizarRegistrar(Productos reg)
        {
            SqlCommand cmd = new SqlCommand("UspIActualizarProducto");
            cmd.Connection = conec.LeerDatos();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", reg.Nombre);
            cmd.Parameters.AddWithValue("@proveedor", reg.IdProveedor);
            cmd.Parameters.AddWithValue("@categoria", reg.IdCategoria);
            cmd.Parameters.AddWithValue("@precio", reg.Precio);
            cmd.Parameters.AddWithValue("@stock", reg.Cantidad);
            cmd.Parameters.AddWithValue("@activo", reg.Activo);
            cmd.Parameters.AddWithValue("@idcodigo", reg.codigo);
        }

        public void EliminarRegistro(Productos reg)
        {
            SqlCommand cmd = new SqlCommand("Usp_EliminarProducto");
            cmd.Connection = conec.LeerDatos();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idproducto", reg.codigo);
        }

        public DataTable Productolistar(int cod)
        {
            SqlDataAdapter da = new SqlDataAdapter("Usp_BuscarProducto", conec.LeerDatos());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@idproducto", cod);
            DataTable tb = new DataTable();
            da.Fill(tb);
            return tb;
        }

        public DataTable Productolistar()
        {
            SqlDataAdapter cmd = new SqlDataAdapter("Usp_ListaProductos", conec.LeerDatos());
            DataTable tb = new DataTable();
            cmd.Fill(tb);
            return tb;
        }

    }
   
}
