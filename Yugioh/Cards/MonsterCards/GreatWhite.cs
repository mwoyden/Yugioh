using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class GreatWhite : MonsterCard
    {
        public GreatWhite(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.greatWhite;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Great White";
            attack = 1600;
            defense = 800;
            effect = false;
            stars = 4;
            cardText = "A giant white shark with razor-sharp teeth.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.FISH;
            attribute = MonsterAttribute.WATER;
        }
    }
}
