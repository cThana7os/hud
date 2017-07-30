using Turbo.Plugins.Default;
using SharpDX;
using System.Linq;
using System.Collections.Generic;
namespace Turbo.Plugins.glq
{
    public class GLQ_PlayerSkillBarPlugin : BasePlugin, IInGameWorldPainter
    {
        public float SkillRatio { get; set; }

        public GLQ_SkillBarPainter SkillPainter { get; set; }
        public float XOffset { get; set; }
        public float YOffset { get; set; }

        private float currentX { get; set; }

        public GLQ_PlayerSkillBarPlugin()
        {
            Enabled = true;
        }
        public override void Load(IController hud)
        {
            base.Load(hud);
            SkillPainter = new GLQ_SkillBarPainter(Hud, true)
            {
                TextureOpacity = 1.0f,
                CooldownFont = Hud.Render.CreateFont("arial", 7, 255, 255, 255, 255, true, false, 255, 0, 0, 0, true),
            };
            SkillRatio = 0.015f;
            XOffset = 0;
            YOffset = Hud.Window.Size.Width * 0.012f;

        }
        public void PaintWorld(WorldLayer layer)
        {
            foreach (IPlayer player in Hud.Game.Players)
            {
                currentX = XOffset;
                if(!player.IsMe) DrawPlayerSkills(player);
            }
        }

        private void DrawPlayerSkills(IPlayer player)
        {
            var size = Hud.Window.Size.Width * SkillRatio;
            var portraitRect = player.PortraitUiElement.Rectangle;
            var index = 0;
            var passivesX = portraitRect.Right;
            foreach (var skill in player.Powers.SkillSlots)
            {
                if (skill != null)
                {
                    index = skill.Key <= ActionKey.RightSkill ? (int)skill.Key + 4 : (int)skill.Key - 2;

                    var y = portraitRect.Y + YOffset;

                    var rect = new RectangleF(currentX + passivesX, y, size, size);

                    SkillPainter.Paint(skill, rect);

                    if (Hud.Window.CursorInsideRect(rect.X, rect.Y, rect.Width, rect.Height))
                    {
                        Hud.Render.SetHint(skill.RuneNameLocalized);
                    }

                }
                currentX += size;
            }

            index = 0;

        }


    }
}
