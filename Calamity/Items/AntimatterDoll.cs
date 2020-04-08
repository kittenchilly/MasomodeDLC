using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace MasomodeDLC.Calamity.Items
{
	public class AntimatterDoll : ModItem
	{
		public override bool Autoload(ref string name)
		{
			return ModLoader.GetMod("CalamityMod") != null;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Antimatter Doll");
			Tooltip.SetDefault("Summons...the void...???\n"
							 + "Alters the appearance, greed, and food preferences of the void if it is already present");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 36;
			item.value = Item.sellPrice(0, 0, 0, 0);
			item.rare = 11;
			ModLoader.GetMod("CalamityMod").Call("SetItemRarity", this, 17);
			item.defense = 0;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MasoDLCPlayer>().antimatterDoll = true;
		}

		public override bool AllowPrefix(int pre)
		{
			return false;
		}
	}
}