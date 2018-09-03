using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MagicCards.Cards
{
    class Fissure : MagicCard
    {
        public Fissure(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.fissure;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Fissure";
            cardText = "Destroy the 1 face-up monster your opponent controls that has the lowest ATK. (If it's a tie, you get to choose.)";
            magicType = MagicType.NORMAL;
        }
    }
}
