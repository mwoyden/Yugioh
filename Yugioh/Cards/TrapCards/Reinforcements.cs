using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.TrapCards
{
    class Reinforcements : TrapCard
    {
        public Reinforcements(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.reinforcements;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Reinforcements";
            cardText = "Increase the ATK of 1 face-up monster on the field by 500 points until the end of this turn.";
            trapType = TrapType.NORMAL;
        }
    }
}
