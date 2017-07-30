namespace Turbo.Plugins.glq
{
    using SharpDX.Direct2D1;
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Default;

    public class GLQ_DangerousSkillsPlugin : BasePlugin, IInGameWorldPainter
    {
        public WorldDecoratorCollection GhomTimerDecorator { get; set; }//纲姆毒云计时器
        public WorldDecoratorCollection TornadoDecorator { get; set; }//龙卷风
		public WorldDecoratorCollection TornadoTimerDecorator { get; set; }//龙卷风计时器
		public WorldDecoratorCollection SlowTimeDecorator { get; set; }//绝对领域
		public WorldDecoratorCollection SlowTimeTimerDecorator { get; set; }//绝对领域计时器
		public WorldDecoratorCollection FirePentagramDecorator { get; set; }//屠夫的火圈
		public WorldDecoratorCollection FirePentagramTimerDecorator { get; set; }//屠夫的火圈计时器
		public WorldDecoratorCollection GeyserTethrysDecorator { get; set; }//特斯瑞斯召唤的地狱喷泉
		public WorldDecoratorCollection GeyserTethrysTimerDecorator { get; set; }//特斯瑞斯召唤的地狱喷泉计时器
		public WorldDecoratorCollection SandmonsterTurretDecorator { get; set; }//石头人的炮台
		public WorldDecoratorCollection SandmonsterTurretTimerDecorator { get; set; }//石头人的炮台计时器
		public WorldDecoratorCollection RatSwarmDecorator { get; set; }//哈默林的召唤鼠群
		public WorldDecoratorCollection FallingRocksDecorator { get; set; }//落石（王大锤，库勒）
		public WorldDecoratorCollection MeteorDecorator { get; set; }//陨石（余烬）
		public WorldDecoratorCollection BloodmawDecorator { get; set; }//血肠的跳
		public WorldDecoratorCollection BruteLeapDecorator { get; set; }//惩罚者的跳跃
		public WorldDecoratorCollection SmolderingPoolDecorator { get; set; }//火爷的火池
		public WorldDecoratorCollection BogBearTrapDecorator { get; set; }//吹箫怪的夹子
		
        public GLQ_DangerousSkillsPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
			
            GhomTimerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 75,
                    TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 0, true, false, 255, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 75,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(230, 0, 120, 0, 0),
                    Radius = 15,
                });
				
            TornadoDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 5,
                    Brush = Hud.Render.CreateBrush(160, 255, 50, 50, 2, DashStyle.Dash)
                });
            TornadoTimerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 30,
                    TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 0, true, false, 255, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 30,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(230, 255, 173, 91, 0),
                    Radius = 15,
                });
					
            SlowTimeDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 16,
                    Brush = Hud.Render.CreateBrush(160, 255, 128, 0, 2, DashStyle.Dash)
                });
            SlowTimeTimerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 16,
                    TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 0, true, false, 255, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 16,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(230, 255, 128, 0, 0),
                    Radius = 15,
                });
				
            FirePentagramDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 10,
                    Brush = Hud.Render.CreateBrush(160, 128, 0, 0, 2, DashStyle.Dash)
                });
            FirePentagramTimerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 15,
                    TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 0, true, false, 255, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 15,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(230, 255, 0, 0, 0),
                    Radius = 15,
                });

            GeyserTethrysDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 15,
                    Brush = Hud.Render.CreateBrush(160, 128, 0, 0, 3, DashStyle.Dash)
                });
            GeyserTethrysTimerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 3,
                    TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 0, true, false, 255, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 3,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(230, 255, 0, 0, 0),
                    Radius = 15,
                });
				
            SandmonsterTurretDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = -1,
                    Brush = Hud.Render.CreateBrush(255, 128, 0, 0, 3, DashStyle.Dash)
                });
            SandmonsterTurretTimerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 20,
                    TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 0, true, false, 255, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 20,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(160, 128, 0, 0, 0),
                    Radius = 15,
                });
				
            RatSwarmDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 7.5f,
                    Brush = Hud.Render.CreateBrush(255, 0, 255, 0, 2, DashStyle.Dash)
                });
				
            FallingRocksDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 20,
                    Brush = Hud.Render.CreateBrush(160, 255, 50, 50, 2, DashStyle.Dash)
                });
            MeteorDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 20,
                    Brush = Hud.Render.CreateBrush(220, 128, 0, 0, 3, DashStyle.Dash)
                });
            BloodmawDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 14,
                    Brush = Hud.Render.CreateBrush(220, 128, 0, 0, 5, DashStyle.Dash)
                });
            BruteLeapDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 15,
                    Brush = Hud.Render.CreateBrush(220, 255, 50, 50, 3, DashStyle.Dash)
                });
            SmolderingPoolDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 9,
                    Brush = Hud.Render.CreateBrush(160, 255, 10, 10, 2, DashStyle.Dash)
                });	
            BogBearTrapDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 2,
                    Brush = Hud.Render.CreateBrush(140, 255, 10, 10, 2, DashStyle.Dash)
                },
                new GroundLabelDecorator(Hud) {
                    BackgroundBrush = Hud.Render.CreateBrush(200, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 0, 0, true, false, false)
                });	
				
		}
			

        public void PaintWorld(WorldLayer layer)
        {
            var Skills = Hud.Game.Actors;
            foreach (var skill in Skills)
            {
				switch (skill.SnoActor.Sno)
				{
					case 93837:
					GhomTimerDecorator.Paint(layer, skill, skill.FloorCoordinate, string.Empty);
					break;
					case 139741:
					TornadoDecorator.Paint(layer, skill, skill.FloorCoordinate, string.Empty);
					TornadoTimerDecorator.Paint(layer, skill, skill.FloorCoordinate, string.Empty);
					break;
					case 185924:
					SlowTimeDecorator.Paint(layer, skill, skill.FloorCoordinate, string.Empty);
					SlowTimeTimerDecorator.Paint(layer, skill, skill.FloorCoordinate, string.Empty);
					break;
					case 359693:
					FirePentagramDecorator.Paint(layer, skill, skill.FloorCoordinate, string.Empty);
					FirePentagramTimerDecorator.Paint(layer, skill, skill.FloorCoordinate, string.Empty);
					break;
					case 315366:
					case 315362:
					GeyserTethrysDecorator.Paint(layer, skill, skill.FloorCoordinate, string.Empty);
					GeyserTethrysTimerDecorator.Paint(layer, skill, skill.FloorCoordinate, string.Empty);
					break;
					case 434201:
					SandmonsterTurretDecorator.Paint(layer, skill, skill.FloorCoordinate, string.Empty);
					SandmonsterTurretTimerDecorator.Paint(layer, skill, skill.FloorCoordinate, string.Empty);
					break;
					case 427170:
					RatSwarmDecorator.Paint(layer, skill, skill.FloorCoordinate, string.Empty);	
					break;
					case 368453:
					case 374732:
					case 3026:
					FallingRocksDecorator.Paint(layer, skill, skill.FloorCoordinate, string.Empty);
					break;
					case 159369:
					case 159368:
					case 159367:
					MeteorDecorator.Paint(layer, skill, skill.FloorCoordinate, string.Empty);
					break;
					case 428962:
					case 428938:
					BloodmawDecorator.Paint(layer, skill, skill.FloorCoordinate, string.Empty);
					break;
					case 289827:
					BruteLeapDecorator.Paint(layer, skill, skill.FloorCoordinate, string.Empty);
					break;
					case 432:
					SmolderingPoolDecorator.Paint(layer, skill, skill.FloorCoordinate, string.Empty);
					break;
					case 237062:
					case 284752:
					BogBearTrapDecorator.Paint(layer, skill, skill.FloorCoordinate, "夹子");
					break;

					
				}
			
            }
        }
    }
}