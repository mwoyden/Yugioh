using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards
{
    abstract class TrapCard : Card
    {
        // Trap Card properties
        public TrapType trapType = TrapType.NONE;
        public bool activated = false;

        public void Apply(TrapCard card)
        {
            // nothing
        }
    }
}
