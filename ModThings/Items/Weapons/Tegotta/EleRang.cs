using _144Prisos.ModThings.Projectiles.Minions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace _144Prisos.ModThings.Items.Weapons.Tegotta
{
    public class EleRang : ModItem
    {
        private int currentWeaponPhase;
        private int currentFrame;
        private int maxFrame;

        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.width = 30;
            Item.height = 30;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 5f;
            Item.value = Item.sellPrice(silver: 5);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.None;
            Item.shootSpeed = 0f;
            Item.noMelee = false;
            Item.noUseGraphic = false;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true; // Allows the weapon to have right-click functionality
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2) // Right-click
            {
                currentWeaponPhase++;
                if (currentWeaponPhase > 3)
                    currentWeaponPhase = 0;

                if (currentWeaponPhase == 0)
                {
                    currentFrame = 0;
                    SetMeleeWeapon(); 
                    return true;
                }

                if (currentWeaponPhase == 1)
                {
                    currentFrame = 1;
                    SetRangedWeapon();
                    return true;
                }

                if (currentWeaponPhase == 2)
                {
                    currentFrame = 2;
                    SetMagicWeapon();
                    return true;
                }

                if (currentWeaponPhase == 3)
                {
                    currentFrame = 3;
                    SetSummonWeapon();
                    return true;
                }

                GetWeaponType();

                currentFrame++;
                if (currentFrame > maxFrame)
                    currentFrame = 0;
                return false;
            }
            else
            {
                return true;
            }
        }
        private int GetWeaponType()
        {
            // Retrieve the weapon type from the item's useAnimation property
            return (Item.useAnimation / 10) % 4;
        }

        private void SetMeleeWeapon()
        {
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.shoot = ProjectileID.None;
            Item.shootSpeed = 0f;
            Item.noMelee = false;
            Item.noUseGraphic = false;
            Item.DamageType = DamageClass.Melee;
            Item.UseSound = SoundID.Item1;
            Item.knockBack = 5f;
        }

        private void SetRangedWeapon()
        {
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 10f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.DamageType = DamageClass.Ranged;
            Item.UseSound = SoundID.Item5;
            Item.knockBack = 2f;
        }

        private void SetMagicWeapon()
        {
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.shoot = ProjectileID.MagicMissile;
            Item.shootSpeed = 12f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.DamageType = DamageClass.Magic;
            Item.UseSound = SoundID.Item9;
            Item.knockBack = 1f;
        }

        private void SetSummonWeapon()
        {
            Item.useAnimation = 35;
            Item.useTime = 35;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.shoot = ModContent.ProjectileType<EleRangSummon>();
            Item.shootSpeed = 8f;
            Item.noMelee = false;
            Item.noUseGraphic = false;
            Item.DamageType = DamageClass.Summon;
            Item.UseSound = SoundID.Item44;
            Item.knockBack = 3f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
