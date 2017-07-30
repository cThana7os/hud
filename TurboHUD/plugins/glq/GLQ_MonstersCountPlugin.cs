using System.Linq;
using Turbo.Plugins.Default;
 
namespace Turbo.Plugins.glq
{
    using System.Text;
 
    // by 我想静静 黑白灰 zjqyf1111 Jack Céparou
    //http://turbohud.freeforums.net/thread/4044/v7-1-english-glq-monsterscountplugin
    public class GLQ_MonstersCountPlugin : BasePlugin, IInGameTopPainter
    {
        public IFont TextFont { get; set; }
        public int yard { get; set; }
        public bool ShowTotalProgression { get; set; }
        public bool ShowLlocustCount { get; set; }
        public bool ShowHauntedCount { get; set; }
        public bool ShowPalmedCount { get; set; }
        public bool ShowPhoenixedCount { get; set; }
        public bool ShowStrongarmedCount { get; set; }
        public float XWidth { get; set; }
        public float YHeight { get; set; }    
        private StringBuilder textBuilder;
 
        public GLQ_MonstersCountPlugin()
        {
            Enabled = true;
        }
 
        public override void Load(IController hud)
        {
            base.Load(hud);
            TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 180, 147, 109, false, false, true);
            yard = 40;
            ShowTotalProgression = true;
            ShowLlocustCount = true;
            ShowHauntedCount = true;
            ShowPalmedCount = true;
            ShowPhoenixedCount = false;
            ShowStrongarmedCount = true;
            XWidth = 0.84f;
            YHeight = 0.61f;
            textBuilder = new StringBuilder();
        }
 
        public void PaintTopInGame(ClipState clipState)
        {
			if (clipState != ClipState.BeforeClip) return;
            var inRift = Hud.Game.SpecialArea == SpecialArea.Rift || Hud.Game.SpecialArea == SpecialArea.GreaterRift;
            if (TextFont == null)
            {
                return;
            }
 
            double totalMonsterRiftProgression = 0;
            double TrashMonsterRiftProgression = 0;
            double EliteProgression = 0;
            double RiftGlobeProgression = 0;
            int monstersCount = 0;
            int EliteCount = 0;
            int ElitePackCount = 0;
            // locust
            int locustCount = 0;
            int ElitelocustCount = 0;
            // haunted
            int hauntedCount = 0;
            int ElitehauntedCount = 0;
            //Palmed
            int palmedCount = 0;
            int ElitepalmedCount = 0;
            //Phoenixed BUG? http://turbohud.freeforums.net/thread/3945/monster-phoenixed
            int phoenixedCount = 0;
            int ElitephoenixedCount = 0;
            //Strongarmed
            int strongarmedCount = 0;
            int ElitestrongarmedCount = 0;
            float XPos = Hud.Window.Size.Width * XWidth;
            float YPos = Hud.Window.Size.Height * YHeight;
 
            var monsters = Hud.Game.AliveMonsters.Where(m => m.SummonerAcdDynamicId == 0 && m.IsElite || !m.IsElite);
            foreach (var monster in monsters)
            {
                var Elite = monster.Rarity == ActorRarity.Rare || monster.Rarity == ActorRarity.Champion;
                if (monster.FloorCoordinate.XYDistanceTo(Hud.Game.Me.FloorCoordinate) > yard) continue;
                monstersCount++;
                if (inRift && ShowTotalProgression)
                {
                    if(monster.Rarity == ActorRarity.Rare) EliteProgression += 4 * 1.15d;
                    if (!monster.IsElite)
                    {
                        TrashMonsterRiftProgression += monster.SnoMonster.RiftProgression * 100.0d / this.Hud.Game.MaxQuestProgress;
                    }
                    else
                        EliteProgression += monster.SnoMonster.RiftProgression * 100.0d / this.Hud.Game.MaxQuestProgress;
                }
                if(monster.Rarity == ActorRarity.Rare)
                {
                    EliteCount++;
                    ElitePackCount++;
                }
                if(monster.Rarity == ActorRarity.Champion) EliteCount++;
                if (monster.Locust && ShowLlocustCount)
                {
                    locustCount++;
                    if(Elite) ElitelocustCount++;
                }
                if (monster.Haunted && ShowHauntedCount)
                {
                    hauntedCount++;
                    if(Elite) ElitehauntedCount++;
                }
                if (monster.Palmed && ShowPalmedCount)
                {
                    palmedCount++;
                    if(Elite) ElitepalmedCount++;
                }
                if (monster.Phoenixed && ShowPhoenixedCount)
                {
                    phoenixedCount++;
                    if(Elite) ElitephoenixedCount++;
                }
                if (monster.Strongarmed && ShowStrongarmedCount)
                {
                    strongarmedCount++;
                    if(Elite) ElitestrongarmedCount++;
                }
            }
            var actors = Hud.Game.Actors.Where(x => x.SnoActor.Kind == ActorKind.RiftOrb);
            foreach (var actor in actors)
            {
                RiftGlobeProgression += 1.15d;
            }
            var packs = Hud.Game.MonsterPacks;
            if (packs.Any())
                {
                foreach (var pack in packs)
                    {
                    if (!pack.MonstersAlive.Any()) continue;
                    if (pack.IsFullChampionPack)
                    {
                        EliteProgression += 3 * 1.15f;
                        ElitePackCount++;
                    }
                    }
                }
            if (monstersCount == 0 && totalMonsterRiftProgression == 0)
            {
                return;
            }
 
            textBuilder.Clear();
            textBuilder.AppendFormat("{0} 码怪物总数: {1}", yard, monstersCount);
            textBuilder.AppendLine();
            if (EliteCount > 0) textBuilder.AppendFormat("精英: {0} 只（{1}组）", EliteCount, ElitePackCount);
            textBuilder.AppendLine();
            textBuilder.AppendLine();
 
            if (inRift && ShowTotalProgression)
            {
                totalMonsterRiftProgression = TrashMonsterRiftProgression + EliteProgression + RiftGlobeProgression;
                textBuilder.AppendFormat("总进度: {0}%", totalMonsterRiftProgression.ToString("f2"));
                textBuilder.AppendLine();
                if (TrashMonsterRiftProgression > 0)
                {
                    textBuilder.AppendFormat("白怪进度: {0}%", TrashMonsterRiftProgression.ToString("f2"));
                    textBuilder.AppendLine();
                }
                if (EliteProgression > 0)
                {
                    textBuilder.AppendFormat("精英进度: {0}%", EliteProgression.ToString("f2"));
                    textBuilder.AppendLine();
                }
                if (RiftGlobeProgression > 0)
                {
                    textBuilder.AppendFormat("进度球进度: {0}%", RiftGlobeProgression.ToString("f2"));
                    textBuilder.AppendLine();
                }
                textBuilder.AppendLine();
            }
            if (locustCount > 0)
            {
                textBuilder.AppendFormat("虫群: {0}/{1}", locustCount, monstersCount);
                if(ElitelocustCount > 0) textBuilder.AppendFormat(" （精英: {0}/{1}）", ElitelocustCount, EliteCount);
                textBuilder.AppendLine();
            }
            if (hauntedCount > 0)
            {
                textBuilder.AppendFormat("蚀魂: {0}/{1}", hauntedCount, monstersCount);
                if(ElitehauntedCount > 0) textBuilder.AppendFormat(" （精英: {0}/{1}）", ElitehauntedCount, EliteCount);
                textBuilder.AppendLine();
            }
            if (palmedCount > 0)
            {
                textBuilder.AppendFormat("爆裂掌: {0}/{1}", palmedCount, monstersCount);
                if(ElitepalmedCount > 0) textBuilder.AppendFormat(" （精英: {0}/{1}）", ElitepalmedCount, EliteCount);
                textBuilder.AppendLine();
            }
            if (phoenixedCount > 0)
            {
                textBuilder.AppendFormat("火鸟: {0}/{1}", phoenixedCount, monstersCount);
                if(ElitephoenixedCount > 0) textBuilder.AppendFormat(" （精英: {0}/{1}）", ElitephoenixedCount, EliteCount);
                textBuilder.AppendLine();
            }
            if (strongarmedCount > 0)
            {
                textBuilder.AppendFormat("力士: {0}/{1}", strongarmedCount, monstersCount);
                if(ElitestrongarmedCount > 0) textBuilder.AppendFormat(" （精英: {0}/{1}）", ElitestrongarmedCount, EliteCount);
                textBuilder.AppendLine();
            }
            if (totalMonsterRiftProgression >= 100d - Hud.Game.RiftPercentage && Hud.Game.RiftPercentage != 100|| TrashMonsterRiftProgression >= 100d - Hud.Game.RiftPercentage && Hud.Game.RiftPercentage != 100)
            {
                if(totalMonsterRiftProgression >= 100d - Hud.Game.RiftPercentage && Hud.Game.RiftPercentage != 100) TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 128, 0, false, false, true);
                if(TrashMonsterRiftProgression >= 100d - Hud.Game.RiftPercentage && Hud.Game.RiftPercentage != 100) TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 0, 0, false, false, true);
            }
            else
            {
                TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 180, 147, 109, false, false, true);
            }
 
            var layout = TextFont.GetTextLayout(textBuilder.ToString());
            TextFont.DrawText(layout, XPos, YPos);
        }
 
    }
 
}