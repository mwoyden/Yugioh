using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class WallOfIllusion : MonsterCard
    {
        public WallOfIllusion(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.wallOfIllusion;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Wall of Illusion";
            attack = 1000;
            defense = 1850;
            effect = true;
            stars = 4;
            cardText = "A monster that attacks this monster is returned to its owner's hand after damage calculation. Damage calculation is applied normally.";
            monsterType = MonsterType.EFFECT;
            subType = MonsterSubType.FIEND;
            attribute = MonsterAttribute.DARK;
        }
    }
}
