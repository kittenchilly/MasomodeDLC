using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using MasomodeDLC;
using MasomodeDLC.Thorium;

namespace MasomodeDLC.Thorium.Buffs
{
	public class RubberWeapon : ModBuff
	{
		public override bool Autoload(ref string name, ref string texture)
		{
			texture = "FargowiltasSouls/Buffs/PlaceholderDebuff";
			return ModLoader.GetMod("ThoriumMod") != null;
		}
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Rubber Weapon");
			Description.SetDefault("Your attacks are friendly and squeaky");
			Main.debuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<MasoDLCPlayer>().rubberWeapon = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			base.Update(npc, ref buffIndex);
		}
	}
}
