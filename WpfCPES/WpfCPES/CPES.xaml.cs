using Microsoft.Win32;
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

namespace WpfCPES
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class CPES : Window
    {
        public CPES()
        {
            InitializeComponent();
        }

        #region StackePanel Cabeçalho
        #endregion

        #region StackePanel Arquivo 1       

        private void btnArquivo1_MouseEnter(object sender, MouseEventArgs e)
        {
            var template = btnArquivo1.Template;
            var brdArquivo1 = (Border)template.FindName("brdArquivo1", btnArquivo1);
            brdArquivo1.Background = Brushes.LightBlue;
        }

        private void btnArquivo1_MouseLeave(object sender, MouseEventArgs e)
        {
            var template = btnArquivo1.Template;
            var brdArquivo1 = (Border)template.FindName("brdArquivo1", btnArquivo1);
            brdArquivo1.Background = Brushes.LightGray;
        }

        private void btnArquivo1_Click(object sender, RoutedEventArgs e)
        {            
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.DefaultExt = ".xls";
            openFileDialog.Filter = "XLS Files (*.xls)|*.xls";

            var resultado = openFileDialog.ShowDialog();
            
            if (resultado == true)
            {                
                string caminhoArquivo = openFileDialog.FileName;
                txtArquivo1.Text = caminhoArquivo;
                btnArquivo2.IsEnabled = true;
                stkArquivo2.Opacity = 1;
            }
        }

        #endregion

        #region StackePanel Arquivo 2    

        private void btnArquivo2_MouseEnter(object sender, MouseEventArgs e)
        {
            var template = btnArquivo2.Template;
            var brdArquivo2 = (Border)template.FindName("brdArquivo2", btnArquivo2);
            brdArquivo2.Background = Brushes.LightBlue;
        }

        private void btnArquivo2_MouseLeave(object sender, MouseEventArgs e)
        {
            var template = btnArquivo2.Template;
            var brdArquivo2 = (Border)template.FindName("brdArquivo2", btnArquivo2);
            brdArquivo2.Background = Brushes.LightGray;
        }

        private void btnArquivo2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.DefaultExt = ".xls";
            openFileDialog.Filter = "XLS Files (*.xls)|*.xls";

            var resultado = openFileDialog.ShowDialog();

            if (resultado == true)
            {
                string caminhoArquivo = openFileDialog.FileName;
                txtArquivo2.Text = caminhoArquivo;
                btnArquivo3.IsEnabled = true;
                stkArquivo3.Opacity = 1;
            }
        }

        #endregion

        #region StackePanel Arquivo 3

        private void btnArquivo3_MouseEnter(object sender, MouseEventArgs e)
        {
            var template = btnArquivo3.Template;
            var brdArquivo3 = (Border)template.FindName("brdArquivo3", btnArquivo3);
            brdArquivo3.Background = Brushes.LightBlue;
        }

        private void btnArquivo3_MouseLeave(object sender, MouseEventArgs e)
        {
            var template = btnArquivo3.Template;
            var brdArquivo3 = (Border)template.FindName("brdArquivo3", btnArquivo3);
            brdArquivo3.Background = Brushes.LightGray;
        }

        private void btnArquivo3_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.DefaultExt = ".xls";
            openFileDialog.Filter = "XLS Files (*.xls)|*.xls";

            var resultado = openFileDialog.ShowDialog();

            if (resultado == true)
            {
                string caminhoArquivo = openFileDialog.FileName;
                txtArquivo3.Text = caminhoArquivo;
                btnExecutar.IsEnabled = true;
                stkRodape.Opacity = 1;
            }
        }

        #endregion

        #region StackePanel Rodapé

        private void btnExecutar_MouseEnter(object sender, MouseEventArgs e)
        {
            var template = btnExecutar.Template;
            var brdExecutar = (Border)template.FindName("brdExecutar", btnExecutar);
            brdExecutar.Background = new SolidColorBrush(Color.FromRgb(91, 175, 70));
        }

        private void btnExecutar_MouseLeave(object sender, MouseEventArgs e)
        {
            var template = btnExecutar.Template;
            var brdExecutar = (Border)template.FindName("brdExecutar", btnExecutar);
            brdExecutar.Background = Brushes.Green;
        }

        private void btnExecutar_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion       
    }
}
