using System;
using System.Collections.Generic;
using System.IO;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using OpenAC.Net.Core.Extensions;
using OpenAC.Net.DFe.Core.Common;
using OpenAC.Net.GNRe.Commom;

namespace OpenAC.Net.GNRe.Demo;

public partial class MainWindow : Window
{
    private OpenGNRe? _openGNRe;

    public MainWindow()
    {
        InitializeComponent();
        Loaded += MainWindow_Loaded;
        SetupEvents();
    }

    private void MainWindow_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ComboAmbiente.ItemsSource = Enum.GetValues(typeof(DFeTipoAmbiente));
        ComboAmbiente.SelectedItem = DFeTipoAmbiente.Homologacao;

        TextTimeout.Value = 30000;
        CheckSalvarXmls.IsChecked = true;
        CheckSalvarXmlsSoap.IsChecked = true;

        TextDiretorioSchemas.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Schemas");
        TextDiretorioXmls.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Gnre");

        _openGNRe = new OpenGNRe();
    }

    private void SetupEvents()
    {
        BtnBuscarCertificado.Click += async (_, _) =>
        {
            var files = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Selecionar Certificado Digital",
                AllowMultiple = false,
                FileTypeFilter = new List<FilePickerFileType>
                {
                    new("Certificados (*.pfx, *.p12, *.cer)")
                    {
                        Patterns = new[] { "*.pfx", "*.p12", "*.cer", "*.*" }
                    }
                }
            });

            if (files.Count > 0)
            {
                TextCertificadoCaminho.Text = files[0].Path.LocalPath;
            }
        };

        BtnBuscarSchemas.Click += async (_, _) =>
        {
            var folders = await StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
            {
                Title = "Selecionar Diretório de Schemas",
                AllowMultiple = false
            });

            if (folders.Count > 0)
            {
                TextDiretorioSchemas.Text = folders[0].Path.LocalPath;
            }
        };

        BtnBuscarXmls.Click += async (_, _) =>
        {
            var folders = await StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
            {
                Title = "Selecionar Diretório de XMLs",
                AllowMultiple = false
            });

            if (folders.Count > 0)
            {
                TextDiretorioXmls.Text = folders[0].Path.LocalPath;
            }
        };

        BtnRecepcaoLote.Click += (_, _) => RecepcaoLote();
        BtnResultadoLote.Click += async (_, _) => await ResultadoLoteAsync();
        BtnConfiguracaoUf.Click += async (_, _) => await ConfiguracaoUfAsync();

        BtnLimparXmls.Click += (_, _) =>
        {
            TextXmlEnvio.Text = string.Empty;
            TextXmlResposta.Text = string.Empty;
        };

        BtnCopiarEnvio.Click += async (_, _) =>
        {
            if (!string.IsNullOrEmpty(TextXmlEnvio.Text) && Clipboard != null)
            {
                await Clipboard.SetTextAsync(TextXmlEnvio.Text);
            }
        };

        BtnCopiarResposta.Click += async (_, _) =>
        {
            if (!string.IsNullOrEmpty(TextXmlResposta.Text) && Clipboard != null)
            {
                await Clipboard.SetTextAsync(TextXmlResposta.Text);
            }
        };
    }

    private void Configurar()
    {
        _openGNRe ??= new OpenGNRe();

        _openGNRe.Config.Arquivos.PathSchemas = TextDiretorioSchemas.Text ?? string.Empty;
        _openGNRe.Config.Arquivos.PathSalvar = TextDiretorioXmls.Text ?? string.Empty;
        _openGNRe.Config.Arquivos.Salvar = CheckSalvarXmls.IsChecked == true;

        if (ComboAmbiente.SelectedItem is DFeTipoAmbiente ambiente)
        {
            _openGNRe.Config.WebServices.Ambiente = ambiente;
        }

        _openGNRe.Config.WebServices.Salvar = CheckSalvarXmlsSoap.IsChecked == true;
        _openGNRe.Config.WebServices.AguardarConsultaRet = (uint)(TextTimeout.Value ?? 30000);

        _openGNRe.Config.Geral.RetirarAcentos = true;
        _openGNRe.Config.Geral.VersaoDFe = VersaoGNre.v200;

        _openGNRe.Config.Certificados.Certificado = string.IsNullOrWhiteSpace(TextCertificadoSerial.Text)
            ? (TextCertificadoCaminho.Text ?? string.Empty)
            : TextCertificadoSerial.Text;

        _openGNRe.Config.Certificados.Senha = TextCertificadoSenha.Text ?? string.Empty;
    }

    private async void RecepcaoLote()
    {
        Configurar();
        _openGNRe!.Guias.Clear();

        var dados = new GuiaGNRe
        {
            Versao = VersaoGNre.v200,
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

        _openGNRe.Guias.Add(dados);

        RecepcaoLoteResposta? resposta = null;
        try
        {
            resposta = _openGNRe.RecepcaoLote();
        }
        catch (Exception ex)
        {
            await InputDialog.ShowMessageAsync(this, "Erro", ex.Message);
        }
        finally
        {
            TextXmlEnvio.Text = resposta?.XmlEnvio ?? string.Empty;
            TextXmlResposta.Text = resposta?.XmlRetorno ?? string.Empty;
        }
    }

    private async System.Threading.Tasks.Task ResultadoLoteAsync()
    {
        var (reciboOk, recibo) = await InputDialog.ShowTextAsync(this, "Envio", "Informe o num. do recibo:", "");
        if (!reciboOk || string.IsNullOrWhiteSpace(recibo))
            return;

        var (pdfOk, incluirPdf) = await InputDialog.ShowBooleanAsync(this, "Envio", "Incluir PDF?", true);
        if (!pdfOk)
            return;

        Configurar();

        ConsultarLoteResposta? resposta = null;
        try
        {
            resposta = _openGNRe!.ConsultaLote(recibo, incluirPdf);
        }
        catch (Exception ex)
        {
            await InputDialog.ShowMessageAsync(this, "Erro", ex.Message);
        }
        finally
        {
            TextXmlEnvio.Text = resposta?.XmlEnvio ?? string.Empty;
            TextXmlResposta.Text = resposta?.XmlRetorno ?? string.Empty;
        }
    }

    private async System.Threading.Tasks.Task ConfiguracaoUfAsync()
    {
        var (ufOk, uf) = await InputDialog.ShowTextAsync(this, "Configuração", "Informe a UF:", "PR");
        if (!ufOk || string.IsNullOrWhiteSpace(uf) || uf.Length != 2)
            return;

        var (receitaOk, receita) = await InputDialog.ShowTextAsync(this, "Configuração", "Informe a receita:", "100102");
        if (!receitaOk || string.IsNullOrWhiteSpace(receita))
            return;

        var (courierOk, courier) = await InputDialog.ShowBooleanAsync(this, "Configuração", "Courier?", true);
        if (!courierOk)
            return;

        Configurar();

        ConsultaConfigUFResposta? resposta = null;
        try
        {
            resposta = _openGNRe!.ConsultaConfigUF(uf.ToUpperInvariant(), receita, courier);
        }
        catch (Exception ex)
        {
            await InputDialog.ShowMessageAsync(this, "Erro", ex.Message);
        }
        finally
        {
            TextXmlEnvio.Text = resposta?.XmlEnvio ?? string.Empty;
            TextXmlResposta.Text = resposta?.XmlRetorno ?? string.Empty;
        }
    }
}
