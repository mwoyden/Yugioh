using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.TrapCards
{
    class TwoProngedAttack : TrapCard
    {
        public TwoProngedAttack(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.twoProngedAttack;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Two-Pronged Attack";
            cardText = "Select and destroy 2 of your monsters and 1 of your opponent's monsters.";
            trapType = TrapType.NORMAL;
        }
    }
}
