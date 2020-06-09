using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using _2do_Usuario.BLL;
using _2do_Usuario.Entidades;

namespace _2do_Usuario.UI.Registros
{
    /// <summary>
    /// Interaction logic for rUsuarios.xaml
    /// </summary>
    public partial class rUsuarios : Window
    {
        Usuarios Usuario = new Usuarios();
        public rUsuarios()
        {
            InitializeComponent();
            this.DataContext = Usuario;
        }


       
            private void Limpiar()
            {
                this.Usuario = new Usuarios();
                this.DataContext = Usuario;
            }

            private bool Validar()
            {
                bool esValido = true;

                if (NombreTextBox.Text.Length == 0 || UsuarioIdTextBox.Text.Length == 0 || ClaveTextBox.Text.Length == 0)
                {
                    esValido = false;
                    MessageBox.Show("Hay campos vacíos, vuelva a intentarlo", "Fallo",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                return esValido;
            }

            private void BuscarButton_Click(object sender, RoutedEventArgs e)
            {
                var usuario = UsuariosBLL.Buscar(Convert.ToInt32(UsuarioIdTextBox.Text));

                if (Usuario != null)
                    this.Usuario = usuario;
                else
                    this.Usuario = new Usuarios();

                this.DataContext = this.Usuario;
            }

            private void NuevoButton_Click(object sender, RoutedEventArgs e)
            {
                Limpiar();
            }

            private void GuardarButton_Click(object sender, RoutedEventArgs e)
            {
                if (!Validar())
                    return;

                var paso = UsuariosBLL.Guardar(Usuario);

                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Guardado con exitosamente!", "Exito",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transaccion Fallida", "Fallo",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }

            private void EliminarButton_Click(object sender, RoutedEventArgs e)
            {
                if (UsuariosBLL.Eliminar(Convert.ToInt32(UsuarioIdTextBox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro eliminado!", "Exito",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No fue posible eliminar", "Fallo",
                       MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

