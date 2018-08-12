using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MagicCards
{
    class SoulExchange : MagicCard
    {
        public SoulExchange(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.soulExchange;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Soul Exchange";
            cardText = "Target 1 monster your opponent controls; this turn, if you Tribute a monster, you must Tribute that monster, as if you controlled it. You cannot conduct your Battle Phase the turn you activate this card.";
            magicType = MagicType.NORMAL;
        }
    }
}
