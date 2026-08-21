using System;
using OpenAC.Net.DFe.Core.Common;
using OpenAC.Net.GNRe.Commom;

namespace OpenAC.Net.GNRe.Tests;

public class RecepcaoLoteTests
{
    [Test]
    public async Task Deve_Serializar_E_Desserializar_RecepcaoLoteResult()
    {
        var result = new RecepcaoLoteResult
        {
            Ambiente = DFeTipoAmbiente.Homologacao,
            SituacaoRecepcao = new SituacaoRecepcao
            {
                Codigo = "100",
                Descricao = "Lote recebido com sucesso"
            },
            Recibo = new Recibo
            {
                Numero = "1234567890",
                DataHoraRecibo = new DateTime(2026, 12, 31, 10, 30, 0),
                TempoEstimadoProc = 1000
            }
        };

        var xml = result.GetXml();
        await Assert.That(xml).IsNotNull();
        await Assert.That(xml).IsNotEmpty();

        var carregado = RecepcaoLoteResult.Load(xml);
        await Assert.That(carregado).IsNotNull();
        await Assert.That(carregado.Ambiente).IsEqualTo(DFeTipoAmbiente.Homologacao);
        await Assert.That(carregado.SituacaoRecepcao.Codigo).IsEqualTo("100");
        await Assert.That(carregado.SituacaoRecepcao.Descricao).IsEqualTo("Lote recebido com sucesso");
        await Assert.That(carregado.Recibo.Numero).IsEqualTo("1234567890");
        await Assert.That(carregado.Recibo.TempoEstimadoProc).IsEqualTo(1000);
    }

    [Test]
    public async Task Deve_Validar_Schema_RecepcaoLoteResult()
    {
        var result = new RecepcaoLoteResult
        {
            Ambiente = DFeTipoAmbiente.Homologacao,
            SituacaoRecepcao = new SituacaoRecepcao
            {
                Codigo = "100",
                Descricao = "Lote recebido com sucesso"
            },
            Recibo = new Recibo
            {
                Numero = "1234567890",
                DataHoraRecibo = new DateTime(2026, 12, 31, 10, 30, 0),
                TempoEstimadoProc = 1000
            }
        };

        var xml = result.GetXml();
        var (isValid, errors) = SchemaValidationHelper.ValidateXml(xml, "lote_gnre_recibo_v1.00.xsd");

        await Assert.That(errors).IsEmpty();
        await Assert.That(isValid).IsTrue();
    }
}
