using OpenAC.Net.DFe.Core.Attributes;
using OpenAC.Net.DFe.Core.Serializer;

namespace OpenAC.Net.GNRe.Commom
{
    [DFeRoot("simNaoCampo", Namespace = "http://www.gnre.pe.gov.br")]
    public sealed partial class SimNaoCampo
    {
        #region Properties

        [DFeAttribute(TipoCampo.Str, "campo")]
        public string Campo { get; set; }

        [DFeItemValue(Tipo = TipoCampo.Str)]
        public string Value { get; set; }

        #endregion Properties

        #region Methods

        public static SimNaoCampo Sim(string campo) => new() { Campo = campo, Value = "S" };

        public static SimNaoCampo Nao(string campo) => new() { Campo = campo, Value = "N" };

        #endregion Methods
    }
}