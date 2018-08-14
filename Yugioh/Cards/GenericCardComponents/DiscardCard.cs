using Yugioh.GameComponents;

namespace Yugioh.Cards.GenericCardComponents
{
    class DiscardCard : Card
    {
        public static new void Apply(Player player, Field field, Card card, int index = 0)
        {
            // Apply to field and player
            player.Discard(card);
            field.graveYard.Add(card);
        }
    }
}
