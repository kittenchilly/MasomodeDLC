using Terraria;
using Terraria.ModLoader;

namespace MasomodeDLC.Thorium.Buffs
{
	public class Clouded : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "FargowiltasSouls/Buffs/PlaceholderDebuff";
			return true;
		}

		public override void SetDefaults()
		{
			Description.SetDefault("Your vision is blinded");
		}

		public override void Update(Player player, ref int buffIndex)
		{
			base.Update(player, ref buffIndex);
		}
	}
}
