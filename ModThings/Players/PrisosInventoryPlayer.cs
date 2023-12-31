﻿using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using _144Prisos.ModThings.Items.Placeable;
using _144Prisos.ModThings.Items.Weapons;
using _144Prisos.ModThings.Items.Consumable;

namespace _144Prisos.ModThings.Players
{
    public class PrisosInventoryPlayer : ModPlayer
    {
        // AddStartingItems is a method you can use to add items to the player's starting inventory.
        // It is also called when the player dies a mediumcore death
        // Return an enumerable with the items you want to add to the inventory.
        // This method adds an ExampleItem and 256 gold ore to the player's inventory.
        //
        // If you know what 'yield return' is, you can also use that here, if you prefer so.
        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
        {
            if (mediumCoreDeath)
            {
                return new[] {
                    new Item(ItemID.LifeCrystal, 5)
                };
            }

            return new[] {
                new Item(ModContent.ItemType<TegotisPath>()),
                new Item(ModContent.ItemType<ImotisPath>()),
                new Item(ModContent.ItemType<GaotisPath>())
            };
        }

        // ModifyStartingItems is a more elaborate version of AddStartingItems, which lets you remove items
        // that either vanilla or other mods add. You can technically use it to add items as well, but it's recommended
        // to only do that in AddStartingItems.
        // In this example, we stop Terraria from adding an Iron Axe to the player's inventory if it's journey mode.
        // (If you want to stop another mod from adding an item, its entry is the mod's internal name, e.g itemsByMod["SomeMod"]
        // Terraria's entry is always named just "Terraria"
        public override void ModifyStartingInventory(IReadOnlyDictionary<string, List<Item>> itemsByMod, bool mediumCoreDeath)
        {
            itemsByMod["Terraria"].RemoveAll(item => item.type == ItemID.IronAxe);
        }
    }
}