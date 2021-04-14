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
    public partial class CrudProveedor : Form
    {
        public CrudProveedor()
        {
            InitializeComponent();
            ora.Open();
            OracleCommand comando = new OracleCommand("SELECT * FROM PROVEEDOR ", ora);
            OracleDataReader lector = comando.ExecuteReader();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
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
        //Método Agregar Proveedor
        private void Button9_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            button4.Enabled = false;
            button7.Enabled = false;
            button9.Enabled = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            ora.Open();
            OracleCommand comando = new OracleCommand("AGREGARPROVEEDOR", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("IDPROVEEDOR", OracleType.Number).Value = Convert.ToInt32(textBox1.Text);
            comando.Parameters.Add("TIPOPROVEEDOR", OracleType.VarChar).Value = textBox2.Text;
            comando.Parameters.Add("NOMBRES", OracleType.VarChar).Value = textBox3.Text;
            comando.ExecuteNonQuery();
            MessageBox.Show("Proveedor Agregado");
            ora.Close();
        }

        //Método Editar Proveedor
        private void Button4_Click(object sender, EventArgs e)
        {

            ora.Open();
            OracleCommand comando = new OracleCommand("MODIFICARPROVEEDOR", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("IDPROVEEDOR", OracleType.Number).Value = Convert.ToInt32(textBox1.Text);
            comando.Parameters.Add("TIPOPROVEEDOR", OracleType.VarChar).Value = textBox2.Text;
            comando.Parameters.Add("NOMBRES", OracleType.VarChar).Value = textBox3.Text;
            comando.ExecuteNonQuery();
            MessageBox.Show("Proveedor Actualizado");
            button3.Visible = true;
            button4.Enabled = false;
            button7.Enabled = false;
            button9.Enabled = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            ora.Close();
        }


        //Método Eliminar Proveedor
        private void Button7_Click(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand comando = new OracleCommand("ELIMINARPROVEEDOR", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("IDPROVEEDOR", OracleType.Number).Value = Convert.ToInt32(textBox1.Text);
            comando.ExecuteNonQuery();
            MessageBox.Show("Proveedor Eliminado");
            ora.Close();
            button3.Visible = true;
            button4.Enabled = false;
            button7.Enabled = false;
            button9.Enabled = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
        }
        //Método Listar Proveedor
        private void Button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            ora.Open();
            OracleCommand comando = new OracleCommand("LISTARPROVEEDOR", ora);
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
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
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
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
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
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button3.Visible = true;
            button4.Enabled = false;
            button7.Enabled = true;
            button9.Enabled = false;
            button4.Visible = true;
            button7.Visible = true;
            button9.Visible = true;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CrudStock form = new CrudStock();
            form.Show();
            this.Hide();
        }
    }
}
