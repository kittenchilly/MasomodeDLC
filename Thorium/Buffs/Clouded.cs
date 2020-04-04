using Terraria;
using Terraria.ModLoader;

namespace MasomodeDLC.Thorium.Buffs
{
	public class Clouded : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "FargowiltasSouls/Buffs/PlaceholderDebuff";
			return ModLoader.GetMod("ThoriumMod") != null;
		}
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Clouded");
			Description.SetDefault("You can’t see a thing");
			Main.debuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<MasoDLCPlayer>().displayClouds = true;
		}
	}
}
