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

using System.Collections.Generic;
using OpenAC.Net.DFe.Core.Attributes;
using OpenAC.Net.DFe.Core.Serializer;

namespace OpenAC.Net.GNRe.Classes
{
    public sealed class CampoAdicional
    {
        #region Constructors

        public CampoAdicional()
        {
            VersoesXml = new List<VersaoXml>();
        }

        #endregion Constructors

        #region Properties

        [DFeAttribute(TipoCampo.Str, "campo")]
        public string Campo { get; set; }

        [DFeAttribute(TipoCampo.Custom, "obrigatorio", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public bool? Obrigatorio { get; set; }

        [DFeElement("codigo")]
        public StringCampoBase Codigo { get; set; }

        [DFeElement("tipo")]
        public TipoCampoAdicionalTipo Tipo { get; set; }

        [DFeElement(TipoCampo.Int, "tamanho")]
        public int Tamanho { get; set; }

        [DFeElement(TipoCampo.Int, "casasDecimais")]
        public int CasasDecimais { get; set; }

        [DFeElement(TipoCampo.Str, "titulo")]
        public string Titulo { get; set; }

        [DFeCollection("versoesXmlCampoAdicional")]
        [DFeItem(typeof(VersaoXml), "versao")]
        public List<VersaoXml> VersoesXml { get; set; }

        #endregion Properties

        #region Methods

        private string SerializeObrigatorio()
        {
            switch (Obrigatorio)
            {
                case true: return "S";
                case false: return "N";
                default: return null;
            }
        }

        private object DeserializeObrigatorio(string value)
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