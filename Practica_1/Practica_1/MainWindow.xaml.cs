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

namespace Practica_1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Usuario administrador = new Usuario("admin","ipo1");
        private int comprobaciones = 0;
        private Boolean english;

        private BitmapImage imagCheck = new BitmapImage(new Uri("check.png", UriKind.Relative));
        private BitmapImage imagCross = new BitmapImage(new Uri("cross.png", UriKind.Relative));
        public MainWindow()
        {
            InitializeComponent();
        }

        private void contUser_KeyDown(object sender, KeyEventArgs e)
        {             
            if(comprobaciones > 0)
            {
                comprobaciones = 0;
                passCont.Password = string.Empty;
                imgCheckUser.Source = null;
                contUser.Background = Brushes.White;
                contUser.BorderBrush = default;
                passCont.IsEnabled = false;
                btnSesion.IsEnabled = false;
                
            }
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrEmpty(contUser.Text))
                {
                    passCont.IsEnabled = true;
                    passCont.Focus();
                }
                else
                {
                    if (!english)
                    {
                        lblEstado.Content = "El/los campos no pueden estar vacíos";
                    }
                    else
                    {
                        lblEstado.Content = "The field(s) cannot be empty";
                    }
                    
                }
            }
        }
        private void contUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void VentanaPrincipal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!english)
            {
                MessageBox.Show("Gracias por usar nuestra aplicación.", "Closing...");
            }
            else
            {
                MessageBox.Show("Thank you for using our app.", "Closing...");
            }
            
        }

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

                componenteEntrada.BorderBrush = Brushes.Red;
                componenteEntrada.Background = Brushes.Red;
                imagenFeedBack.Source = imagCross;
                lblEstado.Foreground = Brushes.Red;
                if (english)
                {
                    lblEstado.Content = "The data entered does not correspond to the user";
                }
                else
                {
                   lblEstado.Content = "Los datos introducidos no corresponden con el usuario";
                }
                
                comprobaciones++;
                valido = false;
            }
            return valido;
        }

        private void lblOlvido_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Olvido_Cont ventanaOlvido = new Olvido_Cont(administrador);
            ventanaOlvido.Show();
        }

        private void passCont_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                btnSesion.IsEnabled  = true;
                btnSesion.Focus();

            }
            
        }
        private async void btnSesion_Click(object sender, RoutedEventArgs e)
        {
            if (ComprobarEntrada(contUser.Text, administrador.User,
            contUser, imgCheckUser) &&
            ComprobarEntrada(passCont.Password, administrador.Password,
            passCont, imgCheckCont))
            {
                lblEstado.Foreground = Brushes.Green;
                if (!english)
                {
                    lblEstado.Content = "Bienvenido, usuario " + administrador.User;
                }
                else
                {
                    lblEstado.Content = "Welcome back, "+ administrador.User;
                }
                
                await Task.Delay(1000);
                this.Hide();
                
                Principal vPrincipal = new Principal();
                vPrincipal.Show();
            }
        }
        private void passCont_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(passCont.Password))
            btnSesion.IsEnabled = true;
        }


        private void Idioma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Idioma.SelectedItem.Equals(English))
            {
                english = true;
                lblusuario.Content = "Username";
                lblCont.Content = "Password";
                lblEstado.Content = "Welcome, enter username and password";
                lblOlvido.Content = "Forgot your password?";
                btnSesion.Content = "Login";
            }
            else
            {
                english = false;
                lblusuario.Content = "Usuario";
                lblCont.Content = "Contraseña";
                lblEstado.Content = "Bienvenido, introduzca nombre y contraseña";
                lblOlvido.Content = "¿Olvidó su contraseña?";
                btnSesion.Content = "Iniciar Sesión";
            }
        }

        private void imagenIdioma_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}