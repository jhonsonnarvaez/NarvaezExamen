using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NarvaezExamen.Modelos;
namespace NarvaezExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnLoguear_Clicked(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario("estudiante2021", "uisrael2021");
            string usu = txtUsuario.Text;
            string con = txtPassword.Text;
            try
            {
                if (usu.Equals(usuario.usuario) && con.Equals(usuario.clave))
                {
                    await Navigation.PushAsync(new Registro(usuario));
                }
                else
                {
                    limpiarCampos();
                    await DisplayAlert("Mensaje", "Usuario o contraseña son incorrectos", "OK");
                }
            }
            catch (NullReferenceException n)
            {
                await DisplayAlert("Mensaje", "Llenar todos los campos", "OK");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Mensaje de advertencia", ex.Message, "OK");
            }
        }

        private void limpiarCampos()
        {
            txtUsuario.Text = "";
            txtPassword.Text = "";
        }
    }
}