﻿// ***********************************************************************
// Assembly         : OpenAC.Net.GNRe
// Author           : Rafael Dias
// Created          : 29-10-2021
//
// Last Modified By : Rafael Dias
// Last Modified On : 29-10-2021
// ***********************************************************************
// <copyright file="ServicoGNReBase.cs" company="OpenAC .Net">
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

using System.IO;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml.Linq;
using OpenAC.Net.Core.Extensions;
using OpenAC.Net.DFe.Core;
using OpenAC.Net.DFe.Core.Extensions;
using OpenAC.Net.DFe.Core.Service;
using OpenAC.Net.GNRe.Commom;

namespace OpenAC.Net.GNRe.WebService
{
    public abstract class ServicoGNReBase : DFeServiceClientResquest12<GNReConfig, GNReGeralConfig, VersaoGNre, GNReWebserviceConfig, GNReCertificadosConfig, GNReArquivosConfig, SchemaGNRe>
    {
        #region Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="config"></param>
        /// <param name="url"></param>
        protected ServicoGNReBase(GNReConfig config, string url) : base(config, url, config.Certificados.ObterCertificado())
        {
            if (Endpoint.Binding is not CustomBinding binding) return;

            var http = binding.Elements.Find<HttpTransportBindingElement>();
            http.MaxBufferSize = int.MaxValue;
            http.MaxReceivedMessageSize = int.MaxValue;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="versao"></param>
        /// <returns></returns>
        protected static string SoapHeader(VersaoGNre versao) => $"<gnr:gnreCabecMsg><gnr:versaoDados>{versao.GetDFeValue()}</gnr:versaoDados></gnr:gnreCabecMsg>";

        /// <summary>
        ///
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <returns></returns>
        /// <exception cref="OpenDFeCommunicationException"></exception>
        protected override string TratarRetorno(XDocument xmlDocument)
        {
            var element = xmlDocument.ElementAnyNs("Fault");
            if (element == null) return xmlDocument.ToXmlDocument().OuterXml;

            var exMessage = $"{element.ElementAnyNs("Code")?.ElementAnyNs("Value")?.GetValue<string>()} - " +
                            $"{element.ElementAnyNs("Reason")?.ElementAnyNs("Text")?.GetValue<string>()}";
            throw new OpenDFeCommunicationException(exMessage);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="conteudoArquivo"></param>
        /// <param name="nomeArquivo"></param>
        protected void GravarXml(string conteudoArquivo, string nomeArquivo)
        {
            if (Configuracoes.WebServices.Salvar == false) return;

            nomeArquivo = Path.Combine(Configuracoes.Arquivos.PathSalvar, nomeArquivo);
            File.WriteAllText(nomeArquivo, conteudoArquivo, Encoding.UTF8);
        }

        #endregion Methods
    }
}