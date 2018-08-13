using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class CurseOfDragon : MonsterCard
    {
        public CurseOfDragon(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.curseOfDragon;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Curse of Dragon";
            attack = 2000;
            defense = 1500;
            effect = false;
            stars = 5;
            cardText = "A wicked dragon that taps into dark forces to execute a powerful attack.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.DRAGON;
            attribute = MonsterAttribute.DARK;
        }
    }
}
