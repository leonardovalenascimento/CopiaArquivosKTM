using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopiaArquivosKTM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnArquivoTreinamento_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opdArquivosTreinamento = new OpenFileDialog();

                opdArquivosTreinamento.InitialDirectory = @"D:\";
                opdArquivosTreinamento.RestoreDirectory = true;
                opdArquivosTreinamento.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                opdArquivosTreinamento.CheckFileExists = true;
                opdArquivosTreinamento.CheckPathExists = true;
                

                DialogResult resultado = opdArquivosTreinamento.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    txtArquivoTreinamento.Text = opdArquivosTreinamento.FileName;
                }
                else
                {
                    throw new Exception("Erro ao ler o arquivo");
                }
            }
            catch (SecurityException ex)
            {
                // O usuário  não possui permissão para ler arquivos
                MessageBox.Show("Erro de segurança Contate o administrador de segurança da rede.\n\n" +
                                            "Mensagem : " + ex.Message + "\n\n" +
                                            "Detalhes (enviar ao suporte):\n\n" + ex.StackTrace);
            }
            catch (Exception ex)
            {
                // Não pode carregar a imagem (problemas de permissão)
                MessageBox.Show("Não é possível exibir a imagem : " /*+ arquivo.Substring(file.LastIndexOf('\\'))*/
                                           + ". Você pode não ter permissão para ler o arquivo , ou " +
                                           " ele pode estar corrompido.\n\nErro reportado : " + ex.Message);
            }
        }
    }
}