using System;
using System.Collections.Generic;
using OpenAC.Net.DFe.Core.Common;
using OpenAC.Net.GNRe.Commom;

namespace OpenAC.Net.GNRe.Tests;

public class ConsultaLoteTests
{
    [Test]
    public async Task Deve_Serializar_E_Desserializar_ConsultaLoteRequest()
    {
        var request = new ConsultaLoteRequest
        {
            Ambiente = DFeTipoAmbiente.Homologacao,
            NumeroRecibo = "12345678901234",
            IncluirPdfsGuias = SimNaoLetra.Sim
        };

        var xml = request.GetXml();
        await Assert.That(xml).IsNotNull();
        await Assert.That(xml).IsNotEmpty();

        var carregado = ConsultaLoteRequest.Load(xml);
        await Assert.That(carregado).IsNotNull();
        await Assert.That(carregado.Ambiente).IsEqualTo(DFeTipoAmbiente.Homologacao);
        await Assert.That(carregado.NumeroRecibo).IsEqualTo("12345678901234");
        await Assert.That(carregado.IncluirPdfsGuias).IsEqualTo(SimNaoLetra.Sim);
    }

    [Test]
    public async Task Deve_Validar_Schema_ConsultaLoteRequest()
    {
        var request = new ConsultaLoteRequest
        {
            Ambiente = DFeTipoAmbiente.Homologacao,
            NumeroRecibo = "12345678901234",
            IncluirPdfsGuias = SimNaoLetra.Sim
        };

        var xml = request.GetXml();
        var (isValid, errors) = SchemaValidationHelper.ValidateXml(xml, "lote_gnre_consulta_v1.00.xsd");

        await Assert.That(errors).IsEmpty();
        await Assert.That(isValid).IsTrue();
    }

    [Test]
    public async Task Deve_Serializar_E_Desserializar_ConsultarLoteResult()
    {
        var result = new ConsultarLoteResult
        {
            Ambiente = DFeTipoAmbiente.Homologacao,
            SituacaoProcess = new Situacao
            {
                Codigo = "100",
                Descricao = "Lote processado com sucesso"
            },
            Resultado = new Resultado
            {
                Guia = new List<GuiaResult>
                {
                    new()
                    {
                        SituacaoGuia = SituacaoGuia.ProcessadaComSucesso,
                        LinhaDigitavel = "85800000001000000000000000000000000000000000",
                        CodigoBarras = "85800000000000000000000000000000000000000000",
                        IdentificadorGuiaV2 = "1"
                    }
                },
                PdfGuias = Convert.ToBase64String(new byte[] { 0x25, 0x50, 0x44, 0x46 }) // %PDF header
            }
        };

        var xml = result.GetXml();
        await Assert.That(xml).IsNotNull();
        await Assert.That(xml).IsNotEmpty();

        var carregado = ConsultarLoteResult.Load(xml);
        await Assert.That(carregado).IsNotNull();
        await Assert.That(carregado.Ambiente).IsEqualTo(DFeTipoAmbiente.Homologacao);
        await Assert.That(carregado.SituacaoProcess.Codigo).IsEqualTo("100");
        await Assert.That(carregado.Resultado.Guia.Count).IsEqualTo(1);
        await Assert.That(carregado.Resultado.Guia[0].SituacaoGuia).IsEqualTo(SituacaoGuia.ProcessadaComSucesso);
        await Assert.That(carregado.Resultado.PdfGuias).IsNotNull();
    }
}
