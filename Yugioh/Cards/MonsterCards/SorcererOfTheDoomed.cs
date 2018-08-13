using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class SorcererOfTheDoomed : MonsterCard
    {
        public SorcererOfTheDoomed(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.sorcererOfTheDoomed;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Sorcerer Of The Doomer";
            attack = 1450;
            defense = 1200;
            effect = false;
            stars = 4;
            cardText = "A slave of the dark arts, this sorcerer is a master of death-dealing spells.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.SPELLCASTER;
            attribute = MonsterAttribute.DARK;
        }
    }
}
