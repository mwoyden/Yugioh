using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MagicCards.Cards
{
    class RemoveTrap : MagicCard
    {
        public RemoveTrap(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.removeTrap;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Remove Trap";
            cardText = "Destroys 1 face-up Trap Card on the field.";
            magicType = MagicType.NORMAL;
        }
    }
}
