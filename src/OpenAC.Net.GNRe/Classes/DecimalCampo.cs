using OpenAC.Net.DFe.Core.Attributes;
using OpenAC.Net.DFe.Core.Serializer;

namespace OpenAC.Net.GNRe.Classes
{
    public class DecimalCampo
    {
        [DFeItemValue(Tipo = TipoCampo.De2)]
        public decimal Value { get; set; }

        [DFeAttribute(TipoCampo.Str, "tipo")]
        public string Tipo { get; set; }
    }
}