using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class NeoTheMagicSwordsMan : MonsterCard
    {
        public NeoTheMagicSwordsMan(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.neoTheMagicSwordsman;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Neo The Magic Swordsman";
            attack = 1700;
            defense = 1000;
            effect = false;
            stars = 4;
            cardText = "A dimensional drifter who not only practices sorcery, but is also a sword and martial arts master.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.SPELLCASTER;
            attribute = MonsterAttribute.LIGHT;
        }
    }
}
