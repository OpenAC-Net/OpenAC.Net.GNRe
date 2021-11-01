using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using OpenAC.Net.Core.Extensions;
using OpenAC.Net.DFe.Core.Common;
using OpenAC.Net.GNRe.Classes;

namespace OpenAC.Net.GNRe.Demo
{
    public partial class FormDemo : Form
    {
        public FormDemo()
        {
            InitializeComponent();
        }

        private void FrmDemo_Load(object sender, EventArgs e)
        {
            TextCertificadoSerial.Text = "05d75a9b9829a807";

            ComboAmbiente.DataSource = Enum.GetValues(typeof(DFeTipoAmbiente));
            ComboAmbiente.SelectedItem = DFeTipoAmbiente.Homologacao;
            TextTimeout.Value = 30000;
            CheckSalvarXmls.Checked = true;
            CheckSalvarXmlsSoap.Checked = true;

            TextDiretorioSchemas.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Schemas");
            TextDiretorioXmls.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Gnre");
        }

        private string InputBox(string mensagem, string texto = null)
        {
            using var form = new FormInputBox();
            form.Text = mensagem;
            form.TextBox1.Text = texto ?? string.Empty;
            form.ShowDialog();

            return form.Tag.ToString()?.Trim() ?? string.Empty;
        }

        private void BtnRecepcaoLote_Click(object sender, EventArgs e)
        {
            var request = new LoteGnreRequest
            {
                Versao = VersaoGNre.v200,
                Guias = new List<GuiaGNRe>()
            };

            //Substitua os dados para realizar o teste
            var dados = new GuiaGNRe
            {
                Versao = VersaoGNre.v200, //"1.00"

                /* Atributos da versão selecionada */

                UfFavorecida = "RJ",
                TipoGnre = TipoGnre.GnreSimples,
                ContribuinteEmitente = new ContribuinteEmitente
                {
                    IdContribuinteEmitente = new IdContribuinte
                    {
                        Cnpj = "00000000000000"
                    },
                    RazaoSocial = "Razão Social do Emitente",
                    Endereco = "Rua de Teste, número 0",
                    Municipio = 14106,
                    Uf = "SP",
                    Cep = "17300000"
                },

                Item = new List<ItemGnre>
                {
                    new()
                    {
                        Receita = "100102",

                        DocumentoOrigem = new StringTipo
                        {
                            Tipo = "24",
                            Value = "00000000000000000000000000000000000000000000"
                        },
                        DataVencimento = DateTime.Today,

                        Valor = new List<DecimalCampo>
                        {
                            new()
                            {
                                Value = 25.00M,
                                Tipo = "11"
                            },
                            new()
                            {
                                Value = 15.00M,
                                Tipo = "12"
                            }
                        },

                        ContribuinteDestinatario = new ContribuinteDestinatario
                        {
                            IdContribuinteEmitente = new IdContribuinte
                            {
                                Cpf = "00000000000"
                            },
                            RazaoSocial = "Destinatário Teste",
                            Municipio = 00209
                        },

                        CamposExtras = new List<CampoExtraBase>
                        {
                            new()
                            {
                                Codigo = 117,
                                Valor = DateTime.Today.ToString("yyyy-MM-dd")
                            }
                        }
                    }
                },

                ValorGnre = 40.00M,
                DataPagamento = DateTime.Today
            };

            request.Guias.Add(dados);

            var client = GetClient();

            try
            {
                client.RecepcaoLote(request);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                TextXmlEnvio.Text = client.XmlEnvio;
                TextXmlResposta.Text = client.XmlResposta;
            }
        }

        private void BtnResultadoLote_Click(object sender, EventArgs e)
        {
            var recibo = string.Empty;
            recibo = InputBox("Informe o num. do recibo", recibo);
            if (recibo.IsNull())
                return;

            var incluirPdf = "sim";
            incluirPdf = InputBox("Incluir Pdf?", incluirPdf);

            var client = GetClient();

            try
            {
                client.ResultadoLote(recibo, incluirPdf.ToLower() == "sim");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                TextXmlEnvio.Text = client.XmlEnvio;
                TextXmlResposta.Text = client.XmlResposta;
            }
        }

        private void BtnConfiguracaoUf_Click(object sender, EventArgs e)
        {
            var uf = "PR";
            uf = InputBox("Informe a UF", uf);

            if (uf.Length != 2)
                return;

            var receita = "100102";
            receita = InputBox("Informe a receita", receita);

            var courier = "N";
            courier = InputBox("Courier", courier);

            var client = GetClient();

            try
            {
                client.ConfigUf(uf, receita, courier == "S" ? (SimNao?)SimNao.S : null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                TextXmlEnvio.Text = client.XmlEnvio;
                TextXmlResposta.Text = client.XmlResposta;
            }
        }
    }
}