using Yugioh.GameComponents;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCardComponents
{
    class Sacrifice : MonsterCard
    {
        public static new void Apply(Player player, Field field, MonsterCard card, int index)
        {
            // Apply to field
            field.monsterZone.RemoveAt(index);
            field.monsterZone.Insert(index, new Card());
            field.graveYard.Add(card);

            // Apply to player
            player.Sacrifice(card);

            // Apply to monster
            card.mode = MonsterPosition.NONE;
        }
    }
}
