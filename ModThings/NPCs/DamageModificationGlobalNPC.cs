using _144Prisos.ModThings.DamageClasses;
using _144Prisos.ModThings.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using _144Prisos.ModThings.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria.DataStructures;
using _144Prisos.ModThings.Buffs.Debuffs;


namespace _144Prisos.ModThings.NPCs
{
    internal class DamageModificationGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public bool freezingPoint;

        public override void ResetEffects(NPC npc)
        {
            freezingPoint = false;
        }

        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            // This simple color effect indicates that the buff is active
            if (freezingPoint)
            {
                drawColor.G = 0;
            }
        }
    }
}