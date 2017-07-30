using System.Collections.Generic;

namespace Turbo.Plugins
{

    public interface IAttribute
    {

        string Code { get; }
        uint Index { get; }
        AttributeValueType ValueType { get; }
        IEnumerable<IAttributeProcessor> Processors { get; }
        bool OrderIndexPrimary { get; }
        string GetDescription(uint modifier);
        int GetModLowestOrderIndex(int mod);
    }

}