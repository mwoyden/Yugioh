using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MagicCards
{
    class LastWill : MagicCard
    {
        public LastWill(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.lastWill;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Last Will";
            cardText = "If a monster on your side of the field was sent to your Graveyard this turn, you can Special Summon 1 monster with an ATK of 1500 points or less from your Deck once during this turn. Then shuffle your Deck.";
            magicType = MagicType.NORMAL;
        }
    }
}
