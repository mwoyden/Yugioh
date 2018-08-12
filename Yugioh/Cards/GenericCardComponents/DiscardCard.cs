using Yugioh.GameComponents;

namespace Yugioh.Cards.GenericCardComponents
{
    class DiscardCard : Card
    {
        public new void Apply(Player player)
        {
            player.Discard(this);
        }

        public new void Apply(Field field)
        {
            field.graveYard.Add(this);
        }

        public new void Apply(Card card)
        {
            // nothing
        }
    }
}
