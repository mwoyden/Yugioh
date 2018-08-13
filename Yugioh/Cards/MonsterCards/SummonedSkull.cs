using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class SummonedSkull : MonsterCard
    {
        public SummonedSkull(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.summonedSkull;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Summoned Skull";
            attack = 2500;
            defense = 1200;
            effect = false;
            stars = 6;
            cardText = "A fiend with dark powers for confusing the enemy. Among the Fiend-Type monsters, this monster boasts considerable force.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.FIEND;
            attribute = MonsterAttribute.DARK;
        }
    }
}
