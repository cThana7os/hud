using System;
using System.Collections.Generic;

namespace Turbo.Plugins
{
    public interface IController
    {
        ITextureController Texture { get; }
        IRenderController Render { get; }
        IStatController Stat { get; }
        IInventoryController Inventory { get; }
        IQueueController Queue { get; }
        IInputController Input { get; }
        IWindow Window { get; }
        IGameController Game { get; }
        ISnoController Sno { get; }

        string MyBattleTag { get; }
        IEnumerable<IHero> AccountHeroes { get; }
        
        T GetPlugin<T>() where T : IPlugin;
        void RunOnPlugin<T>(Action<T> action) where T : IPlugin;
        void TogglePlugin<T>(bool enabled) where T : IPlugin;
        IEnumerable<IPlugin> AllPlugins { get; }

        IWatch CreateWatch();
        IWatch CreateAndStartWatch();

        void Debug(string text);

        bool SpeakEngineEnabled { get; set; }
        IWatch LastSpeak { get; }
        void Speak(string text);

        IStatTracker Session { get; }
        IStatTracker SessionAlwaysRunning { get; } // (ABS)

        IStatTracker CurrentAccountTotal { get; }
        IStatTracker CurrentAccountLastMonth { get; } // only available in menu
        IStatTracker CurrentAccountLastWeek { get; } // only available in menu
        IStatTracker CurrentAccountYesterday { get; }
        IStatTracker CurrentAccountToday { get; }
    }
}