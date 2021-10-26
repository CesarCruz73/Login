using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        ConexionDB conexion = new ConexionDB();
        Usuario user = new Usuario();

        private void AceptarButton_Click(object sender, EventArgs e)
        {

            if (UsuarioTextBox.Text == "")
            {
                errorProvider1.SetError(UsuarioTextBox, "Ingrese Usuario");
                UsuarioTextBox.Focus();
                return;
            }
            if (ContraseniaTextBox.Text == "")
            {
                errorProvider1.SetError(ContraseniaTextBox, "Ingrese Contraseña");
                ContraseniaTextBox.Focus();
                return;
            }



            user.CodigoUsuario = UsuarioTextBox.Text;
            user.Clave = ContraseniaTextBox.Text;

            bool valido = conexion.ValidarUsuario(user);

            if (valido)
            {
                ProductosForm formulario = new ProductosForm();
                this.Hide();
                formulario.Show();
                
                //MessageBox.Show("Usuario Correcto.");
            }
            else
            {
                MessageBox.Show("Datos de Usuario Incorrecto.");
            }
        }
    }
}
