﻿using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    // original idea from http://turbohud.freeforums.net/user/6766 and http://turbohud.freeforums.net/user/1694
    public class GLQ_CosmeticItemsPlugin : BasePlugin, IInGameWorldPainter
    {

        public WorldDecoratorCollection Decorator { get; set; }
        public string DisplayTextOnActors { get; set; }
        public string DisplayTextOnMonsters { get; set; }
        public string DisplayTextOnItems { get; set; }
        public bool EnableSpeak { get; set; }
		
        private HashSet<uint> _monsterSnoList = new HashSet<uint>();
        private HashSet<uint> _actorSnoList = new HashSet<uint>();

        public GLQ_CosmeticItemsPlugin()
        {
            Enabled = true;
            EnableSpeak = true;
            DisplayTextOnActors = "装饰品掉落处";
            DisplayTextOnMonsters = "装饰品掉落者";
            DisplayTextOnItems = "装饰品";
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            Decorator = new WorldDecoratorCollection(
                new MapShapeDecorator(Hud)
                {
                    ShapePainter = new RotatingTriangleShapePainter(Hud),
                    Brush = Hud.Render.CreateBrush(160, 255, 102, 255, 10),
                    ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1),
                    Radius = 2,
                },
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(150, 255, 128, 0, 0),
                    Radius = 1.125f,
                },
                new GroundLabelDecorator(Hud)
                {
                    BackgroundBrush = Hud.Render.CreateBrush(90, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 8, 255, 255, 102, 255, true, false, 88, 0, 0, 0, true),
                }
                );

            _monsterSnoList.Add(214948); // Princess Stardust
            _monsterSnoList.Add(218804); // Creampuff
            _monsterSnoList.Add(225114); // Jay Wilson
            _monsterSnoList.Add(316439); // Josh Mosqueira
            _monsterSnoList.Add(373833); // Super Awesome Sparkle Cake
            _monsterSnoList.Add(444994); // The Succulent
            _monsterSnoList.Add(450997); // Regreb the Slayer
            _monsterSnoList.Add(450999); // Princess Lilian
            _monsterSnoList.Add(451002); // Sir William
            _monsterSnoList.Add(451004); // Graw the Herald
            _monsterSnoList.Add(451011); // Nevaz
            _monsterSnoList.Add(451121); // Ravi Lilywhite
            _monsterSnoList.Add(450993); // Menagerist Goblin

            _monsterSnoList.Add(217744); // Nine Toads
            _monsterSnoList.Add(156738); // Moontooth Dreadshark
            _monsterSnoList.Add(178619); // Urzel Mordreg
            _actorSnoList.Add(225782); // Bishibosh's Remains
            _actorSnoList.Add(173325); // Anvil of Fury
            _actorSnoList.Add(113845); // Fallen Shrine

            _actorSnoList.Add(207706); // Mysterious Chest
            _actorSnoList.Add(451035); // Mysterious Chest
            _actorSnoList.Add(451028); // Mysterious Chest
            _actorSnoList.Add(451030); // Mysterious Chest
            _actorSnoList.Add(451047); // Mysterious Chest
            _actorSnoList.Add(451029); // Mysterious Chest
            _actorSnoList.Add(451038); // Mysterious Chest
            _actorSnoList.Add(451034); // Mysterious Chest
            _actorSnoList.Add(451033); // Mysterious Chest
            _actorSnoList.Add(451027); // Mysterious Chest
            _actorSnoList.Add(451039); // Mysterious Barrel
            _actorSnoList.Add(211861); // Pinata
            _actorSnoList.Add(457828); // Wirt's Stash
			
        }

        private bool IsCosmetic(IItem item)
        {
            return item.SnoItem.HasGroupCode("cosmetic") || item.SnoItem.HasGroupCode("cosmetic_pet") || item.SnoItem.HasGroupCode("cosmetic_portrait_frame") || item.SnoItem.HasGroupCode("cosmetic_wing") || item.SnoItem.HasGroupCode("cosmetic_pennant");
        }

        public void PaintWorld(WorldLayer layer)
        {
            var actors = Hud.Game.Actors.Where(actor => actor.DisplayOnOverlay && _actorSnoList.Contains(actor.SnoActor.Sno));
            foreach (var actor in actors)
            {
                Decorator.Paint(layer, actor, actor.FloorCoordinate, DisplayTextOnActors + "：" + actor.SnoActor.NameLocalized);
				if (EnableSpeak && (actor.LastSpeak == null) && Hud.LastSpeak.TimerTest(2000))
				{
				Hud.Speak(DisplayTextOnActors + "：" + actor.SnoActor.NameLocalized);
				actor.LastSpeak = Hud.CreateAndStartWatch();
				}
            }

            var monsters = Hud.Game.AliveMonsters.Where(monster => _monsterSnoList.Contains(monster.SnoActor.Sno));
            foreach (var monster in monsters)
            {
                Decorator.Paint(layer, monster, monster.FloorCoordinate, DisplayTextOnMonsters + "：" + monster.SnoMonster.NameLocalized);
				if (EnableSpeak && (monster.LastSpeak == null) && Hud.LastSpeak.TimerTest(2000))
				{
				Hud.Speak(DisplayTextOnMonsters + "：" + monster.SnoMonster.NameLocalized);
				monster.LastSpeak = Hud.CreateAndStartWatch();
				}
            }

            var items = Hud.Game.Items.Where(item => item.Location == ItemLocation.Floor && IsCosmetic(item));
            foreach (var item in items)
            {
                Decorator.Paint(layer, item, item.FloorCoordinate, DisplayTextOnItems + "：" + item.SnoItem.NameLocalized);
				if (EnableSpeak && (item.LastSpeak == null) && Hud.LastSpeak.TimerTest(2000))
				{
				Hud.Speak(DisplayTextOnItems + "：" + item.SnoItem.NameLocalized);
				item.LastSpeak = Hud.CreateAndStartWatch();
				}
            }
        }
    }

}