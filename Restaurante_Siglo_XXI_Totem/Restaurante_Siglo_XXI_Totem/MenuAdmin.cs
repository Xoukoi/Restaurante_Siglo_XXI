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
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            CrudUsuarios form = new CrudUsuarios();
            form.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            CrudStock form = new CrudStock();
            form.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            CrudMesas form = new CrudMesas();
            form.Show();
            this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            CrudProveedor form = new CrudProveedor();
            form.Show();
            this.Hide();
        }
    }
}
