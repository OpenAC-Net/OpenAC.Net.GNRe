// ***********************************************************************
// Assembly         : OpenAC.Net.GNRe
// Author           : Rafael Dias
// Created          : 29-10-2021
//
// Last Modified By : Rafael Dias
// Last Modified On : 29-10-2021
// ***********************************************************************
// <copyright file="GNReArquivosConfig.cs" company="OpenAC .Net">
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
using System.IO;
using OpenAC.Net.Core.Extensions;
using OpenAC.Net.DFe.Core.Common;
using OpenAC.Net.GNRe.Commom;

namespace OpenAC.Net.GNRe
{
    public sealed class GNReArquivosConfig : DFeArquivosConfigBase<SchemaGNRe>
    {
        #region Fields

        private readonly GNReConfig config;

        #endregion Fields

        #region Constructors

        internal GNReArquivosConfig(GNReConfig parent)
        {
            config = parent;
        }

        #endregion Constructors

        #region Properties

        public string PathGNRe { get; set; }

        #endregion Properties

        #region Methods

        public string GetPathGNRe(DateTime data, string cnpj = "")
        {
            return GetPath(PathGNRe.IsEmpty() ? PathSalvar : PathGNRe, "GNRe", cnpj, data);
        }

        protected override void ArquivoServicoChange()
        {
            //
        }

        public override string GetSchema(SchemaGNRe schema)
        {
            string result;
            switch (config.Geral.VersaoDFe)
            {
                case VersaoGNre.v100:
                    switch (schema)
                    {
                        case SchemaGNRe.Recepcao:
                            result = "lote_gnre_v1.00.xsd";
                            break;

                        case SchemaGNRe.RetRecepcao:
                            result = "lote_gnre_consulta_v1.00.xsd";
                            break;

                        case SchemaGNRe.ConsultaConfigUF:
                            result = "consulta_config_uf_v1.00.xsd";
                            break;

                        default:
                            throw new ArgumentOutOfRangeException(nameof(schema), schema, null);
                    }
                    break;

                case VersaoGNre.v200:
                    switch (schema)
                    {
                        case SchemaGNRe.Recepcao:
                            result = "lote_gnre_v2.00.xsd";
                            break;

                        case SchemaGNRe.RetRecepcao:
                            result = "lote_gnre_consulta_v1.00.xsd";
                            break;

                        case SchemaGNRe.ConsultaConfigUF:
                            result = "consulta_config_uf_v1.00.xsd";
                            break;

                        default:
                            throw new ArgumentOutOfRangeException(nameof(schema), schema, null);
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return Path.Combine(PathSchemas, result);
        }

        #endregion Methods
    }
}