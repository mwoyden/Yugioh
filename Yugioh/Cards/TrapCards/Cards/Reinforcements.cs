﻿using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.TrapCards.Cards
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
