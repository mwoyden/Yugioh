using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class GaiaTheFierceKnight : MonsterCard
    {
        public GaiaTheFierceKnight(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.gaiaTheFierceKnight;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Gaia The Fierce Knight";
            attack = 2300;
            defense = 2100;
            effect = false;
            stars = 7;
            cardText = "A knight whose horse travels faster than the wind. His battle-charge is a force to be reckoned with.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.WARRIOR;
            attribute = MonsterAttribute.EARTH;
        }
    }
}
