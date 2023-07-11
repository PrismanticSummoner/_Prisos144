using _144Prisos.ModThings.Items.Weapons.Gaotta;
using _144Prisos.ModThings.Rarities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using _144Prisos.ModThings.DamageClasses;
using _144Prisos.ModThings.Items.Placeable;
using Terraria.DataStructures;
using _144Prisos.ModThings.Items.LordSpecific.Imotta;
using static Terraria.ModLoader.PlayerDrawLayer;
using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework.Graphics;

namespace _144Prisos.ModThings.Systems.ImottaSystem
{
    internal class Imotta
    {
        float healAmount = 0;
        int healPower = 0;

        public virtual void Heal(Player player, float HealAmount, int HealPower)
        {
            if (healPower > 0)
            {
                healAmount = player.statLife += HealPower;
            }
        }
    }
}
