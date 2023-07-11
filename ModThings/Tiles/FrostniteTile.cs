using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using System.Collections.Generic;
using Terraria.ID;
using Terraria.IO;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;
using _144Prisos.ModThings.Items.Placeable;

namespace _144Prisos.ModThings.Tiles
{
    internal class FrostniteTile : ModTile
    {
            public override void SetStaticDefaults()
            {
            Main.tileShine[Type] = 1100;
            Main.tileSolid[Type] = true;
            Main.tileFrameImportant[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.addTile(Type);

            DustType = 84; //dustType = DustID.Platinum for vanilla, dustType = mod.dustType.Platinum for modded
            HitSound = SoundID.Tink;
            MinPick = 10; //will set minimum pick strength;
        }
    }
}