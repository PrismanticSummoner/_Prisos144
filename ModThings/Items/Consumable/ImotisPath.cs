using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using _144Prisos.ModThings.Rarities;
using Terraria.GameContent.ItemDropRules;
using _144Prisos.ModThings.Items.Placeable;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using _144Prisos.ModThings.Items.Weapons.Imotta;
using System;

namespace _144Prisos.ModThings.Items.Consumable
{
    public class ImotisPath : ModItem
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
            itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<LifeStealing7KnifeStrike>(), 1, 1, 1));
        }
        public override void RightClick(Player player)
        {
            for (int i = 0; i < 50; i++)
            {
                Item other = player.inventory[i];

                if (other.ModItem is GaotisPath)
                    other.TurnToAir();
                else if (other.ModItem is TegotisPath)
                    other.TurnToAir();
            }
            Main.NewText("You have decided to follow the God of Imotta: The Immortal's Lord. Use the blood of your enemies to prolong your life!");
            AdvancedPopupRequest request = default;
            request.Text = "MUHAHAHAHAH I KNOW WE'LL GET ALONG KID!";
            float seconds = Math.Min(2.5f, 3);
            request.DurationInFrames = (int)(seconds * 60);
            request.Color = new Color(146, 0, 49);

            PopupText.NewText(request, player.Center + new Vector2(0, -35));
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var line = new TooltipLine(Mod, "<right> to choose path", "Do you wish to know what imortality feels like?")
            {
                OverrideColor = new Color(146, 0, 49)
            };
            tooltips.Add(line);
        }
    }
}
