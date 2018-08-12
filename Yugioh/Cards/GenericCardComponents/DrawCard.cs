using Yugioh.GameComponents;

namespace Yugioh.Cards.GenericCardComponents
{
    class DrawCard : Card
    {
        public new void Apply(Player player)
        {
            player.Draw(this);
        }

        public new void Apply(Field field)
        {
            field.deck.Remove(this);
        }

        public new void Apply(Card card)
        {
            // nothing
        }
    }
}
