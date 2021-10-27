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
    public partial class Registro : ContentPage
    {
        public Registro(Usuario usu)
        {
            InitializeComponent();
            lblBienvenido.Text = "Bienvenido " + usu.usuario;
        }

        private async void btnCalcular_Clicked(object sender, EventArgs e)
        {
            double montoInicial = 1800.0;
            double porcentajeCuota = 0.05;
            double monto = Convert.ToDouble(txtMontoInicial.Text);
            if (monto <= 0.0 || monto > montoInicial)
            {
                limpiarCampos();
                await DisplayAlert("Mensaje", "El monto inicial debe estar entre 1 y 1800", "OK");
            }
            else if (monto == montoInicial)
            {
                txtPagoMensual.Text = "0.00";
            }
            else
            {
                double resto = montoInicial - monto;
                double cuota = resto / 3;
                double valorMensual = cuota * porcentajeCuota;
                double pagoMensual = cuota + valorMensual;
                txtPagoMensual.Text = pagoMensual.ToString();
            }
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            string usuario = lblBienvenido.Text;
            string nombre = txtNombre.Text;
            double totalPagar = Convert.ToDouble(txtPagoMensual.Text) * 3;
            string valorPagar = totalPagar.ToString();
            try
            {
                if (!nombre.Equals(""))
                {

                    await Navigation.PushAsync(new Resumen(usuario, nombre, valorPagar));
                    await DisplayAlert("Mensaje", "Elemento guardado con exito", "OK");
                }
            }
            catch (Exception ex)

            {
                await DisplayAlert("Mensaje", ex.Message, "OK");
            }
        }

        private void limpiarCampos()
        {
            txtMontoInicial.Text = "";
            txtPagoMensual.Text = "";
        }
    }
}