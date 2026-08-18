using System;
using System.Collections.Generic;
using OpenAC.Net.GNRe.Commom;

namespace OpenAC.Net.GNRe.Tests;

public class LoteGnreRequestTests
{
    [Test]
    public async Task Deve_Serializar_E_Desserializar_LoteGnreRequest_v200()
    {
        var lote = new LoteGnreRequest
        {
            Versao = VersaoGNre.v200
        };

        lote.Guias.Add(new GuiaGNRe
        {
            Versao = VersaoGNre.v200,
            UfFavorecida = "SP",
            TipoGnre = TipoGnre.GnreSimples,
            ContribuinteEmitente = new ContribuinteEmitente
            {
                IdContribuinteEmitente = new IdContribuinte
                {
                    Cnpj = "12345678000195"
                },
                RazaoSocial = "Empresa Teste SP",
                Endereco = "Rua Teste, 200",
                Municipio = 35503,
                Uf = "SP",
                Cep = "01001000"
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
                            Value = 100.00M,
                            Tipo = "11"
                        }
                    }
                }
            },
            ValorGnre = 100.00M,
            DataPagamento = new DateTime(2026, 12, 31)
        });

        var xml = lote.GetXml();
        await Assert.That(xml).IsNotNull();
        await Assert.That(xml).IsNotEmpty();

        var carregado = LoteGnreRequest.Load(xml);
        await Assert.That(carregado).IsNotNull();
        await Assert.That(carregado.Versao).IsEqualTo(VersaoGNre.v200);
        await Assert.That(carregado.Guias.Count).IsEqualTo(1);
        await Assert.That(carregado.Guias[0].UfFavorecida).IsEqualTo("SP");
        await Assert.That(carregado.Guias[0].ValorGnre).IsEqualTo(100.00M);
    }

    [Test]
    public async Task Deve_Validar_Schema_LoteGnreRequest_v200()
    {
        var lote = new LoteGnreRequest
        {
            Versao = VersaoGNre.v200
        };

        lote.Guias.Add(new GuiaGNRe
        {
            Versao = VersaoGNre.v200,
            UfFavorecida = "SP",
            TipoGnre = TipoGnre.GnreSimples,
            ContribuinteEmitente = new ContribuinteEmitente
            {
                IdContribuinteEmitente = new IdContribuinte
                {
                    Cnpj = "12345678000195"
                },
                RazaoSocial = "Empresa Teste SP",
                Endereco = "Rua Teste, 200",
                Municipio = 35503,
                Uf = "SP",
                Cep = "01001000"
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
                            Value = 100.00M,
                            Tipo = "11"
                        }
                    }
                }
            },
            ValorGnre = 100.00M,
            DataPagamento = new DateTime(2026, 12, 31)
        });

        var xml = lote.GetXml();
        var (isValid, errors) = SchemaValidationHelper.ValidateXml(xml, "lote_gnre_v2.00.xsd");

        await Assert.That(errors).IsEmpty();
        await Assert.That(isValid).IsTrue();
    }

    [Test]
    public async Task Deve_Validar_Schema_LoteGnreRequest_v100()
    {
        var lote = new LoteGnreRequest
        {
            Versao = VersaoGNre.v100
        };

        lote.Guias.Add(new GuiaGNRe
        {
            Versao = VersaoGNre.v100,
            UfFavorecidaV1 = "PE",
            ReceitaV1 = "100056",
            TipoIdentificacaoEmitenteV1 = TipoIdentificacao.Cnpj,
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
        });

        var xml = lote.GetXml();
        var (isValid, errors) = SchemaValidationHelper.ValidateXml(xml, "lote_gnre_v1.00.xsd");

        await Assert.That(errors).IsEmpty();
        await Assert.That(isValid).IsTrue();
    }

    [Test]
    public async Task Deve_Validar_Diretamente_Com_XmlSchemaValidation()
    {
        var lote = new LoteGnreRequest
        {
            Versao = VersaoGNre.v200
        };

        lote.Guias.Add(new GuiaGNRe
        {
            Versao = VersaoGNre.v200,
            UfFavorecida = "SP",
            TipoGnre = TipoGnre.GnreSimples,
            Item = new List<ItemGnre>
            {
                new()
                {
                    Receita = "100102",
                    Valor = new List<DecimalCampo>
                    {
                        new() { Value = 50.00M, Tipo = "11" }
                    }
                }
            },
            ValorGnre = 50.00M,
            DataPagamento = new DateTime(2026, 12, 31)
        });

        var xml = lote.GetXml();
        var schemaPath = SchemaValidationHelper.ObterCaminhoSchema("lote_gnre_v2.00.xsd");
        var valido = OpenAC.Net.DFe.Core.XmlSchemaValidation.ValidarXml(xml, schemaPath, out var erros, out var avisos);

        await Assert.That(erros).IsEmpty();
        await Assert.That(valido).IsTrue();
    }
}
