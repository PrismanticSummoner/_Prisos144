using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using _144Prisos.ModThings.Items.Placeable;

namespace _144Prisos
{
	public class _144Prisos : Mod
	{
        [System.Obsolete]
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.LivingLoom);
            recipe.AddIngredient(ModContent.ItemType<EcologicalMush>(), 12);
            recipe.AddTile(TileID.Sawmill);
            recipe.Register();
        }
    }
}