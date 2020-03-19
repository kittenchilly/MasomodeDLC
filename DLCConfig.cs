using Terraria.ModLoader.Config;

namespace MasomodeDLC
{
	public class DLCConfig : ModConfig
	{
		internal static DLCConfig instance;
		public DLCConfig()
		{
			
		}
		public override bool Autoload(ref string name)
		{
			name = "Masomode DLC Config";
			return true;
		}
		public override ConfigScope Mode => ConfigScope.ClientSide;
		[Label("MasoDLC General")]
		public MasoDLCmenu masodlcmenu = new MasoDLCmenu();

		[SeparatePage]
		public class MasoDLCmenu
		{
			public static MasoDLCmenu instance;
			[Label("Dev Items Do Nothing")]
			[Tooltip("Items intended to represent or use by developers will have no function.")]
			[ReloadRequired]
			public bool DevItemsNoFunction { get; set; } = false;
			[Label("Hide Easter Eggs")]
			public bool HideEasterEggs { get; set; } = false;
			/* [Label("Disable Cross Mod Balancing")]
			 * [Tooltip("Disables the stat tweaks used to balance the game with two or more content mods enabled.")]
			 * public bool DisableCrossBalancing { get; set; } = false;
			 TODO: uncomment this if we ever do this*/ 
		}
	}
}
