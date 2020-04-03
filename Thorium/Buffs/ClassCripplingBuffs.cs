using Terraria;
using Terraria.ModLoader;

namespace MasomodeDLC.Thorium.Buffs
{
	public class WristPain : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "FargowiltasSouls/Buffs/PlaceholderDebuff";
			return ModLoader.GetMod("ThoriumMod") != null;
		}

		public override void SetDefaults()
		{
			DisplayName.SetDefault("Wrist Pain");
			Description.SetDefault("It hurts to throw anything");
			Main.debuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<MasoDLCPlayer>().wristpain = true;
		}
	}
	public class CreativeBlank : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "FargowiltasSouls/Buffs/PlaceholderDebuff";
			return ModLoader.GetMod("ThoriumMod") != null;
		}

		public override void SetDefaults()
		{
			DisplayName.SetDefault("Creative Blank");
			Description.SetDefault("It is hard to keep playing");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<MasoDLCPlayer>().creativeblank = true;
		}
	}
}
