using _144Prisos.ModThings.Rarities;
using Terraria;
using Terraria.ID;
using _144Prisos.ModThings.Tiles;
using Terraria.ModLoader;

namespace _144Prisos.ModThings.Items.Placeable
{
    public class EcologicalMush : ModItem
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
            Item.rare = ModContent.RarityType<TegottaRarity>();
        }

        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe(5);
            recipe1.AddIngredient(ItemID.SnowBlock, 2);
            recipe1.AddIngredient(ItemID.MudBlock, 2);
            recipe1.AddIngredient(ItemID.SandBlock, 2);
            recipe1.AddIngredient(ItemID.DirtBlock, 2);
            recipe1.AddIngredient(ItemID.Shadewood, 2);
            recipe1.AddIngredient(ItemID.PalmWood, 2);
            recipe1.AddTile(TileID.WorkBenches);
            recipe1.Register();

            Recipe recipe2 = CreateRecipe(5);
            recipe2.AddIngredient(ItemID.SnowBlock, 2);
            recipe2.AddIngredient(ItemID.MudBlock, 2);
            recipe2.AddIngredient(ItemID.SandBlock, 2);
            recipe2.AddIngredient(ItemID.DirtBlock, 2);
            recipe2.AddIngredient(ItemID.Ebonwood, 2);
            recipe2.AddIngredient(ItemID.PalmWood, 2);
            recipe2.AddTile(TileID.WorkBenches);
            recipe2.Register();
        }
    }
}