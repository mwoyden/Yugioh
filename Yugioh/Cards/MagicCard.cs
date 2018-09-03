using Yugioh.Cards.CardProperties;
using Yugioh.Cards.MagicCards;
using Yugioh.Cards.MagicCards.Effects;
using Yugioh.GameComponents;

namespace Yugioh.Cards
{
    abstract class MagicCard : Card
    {
        // Magic Card properties
        public MagicType magicType = MagicType.NONE;
        public bool activated = false;
        public MagicEffect effect = null;
    }
}
