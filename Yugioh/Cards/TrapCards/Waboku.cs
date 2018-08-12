using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.TrapCards
{
    class Waboku : TrapCard
    {
        public Waboku(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.waboku;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Waboku";
            cardText = "You take no Battle Damage this turn. Your monsters cannot be destroyed by battle this turn.";
            trapType = TrapType.NORMAL;
        }
    }
}
