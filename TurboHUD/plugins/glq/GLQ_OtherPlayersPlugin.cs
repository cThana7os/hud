using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    public class GLQ_OtherPlayersPlugin : BasePlugin, IInGameWorldPainter
	{

        public Dictionary<HeroClass, WorldDecoratorCollection> DecoratorByClass { get; set; }
        public float NameOffsetZ { get; set; }

        public GLQ_OtherPlayersPlugin()
		{
            Enabled = true;
            DecoratorByClass = new Dictionary<HeroClass, WorldDecoratorCollection>();
            NameOffsetZ = 2.0f;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            var pingTransformator = new StandardPingRadiusTransformator(Hud, 333);
            var shapePainter = new CircleShapePainter(Hud);
            DecoratorByClass.Add(HeroClass.Barbarian, new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7f, 250, 255, 128, 64, false, false, 128, 0, 0, 0, true),
                    Up = true,
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 255, 128, 64, 0),
                    BorderBrush = Hud.Render.CreateBrush(250, 0, 0, 0, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8f, 255, 0, 0, 0, true, false, 128, 255, 255, 255, true),
                }
                ));

            DecoratorByClass.Add(HeroClass.Crusader, new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7f, 240, 240, 240, 240, false, false, 128, 0, 0, 0, true),
                    Up = true,
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 240, 240, 240, 0),
                    BorderBrush = Hud.Render.CreateBrush(240, 0, 0, 0, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8f, 255, 0, 0, 0, true, false, 128, 255, 255, 255, true),
                }
                ));

            DecoratorByClass.Add(HeroClass.DemonHunter, new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7f, 255, 0, 200, 255, false, false, 128, 0, 0, 0, true),
                    Up = true,
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 255, 255, 0),
                    BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8f, 255, 0, 0, 0, true, false, 128, 255, 255, 255, true),
                }
                ));

            DecoratorByClass.Add(HeroClass.Monk, new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7f, 245, 255, 255, 0, false, false, 128, 0, 0, 0, true),
                    Up = true,
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 255, 255, 0, 0),
                    BorderBrush = Hud.Render.CreateBrush(240, 0, 0, 0, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8f, 255, 0, 0, 0, true, false, 128, 255, 255, 255, true),
                }
                ));

            DecoratorByClass.Add(HeroClass.WitchDoctor, new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7f, 255, 0, 255, 0, false, false, 128, 0, 0, 0, true),
                    Up = true,
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 0, 255, 0, 0),
                    BorderBrush = Hud.Render.CreateBrush(250, 0, 0, 0, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8f, 255, 0, 0, 0, true, false, 128, 255, 255, 255, true),
                }
                ));

            DecoratorByClass.Add(HeroClass.Wizard, new WorldDecoratorCollection(
                new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7f, 255, 255, 0, 255, false, false, 128, 0, 0, 0, true),
                    Up = true,
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(255, 255, 0, 255, 0),
                    BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 1),
                    TextFont = Hud.Render.CreateFont("tahoma", 8f, 255, 0, 0, 0, true, false, 128, 255, 255, 255, true),
                }
                ));
            DecoratorByClass.Add(HeroClass.Necromancer, new WorldDecoratorCollection(
                 new MapLabelDecorator(Hud)
                 {
                     LabelFont = Hud.Render.CreateFont("tahoma", 7f, 230, 0, 190, 190, false, false, 128, 0, 0, 0, true),
                     Up = true,
                 },
                 new GroundLabelDecorator(Hud)
                 {
                     BackgroundBrush = Hud.Render.CreateBrush(255, 0, 190, 190, 0),
                     BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 1),
                     TextFont = Hud.Render.CreateFont("tahoma", 8f, 255, 0, 0, 0, true, false, 128, 255, 255, 255, true),
                 }
                 ));



        }

        public void PaintWorld(WorldLayer layer)
        {
            var players = Hud.Game.Players.Where(player => !player.IsMe && player.CoordinateKnown && (player.HeadStone == null));
            foreach (var player in players)
            {
                WorldDecoratorCollection decorator;
                if (!DecoratorByClass.TryGetValue(player.HeroClassDefinition.HeroClass, out decorator)) continue;

                decorator.Paint(layer, null, NameOffsetZ != 0 ? player.FloorCoordinate.Offset(0, 0, NameOffsetZ) : player.FloorCoordinate, player.BattleTagAbovePortrait);
            }
        }

    }

}