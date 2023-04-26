using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace froldanExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public Registro(string user)
        {
            InitializeComponent();

            //txtuser.Text = user;
            string mensaje = "Usuario conectado: " + user;
            labelMensaje.Text = mensaje;
        }

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            double vinicial, cmatricula, vpe, vpc, costoPorCurso, porcentaje;
            cmatricula = 3000;
            if (double.TryParse(valorinicial.Text, out vinicial))
            {
                if (vinicial >= 0.1 && vinicial <= 3000)
                {
                    vpe = cmatricula - vinicial;
                    costoPorCurso = vpe / 3;
                    porcentaje = (costoPorCurso * 1.05)-costoPorCurso;
                    vpc = costoPorCurso + porcentaje;


                    txtDatoresultado.Text = vpc.ToString();

                    DisplayAlert("Estado de Cuenta", "Su cuota mensual es: " + vpc.ToString("C2"), "Cerrar");
                }
                else
                {
                    DisplayAlert("Error", "Los números ingresados deben estar en el rango de 0.1 a 3000", "Cerrar");
                }
            }
            else
            {
                DisplayAlert("Error", "Ingrese números válidos en todos los campos", "Cerrar");
            }
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            string usuario = "estudiante2023";
            string nombre = txtname.Text;
            double total = 3000 * 1.05;
            string resultado=Convert.ToString(total);
            DisplayAlert("Elemento guardado con éxito", "Su nombre es: " + nombre , "Cerrar");


            Navigation.PushAsync(new Resumen(usuario, nombre,resultado));

        }
    }
}