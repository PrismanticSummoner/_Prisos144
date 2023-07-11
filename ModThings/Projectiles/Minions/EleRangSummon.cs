using _144Prisos.ModThings.Items.Weapons.Gaotta;
using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace _144Prisos.ModThings.Projectiles.Minions
{
    public class EleRangSummon : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 20;
        }

        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.minion = true;
            Projectile.minionSlots = 1f;
            Projectile.aiStyle = 26;
            Projectile.timeLeft = 18000;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.netImportant = true;
            AIType = ProjectileID.BabySlime;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            if (player.dead || !player.active)
            {
                player.ClearBuff(ModContent.BuffType<EleRangSummonBuff>());
            }
            if (player.HasBuff(ModContent.BuffType<EleRangSummonBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            // The minion shoots at nearby enemies

            float range = 300f; // The range at which the minion will detect enemies

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC target = Main.npc[i];
                if (target.active && !target.friendly && target.lifeMax > 5 && !target.dontTakeDamage && !target.immortal)
                {
                    float distance = Vector2.Distance(Projectile.Center, target.Center);
                    if (distance <= range && Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, target.position, target.width, target.height))
                    {
                        Vector2 shootVelocity = target.Center - Projectile.Center;
                        shootVelocity.Normalize();

                        Projectile.NewProjectile(player.GetSource_ItemUse(player.HeldItem), player.position.X, player.position.Y, 0, 0, ModContent.ProjectileType<HailstormStaffProjectile>(), 0, 4, player.whoAmI, 0f);
                        break; // Break the loop after shooting at one enemy
                    }
                }
            }

        }
    }

    public class EleRangSummonBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[ModContent.ProjectileType<EleRangSummon>()] > 0)
            {
                player.GetModPlayer<PrisosPlayer>().eRangSummon = true;
            }
            if (!player.GetModPlayer<PrisosPlayer>().eRangSummon)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
        }
    }
}
