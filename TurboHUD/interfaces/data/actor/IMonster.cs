using System.Collections.Generic;

namespace Turbo.Plugins
{

    public interface IMonster: IActor, IAvoid
    {

        ISnoMonster SnoMonster { get; }

        bool IsAlive { get; }

        bool IsElite { get; }
        double MaxHealth { get; }
        double CurHealth { get; }
        ActorRarity Rarity { get; }

        IMonsterPack Pack { get; }

        bool IsQuestMonster { get; }

        float DotDpsApplied { get; }
        bool Frozen { get; }
        bool Chilled { get; }
        bool Slow { get; }
        bool Stunned { get; }
        bool Burrowed { get; }
        bool Invulnerable { get; }
        bool Untargetable { get; }
        bool Hidden { get; }
        bool Stealthed { get; }
        bool Invisible { get; }
        bool Blind { get; }
        bool Attackable { get; set; } // IsOnScreen && !Untargetable && !Invisible

        // note: these will be removed later
        bool Palmed { get; set; }
        bool Haunted { get; set; }
        bool MarkedForDeath { get; set; }
        bool Locust { get; set; }
        bool Strongarmed { get; set; }
        bool Phoenixed { get; set; }

        IEnumerable<ISnoMonsterAffix> AffixSnoList { get; }
    }
}