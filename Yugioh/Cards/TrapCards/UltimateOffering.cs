using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.TrapCards
{
    class UltimateOffering : TrapCard
    {
        public UltimateOffering(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.ultimateOffering;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Ultimate Offering";
            cardText = "You can pay 500 Life Points to Normal Summon or Set 1 extra monster. You can only activate this effect during your Main Phase or your opponent's Battle Phase.";
            trapType = TrapType.CONTINUOUS;
        }
    }
}
