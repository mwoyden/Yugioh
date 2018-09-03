using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;
using Yugioh.Cards.MagicCards.Effects;

namespace Yugioh.Cards.MagicCards.Cards
{
    class DarkHole : MagicCard
    {
        public DarkHole(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.darkHole;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Dark Hole";
            cardText = "Destroy all monsters on the field.";
            magicType = MagicType.NORMAL;
            effect = new DarkHoleEffect();
        }
    }
}
