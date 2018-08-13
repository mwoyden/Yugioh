using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class BaronOfTheFiendSword : MonsterCard
    {
        public BaronOfTheFiendSword(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.baronOfTheFiendSword;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Baron of the Fiend Sword";
            attack = 1550;
            defense = 800;
            effect = false;
            stars = 4;
            cardText = "An aristocrat who wields a sword possessed by a malicious spirit that preys on the weak.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.FIEND;
            attribute = MonsterAttribute.DARK;
        }
    }
}
