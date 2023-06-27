using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TP_final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void botonLimpiar(object sender, RoutedEventArgs e)
        {
             _numeroOperador1 = 0;
             _numeroOperador2 = 0;
             _numeroTexto1 = "";
             _numerotexto2 = "";
             _resultado = "";
             _operador = "";
             pantalla.Text = "0";

        }

        private void botonNumeros(object sender, RoutedEventArgs e)
        {
                Button btn = sender as Button;

            if (_operador == "" && _numerotexto2 == "")
            {
                _numeroTexto1 = _numeroTexto1 + (string)btn.Content;
                _numeroOperador1 = double.Parse(_numeroTexto1);
                mostrarPantalla(_numeroTexto1);
            }

            else
            {
                _numerotexto2 = _numerotexto2 + (string)btn.Content;
                _numeroOperador2 = double.Parse(_numerotexto2);
                mostrarPantalla(_numeroTexto1, _numerotexto2);
            }

        }

        private void botonOperadores(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if(_operador == "" && _numerotexto2 == "")
            {
                _operador = (string)btn.Content;

                mostrarPantalla(_numeroTexto1);
            } 
        }

        private void botonSignos(object sender, RoutedEventArgs e)
        {   
            if(_operador == "")
            { 
                _numeroOperador1 = _numeroOperador1 * (-1);
                _numeroTexto1 = Convert.ToString(_numeroOperador1);
                mostrarPantalla(_numeroTexto1);
            }

            else
            {
                _numeroOperador2 = _numeroOperador2 * (-1);
                _numerotexto2 = Convert.ToString(_numeroOperador2);
                mostrarPantalla(_numeroTexto1, _numerotexto2);
            }
        }


        private void botonPunto(object sender, RoutedEventArgs e)
        {
            if(_operador == "" && _numeroTexto1 != "" && _numeroOperador1 % 1 == 0)
            {
                _numeroTexto1 = _numeroTexto1 + ",";
                mostrarPantalla(_numeroTexto1);
             
            }

            if(_operador != "" && _numerotexto2 != "" && _numeroOperador2 % 1 == 0)
            {
                _numerotexto2 = _numerotexto2 + ",";
                mostrarPantalla(_numeroTexto1, _numerotexto2);
            }

            
        }


        private void botonIgual(object sender, RoutedEventArgs e)
        {
            if (_operador != "")
            {
                switch (_operador) 
                {
                    case "+":
                        _resultado = Convert.ToString(_numeroOperador1 + _numeroOperador2);
                        break;

                    case "-":
                        _resultado = Convert.ToString(_numeroOperador1 - _numeroOperador2);
                        break;

                    case "x":
                        _resultado = Convert.ToString(_numeroOperador1 * _numeroOperador2);
                        break;

                    case "/":
                        _resultado = Convert.ToString(_numeroOperador1 / _numeroOperador2);
                        break;
                }
            }

            _numeroTexto1 = _resultado;
            _numeroOperador1 = double.Parse(_numeroTexto1);

            _numerotexto2 = "";
            _numeroOperador2 = 0;
            _operador = "";
            _resultado = "";

            mostrarPantalla(_numeroTexto1, _numerotexto2);
        }

        private void mostrarPantalla(object numero, object numero2 = null)
        {
            if(_resultado == "")
            { 
                if(_operador == "")
                {
                    pantalla.Text = Convert.ToString(numero);
                }
                else
                {
                    pantalla.Text = "("+ Convert.ToString(numero) +") " + _operador +" (" + Convert.ToString(numero2) +")";
                }
            }

            else
            {
                pantalla.Text = "Ressultado = " + _resultado;
            }
        }

        private double _numeroOperador1 = 0;
        private double _numeroOperador2 = 0;
        private string _numeroTexto1 = "";
        private string _numerotexto2 = "";
        private string _resultado = "";
        private string _operador = "";


    }
}
