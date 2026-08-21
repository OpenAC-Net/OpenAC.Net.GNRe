using OpenAC.Net.DFe.Core.Attributes;
using OpenAC.Net.DFe.Core.Serializer;

namespace OpenAC.Net.GNRe.Commom
{
    [DFeRoot("valor", Namespace = "http://www.gnre.pe.gov.br")]
    public sealed partial class DecimalCampo
    {
        [DFeItemValue(Tipo = TipoCampo.De2)]
        public decimal Value { get; set; }

        [DFeAttribute(TipoCampo.Str, "tipo")]
        public string Tipo { get; set; }
    }
}