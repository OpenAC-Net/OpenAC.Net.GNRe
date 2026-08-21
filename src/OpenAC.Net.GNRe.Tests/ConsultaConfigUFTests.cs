using System.Collections.Generic;
using OpenAC.Net.DFe.Core.Common;
using OpenAC.Net.GNRe.Commom;

namespace OpenAC.Net.GNRe.Tests;

public class ConsultaConfigUFTests
{
    [Test]
    public async Task Deve_Serializar_E_Desserializar_ConsultaConfigUFRequest()
    {
        var request = new ConsultaConfigUFRequest
        {
            Ambiente = DFeTipoAmbiente.Homologacao,
            Uf = "PR",
            Receita = new ReceitaValue
            {
                Value = "100102",
                Courier = SimNaoLetra.Nao
            }
        };

        var xml = request.GetXml();
        await Assert.That(xml).IsNotNull();
        await Assert.That(xml).IsNotEmpty();

        var carregado = ConsultaConfigUFRequest.Load(xml);
        await Assert.That(carregado).IsNotNull();
        await Assert.That(carregado.Ambiente).IsEqualTo(DFeTipoAmbiente.Homologacao);
        await Assert.That(carregado.Uf).IsEqualTo("PR");
        await Assert.That(carregado.Receita.Value).IsEqualTo("100102");
        await Assert.That(carregado.Receita.Courier).IsEqualTo(SimNaoLetra.Nao);
    }

    [Test]
    public async Task Deve_Validar_Schema_ConsultaConfigUFRequest()
    {
        var request = new ConsultaConfigUFRequest
        {
            Ambiente = DFeTipoAmbiente.Homologacao,
            Uf = "PR",
            Receita = new ReceitaValue
            {
                Value = "100102"
            }
        };

        var xml = request.GetXml();
        var (isValid, errors) = SchemaValidationHelper.ValidateXml(xml, "consulta_config_uf_v1.00.xsd");

        await Assert.That(errors).IsEmpty();
        await Assert.That(isValid).IsTrue();
    }

    [Test]
    public async Task Deve_Serializar_E_Desserializar_ConsultaConfigUFResult()
    {
        var result = new ConsultaConfigUFResult
        {
            Ambiente = DFeTipoAmbiente.Homologacao,
            Uf = "PR",
            SituacaoConsulta = new Situacao
            {
                Codigo = "100",
                Descricao = "Consulta realizada com sucesso"
            },
            ExigeUfFavorecida = SimNaoCampo.Nao("c01_UfFavorecida"),
            ExigeReceita = SimNaoCampo.Sim("c02_receita"),
            Receitas = new List<Receita>
            {
                new()
                {
                    Codigo = "100102",
                    Descricao = "ICMS Substituicao Tributaria por Operacao"
                }
            },
            VersoesXml = new List<VersaoXml>
            {
                new()
                {
                    Versao = "2.00"
                }
            }
        };

        var xml = result.GetXml();
        await Assert.That(xml).IsNotNull();
        await Assert.That(xml).IsNotEmpty();

        var carregado = ConsultaConfigUFResult.Load(xml);
        await Assert.That(carregado).IsNotNull();
        await Assert.That(carregado.Ambiente).IsEqualTo(DFeTipoAmbiente.Homologacao);
        await Assert.That(carregado.Uf).IsEqualTo("PR");
        await Assert.That(carregado.SituacaoConsulta.Codigo).IsEqualTo("100");
        await Assert.That(carregado.ExigeUfFavorecida.Value).IsEqualTo("N");
        await Assert.That(carregado.ExigeReceita.Value).IsEqualTo("S");
        await Assert.That(carregado.Receitas.Count).IsEqualTo(1);
        await Assert.That(carregado.Receitas[0].Codigo).IsEqualTo("100102");
        await Assert.That(carregado.VersoesXml.Count).IsEqualTo(1);
        await Assert.That(carregado.VersoesXml[0].Versao).IsEqualTo("2.00");
    }

    [Test]
    public async Task Deve_Validar_Schema_ConsultaConfigUFResult()
    {
        var result = new ConsultaConfigUFResult
        {
            Ambiente = DFeTipoAmbiente.Homologacao,
            Uf = "PR",
            SituacaoConsulta = new Situacao
            {
                Codigo = "100",
                Descricao = "Consulta realizada com sucesso"
            },
            ExigeUfFavorecida = SimNaoCampo.Nao("c01_UfFavorecida"),
            ExigeReceita = SimNaoCampo.Sim("c02_receita"),
            Receitas = new List<Receita>
            {
                new()
                {
                    Codigo = "100102",
                    Descricao = "ICMS Substituicao Tributaria por Operacao",
                    ExigeContribuinteEmitente = SimNaoLetra.Sim,
                    ExigeDetalhamentoReceita = ExigeCampo.Nao("c25_detalhamentoReceita", "item_detalhamentoReceita"),
                    ExigeProduto = ExigeCampo.Nao("c26_produto", "item_produto"),
                    ExigePeriodoReferencia = SimNaoCampo.Nao("c05_referencia"),
                    ExigePeriodoApuracao = ExigeCampo.Nao("periodo", "item_referencia_periodo"),
                    ExigeParcela = SimNaoCampo.Nao("parcela"),
                    ValorExigido = new ValorExigidoCampo { Campo = "c06_valorPrincipal", Value = ValorExigido.PO },
                    ExigeDocumentoOrigem = ExigeCampo.Sim("c04_docOrigem", "item_documentoOrigem"),
                    ExigeContribuinteDestinatario = SimNaoLetra.Nao,
                    ExigeDataVencimento = SimNaoCampo.Sim("c14_dataVencimento"),
                    ExigeDataPagamento = SimNaoCampo.Sim("c33_dataPagamento"),
                    ExigeConvenio = SimNaoCampo.Nao("c15_convenio"),
                    ExigeValorFecp = SimNaoCampo.Nao("item_valorPrincipalFecp"),
                    ExigeCamposAdicionais = SimNaoCampo.Nao("c39_camposExtras")
                }
            },
            VersoesXml = new List<VersaoXml>
            {
                new()
                {
                    Versao = "2.00"
                }
            }
        };

        var xml = result.GetXml();
        var (isValid, errors) = SchemaValidationHelper.ValidateXml(xml, "config_uf_v1.00.xsd");

        await Assert.That(errors).IsEmpty();
        await Assert.That(isValid).IsTrue();
    }
}
