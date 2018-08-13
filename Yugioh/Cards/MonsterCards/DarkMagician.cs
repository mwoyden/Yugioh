using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class DarkMagician : MonsterCard
    {
        public DarkMagician(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.darkMagician;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Dark Magician";
            attack = 2500;
            defense = 2100;
            effect = false;
            stars = 7;
            cardText = "The ultimate wizard in terms of attack and defense.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.SPELLCASTER;
            attribute = MonsterAttribute.DARK;
        }
    }
}
