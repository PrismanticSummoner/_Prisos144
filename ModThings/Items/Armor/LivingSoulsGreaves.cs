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
    public class LivingSoulsGreaves : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 18;
            Item.value = Item.sellPrice(silver: 20);
            Item.rare = ModContent.RarityType<ImottaRarity>();
            Item.defense = 3;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SoulEssence>(), 10);
            recipe.AddIngredient(ModContent.ItemType<LifestoneBar>(), 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 10;
        }
    }
}