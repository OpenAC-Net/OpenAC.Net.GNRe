// ***********************************************************************
// Assembly         : OpenAC.Net.GNRe
// Author           : Rafael Dias
// Created          : 29-10-2021
//
// Last Modified By : Rafael Dias
// Last Modified On : 29-10-2021
// ***********************************************************************
// <copyright file="Referencia.cs" company="OpenAC .Net">
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

using OpenAC.Net.DFe.Core.Attributes;
using OpenAC.Net.DFe.Core.Serializer;

namespace OpenAC.Net.GNRe.Classes
{
    public sealed class Referencia
    {
        #region Properties

        [DFeElement(TipoCampo.Str, "periodo", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 1)]
        public string Periodo { get; set; }

        [DFeElement(TipoCampo.Custom, "mes", Min = 2, Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 2)]
        public int Mes { get; set; }

        [DFeElement(TipoCampo.Custom, "ano", Min = 4, Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 3)]
        public int Ano { get; set; }

        [DFeElement(TipoCampo.Str, "parcela", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 4)]
        public string Parcela { get; set; }

        #endregion Properties

        #region Methods

        private string SerializeMes() => Mes.ToString("00");

        private object DeserializeMes(string value) => int.Parse(value);

        private string SerializeAno() => Ano.ToString("0000");

        private object DeserializeAno(string value) => int.Parse(value);

        #endregion Methods
    }
}