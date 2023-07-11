using _144Prisos.ModThings.DamageClasses;
using _144Prisos.ModThings.Items.Placeable;
using _144Prisos.ModThings.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace _144Prisos.ModThings.Items.Armor
{
  
    [AutoloadEquip(EquipType.Body)]

    public class FrostniteRobe : ModItem
    {

        public override void Load()
        {
            EquipLoader.AddEquipTexture(Mod, $"{Texture}_{EquipType.Legs}", EquipType.Legs, this);
        }

        public override void SetStaticDefaults()
        {
            ArmorIDs.Body.Sets.HidesHands[Item.bodySlot] = false;
        }
        public override void SetDefaults()
        {
            Item.width = 32; 
            Item.height = 18; 
            Item.value = Item.sellPrice(silver: 20); 
            Item.rare = ModContent.RarityType<GaottaRarity>(); 
            Item.defense = 5;
        }

        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Frostnite>(), 30);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
        public override void SetMatch(bool male, ref int equipSlot, ref bool robes)
        {
            robes = true;
            equipSlot = EquipLoader.GetEquipSlot(Mod, Name, EquipType.Legs);
        }
    }
}