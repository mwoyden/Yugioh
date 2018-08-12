using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class MagicalGhost : MonsterCard
    {
        public MagicalGhost(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.magicalGhost;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Magical Ghost";
            attack = 1300;
            defense = 1400;
            effect = false;
            stars = 4;
            cardText = "This creature casts a spell of terror and confusion just before attacking its enemies.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.ZOMBIE;
            attribute = MonsterAttribute.DARK;
        }
    }
}
