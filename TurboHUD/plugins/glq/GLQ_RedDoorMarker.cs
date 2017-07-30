using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using Turbo.Plugins.Default;
namespace Turbo.Plugins.glq
{

    public class GLQ_RedDoorMarker : BasePlugin, IInGameWorldPainter, INewAreaHandler, IInGameTopPainter
    {

        public WorldDecoratorCollection MarkerDecorator { get; set; }
        public TopLabelWithTitleDecorator FinishedDecorator { get; set; }
        public TopLabelWithTitleDecorator TimesDecorator { get; set; }
        bool RedDoor0 { get; set; }
        bool RedDoor1 { get; set; }
        bool RedDoor2 { get; set; }
        bool RedDoor3 { get; set; }
        bool Finished { get; set; }
        int Times { get; set; }
        private HashSet<uint> _actorSnoList = new HashSet<uint>();
        public GLQ_RedDoorMarker()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            RedDoor0 = false;
            RedDoor1 = false;
            RedDoor2 = false;
            RedDoor3 = false;
            Finished = false;
            Times = 0;
            MarkerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 255, 0, 0, 0),
                    BorderBrush = Hud.Render.CreateBrush(192, 255, 255, 255, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 10f, 255, 255, 255, 255, true, false, false),
                }
                );
            FinishedDecorator = new TopLabelWithTitleDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 0, 0, true, false, true),
            };
            TimesDecorator = new TopLabelWithTitleDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 239, 220, 129, false, false, true),
            };
            _actorSnoList.Add(258384); //Uber_PortalSpot0
            _actorSnoList.Add(258385); //Uber_PortalSpot1
            _actorSnoList.Add(258386); //Uber_PortalSpot2
            _actorSnoList.Add(366533); //Uber_PortalSpot3

        }
        public void OnNewArea(bool newGame, ISnoArea area)
        {
            if (newGame)
            {
                RedDoor0 = false;
                RedDoor1 = false;
                RedDoor2 = false;
                RedDoor3 = false;
                Finished = false;
            }
        }
        public void PaintWorld(WorldLayer layer)
        {
            var MapSno = Hud.Game.Me.SnoArea.Sno.ToString();
            var actors = Hud.Game.Actors.Where(actor => actor.DisplayOnOverlay && _actorSnoList.Contains(actor.SnoActor.Sno));
            if (MapSno == "256767") RedDoor0 = true;
            if (MapSno == "256106") RedDoor1 = true;
            if (MapSno == "256742") RedDoor2 = true;
            if (MapSno == "374239") RedDoor3 = true;
            if (RedDoor0 && RedDoor1 && RedDoor2 && RedDoor3 && Finished == false)
            {
                Times++;
                Finished = true;
            }
            foreach (var actor in actors)
            {
                if (RedDoor0 && actor.SnoActor.Sno == 258384) MarkerDecorator.Paint(layer, actor, actor.FloorCoordinate.Offset(0, 0, 6f), "A1装置已进入过");
                if (RedDoor1 && actor.SnoActor.Sno == 258385) MarkerDecorator.Paint(layer, actor, actor.FloorCoordinate.Offset(0, 0, 6f), "A2装置已进入过");
                if (RedDoor2 && actor.SnoActor.Sno == 258386) MarkerDecorator.Paint(layer, actor, actor.FloorCoordinate.Offset(0, 0, 6f), "A3装置已进入过");
                if (RedDoor3 && actor.SnoActor.Sno == 366533) MarkerDecorator.Paint(layer, actor, actor.FloorCoordinate.Offset(0, 0, 6f), "A4装置已进入过");
            }
        }
        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;
            var ui = Hud.Render.GetUiElement("Root.NormalLayer.minimap_dialog_backgroundScreen.minimap_dialog_pve.BoostWrapper.BoostsDifficultyStackPanel.clock");
            var ui2 = Hud.Render.GetUiElement("Root.NormalLayer.minimap_dialog_backgroundScreen.minimap_dialog_pve.minimap_pve_main");
            var w = 0;
            var h = ui.Rectangle.Height;
            float XPos = ui2.Rectangle.Left + ui2.Rectangle.Width / 3.5f;
            float YPos = ui.Rectangle.Top;
            if (Finished) FinishedDecorator.Paint(XPos, YPos - h, w, h, "当前房间所有红门已进入过");
            if (Times != 0)
            {
                TimesDecorator.Paint(XPos, YPos, w, h, "地狱火护符任务已完成：" + Times);
            }
        }

    }
}