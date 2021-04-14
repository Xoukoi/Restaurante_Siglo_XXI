using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_Siglo_XXI_Totem
{
    public partial class CrudStock : Form
    {
        public CrudStock()
        {
            InitializeComponent();

            ora.Open();
            OracleCommand comando = new OracleCommand("SELECT R.ID_ROL,R.TIPO_ROL FROM USUARIO U,ROL R WHERE U.ROL_ID_ROL=R.ID_ROL ", ora);
            OracleDataReader lector = comando.ExecuteReader();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button3.Visible = true;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            dataGridView1.Visible = false;
            ora.Close();
        }

        //String de Conexión
        OracleConnection ora = new OracleConnection("PASSWORD=123;USER ID= ANGEL;");

        //Método Agregar Productos
        private void Button9_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            button4.Enabled = false;
            button7.Enabled = false;
            button9.Enabled = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            ora.Open();
            OracleCommand comando = new OracleCommand("AGREGARPRODUCTO", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("IDPRODUCTO", OracleType.Number).Value = Convert.ToInt32(textBox1.Text);
            comando.Parameters.Add("STOCK", OracleType.Number).Value = Convert.ToInt32(textBox2.Text);
            comando.Parameters.Add("TIPOPRODUCTO", OracleType.Char).Value = textBox3.Text;
            comando.Parameters.Add("UNIDADMEDIDAID", OracleType.Number).Value = Convert.ToInt32(textBox4.Text);
            comando.ExecuteNonQuery();
            MessageBox.Show("Producto Agregado");
            ora.Close();
        }
        //Método Editar Producto
        private void Button4_Click(object sender, EventArgs e)
        {

            ora.Open();
            OracleCommand comando = new OracleCommand("MODIFICARPRODUCTO", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("IDPRODUCTO", OracleType.Number).Value = Convert.ToInt32(textBox1.Text);
            comando.Parameters.Add("STOCK", OracleType.Number).Value = Convert.ToInt32(textBox2.Text);
            comando.Parameters.Add("TIPOPRODUCTO", OracleType.Char).Value = textBox3.Text;
            comando.Parameters.Add("UNIDADMEDIDAID", OracleType.Number).Value = Convert.ToInt32(textBox4.Text);
            comando.ExecuteNonQuery();
            MessageBox.Show("Producto Actualizado");
            button3.Visible = true;
            button4.Enabled = false;
            button7.Enabled = false;
            button9.Enabled = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            ora.Close();
        }
        //Método Eliminar Productos
        private void Button7_Click(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand comando = new OracleCommand("ELIMINARPRODUCTO", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("IDPRODUCTO", OracleType.Number).Value = Convert.ToInt32(textBox1.Text);
            comando.ExecuteNonQuery();
            MessageBox.Show("Producto Eliminado");
            ora.Close();
            button3.Visible = true;
            button4.Enabled = false;
            button7.Enabled = false;
            button9.Enabled = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            
        }
        //Método Listar Productos
        private void Button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            ora.Open();
            OracleCommand comando = new OracleCommand("LISTARPRODUCTO", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("REG", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            dataGridView1.DataSource = tabla;
            ora.Close();
            button3.Visible = false;
            button5.Visible = true;
            button6.Visible = true;
            button8.Visible = true;
            
        }
        
        //Cargar Botones Añadir
        private void Button8_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            button3.Visible = true;
            button4.Enabled = false;
            button7.Enabled = false;
            button9.Enabled = true;
            button4.Visible = true;
            button7.Visible = true;
            button9.Visible = true;
        }

        //Cargar Botones Modificar
        private void Button6_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            button3.Visible = true;
            button4.Enabled = true;
            button7.Enabled = false;
            button9.Enabled = false;
            button4.Visible = true;
            button7.Visible = true;
            button9.Visible = true;
        }
        //Cargar Botones Eliminar
        private void Button5_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button3.Visible = true;
            button4.Enabled = false;
            button7.Enabled = true;
            button9.Enabled = false;
            button4.Visible = true;
            button7.Visible = true;
            button9.Visible = true;
        }
    }
}
