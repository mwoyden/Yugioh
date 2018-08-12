using Microsoft.Xna.Framework;

using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MagicCards
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
        }
    }
}
