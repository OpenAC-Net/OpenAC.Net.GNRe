using System;
using System.Collections.Generic;
using OpenAC.Net.GNRe.Commom;

namespace OpenAC.Net.GNRe.Tests;

public class GuiaGNReTests
{
    [Test]
    public async Task Deve_Serializar_E_Desserializar_Guia_v200()
    {
        var guia = new GuiaGNRe
        {
            Versao = VersaoGNre.v200,
            UfFavorecida = "RJ",
            TipoGnre = TipoGnre.GnreSimples,
            ContribuinteEmitente = new ContribuinteEmitente
            {
                IdContribuinteEmitente = new IdContribuinte
                {
                    Cnpj = "12345678000195"
                },
                RazaoSocial = "Empresa Teste LTDA",
                Endereco = "Rua Teste, 100",
                Municipio = 14106,
                Uf = "SP",
                Cep = "17300000",
                Telefone = "1199999999"
            },
            Item = new List<ItemGnre>
            {
                new()
                {
                    Receita = "100102",
                    DocumentoOrigem = new StringTipo
                    {
                        Tipo = "24",
                        Value = "12345678901234567890123456789012345678901234"
                    },
                    DataVencimento = new DateTime(2026, 12, 31),
                    Valor = new List<DecimalCampo>
                    {
                        new()
                        {
                            Value = 25.50M,
                            Tipo = "11"
                        },
                        new()
                        {
                            Value = 14.50M,
                            Tipo = "12"
                        }
                    },
                    ContribuinteDestinatario = new ContribuinteDestinatario
                    {
                        IdContribuinteEmitente = new IdContribuinte
                        {
                            Cpf = "12345678901"
                        },
                        RazaoSocial = "Destinatario Teste",
                        Municipio = 00209
                    },
                    CamposExtras = new List<CampoExtraBase>
                    {
                        new()
                        {
                            Codigo = 117,
                            Valor = "2026-12-31"
                        }
                    }
                }
            },
            ValorGnre = 40.00M,
            DataPagamento = new DateTime(2026, 12, 31)
        };

        var xml = guia.GetXml();
        await Assert.That(xml).IsNotNull();
        await Assert.That(xml).IsNotEmpty();

        var carregada = GuiaGNRe.Load(xml);
        await Assert.That(carregada).IsNotNull();
        await Assert.That(carregada.Versao).IsEqualTo(VersaoGNre.v200);
        await Assert.That(carregada.UfFavorecida).IsEqualTo("RJ");
        await Assert.That(carregada.TipoGnre).IsEqualTo(TipoGnre.GnreSimples);
        await Assert.That(carregada.ContribuinteEmitente.IdContribuinteEmitente.Cnpj).IsEqualTo("12345678000195");
        await Assert.That(carregada.ContribuinteEmitente.RazaoSocial).IsEqualTo("Empresa Teste LTDA");
        await Assert.That(carregada.Item.Count).IsEqualTo(1);
        await Assert.That(carregada.Item[0].Receita).IsEqualTo("100102");
        await Assert.That(carregada.Item[0].Valor.Count).IsEqualTo(2);
        await Assert.That(carregada.Item[0].Valor[0].Value).IsEqualTo(25.50M);
        await Assert.That(carregada.Item[0].ContribuinteDestinatario.IdContribuinteEmitente.Cpf).IsEqualTo("12345678901");
        await Assert.That(carregada.ValorGnre).IsEqualTo(40.00M);
    }

    [Test]
    public async Task Deve_Serializar_E_Desserializar_Guia_v100()
    {
        var guia = new GuiaGNRe
        {
            Versao = VersaoGNre.v100,
            UfFavorecidaV1 = "PE",
            ReceitaV1 = "100056",
            IdContribuinteEmitenteV1 = new IdContribuinte
            {
                Cnpj = "12345678000195"
            },
            RazaoSocialEmitenteV1 = "Emitente V1 Teste",
            EnderecoEmitenteV1 = "Av Brasil, 500",
            MunicipioEmitenteV1 = 26116,
            UfEnderecoEmitenteV1 = "PE",
            CepEmitenteV1 = "50000000",
            ValorPrincipalV1 = 150.00M,
            ValorTotalV1 = 150.00M,
            DataVencimentoV1 = new DateTime(2026, 12, 31),
            DataPagamentoV1 = new DateTime(2026, 12, 31)
        };

        var xml = guia.GetXml();
        await Assert.That(xml).IsNotNull();
        await Assert.That(xml).IsNotEmpty();

        var carregada = GuiaGNRe.Load(xml);
        await Assert.That(carregada).IsNotNull();
        await Assert.That(carregada.Versao).IsEqualTo(VersaoGNre.v100);
        await Assert.That(carregada.UfFavorecidaV1).IsEqualTo("PE");
        await Assert.That(carregada.ReceitaV1).IsEqualTo("100056");
        await Assert.That(carregada.IdContribuinteEmitenteV1.Cnpj).IsEqualTo("12345678000195");
        await Assert.That(carregada.RazaoSocialEmitenteV1).IsEqualTo("Emitente V1 Teste");
        await Assert.That(carregada.ValorPrincipalV1).IsEqualTo(150.00M);
        await Assert.That(carregada.ValorTotalV1).IsEqualTo(150.00M);
    }
}
