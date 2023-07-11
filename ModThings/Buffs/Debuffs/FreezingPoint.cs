using Terraria;
using Terraria.ModLoader;

namespace _144Prisos.ModThings.Buffs.Debuffs
{
    public class FreezingPoint : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense -= 10; // Reduce defense by 10
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.defense -= 5; // Reduce defense by 10
        }
    }
}
