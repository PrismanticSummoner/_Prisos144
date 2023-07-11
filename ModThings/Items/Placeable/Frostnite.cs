using _144Prisos.ModThings.Rarities;
using Terraria;
using Terraria.ID;
using _144Prisos.ModThings.Tiles;
using Terraria.ModLoader;

namespace _144Prisos.ModThings.Items.Placeable
{
    public class Frostnite : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.FrostniteTile>());
            Item.width = 12;
            Item.height = 12;
            Item.value = 3000;
            Item.rare = ModContent.RarityType<GaottaRarity>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IceBlock, 2);
            recipe.AddIngredient(ItemID.BorealWood);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}