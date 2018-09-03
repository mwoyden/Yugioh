using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MagicCards.Cards
{
    class DianKetoTheCureMaster : MagicCard
    {
        public DianKetoTheCureMaster(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.dianKetoTheCureMaster;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Dian Keto The Cure Master";
            cardText = "Increase your Life Points by 1000 points.";
            magicType = MagicType.NORMAL;
        }
    }
}
