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

        private OpenGNRe _OpenGNRe;

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

            _OpenGNRe = new OpenGNRe();
        }

        private void Configurar()
        {
            _OpenGNRe.Config.Arquivos.PathSchemas = TextDiretorioSchemas.Text;
            _OpenGNRe.Config.Arquivos.PathSalvar = TextDiretorioXmls.Text;
            _OpenGNRe.Config.Arquivos.Salvar = true;

            _OpenGNRe.Config.WebServices.Ambiente = (DFeTipoAmbiente)ComboAmbiente.SelectedItem;
            _OpenGNRe.Config.WebServices.Salvar = true;

            _OpenGNRe.Config.Geral.RetirarAcentos = true;
            _OpenGNRe.Config.Geral.VersaoDFe = VersaoGNre.v200;

            _OpenGNRe.Config.Certificados.Certificado = TextCertificadoSerial.Text.IsNull() ? TextCertificadoCaminho.Text : TextCertificadoSerial.Text;
            _OpenGNRe.Config.Certificados.Senha = TextCertificadoCaminho.Text;
        }

        private void BtnRecepcaoLote_Click(object sender, EventArgs e)
        {
            Configurar();

            _OpenGNRe.Guias.Clear();

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

            _OpenGNRe.Guias.Add(dados);

            RecepcaoLoteResposta resposta = null;

            try
            {
                resposta = _OpenGNRe.RecepcaoLote();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                TextXmlEnvio.Text = resposta.XmlEnvio;
                TextXmlResposta.Text = resposta.XmlRetorno;
            }
        }

        private void BtnResultadoLote_Click(object sender, EventArgs e)
        {
            var recibo = string.Empty;
            if (InputBox.Show("Envio", "Informe o num. do recibo", ref recibo) != DialogResult.OK) return;
            if (recibo.IsNull())
                return;

            var incluirPdf = true;
            if (InputBox.Show("Envio", "Incluir PDF ?", ref recibo) != DialogResult.OK) return;

            Configurar();

            ConsultarLoteResposta resposta = null;
            try
            {
                resposta = _OpenGNRe.ConsultaLote(recibo, incluirPdf);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                TextXmlEnvio.Text = resposta.XmlEnvio;
                TextXmlResposta.Text = resposta.XmlRetorno;
            }
        }

        private void BtnConfiguracaoUf_Click(object sender, EventArgs e)
        {
            var uf = "PR";
            if (InputBox.Show("Configuração", "Informe a UF", ref uf) != DialogResult.OK) return;

            if (uf.Length != 2)
                return;

            var receita = "100102";
            if (InputBox.Show("Configuração", "Informe a receita", ref receita) != DialogResult.OK) return;

            var courier = true;
            if (InputBox.Show("Configuração", "Courier?", ref courier) != DialogResult.OK) return;

            Configurar();

            ConsultaConfigUFResposta resposta = null;
            try
            {
                resposta = _OpenGNRe.ConsultaConfigUF(uf, receita, courier);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                TextXmlEnvio.Text = resposta.XmlEnvio;
                TextXmlResposta.Text = resposta.XmlRetorno;
            }
        }
    }
}