using System.Linq;
using System;
using Turbo.Plugins.Default;
 
namespace Turbo.Plugins.glq
{
    using System.Text;
    public class GLQ_AncientParthanCount : BasePlugin, IInGameTopPainter
    {
        public IFont TextFont { get; set; }
        public float XWidth { get; set; }
        public float YHeight { get; set; } 
		public int percent { get; set; }     
        private StringBuilder textBuilder;
 
        public GLQ_AncientParthanCount()
        {
            Enabled = true;
        }
 
        public override void Load(IController hud)
        {
            base.Load(hud);
            TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 170, 90, 90, false, false, true);
            XWidth = 0.7f;
            YHeight = 0.4f;
			percent = 10;
            textBuilder = new StringBuilder();
        }
 
        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;
            if (!Hud.Game.Me.Powers.BuffIsActive(Hud.Sno.SnoPowers.AncientParthanDefenders.Sno)) return;
            int Count = Hud.Game.AliveMonsters.Count(m => (m.Stunned || m.Frozen) && m.NormalizedXyDistanceToMe <= 25);
            if (Count == 0) return;
            double dr = 100 * ( 1 - Math.Pow(1 - percent * 0.01d, Count));  
            float XPos = Hud.Window.Size.Width * XWidth;
            float YPos = Hud.Window.Size.Height * YHeight;
             if (Hud.Game.Me.CubeSnoItem2.LegendaryPower.Sno == Hud.Sno.SnoPowers.AncientParthanDefenders.Sno) 
             { 
               percent = 12; 
             }
            textBuilder.Clear();
            textBuilder.AppendFormat("古帕触发数: {0} 特效值：{1}%", Count, percent);
            textBuilder.AppendLine();
            textBuilder.AppendFormat("古帕总减伤: {0}",dr.ToString("f2") + "%");

            var layout = TextFont.GetTextLayout(textBuilder.ToString());
            TextFont.DrawText(layout, XPos, YPos);
        }
 
    }
 
}