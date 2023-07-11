using Terraria.ModLoader;
using Terraria;
using _144Prisos.ModThings.Projectiles.Minions;

public class PrisosPlayer : ModPlayer
{
    public bool eRangSummon;

    public override void ResetEffects()
    {
        eRangSummon = false;
    }

    public override void PostUpdateMiscEffects()
    {
        if (eRangSummon)
        {
            Player.AddBuff(ModContent.BuffType<EleRangSummonBuff>(), 2);
        }
    }
}