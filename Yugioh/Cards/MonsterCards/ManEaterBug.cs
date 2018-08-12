using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class ManEaterBug : MonsterCard
    {
        public ManEaterBug(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.manEaterBug;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Man-Eater Bug";
            attack = 450;
            defense = 600;
            effect = true;
            stars = 2;
            cardText = "FLIP: Select and destroy 1 monster on the field.";
            monsterType = MonsterType.FLIP_EFFECT;
            subType = MonsterSubType.INSECT;
            attribute = MonsterAttribute.EARTH;
        }
    }
}
