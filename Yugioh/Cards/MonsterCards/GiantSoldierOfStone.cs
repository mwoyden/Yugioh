using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class GiantSoldierOfStone : MonsterCard
    {
        public GiantSoldierOfStone(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.giantSoldierOfStone;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Giant Soldier Of Stone";
            attack = 1300;
            defense = 2000;
            effect = false;
            stars = 4;
            cardText = "A giant warrior made of stone. A punch from this creature has earth-shaking results.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.ROCK;
            attribute = MonsterAttribute.EARTH;
        }
    }
}
