using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MagicCards.Cards
{
    class DeSpell : MagicCard
    {
        public DeSpell(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.deSpell;
            position = new Vector2(0, 0);

            // Card attributes
            name = "De-Spell";
            cardText = "Select 1 Spell Card on the field and destroy it. If the selected card is Set, pick up and see the card. If it is a Spell Card, it is destroyed. If it is a Trap Card, return it to its original position.";
            magicType = MagicType.NORMAL;
        }
    }
}
