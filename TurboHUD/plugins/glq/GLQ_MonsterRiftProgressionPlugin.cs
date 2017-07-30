using SharpDX.DirectInput;
using System.Collections.Generic;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    public class GLQ_MonsterRiftProgressionPlugin : BasePlugin, IInGameWorldPainter, IKeyEventHandler
	{
        public WorldDecoratorCollection Decorator1 { get; set; }
        public WorldDecoratorCollection Decorator2 { get; set; }
        public WorldDecoratorCollection Decorator3 { get; set; }
        public WorldDecoratorCollection Decorator4 { get; set; }
        public WorldDecoratorCollection Decorator5 { get; set; }
        public double DisplayLimit { get; set; }
        public IKeyEvent ToggleKeyEvent { get; set; }
        public bool TurnedOn { get; set; }
        public GLQ_MonsterRiftProgressionPlugin()
		{
            Enabled = true;
		}

        public override void Load(IController hud)
        {
            base.Load(hud);
            ToggleKeyEvent = Hud.Input.CreateKeyEvent(true, Key.F9, false, false, false);
            TurnedOn = true;
            DisplayLimit = 0.0;

            Decorator1 = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(90, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 255, false, false, 88, 0, 0, 0, true),
                }
                );
            Decorator2 = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(90, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 0, 200, 0, false, false, 88, 0, 0, 0, true),
                }
                );
            Decorator3 = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(200, 0, 125, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 255, true, false, 88, 0, 0, 0, true),
                }
                );
            Decorator4 = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(200, 0, 55, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 255, 255, true, false, 88, 0, 200, 0, true),
                }
                );
            Decorator5 = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(200, 0, 20, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 0, 125, 0, true, false, 88, 255, 255, 255, true),
                }
                );
				
        }
        public WorldDecoratorCollection GetDecoratorByProgression(float progression)
        {
            if (progression <= 1.0) return Decorator1;
            if (progression <= 2.0) return Decorator2;
            if (progression <= 3.0) return Decorator3;
            if (progression <= 4.0) return Decorator4;
            return Decorator5; // in theory there is no monster with >10 progression
        }
		public void OnKeyEvent(IKeyEvent keyEvent)
        {
            if (keyEvent.IsPressed && ToggleKeyEvent.Matches(keyEvent))
            {
                TurnedOn = !TurnedOn;
            }
        }		
        public void PaintWorld(WorldLayer layer)
        {
            var inRift = Hud.Game.SpecialArea == SpecialArea.Rift || Hud.Game.SpecialArea == SpecialArea.GreaterRift;
            var monsters = Hud.Game.AliveMonsters;
            if (!TurnedOn) return;
			if (!inRift) return;
            foreach (var monster in monsters)
            {
				double MonsterRiftProgression = monster.SnoMonster.RiftProgression * 100.0d / Hud.Game.MaxQuestProgress;
				var decorator = GetDecoratorByProgression(monster.SnoMonster.RiftProgression);
				if (monster.IsElite && monster.SummonerAcdDynamicId == 0 && MonsterRiftProgression >= DisplayLimit)
				{
                decorator.Paint(layer, monster, monster.FloorCoordinate, MonsterRiftProgression.ToString("f2") + "%");
				}
				if (!monster.IsElite && MonsterRiftProgression >= DisplayLimit)
				{
                decorator.Paint(layer, monster, monster.FloorCoordinate, MonsterRiftProgression.ToString("f2") + "%");
				}
            }
        }

    }

}