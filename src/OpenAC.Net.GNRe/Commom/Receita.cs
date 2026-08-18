using System.Collections.Generic;
using OpenAC.Net.DFe.Core.Attributes;
using OpenAC.Net.DFe.Core.Serializer;

namespace OpenAC.Net.GNRe.Commom
{
    public sealed partial class Receita
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

        [DFeAttribute(TipoCampo.Enum, "courier", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public SimNaoLetra? Courier { get; set; }

        [DFeElement(TipoCampo.Enum, "exigeContribuinteEmitente", Namespace = "http://www.gnre.pe.gov.br", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public SimNaoLetra? ExigeContribuinteEmitente { get; set; }

        [DFeElement(TipoCampo.Enum, "exigeDetalhamentoReceita", Namespace = "http://www.gnre.pe.gov.br", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public ExigeCampo ExigeDetalhamentoReceita { get; set; }

        [DFeCollection("detalhamentosReceita", Namespace = "http://www.gnre.pe.gov.br")]
        [DFeItem(typeof(DetalhamentoReceita), "detalhamentoReceita", Namespace = "http://www.gnre.pe.gov.br")]
        public List<DetalhamentoReceita> DetalhamentosReceita { get; set; }

        [DFeElement(TipoCampo.Enum, "exigeProduto", Namespace = "http://www.gnre.pe.gov.br", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public ExigeCampo ExigeProduto { get; set; }

        [DFeCollection("produtos", Namespace = "http://www.gnre.pe.gov.br")]
        [DFeItem(typeof(Produto), "produto", Namespace = "http://www.gnre.pe.gov.br")]
        public List<Produto> Produtos { get; set; }

        [DFeElement(TipoCampo.Enum, "exigePeriodoReferencia", Namespace = "http://www.gnre.pe.gov.br", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public SimNaoCampo ExigePeriodoReferencia { get; set; }

        [DFeElement(TipoCampo.Enum, "exigePeriodoApuracao", Namespace = "http://www.gnre.pe.gov.br", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public ExigeCampo ExigePeriodoApuracao { get; set; }

        [DFeCollection("periodosApuracao", Namespace = "http://www.gnre.pe.gov.br")]
        [DFeItem(typeof(PeriodoApuracao), "periodoApuracao", Namespace = "http://www.gnre.pe.gov.br")]
        public List<PeriodoApuracao> PeriodosApuracao { get; set; }

        [DFeElement(TipoCampo.Enum, "exigeParcela", Namespace = "http://www.gnre.pe.gov.br", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public SimNaoCampo ExigeParcela { get; set; }

        [DFeElement(TipoCampo.Enum, "valorExigido", Namespace = "http://www.gnre.pe.gov.br", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public ValorExigidoCampo ValorExigido { get; set; }

        [DFeElement(TipoCampo.Enum, "exigeDocumentoOrigem", Namespace = "http://www.gnre.pe.gov.br", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public ExigeCampo ExigeDocumentoOrigem { get; set; }

        [DFeElement("tiposDocumentosOrigem", Namespace = "http://www.gnre.pe.gov.br")]
        public TiposDocumentosOrigem TiposDocumentosOrigem { get; set; }

        [DFeCollection("versoesXmlDocOrigem", Namespace = "http://www.gnre.pe.gov.br")]
        [DFeItem(typeof(VersaoXml), "versao", Namespace = "http://www.gnre.pe.gov.br")]
        public List<VersaoXml> VersoesXmlDocOrigem { get; set; }

        [DFeElement(TipoCampo.Enum, "exigeContribuinteDestinatario", Namespace = "http://www.gnre.pe.gov.br", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public SimNaoLetra? ExigeContribuinteDestinatario { get; set; }

        [DFeElement(TipoCampo.Enum, "exigeDataVencimento", Namespace = "http://www.gnre.pe.gov.br", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public SimNaoCampo ExigeDataVencimento { get; set; }

        [DFeElement(TipoCampo.Enum, "exigeDataPagamento", Namespace = "http://www.gnre.pe.gov.br", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public SimNaoCampo ExigeDataPagamento { get; set; }

        [DFeElement(TipoCampo.Enum, "exigeConvenio", Namespace = "http://www.gnre.pe.gov.br", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public SimNaoCampo ExigeConvenio { get; set; }

        [DFeElement(TipoCampo.Enum, "exigeValorFecp", Namespace = "http://www.gnre.pe.gov.br", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public SimNaoCampo ExigeValorFecp { get; set; }

        [DFeElement(TipoCampo.Enum, "exigeCamposAdicionais", Namespace = "http://www.gnre.pe.gov.br", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public SimNaoCampo ExigeCamposAdicionais { get; set; }

        [DFeCollection("camposAdicionais", Namespace = "http://www.gnre.pe.gov.br")]
        [DFeItem(typeof(CampoAdicional), "campoAdicional", Namespace = "http://www.gnre.pe.gov.br")]
        public List<CampoAdicional> CamposAdicionais { get; set; }

        public bool ShouldSerializeDetalhamentosReceita() => DetalhamentosReceita != null && DetalhamentosReceita.Count > 0;
        public bool ShouldSerializeProdutos() => Produtos != null && Produtos.Count > 0;
        public bool ShouldSerializePeriodosApuracao() => PeriodosApuracao != null && PeriodosApuracao.Count > 0;
        public bool ShouldSerializeCamposAdicionais() => CamposAdicionais != null && CamposAdicionais.Count > 0;
        public bool ShouldSerializeVersoesXmlDocOrigem() => VersoesXmlDocOrigem != null && VersoesXmlDocOrigem.Count > 0;
        public bool ShouldSerializeTiposDocumentosOrigem() => TiposDocumentosOrigem != null && TiposDocumentosOrigem.TipoDocumentoOrigem.Count > 0;

        #endregion Properties
    }
}