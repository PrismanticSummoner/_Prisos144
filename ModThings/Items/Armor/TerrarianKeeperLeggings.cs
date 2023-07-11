using _144Prisos.ModThings.DamageClasses;
using _144Prisos.ModThings.Items.LordSpecific.Imotta;
using _144Prisos.ModThings.Items.Placeable;
using _144Prisos.ModThings.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace _144Prisos.ModThings.Items.Armor
{

    [AutoloadEquip(EquipType.Legs)]
    public class TerrarianKeeperLeggings : ModItem
    {
        
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 18;
            Item.value = Item.sellPrice(silver: 20);
            Item.rare = ModContent.RarityType<TegottaRarity>();
            Item.defense = 7;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<EcologicalMush>(), 10);
            recipe.AddTile(TileID.LivingLoom);
            recipe.Register();
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.15f;
            player.moveSpeed *= 1.05f;
        }
    }
}