// ***********************************************************************
// Assembly         : OpenAC.Net.GNRe
// Author           : Rafael Dias
// Created          : 29-10-2021
//
// Last Modified By : Rafael Dias
// Last Modified On : 29-10-2021
// ***********************************************************************
// <copyright file="Receita.cs" company="OpenAC .Net">
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

using System.Collections.Generic;
using OpenAC.Net.DFe.Core.Attributes;
using OpenAC.Net.DFe.Core.Serializer;

namespace OpenAC.Net.GNRe.Classes
{
    public sealed class Receita
    {
        #region Constructors

        public Receita()
        {
            DetalhamentosReceita = new List<DetalhamentoReceita>();
            Produtos = new List<Produto>();
            PeriodosApuracao = new List<PeriodoApuracao>();
            TiposDocumentosOrigem = new TiposDocumentosOrigem();
            VersoesXmlDocOrigem = new List<VersaoXml>();
            CamposAdicionais = new List<CampoAdicional>();
        }

        #endregion Constructors

        #region Properties

        [DFeAttribute(TipoCampo.Str, "codigo")]
        public string Codigo { get; set; }

        [DFeAttribute(TipoCampo.Str, "descricao")]
        public string Descricao { get; set; }

        [DFeAttribute(TipoCampo.Custom, "courier", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public bool? Courier { get; set; }

        [DFeElement(TipoCampo.Custom, "exigeContribuinteEmitente", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public bool? ExigeContribuinteEmitente { get; set; }

        [DFeElement(TipoCampo.Enum, "exigeDetalhamentoReceita", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public ExigeCampo ExigeDetalhamentoReceita { get; set; }

        [DFeCollection("detalhamentosReceita")]
        [DFeItem(typeof(DetalhamentoReceita), "detalhamentoReceita")]
        public List<DetalhamentoReceita> DetalhamentosReceita { get; set; }

        [DFeElement(TipoCampo.Enum, "exigeProduto", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public ExigeCampo ExigeProduto { get; set; }

        [DFeCollection("produtos")]
        [DFeItem(typeof(Produto), "produto")]
        public List<Produto> Produtos { get; set; }

        [DFeElement(TipoCampo.Enum, "exigePeriodoReferencia", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public SimNaoCampo ExigePeriodoReferencia { get; set; }

        [DFeElement(TipoCampo.Enum, "exigePeriodoApuracao", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public ExigeCampo ExigePeriodoApuracao { get; set; }

        [DFeCollection("periodosApuracao")]
        [DFeItem(typeof(PeriodoApuracao), "periodoApuracao")]
        public List<PeriodoApuracao> PeriodosApuracao { get; set; }

        [DFeElement(TipoCampo.Enum, "exigeParcela", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public SimNaoCampo ExigeParcela { get; set; }

        [DFeElement(TipoCampo.Enum, "valorExigido", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public ValorExigidoCampo ValorExigido { get; set; }

        [DFeElement(TipoCampo.Enum, "exigeDocumentoOrigem", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public ExigeCampo ExigeDocumentoOrigem { get; set; }

        [DFeElement("tiposDocumentosOrigem")]
        public TiposDocumentosOrigem TiposDocumentosOrigem { get; set; }

        [DFeCollection("versoesXmlDocOrigem")]
        [DFeItem(typeof(VersaoXml), "versao")]
        public List<VersaoXml> VersoesXmlDocOrigem { get; set; }

        [DFeElement(TipoCampo.Custom, "exigeContribuinteDestinatario", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public bool? ExigeContribuinteDestinatario { get; set; }

        [DFeElement(TipoCampo.Enum, "exigeDataVencimento", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public SimNaoCampo ExigeDataVencimento { get; set; }

        [DFeElement(TipoCampo.Enum, "exigeDataPagamento", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public SimNaoCampo ExigeDataPagamento { get; set; }

        [DFeElement(TipoCampo.Enum, "exigeConvenio", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public SimNaoCampo ExigeConvenio { get; set; }

        [DFeElement(TipoCampo.Enum, "exigeValorFecp", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public SimNaoCampo ExigeValorFecp { get; set; }

        [DFeElement(TipoCampo.Enum, "exigeCamposAdicionais", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public SimNaoCampo ExigeCamposAdicionais { get; set; }

        [DFeCollection("camposAdicionais")]
        [DFeItem(typeof(CampoAdicional), "campoAdicional")]
        public List<CampoAdicional> CamposAdicionais { get; set; }

        #endregion Properties

        #region Methods

        private string SerializeCourier()
        {
            switch (Courier)
            {
                case true: return "S";
                case false: return "N";
                default: return null;
            }
        }

        private object DeserializeCourier(string value)
        {
            switch (value)
            {
                case "S": return true;
                case "N": return false;
                default: return null;
            }
        }

        private string SerializeExigeContribuinteEmitente()
        {
            switch (ExigeContribuinteEmitente)
            {
                case true: return "S";
                case false: return "N";
                default: return null;
            }
        }

        private object DeserializeExigeContribuinteEmitente(string value)
        {
            switch (value)
            {
                case "S": return true;
                case "N": return false;
                default: return null;
            }
        }

        private string SerializeExigeContribuinteDestinatario()
        {
            switch (ExigeContribuinteDestinatario)
            {
                case true: return "S";
                case false: return "N";
                default: return null;
            }
        }

        private object DeserializeExigeContribuinteDestinatario(string value)
        {
            switch (value)
            {
                case "S": return true;
                case "N": return false;
                default: return null;
            }
        }

        #endregion Methods
    }
}