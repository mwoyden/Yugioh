using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MagicCards.Cards
{
    class CardDestruction : MagicCard
    {
        public CardDestruction(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.cardDestruction;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Card Destruction";
            cardText = "Each player discards their entire hand, then draws the same number of cards they discarded.";
            magicType = MagicType.NORMAL;
        }
    }
}
