using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_Siglo_XXI_Totem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        //String de Conexión
        OracleConnection ora = new OracleConnection("PASSWORD=123;USER ID= ANGEL;");
        private void Button1_Click(object sender, EventArgs e)
        {

            ora.Open();
            OracleCommand comando = new OracleCommand("SELECT * FROM USUARIO U,ROL R WHERE U.ROL_ID_ROL=R.ID_ROL AND CORREO=:correo AND CLAVE=:clave", ora);
            comando.Parameters.AddWithValue(":correo", textBox1.Text);
            comando.Parameters.AddWithValue(":clave", textBox2.Text);
            OracleDataReader lector = comando.ExecuteReader();
            if (lector.Read())
            {
                
                if (lector["TIPO_ROL"].ToString()=="ADMINISTRADOR") {
                    MenuAdmin form = new MenuAdmin();
                    form.Show();
                    this.Hide();

                }

                if (lector["TIPO_ROL"].ToString()=="CLIENTE")
                {
                }
                if (lector["TIPO_ROL"].ToString() == "BODEGA")
                {
                    CrudStock form = new CrudStock();
                    form.Show();
                    this.Hide();
                }
                if (lector["TIPO_ROL"].ToString() == "FINANZA")
                {
                     
                }
                if (lector["TIPO_ROL"].ToString() == "CAJERO")
                {
                }
                if (lector["TIPO_ROL"].ToString() == "GARZON")
                {
                    CrudMesas form = new CrudMesas();
                    form.Show();
                    this.Hide();
                }
                if (lector["TIPO_ROL"].ToString() == "REPARTIDOR")
                {
                     
                }
                ora.Close();
                
            }
            

        }
    }
}
