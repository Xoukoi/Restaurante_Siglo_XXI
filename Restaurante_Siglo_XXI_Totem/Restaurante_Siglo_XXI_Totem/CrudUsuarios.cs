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
    public partial class CrudUsuarios : Form
    {
        public CrudUsuarios()
        {
            InitializeComponent();
           
            ora.Open();
            OracleCommand comando = new OracleCommand("SELECT R.TIPO_ROL FROM USUARIO U,ROL R WHERE U.ROL_ID_ROL=R.ID_ROL ", ora);
            OracleDataReader lector = comando.ExecuteReader();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label11.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            button3.Visible = true;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            dataGridView1.Visible = false;
            ora.Close();       }

        //String de Conexión
        OracleConnection ora = new OracleConnection("PASSWORD=123;USER ID= ANGEL;");

        //Método Agregar Usuario
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
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label11.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            ora.Open();
            OracleCommand comando = new OracleCommand("AGREGARUSUARIO", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("RUT", OracleType.VarChar).Value = textBox1.Text;
            comando.Parameters.Add("NOMBRES", OracleType.VarChar).Value = textBox2.Text;
            comando.Parameters.Add("APELLIDOP", OracleType.VarChar).Value = textBox3.Text;
            comando.Parameters.Add("APELLIDOM", OracleType.VarChar).Value = textBox4.Text;
            comando.Parameters.Add("ROLIDROL", OracleType.Number).Value = Convert.ToInt32(textBox5.Text);
            comando.Parameters.Add("CORREOS", OracleType.VarChar).Value = textBox6.Text;
            comando.Parameters.Add("DIRECCIONES", OracleType.VarChar).Value = textBox7.Text;
            comando.Parameters.Add("CLAVES", OracleType.VarChar).Value = textBox8.Text;
            comando.ExecuteNonQuery();
            MessageBox.Show("Usuario Agregado");
            ora.Close();
        }
        //Método Editar Usuario
        private void Button4_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            button4.Enabled = false;
            button7.Enabled = false;
            button9.Enabled = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label11.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            ora.Open();
            OracleCommand comando = new OracleCommand("MODIFICARUSUARIO", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("RUT", OracleType.VarChar).Value = textBox1.Text;
            comando.Parameters.Add("NOMBRES", OracleType.VarChar).Value = textBox2.Text;
            comando.Parameters.Add("APELLIDOP", OracleType.VarChar).Value = textBox3.Text;
            comando.Parameters.Add("APELLIDOM", OracleType.VarChar).Value = textBox4.Text;
            comando.Parameters.Add("ROLIDROL", OracleType.Number).Value = Convert.ToInt32(textBox5.Text);
            comando.Parameters.Add("CORREOS", OracleType.VarChar).Value = textBox6.Text;
            comando.Parameters.Add("DIRECCIONES", OracleType.VarChar).Value = textBox7.Text;
            comando.Parameters.Add("CLAVES", OracleType.VarChar).Value = textBox8.Text;
            comando.ExecuteNonQuery();
            MessageBox.Show("Usuario Actualizado");
            ora.Close();
        }
        //Método Eliminar Usuario
        private void Button7_Click(object sender, EventArgs e)
        {
            ora.Open();
            OracleCommand comando = new OracleCommand("ELIMINARUSUARIO", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("RUT", OracleType.VarChar).Value = textBox1.Text;
            comando.ExecuteNonQuery();
            MessageBox.Show("Usuario Eliminado");
            ora.Close();
            button3.Visible = true;
            button4.Enabled = false;
            button7.Enabled = false;
            button9.Enabled = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label11.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
        }
        //Método Listar Usuario
        private void Button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            ora.Open();
            OracleCommand comando = new OracleCommand("LISTARUSUARIO", ora);
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
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label11.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
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
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label11.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
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
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label11.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            button3.Visible = true;
            button4.Enabled = false;
            button7.Enabled = true;
            button9.Enabled = false;
            button4.Visible = true;
            button7.Visible = true;
            button9.Visible = true;
        }

        private void CrudUsuarios_Load(object sender, EventArgs e)
        {

        }
    }
}
