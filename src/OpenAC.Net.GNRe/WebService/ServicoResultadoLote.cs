// ***********************************************************************
// Assembly         : OpenAC.Net.GNRe
// Author           : Rafael Dias
// Created          : 29-10-2021
//
// Last Modified By : Rafael Dias
// Last Modified On : 29-10-2021
// ***********************************************************************
// <copyright file="ServicoResultadoLote.cs" company="OpenAC .Net">
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
using OpenAC.Net.DFe.Core.Common;
using OpenAC.Net.GNRe.Commom;

namespace OpenAC.Net.GNRe.WebService
{
    public sealed class ServicoResultadoLote : ServicoGNReBase
    {
        #region Fields

        private const string UrlProducao = @"https://www.gnre.pe.gov.br/gnreWS/services/GnreResultadoLote?wsdl";
        private const string UrlHomologacao = @"https://www.testegnre.pe.gov.br/gnreWS/services/GnreResultadoLote?wsdl";

        #endregion Fields

        #region Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="config"></param>
        public ServicoResultadoLote(GNReConfig config) : base(config, Url(config.WebServices))
        {
            NomeArquivo = "resultado-lot-soap";
        }

        #endregion Constructors

        #region Methods

        private static string Url(GNReWebserviceConfig configuracao) =>
            configuracao.Ambiente switch
            {
                DFeTipoAmbiente.Homologacao => UrlHomologacao,
                DFeTipoAmbiente.Producao => UrlProducao,
                _ => throw new NotImplementedException($"Ambiente \"{configuracao.Ambiente}\" não implementado")
            };

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ConsultarLoteResposta Processar(ConsultaLoteRequest request)
        {
            var message = request.GetXml(DFeSaveOptions.DisableFormatting | DFeSaveOptions.OmitDeclaration | DFeSaveOptions.RemoveSpaces);
            GravarXml(message, $"{DateTime.Now:yyyyMMddssfff}-resultado-lot-env.xml");

            ValidateMessage(message, SchemaGNRe.RetRecepcao);

            var resposta = Execute("consultar", $@"<gnr:gnreDadosMsg>{message}</gnr:gnreDadosMsg>", SoapHeader(Configuracoes.Geral.VersaoDFe), "xmlns:gnr=\"http://www.gnre.pe.gov.br/webservice/GnreResultadoLote\"");

            GravarXml(resposta, $"{DateTime.Now:yyyyMMddssfff}-resultado-lot-resp.xml");
            return new ConsultarLoteResposta(message, resposta, EnvelopeEnvio, EnvelopeRetorno);
        }

        #endregion Methods
    }
}