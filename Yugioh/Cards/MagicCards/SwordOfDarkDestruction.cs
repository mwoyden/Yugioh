using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MagicCards
{
    class SwordOfDarkDestruction : MagicCard
    {
        public SwordOfDarkDestruction(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.swordOfDarkDestruction;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Ansatsu";
            cardText = "A Dark monster equipped with this card increases its ATK by 400 points and decreases its DEF by 200 points.";
            magicType = MagicType.EQUIP;
        }
    }
}
