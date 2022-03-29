using OpenAC.Net.DFe.Core.Attributes;
using OpenAC.Net.DFe.Core.Serializer;

namespace OpenAC.Net.GNRe.Commom
{
    public class DecimalCampo
    {
        [DFeItemValue(Tipo = TipoCampo.De2)]
        public decimal Value { get; set; }

        [DFeAttribute(TipoCampo.Str, "tipo")]
        public string Tipo { get; set; }
    }
}