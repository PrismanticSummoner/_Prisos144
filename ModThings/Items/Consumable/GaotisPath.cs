using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using _144Prisos.ModThings.Rarities;
using Terraria.GameContent.ItemDropRules;
using _144Prisos.ModThings.Items.Placeable;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;

namespace _144Prisos.ModThings.Items.Consumable
{
    public class GaotisPath : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.PreHardmodeLikeBossBag[Type] = true;
            ItemID.Sets.BossBag[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 1;
            Item.consumable = true;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.UseSound = SoundID.Item1;
            Item.rare = ModContent.RarityType<PathRarity>();
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<Frostnite>(), 1, 7, 7));
        }
        public override void RightClick(Player player)
        {
            for (int i = 0; i < 50; i++)
            {
                Item other = player.inventory[i];

                if (other.ModItem is TegotisPath)
                    other.TurnToAir();
                else if (other.ModItem is ImotisPath)
                    other.TurnToAir();
            }
            Main.NewText("You have decided to follow the God of Gaotta: The Cultist's Lord. Use your sigils to ruin hordes of troops!");
            AdvancedPopupRequest request = default;
            request.Text = "Good...I have bestowed upon you items to begin your discipleship...";
            float seconds = Math.Min(2.5f, 3);
            request.DurationInFrames = (int)(seconds * 60);
            request.Color = new Color(159, 228, 245);

            PopupText.NewText(request, player.Center + new Vector2(0, -35));
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var line = new TooltipLine(Mod, "<right> to choose path", "Do you wish to learn about the stars as well?")
            {
                OverrideColor = new Color(159, 228, 245)
            };
            tooltips.Add(line);
        }
    }
}
