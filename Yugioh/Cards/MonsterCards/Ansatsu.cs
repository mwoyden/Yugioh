using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class Ansatsu : MonsterCard
    {
        public Ansatsu(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.ansatsu;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Ansatsu";
            attack = 1700;
            defense = 1200;
            effect = false;
            stars = 5;
            cardText = "A silent and deadly warrior specializing in assassinations.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.WARRIOR;
            attribute = MonsterAttribute.EARTH;
        }
    }
}
