using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
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
                RagnarokCount
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