using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using CPES.Models;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace WpfCPES
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainCPES : Window
    {
        Erro erro = new Erro();

        public MainCPES()
        {
            InitializeComponent();
            stkCabecalho.Background = new SolidColorBrush(Color.FromRgb(42, 46, 50));
            txtArquivo1.Text = "...Informe a planilha das matrículas";
            txtArquivo2.Text = "...Informe a planilha dos endereços";
            txtArquivo3.Text = "...Informe a planilha das lotações";
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
                stkMensagem.Visibility = Visibility.Hidden;
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
                stkMensagem.Visibility = Visibility.Hidden;
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
                stkMensagem.Visibility = Visibility.Hidden;
                txtArquivo3.Text = caminhoArquivo;
                btnExecutar.IsEnabled = true;
                stkRodape.Opacity = 1;
            }
        }

        #endregion

        #region StackePanel Mensagem

        private void btnMensagem_MouseEnter(object sender, MouseEventArgs e)
        {
            var template = btnMensagem.Template;
            var brdMensagem = (Border)template.FindName("brdMensagem", btnMensagem);
            brdMensagem.Background = Brushes.LightBlue;
        }

        private void btnMensagem_MouseLeave(object sender, MouseEventArgs e)
        {
            var template = btnMensagem.Template;
            var brdMensagem = (Border)template.FindName("brdMensagem", btnMensagem);
            brdMensagem.Background = Brushes.LightGray;
        }

        private void btnMensagem_Click(object sender, RoutedEventArgs e)
        {
            txtMensagem.Text = string.Empty;
            FadeOut(stkMensagem);
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
            var template = btnExecutar.Template;
            var txtExecutar = (TextBlock)template.FindName("txtExecutar", btnExecutar);

            try
            {
                btnExecutar.IsEnabled = false;
                stkRodape.Opacity = 0.5;
                txtExecutar.Text = "Aguarde...";

                #region Grava os parametros de entrada caso haja algum tipo de erro

                erro.CaminhoArquivoParametro = txtArquivo1.Text;
                erro.CaminhoArquivoEndereco = txtArquivo2.Text;
                erro.CaminhoArquivoLotacao = txtArquivo3.Text;
                erro.TabelaParametro = "PESQUISA";
                erro.TabelaEndereco = "RJCDC";
                erro.TabelaLotacao = "RJCD";
                erro.NumColMatricula = 1;
                erro.NumColMatriculaEndereco = 1;
                erro.NumColMatriculaLotacao = 1;
                erro.NumColNome = 2;
                erro.NumColEndereco = 5;
                erro.NumColNumero = 6;
                erro.NumColComplemento = 7;
                erro.NumColBairro = 8;
                erro.NumColCidade = 9;
                erro.NumColUF = 10;
                erro.NumColCEP = 11;
                erro.NumColLotacao = 26;

                #endregion   

                var planilhaParametro = CPES.CPES.GetExcel(txtArquivo1.Text, "PESQUISA$", 1, 1, 1);
                var planilhaEndereco = CPES.CPES.GetExcel(txtArquivo2.Text, "RJCDC$");
                var planilhaLotacao = CPES.CPES.GetExcel(txtArquivo3.Text, "RJCD$", 1, 1, 1);

                var colParametro = planilhaParametro.Select(s => s.Table.Columns).First();
                var colEndereco = planilhaEndereco.Select(s => s.Table.Columns).First();
                var colLotacao = planilhaLotacao.Select(s => s.Table.Columns).First();

                string[] retorno = CPES.CPES.GetDados(planilhaParametro, planilhaEndereco, planilhaLotacao, colParametro, colEndereco, colLotacao);

                stkMensagem.Visibility = Visibility.Visible;
                txtMensagem.Foreground = new SolidColorBrush(Color.FromRgb(60, 118, 61));
                txtMensagem.Background = new SolidColorBrush(Color.FromRgb(223, 240, 216));
                txtMensagem.Text = string.Empty;
                txtMensagem.Text = string.Format("Operação realizada com sucesso!\nFoi gerado o arquivo {0} \nem {1} \ncom um total de {2} registros.", retorno[0], retorno[1], retorno[2]);
                FadeIn(stkMensagem);

                btnExecutar.IsEnabled = true;
                stkRodape.Opacity = 1;
                txtExecutar.Text = "Executar";
            }
            catch (Exception ex)
            {
                var stackTrace = new StackTrace(ex, true);
                var frames = stackTrace.GetFrames();

                string textoStackTrace = string.Empty;
                foreach (var frame in frames)
                {
                    textoStackTrace += "Metodo do erro: " + frame.GetMethod().Name.ToString() + " Linha do erro: " + frame.GetFileLineNumber().ToString() + ", ";
                }

                erro.Mensagem = ex.Message;
                erro.StackTrace = textoStackTrace;
                string[] retorno = CPES.CPES.CreateCsvErro(erro);

                stkMensagem.Visibility = Visibility.Visible;
                txtMensagem.Foreground = new SolidColorBrush(Color.FromRgb(169, 68, 66));
                txtMensagem.Background = new SolidColorBrush(Color.FromRgb(242, 222, 222));
                txtMensagem.Text = string.Empty;
                txtMensagem.Text = string.Format("Houve um erro!\nFoi gerado um arquivo de log de erro: {0} \nem {1} \nTente novamente mais tarde ou contacte o administrador do sistema.", retorno[0], retorno[1]);

                btnExecutar.IsEnabled = true;
                stkRodape.Opacity = 1;
                txtExecutar.Text = "Executar";
            }
        }

        #endregion        

        #region Comum

        public void FadeIn(StackPanel sender)
        {
            var a = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                FillBehavior = FillBehavior.Stop,
                BeginTime = TimeSpan.FromSeconds(0),
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };
            var storyboard = new Storyboard();

            storyboard.Children.Add(a);
            Storyboard.SetTarget(a, sender);
            Storyboard.SetTargetProperty(a, new PropertyPath(OpacityProperty));
            storyboard.Completed += delegate { sender.Visibility = Visibility.Visible; };
            storyboard.Begin();
        }

        public void FadeOut(StackPanel sender)
        {
            var a = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                FillBehavior = FillBehavior.Stop,
                BeginTime = TimeSpan.FromSeconds(0),
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };
            var storyboard = new Storyboard();

            storyboard.Children.Add(a);
            Storyboard.SetTarget(a, sender);
            Storyboard.SetTargetProperty(a, new PropertyPath(OpacityProperty));
            storyboard.Completed += delegate { sender.Visibility = Visibility.Hidden; };
            storyboard.Begin();
        }

        #endregion
    }
}
