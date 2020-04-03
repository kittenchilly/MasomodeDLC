using Terraria;
using Terraria.ModLoader;

namespace MasomodeDLC.Thorium.Buffs
{
	public class Teslasurge : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "FargowiltasSouls/Buffs/PlaceholderDebuff";
			return ModLoader.GetMod("ThoriumMod") != null;
		}
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Tesla Surge");
			Description.SetDefault("You're shocked and cannot control your speed");
			Main.debuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<MasoDLCPlayer>().teslasurge = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			ModContent.GetInstance<MasoThoriumGlobalNPC>().teslasurge = true;
		}
	}
}
