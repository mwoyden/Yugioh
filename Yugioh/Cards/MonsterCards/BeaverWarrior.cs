using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class BeaverWarrior : MonsterCard
    {
        public BeaverWarrior(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.beaverWarrior;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Beaver Warrior";
            attack = 1200;
            defense = 1500;
            effect = false;
            stars = 4;
            cardText = "What this creature lacks in size it makes up for in defense when battling in the prairie.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.BEAST_WARRIOR;
            attribute = MonsterAttribute.EARTH;
        }
    }
}
