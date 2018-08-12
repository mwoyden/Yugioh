using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class TheSternMystic : MonsterCard
    {
        public TheSternMystic(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.theSternMystic;
            position = new Vector2(0, 0);

            // Card attributes
            name = "The Stern Mystic";
            attack = 1500;
            defense = 1200;
            effect = true;
            stars = 4;
            cardText = "FLIP: All face-down cards on the field are turned face-up, and then returned to their original position. No card effects are activated when cards are turned face-up.";
            monsterType = MonsterType.FLIP_EFFECT;
            subType = MonsterSubType.SPELLCASTER;
            attribute = MonsterAttribute.LIGHT;
        }
    }
}
