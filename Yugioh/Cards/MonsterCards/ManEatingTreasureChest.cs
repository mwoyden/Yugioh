using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class ManEatingTreasureChest : MonsterCard
    {
        public ManEatingTreasureChest(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.manEatingTreasureChest;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Man-Eating Treasure Chest";
            attack = 1600;
            defense = 1000;
            effect = false;
            stars = 4;
            cardText = "A monster disguised as a treasure chest that is known to attack the unwary adventurer.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.FIEND;
            attribute = MonsterAttribute.DARK;
        }
    }
}
