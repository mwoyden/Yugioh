using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MagicCards
{
    class BookOfSecretArts : MagicCard
    {
        public BookOfSecretArts(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.bookOfSecretArts;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Book of Secret Arts";
            cardText = "A Spellcaster-Type monster equipped with this card increases its ATK and DEF by 300 points.";
            magicType = MagicType.EQUIP;
        }
    }
}
