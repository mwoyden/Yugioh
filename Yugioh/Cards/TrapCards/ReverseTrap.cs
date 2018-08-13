using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.TrapCards
{
    class ReverseTrap : TrapCard
    {
        public ReverseTrap(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.reverseTrap;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Reverse Trap";
            cardText = "All increases and decreases to ATK and DEF are reversed for the turn in which this card is activated.";
            trapType = TrapType.NORMAL;
        }
    }
}
