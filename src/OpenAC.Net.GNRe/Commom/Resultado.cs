// ***********************************************************************
// Assembly         : OpenAC.Net.GNRe
// Author           : Rafael Dias
// Created          : 29-10-2021
//
// Last Modified By : Rafael Dias
// Last Modified On : 29-10-2021
// ***********************************************************************
// <copyright file="Resultado.cs" company="OpenAC .Net">
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
using System.IO;
using OpenAC.Net.DFe.Core.Attributes;
using OpenAC.Net.DFe.Core.Serializer;

namespace OpenAC.Net.GNRe.Commom
{
    public sealed partial class Resultado
    {
        #region Constructors

        public Resultado()
        {
            Guia = new List<GuiaResult>();
        }

        #endregion Constructors

        #region Properties

        [DFeCollection("guia")]
        public List<GuiaResult> Guia { get; set; }

        [DFeElement(TipoCampo.Str, "pdfGuias")]
        public string PdfGuias { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Salva o PDF da guia caso a mesma tenha vindo no xml.
        /// </summary>
        /// <param name="path">Caminho completo para salvar o pdf das guias.</param>
        /// <returns></returns>
        public bool SalvarGuia(string path = "guias.pdf")
        {
            if (string.IsNullOrWhiteSpace(PdfGuias)) return false;

            if (File.Exists(path)) File.Delete(path);

            var bytes = Convert.FromBase64String(PdfGuias);
            File.WriteAllBytes(path, bytes);

            return true;
        }

        /// <summary>
        /// Retorna um Stream contendo o PDF das guias.
        /// </summary>
        /// <returns></returns>
        public Stream GetPdfGuiasStream()
        {
            if (string.IsNullOrWhiteSpace(PdfGuias)) return Stream.Null;
            var bytes = Convert.FromBase64String(PdfGuias);
            return new MemoryStream(bytes);
        }

        #endregion Methods
    }
}