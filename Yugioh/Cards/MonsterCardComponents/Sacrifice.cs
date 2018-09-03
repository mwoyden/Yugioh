using Yugioh.GameComponents;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCardComponents
{
    class Sacrifice
    {
        public static void Apply(Player player, Field field, MonsterCard card, int index)
        {
            // Apply to field
            field.monsterZone[index] =  new Card();
            field.graveYard.Add(card);

            // Apply to monster
            card.mode = MonsterPosition.NONE;

            // Apply to player
            player.Sacrifice(card);
        }
    }
}
