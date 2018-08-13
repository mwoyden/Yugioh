using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class ClawReacher : MonsterCard
    {
        public ClawReacher(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.clawReacher;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Claw Reacher";
            attack = 1000;
            defense = 800;
            effect = false;
            stars = 3;
            cardText = "Stretching arms and razor-sharp claws make this monster a formidable opponent.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.FIEND;
            attribute = MonsterAttribute.DARK;
        }
    }
}
