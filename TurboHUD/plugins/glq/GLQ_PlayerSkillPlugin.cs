using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    public class GLQ_PlayerSkillPlugin : BasePlugin, IInGameWorldPainter
    {

        public WorldDecoratorCollection HydraDecorator { get; set; }
        public WorldDecoratorCollection SentryDecorator { get; set; }
        public WorldDecoratorCollection SentryMapDecorator { get; set; }
        public WorldDecoratorCollection SentryTimerDecorator { get; set; }
        public WorldDecoratorCollection SentryWithCustomEngineeringTimerDecorator { get; set; }
        public WorldDecoratorCollection SlowTimeDecorator { get; set; }
        public WorldDecoratorCollection SlowTimeTimerDecorator { get; set; }
        public WorldDecoratorCollection BlackHoleDecorator { get; set; }
        public WorldDecoratorCollection BlackHoleSupermassiveDecorator { get; set; }
        public WorldDecoratorCollection BlackHoleTimerDecorator { get; set; }
        public WorldDecoratorCollection PiranhasDecorator { get; set; }
        public WorldDecoratorCollection PiranhasTimerDecorator { get; set; }
        public WorldDecoratorCollection PiranhasPiranhadoTimerDecorator { get; set; }
        public WorldDecoratorCollection SpiritWalkTimerDecorator { get; set; }
        public WorldDecoratorCollection SpiritWalkWithJauntTimerDecorator { get; set; }
        public WorldDecoratorCollection BigBadVoodooDecorator { get; set; }
        public WorldDecoratorCollection BigBadVoodooWithJungleDrumsDecorator { get; set; }
        public WorldDecoratorCollection BigBadVoodooTimerDecorator { get; set; }
        public WorldDecoratorCollection BigBadVoodooWithJungleDrumsTimerDecorator { get; set; }
        public WorldDecoratorCollection InnerSanctuaryDecorator { get; set; }
        public WorldDecoratorCollection InnerSanctuaryTimerDecorator { get; set; }
        public WorldDecoratorCollection SpiritBarragePhantasmDecorator { get; set; }
        public WorldDecoratorCollection SpiritBarragePhantasmTimerDecorator { get; set; }
        public WorldDecoratorCollection MarkedForDeathDecorator { get; set; }
        public WorldDecoratorCollection MarkedForDeathTimerDecorator { get; set; }
        public WorldDecoratorCollection GraspoftheDeadDecorator { get; set; }
        public WorldDecoratorCollection GraspoftheDeadTimerDecorator { get; set; }
        
        public bool Sentry { get; set; }
        public bool SentryTimer { get; set; }
        public bool SlowTime { get; set; }
        public bool SlowTimeTimer { get; set; }
        public bool BlackHole { get; set; }
        public bool BlackHoleTimer { get; set; }
        public bool Piranhas { get; set; }
        public bool PiranhasTimer { get; set; }
        public bool InnerSanctuary { get; set; }
        public bool InnerSanctuaryTimer { get; set; }
        public bool SpiritWalkTimer { get; set; }
        public bool MarkedForDeath { get; set; }
        public bool MarkedForDeathTimer { get; set; }
        public bool BigBadVoodoo { get; set; }
        public bool BigBadVoodooTimer { get; set; }
        public bool GraspoftheDead { get; set; }
        public bool GraspoftheDeadTimer { get; set; }
        public bool SpiritBarragePhantasm { get; set; }
        public bool SpiritBarragePhantasmTimer { get; set; }

        public GLQ_PlayerSkillPlugin()
        {
            Enabled = true;
            Sentry = true;
            SentryTimer = true;
            SlowTime = true;
            SlowTimeTimer = true;
            BlackHole = true;
            BlackHoleTimer = true;
            Piranhas = true;
            PiranhasTimer = true;
            SpiritWalkTimer = true;
            SpiritBarragePhantasm = true;
            SpiritBarragePhantasmTimer = true;
            BigBadVoodoo = true;
            BigBadVoodooTimer = true;
            GraspoftheDead = true;
            GraspoftheDeadTimer = true;

        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            HydraDecorator = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 100, 100, 2),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    ShapePainter = new TriangleShapePainter(Hud),
                    Radius = 4f,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 15,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 200, 200, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 15,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(230, 255, 50, 50, 0),
                    Radius = 30,
                }
                );
            SentryDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 170, 170, 210, 2),
                    Radius = 16,
                }
                );
            SentryMapDecorator = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 240, 148, 32, 2),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    ShapePainter = new TriangleShapePainter(Hud),
                    Radius = 4f,
                }
                );
            SentryTimerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 30,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 240, 148, 32, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 30,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(160, 240, 148, 32, 0),
                    Radius = 30,
                }
                );

            SentryWithCustomEngineeringTimerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 60,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 240, 148, 32, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 60,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(160, 240, 148, 32, 0),
                    Radius = 30,
                }
                );
            SlowTimeDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 255, 128, 255, 2),
                    Radius = 20,
                }
            );
            SlowTimeTimerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 15,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 200, 200, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 15,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(230, 255, 128, 255, 0),
                    Radius = 30,
                }
                );
            BlackHoleDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 64, 0, 64, 2),
                    Radius = 15,
                }
            );
            BlackHoleSupermassiveDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 0, 50, 250, 2),
                    Radius = 20,
                }
            );
            BlackHoleTimerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 2,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 200, 200, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 2,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(230, 64, 0, 64, 0),
                    Radius = 30,
                }
                );
            PiranhasDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 100, 255, 150, 2),
                    Radius = 15,
                }
            );
            PiranhasTimerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 8,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 100, 255, 150, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 8,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(160, 100, 255, 150, 0),
                    Radius = 30,
                }
                );
            PiranhasPiranhadoTimerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 4,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 100, 255, 150, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 4,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(160, 100, 255, 150, 0),
                    Radius = 30,
                }
                );

            SpiritWalkTimerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 2,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 150, 255, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 2,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(160, 255, 150, 255, 0),
                    Radius = 30,
                }
                );

            SpiritWalkWithJauntTimerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 3,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 150, 255, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 3,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(160, 255, 150, 255, 0),
                    Radius = 30,
                }
                );

            BigBadVoodooDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 128, 0, 0, 2),
                    Radius = 30,
                }
                );

            BigBadVoodooTimerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 20,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 100, 200, 100, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 20,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(160, 128, 0, 0, 0),
                    Radius = 30,
                }
                );

            BigBadVoodooWithJungleDrumsDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 128, 0, 0, 2),
                    Radius = 30,
                }
                );

            BigBadVoodooWithJungleDrumsTimerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 30,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 100, 200, 100, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 30,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(160, 128, 0, 0, 0),
                    Radius = 30,
                }
                );

            InnerSanctuaryDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 190, 117, 0, 3),
                    Radius = 11,
                }
            );
            InnerSanctuaryTimerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 6,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 100, 255, 150, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 6,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(100, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(100, 190, 117, 0, 0),
                    Radius = 35,
                }
            );

            SpiritBarragePhantasmDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 0, 128, 255, 2),
                    Radius = 10,
                }
            );
            SpiritBarragePhantasmTimerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 5,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 100, 255, 150, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 5,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(100, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(200, 0, 128, 255, 0),
                    Radius = 25,
                }
            );

            MarkedForDeathDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 128, 0, 0, 2),
                    Radius = 15,
                }
            );
            MarkedForDeathTimerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 15,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 100, 255, 150, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 15,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(100, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(200, 128, 0, 0, 0),
                    Radius = 25,
                }
            );

            GraspoftheDeadDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 0, 128, 0, 2),
                    Radius = 15,
                }
            );

            GraspoftheDeadTimerDecorator = new WorldDecoratorCollection(
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 8,
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 100, 255, 150, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 8,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(100, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(200, 0, 128, 0, 0),
                    Radius = 25,
                }
            );
        }

        public void PaintWorld(WorldLayer layer)
        {
            var actors = Hud.Game.Actors;
            foreach (var actor in actors)
            {
                if (actor.SummonerAcdDynamicId == Hud.Game.Me.SummonerId)
                {
                    switch (actor.SnoActor.Sno)
                    {
                        case 81230: // light
                        case 81232: // arcane
                        case 325807:
                        case 83024:
                            HydraDecorator.Paint(layer, actor, actor.FloorCoordinate.Offset(2f, 2f, 0), null);
                            break;
                        case 83959: // mammoth
                            HydraDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                            break;
                        case 141402:
                        case 150025:
                        case 150024:
                        case 168815:
                        case 150026:
                        case 150027:
                            if (!Hud.Game.Me.Powers.BuffIsActive(208610, 0))
                            {
                                //if (Sentry == true) SentryDecorator.Paint(layer, actor, actor.FloorCoordinate, null); SentryMapDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                                if (SentryTimer == true) SentryTimerDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                            }
                            else
                            {
                                if (SentryTimer == true) SentryWithCustomEngineeringTimerDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                            }
                            break;
                        case 107705:
                        case 106584:
                            {
                                var skill = Hud.Game.Me.Powers.UsedSkills.Where(x => x.SnoPower.Sno == 106237).FirstOrDefault();
                                if (skill != null && SpiritWalkTimer == true)
                                {
                                    if (skill.Rune == 1)
                                    {
                                        SpiritWalkWithJauntTimerDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                                    }
                                    else
                                    {
                                        SpiritWalkTimerDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                                    }
                                }
                            }
                            break;
                        case 181880:
                            if (SpiritBarragePhantasm == true) SpiritBarragePhantasmDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                            if (SpiritBarragePhantasmTimer == true) SpiritBarragePhantasmTimerDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                            break;
                    }
                }
                switch (actor.SnoActor.Sno)
                {
                    case 141402:
                    case 150025:
                    case 150024:
                    case 168815:
                        if (Sentry == true) SentryMapDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        break;
                    case 150026:
                    case 150027:
                        if (Sentry == true) SentryDecorator.Paint(layer, actor, actor.FloorCoordinate, null); SentryMapDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        break;
                    case 6553:
                    case 112697:
                    case 112572:
                    case 112585:
                    case 112808:
                    case 112560:
                        if (SlowTime == true) SlowTimeDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        if (SlowTimeTimer == true) SlowTimeTimerDecorator.Paint(layer, actor, actor.FloorCoordinate.Offset(0, 0, 5.2f), null);
                        break;
                    case 341381:
                        if (BlackHole == true) BlackHoleSupermassiveDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        if (BlackHoleTimer == true) BlackHoleTimerDecorator.Paint(layer, actor, actor.FloorCoordinate.Offset(0, 0, 5.2f), null);
                        break;
                    case 336410:
                    case 341426:
                    case 341411:
                    case 341396:
                    case 341441:
                        if (BlackHole == true) BlackHoleDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        if (BlackHoleTimer == true) BlackHoleTimerDecorator.Paint(layer, actor, actor.FloorCoordinate.Offset(0, 0, 5.2f), null);
                        break;
                    case 348308:
                    case 356987:
                    case 358018:
                    case 358653:
                        if (Piranhas == true) PiranhasDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        if (PiranhasTimer == true) PiranhasTimerDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        break;
                    case 357846:
                        if (Piranhas == true) PiranhasDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        if (PiranhasTimer == true) PiranhasPiranhadoTimerDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        break;
                    case 320135:
                    case 320136:
                    case 319583:
                    case 319776:
                    case 319337:
                        if (InnerSanctuary == true) InnerSanctuaryDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        if (InnerSanctuaryTimer == true) InnerSanctuaryTimerDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        break;
                    case 230674:
                        if (MarkedForDeath == true) MarkedForDeathDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        if (MarkedForDeathTimer == true) MarkedForDeathTimerDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        break;
                    case 69308:
                    case 105958:
                    case 105953:
                    case 105957:
                    case 105955:
                    case 105956:
                        if (GraspoftheDead == true) GraspoftheDeadDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        if (GraspoftheDeadTimer == true) GraspoftheDeadTimerDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        break;
                    case 117574:
                        if (BigBadVoodoo == true) BigBadVoodooWithJungleDrumsDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        if (BigBadVoodooTimer == true) BigBadVoodooWithJungleDrumsTimerDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        break;
                    case 182276:
                    case 182278:
                    case 182271:
                    case 182283:
                        if (BigBadVoodoo == true) BigBadVoodooDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        if (BigBadVoodooTimer == true) BigBadVoodooTimerDecorator.Paint(layer, actor, actor.FloorCoordinate, null);
                        break;  
                }
            }
        }

    }

}