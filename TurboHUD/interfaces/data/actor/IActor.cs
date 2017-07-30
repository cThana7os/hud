namespace Turbo.Plugins
{
    public interface IActor
    {
        ISnoActor SnoActor { get; }
        GizmoType GizmoType { get; }

        uint AcdId { get; }
        uint AnnId { get; }
        IWorldCoordinate FloorCoordinate { get; }
        IWorldCoordinate CollisionCoordinate { get; }
        float RadiusScaled { get; }
        float RadiusBottom { get; }

        uint WorldId { get; }
        uint WorldSno { get; }
        ISnoWorld SnoWorld { get; }
        IScene Scene { get; }

        // ---------------------------
        // hint: use these members because they are cached and not calculated at every call
        IScreenCoordinate ScreenCoordinate { get; }
        bool IsOnScreen { get; }
        double CentralXyDistanceToMe { get; }
        double NormalizedXyDistanceToMe { get; }
        double ZDistanceToMeAbsolute { get; }
        // ---------------------------

        float Hitpoints { get; }
        uint SummonerId { get; }
        uint SummonerAcdDynamicId { get; }

        bool IsClickable { get; }
        bool IsDisabled { get; }
        bool IsOperated { get; }
        bool DisplayOnOverlay { get; } // !Disabled && !Operated

        // valid only for gold
        uint Amount { get; }
        
        int CreatedAtInGameTick { get; }

        // Get/set plugin-specific custom data. Only one data can be stored per type!
        T GetData<T>() where T : class;
        void SetData<T>(T data) where T : class;

        IWatch LastSpeak { get; set; } // null by default to spare memory
    }
}