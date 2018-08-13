using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class AncientElf : MonsterCard
    {
        public AncientElf(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.ancientElf;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Ancient Elf";
            attack = 1450;
            defense = 1200;
            effect = false;
            stars = 4;
            cardText = "This elf is rumored to have lived for thousands of years. He leads an army of spirits against his enemies.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.SPELLCASTER;
            attribute = MonsterAttribute.LIGHT;
        }
    }
}
