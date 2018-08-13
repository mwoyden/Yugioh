using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class MysticClown : MonsterCard
    {
        public MysticClown(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.mysticClown;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Mystic Clown";
            attack = 1500;
            defense = 1000;
            effect = false;
            stars = 4;
            cardText = "Nothing can stop the mad attack of this powerful creature.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.FIEND;
            attribute = MonsterAttribute.DARK;
        }
    }
}
