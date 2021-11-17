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
using System.Windows.Shapes;

namespace Practica_1
{
    /// <summary>
    /// Lógica de interacción para Olvido_Cont.xaml
    /// </summary>
    public partial class Olvido_Cont : Window
    {
        MainWindow ventanaPrincipal = new MainWindow();
        Usuario user;
        public Olvido_Cont(Usuario admin)
        {
            InitializeComponent();
            user = admin;
        }

        private void compUser_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Return) 
            {
                if (compUser.Text.Equals(user.User))
                {
                    pedirCont.Visibility = 0;
                    Nuevacont.Visibility = 0;
                    Nuevacont.Focus();
                }
                else
                {
                    MessageBox.Show("El usuario no existe", "Advertencia");
                    compUser.Text = string.Empty;
                }
            }
        }

        private void compUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Nuevacont_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        private void Nuevacont_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void Nuevacont_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                user.Password=Nuevacont.Text;
                btn_cambiar.IsEnabled = true;
                btn_cambiar.Focus();
            }

        }

        private void btn_cambiar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MessageBox.Show("La contraseña se cambió con éxito", "Cambio de contraseña");
        }
    }
}
