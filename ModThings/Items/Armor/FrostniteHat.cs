using _144Prisos.ModThings.DamageClasses;
using _144Prisos.ModThings.Items.Placeable;
using _144Prisos.ModThings.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace _144Prisos.ModThings.Items.Armor
{
    
    [AutoloadEquip(EquipType.Head)]
    public class FrostniteHat : ModItem
    {

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
            recipe.AddIngredient(ModContent.ItemType<Frostnite>(),30);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs) 
        { 
            return body.type == Mod.Find<ModItem>("FrostniteRobe").Type;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increased Gaotta Damage by 5%" +
                "\n Increased defense by 5";
            player.GetDamage<GaottaDamageClass>() *= 1.05f;
            player.statDefense += 5;

        }
    }
}