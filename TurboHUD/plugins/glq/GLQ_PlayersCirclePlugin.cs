using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    public class GLQ_PlayersCirclePlugin : BasePlugin, IInGameWorldPainter
    {
        public WorldDecoratorCollection MeDecorator { get; set; }
        public WorldDecoratorCollection WizardDecorator { get; set; }
        public WorldDecoratorCollection WitchDoctorDecorator { get; set; }
        public WorldDecoratorCollection BarbarianDecorator { get; set; }
        public WorldDecoratorCollection DemonHunterDecorator { get; set; }
        public WorldDecoratorCollection CrusaderDecorator { get; set; }
		public WorldDecoratorCollection MonkDecorator { get; set; }
        public WorldDecoratorCollection NecDecorator { get; set; }

        public GLQ_PlayersCirclePlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
			
			var MeGroundBrush = Hud.Render.CreateBrush(255, 255, 0, 0, 3);
            MeDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = MeGroundBrush,
                    Radius = 3,
                }
                );
				
			var WizardGroundBrush = Hud.Render.CreateBrush(255, 255, 0, 255, 3);
            WizardDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = WizardGroundBrush,
                    Radius = 3,
                }
                );
				
			var WitchDoctorGroundBrush = Hud.Render.CreateBrush(255, 0, 128, 64, 3);
            WitchDoctorDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = WitchDoctorGroundBrush,
                    Radius = 3,
                }
                );
				
			var BarbarianGroundBrush = Hud.Render.CreateBrush(255, 255, 128, 64, 3);
            BarbarianDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = BarbarianGroundBrush,
                    Radius = 3,
                }
                );
				
			var DemonHunterGroundBrush = Hud.Render.CreateBrush(255, 36, 4, 187, 3);
            DemonHunterDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = DemonHunterGroundBrush,
                    Radius = 3,
                }
                );
				
			var CrusaderGroundBrush = Hud.Render.CreateBrush(255, 240, 240, 240, 3);
            CrusaderDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = CrusaderGroundBrush,
                    Radius = 3,
                }
                );

			var MonkGroundBrush = Hud.Render.CreateBrush(255, 255, 255, 0, 3);
            MonkDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = MonkGroundBrush,
                    Radius = 3,
                }
                );

            var NecGroundBrush = Hud.Render.CreateBrush(255, 0, 128, 128, 3);
            NecDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = NecGroundBrush,
                    Radius = 3,
                }
                );
        }

		public void PaintWorld(WorldLayer layer)
		{
            var players = Hud.Game.Players.Where(player => player.CoordinateKnown && (player.HeadStone == null));
            foreach (var player in players)
            {
				if (player.IsMe) 
				MeDecorator.Paint(layer, null, player.FloorCoordinate, null); 
				else
				{
					switch (player.HeroClassDefinition.HeroClass)
					{
						case HeroClass.Wizard:
						WizardDecorator.Paint(layer, null, player.FloorCoordinate, null);  
						break;

						case HeroClass.WitchDoctor:
						WitchDoctorDecorator.Paint(layer, null, player.FloorCoordinate, null);  
						break;

						case HeroClass.Barbarian:
						BarbarianDecorator.Paint(layer, null, player.FloorCoordinate, null);  
						break;

						case HeroClass.DemonHunter:
						DemonHunterDecorator.Paint(layer, null, player.FloorCoordinate, null);  
						break;

						case HeroClass.Crusader:
						CrusaderDecorator.Paint(layer, null, player.FloorCoordinate, null); 
						break;

						case HeroClass.Monk:
						MonkDecorator.Paint(layer, null, player.FloorCoordinate, null); 
						break;
                        case HeroClass.Necromancer:
                            NecDecorator.Paint(layer, null, player.FloorCoordinate, null);
                            break;

                    }
				}
			}
		}
  
    } 

} 