using OpenAC.Net.DFe.Core.Attributes;
using OpenAC.Net.DFe.Core.Serializer;

namespace OpenAC.Net.GNRe.Commom
{
    [DFeRoot("exigeCampo", Namespace = "http://www.gnre.pe.gov.br")]
    public sealed partial class ExigeCampo
    {
        #region Properties

        [DFeItemValue(Tipo = TipoCampo.Str)]
        public string Value { get; set; }

        [DFeAttribute(TipoCampo.Str, "campo")]
        public string Campo { get; set; }

        [DFeAttribute(TipoCampo.Str, "campo2_00", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public string Campo200 { get; set; }

        #endregion Properties

        #region Methods

        public static ExigeCampo Sim(string campo, string campo200 = null) => new() { Campo = campo, Campo200 = campo200, Value = "S" };

        public static ExigeCampo Nao(string campo, string campo200 = null) => new() { Campo = campo, Campo200 = campo200, Value = "N" };

        #endregion Methods
    }
}