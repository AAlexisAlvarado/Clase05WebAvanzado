using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Objeto;

namespace Clase_02
{
    public partial class Form1 : Form
    {
        //definir la clase 
        Datos obj = new Datos();


        public Form1()
        {
            InitializeComponent();
        }
       

    


        
        private void Form4_Load(object sender, EventArgs e)
        {
            dgdProducto.DataSource = obj.ProductosListar();

        }

        Productos xreg = new Productos();
        private void btnGrabar_Click(object sender, EventArgs e)
        {

            //asignar valores a las propiedades
            xreg.Nombre = txtDescripcion.Text;
            xreg.Activo = chkSuspendido.Checked;
            xreg.Cantidad = Convert.ToInt32(numCantidad.Value);
            xreg.IdProveedor = Convert.ToInt32(cboProveedor.SelectedItem);
            xreg.IdCategoria = Convert.ToInt32(cboCategoria.SelectedItem);
            xreg.Precio = Convert.ToDecimal(txtPrecio.Text);
            obj.ProductoRegistrar(xreg);
            txtIdProducto.Text = xreg.codigo.ToString();

            dgdProducto.DataSource = obj.ProductosListar();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
       
            
        }

        private void chkSuspendido_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        DataTable dt = new DataTable();
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                dt = obj.ProductoListar(Convert.ToInt32(txtBuscar.Text));
                if (dt.Rows.Count>0)
                {
                    txtIdProducto.Text = dt.Rows[0][0].ToString();
                    txtDescripcion.Text = dt.Rows[0][1].ToString();
                    cboProveedor.SelectedValue = dt.Rows[0][2].ToString();
                    cboCategoria.SelectedValue = dt.Rows[0][3].ToString();
                    txtPrecio.Text = dt.Rows[0][4].ToString();
                    numCantidad.Value = Convert.ToDecimal(dt.Rows[0][6]);
                    if (dt.Rows[0][9].Equals("1"))
                    {
                        chkSuspendido.
                    }

                }else
                {
                    MessageBox.Show("Ingresar Codigo");
                }
            }
            
           

            
            
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
             
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
           
        
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void dgdProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgdProducto_DoubleClick(object sender, EventArgs e)
        {
             
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        
    }
}
