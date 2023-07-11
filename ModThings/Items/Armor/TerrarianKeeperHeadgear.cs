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

    [AutoloadEquip(EquipType.Head)]
    public class TerrarianKeeperHeadgear : ModItem
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
            recipe.AddIngredient(ModContent.ItemType<EcologicalMush>(), 20);
            recipe.AddTile(TileID.LivingLoom);
            recipe.Register();
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == Mod.Find<ModItem>("TerrarianKeeperArmorPlating").Type && legs.type == Mod.Find<ModItem>("TerrarianKeeperLeggings").Type;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.15f;
            player.statManaMax2 += 30;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+1 Armor Penetration" +
                "\n +30 Mana" +
                "\n +1 Minion Slot";

            player.GetArmorPenetration(DamageClass.Generic) += 1;
            player.statManaMax2 += 30;
            player.maxMinions += 1;
        }
    }
}