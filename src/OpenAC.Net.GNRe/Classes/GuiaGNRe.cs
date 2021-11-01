// ***********************************************************************
// Assembly         : OpenAC.Net.GNRe
// Author           : Rafael Dias
// Created          : 29-10-2021
//
// Last Modified By : Rafael Dias
// Last Modified On : 29-10-2021
// ***********************************************************************
// <copyright file="GuiaGNRe.cs" company="OpenAC .Net">
//		        		   The MIT License (MIT)
//	     		    Copyright (c) 2014 - 2021 Projeto OpenAC .Net
//
//	 Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//	 The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//	 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using OpenAC.Net.DFe.Core.Attributes;
using OpenAC.Net.DFe.Core.Document;
using OpenAC.Net.DFe.Core.Serializer;

namespace OpenAC.Net.GNRe.Classes
{
    /// <summary>
    /// Dados do Gnre para a versão 1.00 e 2.00.
    /// </summary>
    public sealed class GuiaGNRe : DFeDocument<GuiaGNRe>
    {
        #region Constructors

        public GuiaGNRe()
        {
            Versao = VersaoGNre.v200;
        }

        #endregion Constructors

        #region Properties

        [DFeAttribute(TipoCampo.Enum, "versao", Ocorrencia = Ocorrencia.Obrigatoria)]
        public VersaoGNre Versao { get; set; }

        #region Versao1

        [DFeElement(TipoCampo.Str, "c01_UfFavorecida", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string UfFavorecidaV1 { get; set; }

        public bool ShouldSerializeUfFavorecidaV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.Str, "c02_receita", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 2)]
        public string ReceitaV1 { get; set; }

        public bool ShouldSerializeReceitaV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.Str, "c25_detalhamentoReceita", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 3)]
        public string DetalhamentoReceitaV1 { get; set; }

        public bool ShouldSerializeDetalhamentoReceitaV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.Str, "c26_produto", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 4)]
        public string ProdutoV1 { get; set; }

        public bool ShouldSerializeProdutoV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.Enum, "c27_tipoIdentificacaoEmitente", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 5)]
        public TipoIdentificacao? TipoIdentificacaoEmitenteV1 { get; set; }

        public bool ShouldSerializeTipoIdentificacaoEmitenteV1() => Versao == VersaoGNre.v100;

        [DFeElement("c03_idContribuinteEmitente", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 6)]
        public IdContribuinte IdContribuinteEmitenteV1 { get; set; }

        public bool ShouldSerializeIdContribuinteEmitenteV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.Str, "c28_tipoDocOrigem", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 7)]
        public string TipoDocOrigemV1 { get; set; }

        public bool ShouldSerializeTipoDocOrigemV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.Str, "c04_docOrigem", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 8)]
        public string DocOrigemV1 { get; set; }

        public bool ShouldSerializeDocOrigemV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.De2, "c06_valorPrincipal", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 9)]
        public decimal? ValorPrincipalV1 { get; set; }

        public bool ShouldSerializeValorPrincipalV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.De2, "c10_valorTotal", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 10)]
        public decimal? ValorTotalV1 { get; set; }

        public bool ShouldSerializeValorTotalV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.Dat, "c14_dataVencimento", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 11)]
        public DateTime? DataVencimentoV1 { get; set; }

        public bool ShouldSerializeDataVencimentoV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.Str, "c15_convenio", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 12)]
        public string ConvenioV1 { get; set; }

        public bool ShouldSerializeConvenioV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.Str, "c16_razaoSocialEmitente", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 13)]
        public string RazaoSocialEmitenteV1 { get; set; }

        public bool ShouldSerializeRazaoSocialEmitenteV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.Str, "c17_inscricaoEstadualEmitente", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 14)]
        public string InscricaoEstadualEmitenteV1 { get; set; }

        public bool ShouldSerializeInscricaoEstadualEmitenteV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.Str, "c18_enderecoEmitente", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 15)]
        public string EnderecoEmitenteV1 { get; set; }

        public bool ShouldSerializeEnderecoEmitenteV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.Long, "c19_municipioEmitente", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 16, Min = 5, Max = 5)]
        public long? MunicipioEmitenteV1 { get; set; }

        public bool ShouldSerializeMunicipioEmitenteV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.Str, "c20_ufEnderecoEmitente", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 17)]
        public string UfEnderecoEmitenteV1 { get; set; }

        public bool ShouldSerializeUfEnderecoEmitenteV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.Str, "c21_cepEmitente", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 18)]
        public string CepEmitenteV1 { get; set; }

        public bool ShouldSerializeCepEmitenteV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.Str, "c22_telefoneEmitente", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 19)]
        public string TelefoneEmitenteV1 { get; set; }

        public bool ShouldSerializeTelefoneEmitenteV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.Enum, "c34_tipoIdentificacaoDestinatario", Ocorrencia = Ocorrencia.NaoObrigatoria,
            Ordem = 20)]
        public TipoIdentificacao? TipoIdentificacaoDestinatarioV1 { get; set; }

        public bool ShouldSerializeTipoIdentificacaoDestinatarioV1() =>
            Versao == VersaoGNre.v100 && TipoIdentificacaoDestinatarioV1 != null;

        [DFeElement("c35_idContribuinteDestinatario", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 21)]
        public IdContribuinte IdContribuinteDestinatarioV1 { get; set; }

        public bool ShouldSerializeIdContribuinteDestinatarioV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.Str, "c36_inscricaoEstadualDestinatario", Ocorrencia = Ocorrencia.NaoObrigatoria,
            Ordem = 22)]
        public string InscricaoEstadualDestinatarioV1 { get; set; }

        public bool ShouldSerializeInscricaoEstadualDestinatarioV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.Str, "c37_razaoSocialDestinatario", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 23)]
        public string RazaoSocialDestinatarioV1 { get; set; }

        public bool ShouldSerializeInscricaoRazaoSocialDestinatarioV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.Long, "c38_municipioDestinatario", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 24,
            Min = 5, Max = 5)]
        public long? MunicipioDestinatarioV1 { get; set; }

        public bool ShouldSerializeInscricaoMunicipioDestinatarioV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.Dat, "c33_dataPagamento", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 25)]
        public DateTime? DataPagamentoV1 { get; set; }

        public bool ShouldSerializeDataPagamentoV1() => Versao == VersaoGNre.v100;

        [DFeElement("c05_referencia", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 26)]
        public Referencia ReferenciaV1 { get; set; }

        public bool ShouldSerializeReferenciaV1() => Versao == VersaoGNre.v100;

        [DFeCollection("c39_camposExtras", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 27)]
        [DFeItem(typeof(CampoExtra), "campoExtra")]
        public List<CampoExtra> CamposExtrasV1 { get; set; }

        public bool ShouldSerializeCamposExtrasV1() => Versao == VersaoGNre.v100;

        [DFeElement(TipoCampo.Str, "c42_identificadorGuia", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 28)]
        public string IdentificadorGuiaV1 { get; set; }

        public bool ShouldSerializeIdentificadorGuiaV1() => Versao == VersaoGNre.v100;

        #endregion Versao1

        #region Versao2

        [DFeElement(TipoCampo.Str, "ufFavorecida", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string UfFavorecida { get; set; }

        public bool ShouldSerializeUfFavorecida() => Versao == VersaoGNre.v200;

        [DFeElement(TipoCampo.Enum, "tipoGnre", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 2)]
        public TipoGnre? TipoGnre { get; set; }

        public bool ShouldSerializeTipoGnre() => Versao == VersaoGNre.v200 && TipoGnre != null;

        [DFeElement("contribuinteEmitente", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 3)]
        public ContribuinteEmitente ContribuinteEmitente { get; set; }

        public bool ShouldSerializeIdContribuinteEmitente() => Versao == VersaoGNre.v200;

        [DFeItem(typeof(ItemGnre), "item")]
        [DFeCollection("itensGNRE", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 4)]
        public List<ItemGnre> Item { get; set; }

        public bool ShouldSerializeItensGnre() => Versao == VersaoGNre.v200;

        [DFeElement(TipoCampo.De2, "valorGNRE", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 5)]
        public decimal? ValorGnre { get; set; }

        public bool ShouldSerializeValorGnre() => Versao == VersaoGNre.v200;

        [DFeElement(TipoCampo.Dat, "dataPagamento", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 6)]
        public DateTime? DataPagamento { get; set; }

        public bool ShouldSerializeDataPagamento() => Versao == VersaoGNre.v200;

        [DFeElement(TipoCampo.Str, "identificadorGuia", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 7)]
        public string IdentificadorGuia { get; set; }

        public bool ShouldSerializeIdentificadorGuia() => Versao == VersaoGNre.v200;

        #endregion Versao2

        #endregion Properties
    }
}