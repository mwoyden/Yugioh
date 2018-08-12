using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class CelticGuardian : MonsterCard
    {
        public CelticGuardian(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.celticGuardian;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Celtic Guardian";
            attack = 1400;
            defense = 1200;
            effect = false;
            stars = 4;
            cardText = "An elf who learned to wield a sword, he baffles enemies with lightning-swift attacks.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.WARRIOR;
            attribute = MonsterAttribute.EARTH;
        }
    }
}
