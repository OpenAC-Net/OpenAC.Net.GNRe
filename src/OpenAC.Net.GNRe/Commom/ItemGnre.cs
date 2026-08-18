using System;
using System.Collections.Generic;
using OpenAC.Net.DFe.Core.Attributes;
using OpenAC.Net.DFe.Core.Serializer;

namespace OpenAC.Net.GNRe.Commom
{
    [DFeRoot("item", Namespace = "http://www.gnre.pe.gov.br")]
    public sealed partial class ItemGnre
    {
        #region Properties

        [DFeElement(TipoCampo.Str, "receita", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 1)]
        public string Receita { get; set; }

        [DFeElement(TipoCampo.Str, "detalhamentoReceita", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 2)]
        public string DetalhamentoReceita { get; set; }

        [DFeElement(TipoCampo.Str, "documentoOrigem", Namespace = "http://www.gnre.pe.gov.br", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 3)]
        public StringTipo DocumentoOrigem { get; set; }

        [DFeElement(TipoCampo.Str, "produto", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 4)]
        public string Produto { get; set; }

        [DFeElement("referencia", Namespace = "http://www.gnre.pe.gov.br", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 5)]
        public Referencia Referencia { get; set; }

        [DFeElement(TipoCampo.Dat, "dataVencimento", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 6)]
        public DateTime? DataVencimento { get; set; }

        [DFeCollection("", Tipo = TipoCampo.De2, Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 7)]
        [DFeItem(typeof(DecimalCampo), "valor", Namespace = "http://www.gnre.pe.gov.br")]
        public List<DecimalCampo> Valor { get; set; }

        [DFeElement(TipoCampo.Str, "convenio", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 8)]
        public string Convenio { get; set; }

        [DFeElement("contribuinteDestinatario", Namespace = "http://www.gnre.pe.gov.br", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 9)]
        public ContribuinteDestinatario ContribuinteDestinatario { get; set; }

        [DFeCollection("camposExtras", Namespace = "http://www.gnre.pe.gov.br", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 10)]
        [DFeItem(typeof(CampoExtraBase), "campoExtra", Namespace = "http://www.gnre.pe.gov.br")]
        public List<CampoExtraBase> CamposExtras { get; set; }

        [DFeElement(TipoCampo.Str, "numeroControle", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 11)]
        public string NumeroControle { get; set; }

        [DFeElement(TipoCampo.Str, "numeroControleFecp", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 12)]
        public string NumeroControleFecp { get; set; }

        #endregion Properties
    }
}