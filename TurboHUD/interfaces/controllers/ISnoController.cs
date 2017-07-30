using System.Collections.Generic;

namespace Turbo.Plugins
{
    public interface ISnoController
    {
        ISnoPowerList SnoPowers { get; }
        ISnoPower GetSnoPower(uint sno);
        IEnumerable<ISnoPower> AllSnoPower { get; }

        ISnoItemList SnoItems { get; }

        long TotalParagonExperienceRequired(uint paragonLevel);
    }
}