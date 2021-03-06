﻿namespace Turbo.Plugins
{
    public interface IHeroClassDefinition
    {
        HeroClass HeroClass { get; }
        string Code { get; }
        string FullCode { get; }
        string Name { get; }
        uint MaleActorSno { get; }
        uint FemaleActorSno { get; }
        bool IsRanged { get; }
        string PrimaryResourceName { get; } // todo: add localized
        string SecondaryResourceName { get; } // todo: add localized
    }
}