using Yugioh.GameComponents;

namespace Yugioh.Cards.GenericCardComponents
{
    class DrawCard : Card
    {
        public static new void Apply(Player player, Field field, Card card = null)
        {
            // Apply to field and player
            if (field.deck.Count == 0)
                return;
            player.Draw(field.deck[0]);
            field.deck.RemoveAt(0);
        }
    }
}
