// ***********************************************************************
// Assembly         : OpenAC.Net.GNRe
// Author           : Rafael Dias
// Created          : 29-10-2021
//
// Last Modified By : Rafael Dias
// Last Modified On : 29-10-2021
// ***********************************************************************
// <copyright file="ItemGnre.cs" company="OpenAC .Net">
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

namespace OpenAC.Net.GNRe.Classes
{
    public sealed class ItemGnre
    {
        #region Properties

        [DFeElement(TipoCampo.Str, "receita", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 1)]
        public string Receita { get; set; }

        [DFeElement(TipoCampo.Str, "detalhamentoReceita", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 2)]
        public string DetalhamentoReceita { get; set; }

        [DFeElement(TipoCampo.Str, "documentoOrigem", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 3)]
        public StringTipo DocumentoOrigem { get; set; }

        [DFeElement(TipoCampo.Str, "produto", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 4)]
        public string Produto { get; set; }

        [DFeElement("referencia", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 5)]
        public Referencia Referencia { get; set; }

        [DFeElement(TipoCampo.Dat, "dataVencimento", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 6)]
        public DateTime? DataVencimento { get; set; }

        [DFeCollection("", Tipo = TipoCampo.De2, Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 7)]
        [DFeItem(typeof(DecimalCampo), "valor")]
        public List<DecimalCampo> Valor { get; set; }

        [DFeElement(TipoCampo.Str, "convenio", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 8)]
        public string Convenio { get; set; }

        [DFeElement("contribuinteDestinatario", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 9)]
        public ContribuinteDestinatario ContribuinteDestinatario { get; set; }

        [DFeCollection("camposExtras", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 10)]
        [DFeItem(typeof(CampoExtraBase), "campoExtra")]
        public List<CampoExtraBase> CamposExtras { get; set; }

        [DFeElement(TipoCampo.Str, "numeroControle", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 11)]
        public string NumeroControle { get; set; }

        [DFeElement(TipoCampo.Str, "numeroControleFecp", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 12)]
        public string NumeroControleFecp { get; set; }

        #endregion Properties
    }
}