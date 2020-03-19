using Terraria;
using Terraria.ModLoader;
using ThoriumMod;

namespace MasomodeDLC
{
    public class MasomodeDLC : Mod
    {
        private readonly Mod Thorium = ModLoader.GetMod("ThoriumMod");
        private readonly Mod Calamity = ModLoader.GetMod("CalamityMod");
        //private readonly Mod Redemption = ModLoader.GetMod("Redemption");
        public MasomodeDLC()
        {

        }

        public override void Load()
        {
            if (Main.netMode != NetmodeID.Server)
            {
                Ref<Effect> clouds = new Ref<Effect>(GetEffect("Effects/Clouds"));
                Filters.Scene["CloudFilter"] = new Filter(new ScreenShaderData(clouds, "CreateClouds"), EffectPriority.VeryHigh);
                Filters.Scene["CloudFilter"].Load();
            }
        }

        public static bool NoInvasion(NPCSpawnInfo spawnInfo) => !spawnInfo.invasion && (!Main.pumpkinMoon && !Main.snowMoon || spawnInfo.spawnTileY > Main.worldSurface || Main.dayTime) &&
                   (!Main.eclipse || spawnInfo.spawnTileY > Main.worldSurface || !Main.dayTime);

        public static bool NoBiome(NPCSpawnInfo spawnInfo)
        {
            Player player = spawnInfo.player;
            return !player.ZoneJungle && !player.ZoneDungeon && !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneHoly && !player.ZoneSnow && !player.ZoneUndergroundDesert;
        }

        public static bool NoZoneAllowWater(NPCSpawnInfo spawnInfo) => !spawnInfo.sky && !spawnInfo.player.ZoneMeteor && !spawnInfo.spiderCave;

        public static bool NoZone(NPCSpawnInfo spawnInfo) => NoZoneAllowWater(spawnInfo) && !spawnInfo.water;

        public static bool NormalSpawn(NPCSpawnInfo spawnInfo) => !spawnInfo.playerInTown && NoInvasion(spawnInfo);

        public static bool NoZoneNormalSpawn(NPCSpawnInfo spawnInfo) => NormalSpawn(spawnInfo) && NoZone(spawnInfo);

        public static bool NoZoneNormalSpawnAllowWater(NPCSpawnInfo spawnInfo) => NormalSpawn(spawnInfo) && NoZoneAllowWater(spawnInfo);

        public static bool NoBiomeNormalSpawn(NPCSpawnInfo spawnInfo) => NormalSpawn(spawnInfo) && NoBiome(spawnInfo) && NoZone(spawnInfo);

        public override void Load()
        {
            
        }

        public override void PostSetupContent()
        {
            base.PostSetupContent();
        }

        public override void Unload()
        {
            
        }
        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            /* TODO: get more music for these easter eggs, we have redemption
            if(Thorium != null)
            {
                if (ModContent.GetInstance<ThoriumPlayer>().ZoneAqua)
                {

                }
            }
            if (Calamity != null)
            {

            }*/
        }
    }
}