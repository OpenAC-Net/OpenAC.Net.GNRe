// ***********************************************************************
// Assembly         : OpenAC.Net.GNRe
// Author           : Rafael Dias
// Created          : 29-10-2021
//
// Last Modified By : Rafael Dias
// Last Modified On : 29-10-2021
// ***********************************************************************
// <copyright file="CampoAdicional.cs" company="OpenAC .Net">
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
using OpenAC.Net.DFe.Core.Serializer;

namespace OpenAC.Net.GNRe.Commom
{
    public sealed class GuiaResult
    {
        #region Properties

        [DFeElement(TipoCampo.Enum, "situacaoGuia")]
        public SituacaoGuia SituacaoGuia { get; set; }

        #region Dados Versao1

        [DFeElement(TipoCampo.Str, "c01_UfFavorecida")]
        public string UfFavorecidaV1 { get; set; }

        [DFeElement(TipoCampo.Str, "c02_receita")]
        public string ReceitaV1 { get; set; }

        [DFeElement(TipoCampo.Str, "c25_detalhamentoReceita")]
        public string DetalhamentoReceitaV1 { get; set; }

        [DFeElement(TipoCampo.Str, "c26_produto")]
        public string ProdutoV1 { get; set; }

        [DFeElement(TipoCampo.Custom, "c27_tipoIdentificacaoEmitente")]
        public TipoIdentificacao? TipoIdentificacaoEmitenteV1 { get; set; }

        [DFeElement("c03_idContribuinteEmitente")]
        public IdContribuinte IdContribuinteEmitenteV1 { get; set; }

        [DFeElement(TipoCampo.Str, "c28_tipoDocOrigem")]
        public string TipoDocOrigemV1 { get; set; }

        [DFeElement(TipoCampo.Str, "c04_docOrigem")]
        public string DocOrigemV1 { get; set; }

        [DFeElement(TipoCampo.De2, "c06_valorPrincipal")]
        public decimal? ValorPrincipalV1 { get; set; }

        [DFeElement(TipoCampo.De2, "c07_atualizacaoMonetaria")]
        public decimal? AtualizacaoMonetariaV1 { get; set; }

        [DFeElement(TipoCampo.De2, "c08_juros")]
        public decimal? JurosV1 { get; set; }

        [DFeElement(TipoCampo.De2, "c09_multa")]
        public decimal? MultaV1 { get; set; }

        [DFeElement(TipoCampo.De2, "c10_valorTotal")]
        public decimal? ValorTotal2V1 { get; set; }

        [DFeElement(TipoCampo.Dat, "c14_dataVencimento")]
        public DateTime? DataVencimentoV1 { get; set; }

        [DFeElement(TipoCampo.Dat, "c29_dataLimitePagamento")]
        public DateTime? DataLimitePagamentoV1 { get; set; }

        [DFeElement(TipoCampo.Str, "c15_convenio")]
        public string ConvenioV1 { get; set; }

        [DFeElement(TipoCampo.Str, "c16_razaoSocialEmitente")]
        public string RazaoSocialEmitenteV1 { get; set; }

        [DFeElement(TipoCampo.Str, "c17_inscricaoEstadualEmitente")]
        public string InscricaoEstadualEmitenteV1 { get; set; }

        [DFeElement(TipoCampo.Str, "c18_enderecoEmitente")]
        public string EnderecoEmitenteV1 { get; set; }

        [DFeElement(TipoCampo.Long, "c19_municipioEmitente")]
        public long? MunicipioEmitenteV1 { get; set; }

        [DFeElement(TipoCampo.Str, "c20_ufEnderecoEmitente")]
        public string UfEnderecoEmitenteV1 { get; set; }

        [DFeElement(TipoCampo.Str, "c21_cepEmitente")]
        public string CepEmitenteV1 { get; set; }

        [DFeElement(TipoCampo.Str, "c22_telefoneEmitente")]
        public string TelefoneEmitenteV1 { get; set; }

        [DFeElement(TipoCampo.Custom, "c34_tipoIdentificacaoDestinatario")]
        public TipoIdentificacao? TipoIdentificacaoDestinatarioV1 { get; set; }

        [DFeElement("c35_idContribuinteDestinatario")]
        public IdContribuinte IdContribuinteDestinatarioV1 { get; set; }

        [DFeElement(TipoCampo.Str, "c36_inscricaoEstadualDestinatario")]
        public string InscricaoEstadualDestinatarioV1 { get; set; }

        [DFeElement(TipoCampo.Str, "c37_razaoSocialDestinatario")]
        public string RazaoSocialDestinatarioV1 { get; set; }

        [DFeElement(TipoCampo.Long, "c38_municipioDestinatario")]
        public long? MunicipioDestinatarioV1 { get; set; }

        [DFeElement(TipoCampo.Str, "c23_informacoes")]
        public string InformacoesV1 { get; set; }

        [DFeElement(TipoCampo.Str, "c30_nossoNumero")]
        public string NossoNumeroV1 { get; set; }

        [DFeElement(TipoCampo.Dat, "c33_dataPagamento")]
        public DateTime? DataPagamentoV1 { get; set; }

        [DFeElement("c05_referencia")]
        public Referencia ReferenciaV1 { get; set; }

        [DFeCollection("c39_camposExtras")]
        [DFeItem(typeof(CampoExtra), "campoExtra")]
        public List<CampoExtra> CamposExtrasV1 { get; set; }

        [DFeElement(TipoCampo.Str, "c42_identificadorGuia")]
        public string IdentificadorGuiaV1 { get; set; }

        #endregion Dados Versao1

        #region Versao2

        [DFeElement(TipoCampo.Str, "ufFavorecida")]
        public string UfFavorecidaV2 { get; set; }

        [DFeElement(TipoCampo.Custom, "tipoGnre")]
        public TipoGnre? TipoGnreV2 { get; set; }

        [DFeElement("contribuinteEmitente")]
        public ContribuinteEmitente IdContribuinteEmitenteV2 { get; set; }

        [DFeCollection("itensGNRE")]
        [DFeItem(typeof(ItemGnre), "item")]
        public List<ItemGnre> ItensGnreV2 { get; set; }

        [DFeElement(TipoCampo.De2, "valorGNRE")]
        public decimal? ValorGnreV2 { get; set; }

        [DFeElement(TipoCampo.Dat, "dataPagamento")]
        public DateTime? DataPagamentoV2 { get; set; }

        [DFeElement(TipoCampo.Str, "identificadorGuia")]
        public string IdentificadorGuiaV2 { get; set; }

        #endregion Versao2

        [DFeElement(TipoCampo.Dat, "dataLimitePagamento")]
        public DateTime? DataLimitePagamento { get; set; }

        [DFeCollection("informacoesComplementares")]
        [DFeItem(typeof(Informacao), "informacao")]
        public List<Informacao> InformacoesComplementares { get; set; }

        [DFeElement(TipoCampo.Str, "nossoNumero")]
        public string NossoNumero { get; set; }

        #region ResultadoGuia

        [DFeElement(TipoCampo.Str, "linhaDigitavel")]
        public string LinhaDigitavel { get; set; }

        [DFeElement(TipoCampo.Str, "codigoBarras")]
        public string CodigoBarras { get; set; }

        [DFeCollection("motivosRejeicao")]
        [DFeItem(typeof(Motivo), "motivo")]
        public List<Motivo> MotivosRejeicao { get; set; }

        #endregion ResultadoGuia

        #endregion Properties

        #region Methods

        private string SerializeTipoIdentificacaoEmitenteV1()
        {
            switch (TipoIdentificacaoEmitenteV1)
            {
                case TipoIdentificacao.Cnpj: return "1";
                case TipoIdentificacao.Cpf: return "2";
                default: return null;
            }
        }

        private object DeserializeTipoIdentificacaoEmitenteV1(string value)
        {
            switch (value)
            {
                case "1": return TipoIdentificacao.Cnpj;
                case "2": return TipoIdentificacao.Cpf;
                default: return null;
            }
        }

        private string SerializeTipoIdentificacaoDestinatarioV1()
        {
            switch (TipoIdentificacaoEmitenteV1)
            {
                case TipoIdentificacao.Cnpj: return "1";
                case TipoIdentificacao.Cpf: return "2";
                default: return null;
            }
        }

        private object DeserializeTipoIdentificacaoDestinatarioV1(string value)
        {
            switch (value)
            {
                case "1": return TipoIdentificacao.Cnpj;
                case "2": return TipoIdentificacao.Cpf;
                default: return null;
            }
        }

        private string SerializeTipoGnreV2()
        {
            switch (TipoGnreV2)
            {
                case TipoGnre.GnreSimples: return "0";
                case TipoGnre.GnreMultiplosDoctos: return "1";
                case TipoGnre.GnreMultiplasReceitas: return "2";
                default: return null;
            }
        }

        private object DeserializeTipoGnreV2(string value)
        {
            switch (value)
            {
                case "0": return TipoGnre.GnreSimples;
                case "1": return TipoGnre.GnreMultiplosDoctos;
                case "2": return TipoGnre.GnreMultiplasReceitas;
                default: return null;
            }
        }

        #endregion Methods
    }
}