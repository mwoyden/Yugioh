using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MagicCards.Cards
{
    class ChangeOfHeart : MagicCard
    {
        public ChangeOfHeart(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.changeOfHeart;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Change Of Heart";
            cardText = "Target 1 monster your opponent controls; take control of it until the End Phase.";
            magicType = MagicType.NORMAL;
        }
    }
}
