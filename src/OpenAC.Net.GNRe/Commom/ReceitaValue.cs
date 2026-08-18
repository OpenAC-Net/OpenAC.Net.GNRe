using OpenAC.Net.DFe.Core.Attributes;
using OpenAC.Net.DFe.Core.Serializer;

namespace OpenAC.Net.GNRe.Commom
{
    public sealed partial class ReceitaValue
    {
        #region Properties

        [DFeItemValue(Tipo = TipoCampo.Str)]
        public string Value { get; set; }

        [DFeAttribute(TipoCampo.Enum, "courier", Ocorrencia = Ocorrencia.NaoObrigatoria)]
        public SimNaoLetra? Courier { get; set; }

        #endregion Properties
    }
}