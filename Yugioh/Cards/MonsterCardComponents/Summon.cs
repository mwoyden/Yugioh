using Yugioh.GameComponents;
using Yugioh.Cards.CardProperties;
using System;
using System.Collections.Generic;

namespace Yugioh.Cards.MonsterCardComponents
{
    class Summon
    {
        public static void Apply(Player player, Field field, MonsterCard card, int index)
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
            if (card.stars > 4) // If monster was tribute summoned
                player.sacrificed = new List<MonsterCard>(); // Use up the sacrifices
            player.canNormalSummon = false;

            // Apply to card BEFORE summoning to field.
            card.mode = MonsterPosition.ATTACK;
            card.canChangePosition = false;

            // Apply to field
            field.monsterZone[index] = card;
        }
    }
}
