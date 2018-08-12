using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class DomaTheAngelOfSilence : MonsterCard
    {
        public DomaTheAngelOfSilence(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.domaTheAngelOfSilence;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Doma The Angel Of Silence";
            attack = 1600;
            defense = 1400;
            effect = false;
            stars = 5;
            cardText = "This fairy rules over the end of existence.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.FAIRY;
            attribute = MonsterAttribute.DARK;
        }
    }
}
