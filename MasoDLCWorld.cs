using System.Collections.Generic;
using System.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MasomodeDLC
{
	public class MasoDLCWorld : ModWorld
	{
		public static int ThunderBirdCount;
		public static int JellyCount;
		public static int VisCount; //heh
		public static int GraniteCount;
		public static int ChampionCount;
		public static int ScouterCount;
		public static int StriderCount;
		public static int BeholderCount;
		public static int LichCount;
		public static int AbyssionCount;
		public static int RagnarokCount;

		public static int DesertWormBossCount;
		public static int CrabRaveCount;
		public static int HiiHMiiMCount;
		public static int BloodyWormBossesCount;
		public static int TwoBiomeMimicsAndAFlockoCount;
		public static int IceCubeCount;
		public static int SulphurousWormBossCount;
		public static int BrimboCount;
		public static int CalamitasCount; // calamitas;
		public static int AuroraBorealisCount;
		public static int FatFishFucksCount;
		public static int PeanutButterGoliathCount;
		public static int ScavengerCount;
		public static int StarGodWormBossCount;
		public static int DunkinDonutsCount;
		public static int birb;
		public static int ProvidabCount;
		public static int ElectricWormBossCount;
		public static int CeaselessVoreCount;
		public static int SignutCount;
		public static int WormBossSupremeCount;
		public static int KentuckyFriedChickenCount;
		public static int SupremeCountamitas;


		public override void Initialize()
		{
			ThunderBirdCount = 0;
			JellyCount = 0;
			VisCount = 0;
			GraniteCount = 0;
			ChampionCount = 0;
			ScouterCount = 0;
			StriderCount = 0;
			BeholderCount = 0;
			LichCount = 0;
			AbyssionCount = 0;
			RagnarokCount = 0;

			DesertWormBossCount = 0;
			CrabRaveCount = 0;
			HiiHMiiMCount = 0;
			BloodyWormBossesCount = 0;
			TwoBiomeMimicsAndAFlockoCount = 0;
			IceCubeCount = 0;
			SulphurousWormBossCount = 0;
			BrimboCount = 0;
			CalamitasCount = 0;
			AuroraBorealisCount = 0;
			FatFishFucksCount = 0;
			PeanutButterGoliathCount = 0;
			ScavengerCount = 0;
			StarGodWormBossCount = 0;
			DunkinDonutsCount = 0;
			birb = 0;
			ProvidabCount = 0;
			ElectricWormBossCount = 0;
			CeaselessVoreCount = 0;
			SignutCount = 0;
			WormBossSupremeCount = 0;
			KentuckyFriedChickenCount = 0;
			SupremeCountamitas = 0;
		}

		public override TagCompound Save()
		{
			List<int> count = new List<int>
			{
				ThunderBirdCount,
				JellyCount,
				VisCount,
				GraniteCount,
				ChampionCount,
				ScouterCount,
				StriderCount,
				BeholderCount,
				LichCount,
				AbyssionCount,
				RagnarokCount,
				DesertWormBossCount,
				CrabRaveCount,
				HiiHMiiMCount,
				BloodyWormBossesCount,
				TwoBiomeMimicsAndAFlockoCount,
				IceCubeCount,
				SulphurousWormBossCount,
				BrimboCount,
				CalamitasCount,
				AuroraBorealisCount,
				FatFishFucksCount,
				PeanutButterGoliathCount,
				ScavengerCount,
				StarGodWormBossCount,
				DunkinDonutsCount,
				birb,
				ProvidabCount,
				ElectricWormBossCount,
				CeaselessVoreCount,
				SignutCount,
				WormBossSupremeCount,
				KentuckyFriedChickenCount,
				SupremeCountamitas
			};

			return new TagCompound
			{
				{"count", count}
			};
		}

		public override void Load(TagCompound tag)
		{
			if (tag.ContainsKey("count"))
			{
				IList<int> count = tag.GetList<int>("count");
				ThunderBirdCount = count[0];
				JellyCount = count[1];
				VisCount = count[2];
				GraniteCount = count[3];
				ChampionCount = count[4];
				ScouterCount = count[5];
				StriderCount = count[6];
				BeholderCount = count[7];
				LichCount = count[8];
				AbyssionCount = count[9];
				RagnarokCount = count[10];
			}
		}

		public override void NetReceive(BinaryReader reader)
		{
			ThunderBirdCount = reader.ReadInt32();
			JellyCount = reader.ReadInt32();
			VisCount = reader.ReadInt32();
			GraniteCount = reader.ReadInt32();
			ChampionCount = reader.ReadInt32();
			ScouterCount = reader.ReadInt32();
			StriderCount = reader.ReadInt32();
			BeholderCount = reader.ReadInt32();
			LichCount = reader.ReadInt32();
			AbyssionCount = reader.ReadInt32();
			RagnarokCount = reader.ReadInt32();
		}

		public override void NetSend(BinaryWriter writer)
		{
			writer.Write(ThunderBirdCount);
			writer.Write(JellyCount);
			writer.Write(VisCount);
			writer.Write(GraniteCount);
			writer.Write(ChampionCount);
			writer.Write(ScouterCount);
			writer.Write(StriderCount);
			writer.Write(BeholderCount);
			writer.Write(LichCount);
			writer.Write(AbyssionCount);
			writer.Write(RagnarokCount);
		}
	}
}