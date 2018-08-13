using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class DragonZombie : MonsterCard
    {
        public DragonZombie(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.dragonZombie;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Dragon Zombie";
            attack = 1500;
            defense = 0;
            effect = false;
            stars = 3;
            cardText = "A dragon revived by sorcery. Its breath is highly corrosive.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.ZOMBIE;
            attribute = MonsterAttribute.DARK;
        }
    }
}
