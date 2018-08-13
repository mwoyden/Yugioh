using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class TrapMaster : MonsterCard
    {
        public TrapMaster(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.trapMaster;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Trap Master";
            attack = 500;
            defense = 1100;
            effect = true;
            stars = 3;
            cardText = "FLIP: Select 1 Trap Card on the field and destroy it. If the selected card is Set, pick up and see the card. If it is a Trap Card, it is destroyed. If it is a Spell Card, return it to its original position.";
            monsterType = MonsterType.FLIP_EFFECT;
            subType = MonsterSubType.WARRIOR;
            attribute = MonsterAttribute.EARTH;
        }
    }
}
