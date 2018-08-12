using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.TrapCards
{
    class TrapHole : TrapCard
    {
        public TrapHole(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.trapHole;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Trap Hole";
            cardText = "When your opponent Normal or Flip Summons a monster with 1000 or more ATK: Target that monster; destroy that target.";
            trapType = TrapType.NORMAL;
        }
    }
}
