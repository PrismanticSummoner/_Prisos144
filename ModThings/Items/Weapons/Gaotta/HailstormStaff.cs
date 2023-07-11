using _144Prisos.ModThings.DamageClasses;
using _144Prisos.ModThings.Items.Placeable;
using _144Prisos.ModThings.Rarities;
using _144Prisos.ModThings.Players;
using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Security.Cryptography.X509Certificates;
using Terraria.Localization;
using System.Collections.Generic;

namespace _144Prisos.ModThings.Items.Weapons.Gaotta
{
    public class HailstormStaff : ModItem
    {
        private int starpowerResourceCost; // Add our custom resource cost

        public static LocalizedText UsesXStarpowerResourceText { get; private set; }

        public override void SetStaticDefaults()
        {
            UsesXStarpowerResourceText = this.GetLocalization("UsesXStarpowerResource");
        }

        public override void SetDefaults()
        {
            Item.damage = 5;
            Item.DamageType = DamageClass.Magic;
            Item.width = 58;
            Item.height = 58;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = true;
            Item.knockBack = 6;
            Item.value = Item.buyPrice(gold: 15);
            Item.rare = ModContent.RarityType<GaottaRarity>();
            Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<HailstormStaffProjectile>();
            Item.shootSpeed = 7;
            Item.crit = 32;
            starpowerResourceCost = 5; // Set our custom resource cost to 5
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Frostnite>(), 5);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "StarpowerResourceCost", UsesXStarpowerResourceText.Format(starpowerResourceCost)));
        }

        // Make sure you can't use the item if you don't have enough resource
        public override bool CanUseItem(Player player)
        {
            var starpowerResourcePlayer = player.GetModPlayer<GaottaPlayer>();

            return starpowerResourcePlayer.starpowerResourceCurrent >= starpowerResourceCost;
        }

        // Reduce resource on use
        public override bool? UseItem(Player player)
        {
            var starpowerResourcePlayer = player.GetModPlayer<GaottaPlayer>();

            starpowerResourcePlayer.starpowerResourceCurrent -= starpowerResourceCost;

            return true;
        }
    }

    public class HailstormStaffProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<GaottaDamageClass>();
            Projectile.tileCollide = false;
            Projectile.timeLeft = 180; // Lifetime of the projectile in frames (3 seconds)
        }

        public override void AI()
        {
            // Homing behavior
            float desiredSpeed = 8f;
            float turnResistance = 10f; // Higher values make the projectile turn slower
            Vector2 targetVector = Main.MouseWorld - Projectile.Center;
            float length = targetVector.Length();
            if (length > 200f) // Maximum homing range
                length = 200f;
            targetVector.Normalize();
            targetVector *= desiredSpeed;
            Projectile.velocity = (Projectile.velocity * (turnResistance - 1) + targetVector) / turnResistance;

            // Projectile rotation
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
    }
}
