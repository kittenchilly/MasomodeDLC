using CalamityMod.CalPlayer;
using MasomodeDLC.Calamity.Buffs;
using MasomodeDLC.Thorium.Buffs;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using ThoriumMod.Buffs;

namespace MasomodeDLC
{
	public static class MasoDLCUtils
	{

	}

	public static class ThorWorldBools
	{
		public static bool DownedJellyfishJam
		{
			get { return ThoriumMod.ThoriumWorld.downedJelly; }
		}

		public static bool DownedCoolBloomFacts
		{
			get { return ThoriumMod.ThoriumWorld.downedBloom; }
		}

		public static bool DownedFallenBeholster
		{
			get { return ThoriumMod.ThoriumWorld.downedFallenBeholder; }
		}
	}

	public static class ThorBuffIDs
	{
		public static int Freezing
		{
			get { return ModContent.BuffType<ThoriumMod.Buffs.EnemyFrozen>(); }
		}

		public static int TaintedHearts
		{
			get { return ModContent.BuffType<ThoriumMod.Buffs.PoisonHeart>(); }
		}
	}

	public static class ThorItemIDs
	{

	}

	public static class ThorProjectileIDs
	{

	}

	public static class ThorNPCIDs
	{

	}

	public static class ClamWorldBools
	{
		public static bool DownedDessertWorm
		{
			get { return CalamityMod.World.CalamityWorld.downedDesertScourge; }
		}

		public static bool DownedCuteAnimeHiveMind
		{
			get { return CalamityMod.World.CalamityWorld.downedHiveMind; }
		}

		public static bool DownedPerfs
		{
			get { return CalamityMod.World.CalamityWorld.downedPerforator; }
		}

		public static bool DownedAquaticWorm
		{
			get { return CalamityMod.World.CalamityWorld.downedAquaticScourge; }
		}

		public static bool DownedBootlegCalamitas
		{
			get { return CalamityMod.World.CalamityWorld.downedCalamitas; }
		}

		public static bool DownedCalamitas
		{
			get { return CalamityMod.World.CalamityWorld.downedSCal; }
		}
	}

	public static class ClamBuffIDs
	{

	}

	public static class ClamItemIDs
	{
		#region Materials
		#region Ashes of Calamity
		public static int CalamityAsh
		{
			get { return ModContent.ItemType<CalamityMod.Items.Materials.CalamityDust>(); }
		}
		#endregion
		#endregion
		#region Potions
		#region Calamitas' Brew
		public static int CalamitasBathWater
		{
			get { return ModContent.ItemType<CalamityMod.Items.Potions.CalamitasBrew>(); }
		}
		#endregion
		#region Tesla Potion
		public static int TeslaPotion
		{
			get { return ModContent.ItemType<CalamityMod.Items.Potions.TeslaPotion>(); }
		}
		#endregion
		#region Triumph Potion
		public static int TriumphPotion
		{
			get { return ModContent.ItemType<CalamityMod.Items.Potions.TriumphPotion>(); }
		}
		#endregion
		#endregion
	}

	public static class ClamProjectileIDs
	{
		#region Melee
		#region Spark from Amidias' Spark
		public static int AmidiasSpark
		{
			get { return ModContent.ProjectileType<CalamityMod.Projectiles.Melee.Spark>(); }
		}
		#endregion
		#endregion
	}

	public static class ClamNPCIDs
	{
		public static int CosmicElemental
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.CosmicElemental>(); }
		}

		public static int StormlionCharger
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.StormlionCharger>(); }
		}

		public static int GhostBell
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.SunkenSea.GhostBell>(); }
		}

		public static int BabyGhostBell
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.SunkenSea.GhostBellSmall>(); }
		}

		public static int BlightedEye
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.NormalNPCs.BlightedEye>(); }
		}

		public static int CalamityEye
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.Crags.CalamityEye>(); }
		}

		public static int SandScourgeHead
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.DesertScourge.DesertScourgeHead>(); }
		}

		public static int SandScourgeBody
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.DesertScourge.DesertScourgeBody>(); }
		}

		public static int SandScourgeTail
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.DesertScourge.DesertScourgeTail>(); }
		}

		public static int DriedSeekerHead
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.DesertScourge.DriedSeekerHead>(); }
		}

		public static int DriedSeekerBody
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.DesertScourge.DriedSeekerBody>(); }
		}

		public static int DriedSeekerTail
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.DesertScourge.DriedSeekerTail>(); }
		}

		public static int SandScourgeHeadSmall
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.DesertScourge.DesertScourgeHeadSmall>(); }
		}

		public static int SandScourgeBodySmall
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.DesertScourge.DesertScourgeBodySmall>(); }
		}

		public static int SandScourgeTailSmall
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.DesertScourge.DesertScourgeTailSmall>(); }
		}

		public static int Crabulon
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.Crabulon.CrabulonIdle>(); }
		}

		public static int CrabulonShroom
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.Crabulon.CrabShroom>(); }
		}

		public static int HiiHMiiM
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.HiveMind.HiveMind>(); }
		}

		public static int HiiHMiiM2
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.HiveMind.HiveMindP2>(); }
		}

		public static int DankCreeperAwMan
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.HiveMind.DankCreeper>(); }
		}

		public static int HiveBlob
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.HiveMind.HiveBlob>(); }
		}

		public static int HiveBlob2
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.HiveMind.HiveBlob2>(); }
		}

		public static int DarkHeart
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.HiveMind.DarkHeart>(); }
		}

		public static int PerfHive
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorHive>(); }
		}

		public static int PerfWormHeadBig
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorHeadLarge>(); }
		}

		public static int PerfWormBodyBig
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorBodyLarge>(); }
		}

		public static int PerfWormTailBig
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorTailLarge>(); }
		}

		public static int PerfWormHeadMedium
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorHeadMedium>(); }
		}

		public static int PerfWormBodyMedium
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorBodyMedium>(); }
		}

		public static int PerfWormTailMedium
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorTailMedium>(); }
		}

		public static int PerfWormHeadSmall
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorHeadSmall>(); }
		}

		public static int PerfWormBodySmall
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorBodySmall>(); }
		}

		public static int PerfWormTailSmall
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.Perforator.PerforatorTailSmall>(); }
		}

		public static int SlimeGodCore
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodCore>(); }
		}

		public static int SlimeGodWhichOneIsWhich
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGod>(); }
		}

		public static int SlimeGodWhichOneIsWhichSplit
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodSplit>(); }
		}

		public static int SlimeGodWhichOtherOneIsWhich
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodRun>(); }
		}

		public static int SlimeGodWhichOtherOneIsWhichSplit
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeGodRunSplit>(); }
		}

		public static int SlimeGodSpawnCrimson
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeSpawnCrimson>(); }
		}

		public static int SlimeGodSpawnCrimson2
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeSpawnCrimson2>(); }
		}

		public static int SlimeGodSpawnCorrupt
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeSpawnCorrupt>(); }
		}

		public static int SlimeGodSpawnCorrupt2
		{
			get { return ModContent.NPCType<CalamityMod.NPCs.SlimeGod.SlimeSpawnCorrupt2>(); }
		}
	}
}