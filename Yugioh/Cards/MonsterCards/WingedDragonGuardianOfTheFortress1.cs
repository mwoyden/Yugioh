using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class WingedDragonGuardianOfTheFortress1 : MonsterCard
    {
        public WingedDragonGuardianOfTheFortress1(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.wingedDragonGuardianOfTheFortress1;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Winged Dragon, Guardian Of The Fotress #1";
            attack = 1400;
            defense = 1200;
            effect = false;
            stars = 4;
            cardText = "A dragon commonly found guarding mountain fortresses. Its signature attack is a sweeping dive from out of the blue.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.DRAGON;
            attribute = MonsterAttribute.WIND;
        }
    }
}
