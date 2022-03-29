// ***********************************************************************
// Assembly         : OpenAC.Net.GNRe
// Author           : Rafael Dias
// Created          : 29-10-2021
//
// Last Modified By : Rafael Dias
// Last Modified On : 29-10-2021
// ***********************************************************************
// <copyright file="OpenGNRe.cs" company="OpenAC .Net">
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
using System.Linq;
using System.Threading.Tasks;
using OpenAC.Net.Core;
using OpenAC.Net.Core.Logging;
using OpenAC.Net.GNRe.Commom;
using OpenAC.Net.GNRe.WebService;

namespace OpenAC.Net.GNRe
{
    public sealed class OpenGNRe : IOpenLog
    {
        #region properties

        public GNReConfig Config { get; private set; }

        public GuiasCollections Guias { get; private set; }

        #endregion properties

        #region Constructors

        public OpenGNRe()
        {
            Config = new GNReConfig();
            Guias = new GuiasCollections();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Envia um lote de guias para processamento
        /// </summary>
        /// <returns></returns>
        public Task<RecepcaoLoteResposta> RecepcaoLoteAsync()
        {
            Guard.Against<ArgumentException>(!Guias.Any(), "Nenhuma Guia adicionada para envio.");

            return Task.Run(() =>
            {
                var request = new LoteGnreRequest
                {
                    Versao = Config.Geral.VersaoDFe,
                    Guias = Guias
                };

                using var service = new ServicoRecepcaoLote(Config);
                return service.Processar(request);
            });
        }

        /// <summary>
        /// Envia um lote de guias para processamento
        /// </summary>
        /// <returns></returns>
        public RecepcaoLoteResposta RecepcaoLote()
        {
            var request = new LoteGnreRequest
            {
                Versao = Config.Geral.VersaoDFe,
                Guias = Guias
            };

            using var service = new ServicoRecepcaoLote(Config);
            return service.Processar(request);
        }

        /// <summary>
        /// Consulta o resultado do processamento do lote de guias.
        /// </summary>
        /// <param name="numeroRecibo"></param>
        /// <param name="incluirPdf"></param>
        /// <returns></returns>
        public Task<ConsultarLoteResposta> ConsultaLoteAsync(string numeroRecibo, bool incluirPdf)
        {
            return Task.Run(() =>
            {
                var request = new ConsultaLoteRequest
                {
                    Ambiente = Config.WebServices.Ambiente,
                    NumeroRecibo = numeroRecibo,
                    IncluirPdfsGuias = incluirPdf
                };

                using var service = new ServicoResultadoLote(Config);
                return service.Processar(request);
            });
        }

        /// <summary>
        /// Consulta o resultado do processamento do lote de guias.
        /// </summary>
        /// <param name="numeroRecibo"></param>
        /// <param name="incluirPdf"></param>
        /// <returns></returns>
        public ConsultarLoteResposta ConsultaLote(string numeroRecibo, bool incluirPdf)
        {
            var request = new ConsultaLoteRequest
            {
                Ambiente = Config.WebServices.Ambiente,
                NumeroRecibo = numeroRecibo,
                IncluirPdfsGuias = incluirPdf
            };

            using var service = new ServicoResultadoLote(Config);
            return service.Processar(request);
        }

        /// <summary>
        /// Consultas as configurações da UF.
        /// </summary>
        /// <param name="uf"></param>
        /// <param name="receita"></param>
        /// <param name="courier"></param>
        /// <returns></returns>
        public Task<ConsultaConfigUFResposta> ConsultaConfigUFAsync(string uf, string receita = null, bool? courier = null)
        {
            return Task.Run(() =>
            {
                var request = new ConsultaConfigUFRequest()
                {
                    Ambiente = Config.WebServices.Ambiente,
                    Uf = uf,
                    Receita = new ReceitaValue()
                    {
                        Value = receita,
                        Courier = courier
                    }
                };

                using var service = new ServicoConfigUF(Config);
                return service.Processar(request);
            });
        }

        /// <summary>
        /// Consultas as configurações da UF.
        /// </summary>
        /// <param name="uf"></param>
        /// <param name="receita"></param>
        /// <param name="courier"></param>
        /// <returns></returns>
        public ConsultaConfigUFResposta ConsultaConfigUF(string uf, string receita = null, bool? courier = null)
        {
            var request = new ConsultaConfigUFRequest()
            {
                Ambiente = Config.WebServices.Ambiente,
                Uf = uf,
                Receita = new ReceitaValue()
                {
                    Value = receita,
                    Courier = courier
                }
            };

            using var service = new ServicoConfigUF(Config);
            return service.Processar(request);
        }

        #endregion Methods
    }
}