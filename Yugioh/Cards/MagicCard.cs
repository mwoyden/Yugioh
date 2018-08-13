using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards
{
    abstract class MagicCard : Card
    {
        // Magic Card properties
        public MagicType magicType = MagicType.NONE;
        public bool activated = false;

        public void Apply(MagicCard card)
        {
            // nothing
        }
    }
}
