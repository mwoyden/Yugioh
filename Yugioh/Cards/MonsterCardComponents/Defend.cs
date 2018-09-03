using Yugioh.Cards.CardProperties;
using Yugioh.GameComponents;

namespace Yugioh.Cards.MonsterCardComponents
{
    class Defend : MonsterCard
    {
        public static new void Apply(Player player, Field field, MonsterCard card, int index = 0)
        {
            // Apply to monster
            if (card.canChangePosition) // Maybe this logic should be somewhere else?
                card.mode = MonsterPosition.DEFENSE;
        }
    }
}
