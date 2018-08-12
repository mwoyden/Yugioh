using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class WittyPhantom : MonsterCard
    {
        public WittyPhantom(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.wittyPhantom;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Witty Phantom";
            attack = 1400;
            defense = 1300;
            effect = false;
            stars = 4;
            cardText = "Dressed in a night-black tuxedo, this creature presides over death.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.FIEND;
            attribute = MonsterAttribute.DARK;
        }
    }
}
