using _144Prisos.ModThings.Items.Weapons.Gaotta;
using _144Prisos.ModThings.Rarities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using _144Prisos.ModThings.DamageClasses;
using _144Prisos.ModThings.Items.Placeable;
using Terraria.DataStructures;
using _144Prisos.ModThings.Items.LordSpecific.Imotta;
using static Terraria.ModLoader.PlayerDrawLayer;
using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework.Graphics;
using _144Prisos.ModThings.Players;
using Mono.Cecil;

namespace _144Prisos.ModThings.Items.Weapons.Imotta
{
    internal class LifeStealing7KnifeStrike : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 4;
            Item.DamageType = DamageClass.Magic;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = true;
            Item.knockBack = 3;
            Item.value = Item.buyPrice(gold: 15);
            Item.rare = ModContent.RarityType<ImottaRarity>();
            Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<LifeStealing7KnifeStrikeProjectile>();
            Item.shootSpeed = 15;
            Item.crit = 40;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<LifestoneBar>(), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 7;
            float rotation = MathHelper.ToRadians(45);

            position += Vector2.Normalize(velocity) * 45f;

            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .6f; // Watch out for dividing by 0 if there is only 1 projectile.
                Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }

            return false;
        }

        public class LifeStealing7KnifeStrikeProjectile : ModProjectile
        {

            public override void SetDefaults()
            {
                Projectile.width = 16;
                Projectile.height = 16;
                Projectile.friendly = true;
                Projectile.DamageType = DamageClass.Magic;
                Projectile.tileCollide = false;
                Projectile.timeLeft = 60; // Lifetime of the projectile in frames (3 seconds)
            }

            public override void AI()
            {
                // Rotate projectile towards cursor before shooting
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            }

            public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
            {
                Player player = Main.LocalPlayer;

                player.statLife += 2;
                player.HealEffect(2);


                if (target.life <= 0)
                {
                    int index = Item.NewItem(Projectile.GetSource_DropAsItem(), Projectile.getRect(), ModContent.ItemType<SoulEssence>(), 2);
                }
            }
        }
    }
}
