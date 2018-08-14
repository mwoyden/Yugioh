using Yugioh.GameComponents;
using Yugioh.Cards.CardProperties;
using System;

namespace Yugioh.Cards.MonsterCardComponents
{
    class Summon : MonsterCard
    {
        public static new void Apply(Player player, Field field, MonsterCard card, int index)
        {
            bool canSummon = true;

            // Check for field space
            if (field.monsterZone[index].sprite != null)
                return;

            // Order of application here is important.
            // Apply to player
            canSummon = player.Play(card);
            if (!canSummon)
                return;

            // Apply to card BEFORE summoning to field.
            card.mode = MonsterPosition.ATTACK;

            // Apply to field
            field.monsterZone.RemoveAt(index);
            field.monsterZone.Insert(index, card);
        }
    }
}
