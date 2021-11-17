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

namespace Eventos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtUsuario_keyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                lblEstado.Content = "Se pulsó el enter ";
                if (!String.IsNullOrEmpty(txtUsuario.Text)
                && ComprobarEntrada(txtUsuario.Text, usuario,
                txtUsuario, imagCheckUsuario))
                {
                    // habilitar entrada de contraseña y pasarle el foco
                    passContrasena.IsEnabled = true;
                    passContrasena.Focus();
                    // deshabilitar entrada de login
                    txtUsuario.IsEnabled = false;
                }
            }
        }

        private void diseñoPrincipal_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            lblEstado.Content = "Coordenadas del click: (" + p.X + ", " + p.Y + ")";
        }

        private void passContrasena_KeyUp(object sender, KeyEventArgs e)
        {
            lblEstado.Content = "Has pulsado la tecla <<" + e.Key.ToString() + ">>";
            if (ComprobarEntrada(passContrasena.Password, password,
            passContrasena, imagCheckContrasena))
                btnLogin.Focus();
        }

        private void VentanaPrincipal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Gracias por usar nuestra aplicación...", "Despedida");
        }
        private string usuario = "admin";
        private string password = "ipo1";

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Si no se ha introducido el login
            if (String.IsNullOrEmpty(txtUsuario.Text)
            || String.IsNullOrEmpty(passContrasena.Password))
            {
                // feedback al usuario
                lblEstado.Foreground = Brushes.Red;
                lblEstado.Content = "Introduzca el usuario y la contraseña";
            }
            else
            {
                if (txtUsuario.Text.Equals(usuario)
                && passContrasena.Password.Equals(password))
                {
                    Application.Current.Shutdown();
                }
                else
                {
                    // feedback al usuario
                    lblEstado.Foreground = Brushes.Red;
                    lblEstado.Content = "Combinación usuario-contraseña incorrecta";
                }
            }
        }

        private BitmapImage imagCheck = new BitmapImage(new Uri("/imagenes/check.png", UriKind.Relative));
        private BitmapImage imagCross = new BitmapImage(new Uri("/imagenes/cross.png", UriKind.Relative));
        private Boolean ComprobarEntrada(string valorIntroducido, string valorValido,
Control componenteEntrada, Image imagenFeedBack)
        {
            Boolean valido = false;
            componenteEntrada.BorderThickness = new Thickness(2);
            if (valorIntroducido.Equals(valorValido))
            {
                // borde y background en verde
                componenteEntrada.BorderBrush = Brushes.Green;
                componenteEntrada.Background = Brushes.LightGreen;
                // imagen al lado de la entrada de usuario --> check
                imagenFeedBack.Source = imagCheck;
                valido = true;
            }
            else
            {
                // marcamos borde en rojo
                componenteEntrada.BorderBrush = Brushes.Red;
                // imagen al lado de la entrada de usuario --> cross
                imagenFeedBack.Source = imagCross;
                valido = false;
            }
            return valido;
        }
    }
}
