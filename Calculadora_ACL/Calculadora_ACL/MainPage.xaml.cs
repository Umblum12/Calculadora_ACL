using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculadora_ACL
{
    public partial class MainPage : ContentPage
    {
        private double? valor1 = null, valor2 = null, resultado = null;
        private string operador = null;
        public MainPage()
        {
            InitializeComponent();
        }
        private void OnSelect(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if ("0123456789".Contains(button.Text) && (valor1==null || operador==null))
            {
                Pantalla.Text += button.Text;
                valor1 = Convert.ToDouble(Pantalla.Text);
            }
            else if ("0123456789".Contains(button.Text) && (valor2 == null || operador != null))
            {
                Pantalla.Text += button.Text;
                valor2 = Convert.ToDouble(Pantalla.Text);
            }
            else if ("%+-*÷".Contains(button.Text) && valor1 != null)
            {
               operador = button.Text;
               valor1 = Convert.ToDouble(Pantalla.Text);
               Pantalla.Text = null;
            }
            else if ("AC".Contains(button.Text))
            {
                valor1 = null;
                valor2 = null;
                operador = null;
                resultado = null;
                Pantalla.Text = null;
            }
            else if ("←".Contains(button.Text) && (Pantalla.Text.Length != 0))
            {
                Pantalla.Text = Pantalla.Text.Substring(0, Pantalla.Text.Length - 1);
            }
            else if (",".Contains(button.Text) && valor1 != null)
            {
                Pantalla.Text += button.Text;
            }
            else if ("%".Contains(button.Text) && valor1 != null)
            {
                operador = button.Text;
                valor1 = Convert.ToDouble(Pantalla.Text);
                Pantalla.Text = null;
            }
            else
            {
                calcular(valor1, valor2, operador);
                calcular1(valor1, operador);
            }
        }
        public void calcular(double? v1, double? v2, string op)
        {
            switch (op)
            { 
                case "÷":
                    if (v2 != 0)
                    {
                        resultado = v1 / v2;
                        Pantalla.Text = resultado.ToString();
                        valor1 = resultado;
                        valor2 = null;
                    }
                    else
                    {
                        Pantalla.Text = "Error";
                    }
                    break;
                case "*":
                    resultado = v1 * v2;
                    Pantalla.Text =  resultado.ToString();
                    valor1 = resultado;
                    valor2 = null;
                    break;
                case "-":
                    resultado = v1 - v2;
                    Pantalla.Text = resultado.ToString();
                    valor1 = resultado;
                    valor2 = null;
                    break;
                case "+":
                    resultado = v1 + v2;
                    Pantalla.Text =  resultado.ToString();
                    valor1 = resultado;
                    valor2 = null;
                    break;
                default:
                    break;
            }
        }
        public void calcular1(double? v1, string op)
        {
            switch (op)
            {
                case "%":
                    resultado = v1 / 100;
                    Pantalla.Text = resultado.ToString();
                    valor1 = resultado;
                    break;
                default:
                    break;
            }
        }
    }
}
