using SharpDX.Direct2D1;

namespace Turbo.Plugins
{

    public interface IRenderController
    {

        bool UiHidden { get; }
        IBrush CreateBrush(int a, int r, int g, int b, float strokeWidth, DashStyle dash = DashStyle.Solid, CapStyle startCap = CapStyle.Flat, CapStyle endCap = CapStyle.Flat);
        IFont CreateFont(string fontFamily, float size, int a, int r, int g, int b, bool bold, bool italic, bool standardShadow);
        IFont CreateFont(string fontFamily, float size, int a, int r, int g, int b, bool bold, bool italic, int shadowA, int shadowR, int shadowG, int shadowB, bool shadowIsHeavy);

        IUiElement GetUiElement(string path);
        IUiElement MonsterHpBarUiElement { get; }
        IUiElement GetPlayerSkillUiElement(ActionKey key);
        IUiElement MinimapUiElement { get; }
        IUiElement NephalemRiftBarUiElement { get; }
        IUiElement GreaterRiftBarUiElement { get; }
        IUiElement ChallengeRiftBarUiElement { get; }
        IUiElement ChallengeRiftAheadPanelUiElement { get; }

        PathGeometry CreateGeometry();

        void GetMinimapCoordinates(float x, float y, out float mapX, out float mapY);
        float MinimapScale { get; }

        void SetHint(string text, string specialLocation = null);

        void TurnOnAliasing();
        // ALWAYS turn off aliasing after turning it on!
        void TurnOffAliasing();

    }

}