using Yugioh.GameComponents;
using Yugioh.Cards.CardProperties;
using System;

namespace Yugioh.Cards.MonsterCardComponents
{
    class Summon : MonsterCard
    {
        public static new void Apply(Player player, Field field, MonsterCard card)
        {
            bool canSummon = true;

            // Order of application here is important.
            // Apply to player
            canSummon = player.Play(card);
            if (!canSummon)
                return;

            // Apply to card BEFORE summoning to field.
            card.mode = MonsterPosition.ATTACK;

            // Apply to field
            // Check for full monster zone
            int count = 0;
            foreach (Card c in field.monsterZone)
                if (c.sprite != null)
                    count++;
            if (count == 5)
            {
                canSummon = false;
                throw new Exception("Shouldn't be summoning cards fren");
            }
            // Inadequate field space
            if (!canSummon)
            {
                player.Draw(card); // Reverse summon in case of failure
                return;
            }

            // If it's not full, summon at leftmost position (can't fail?)
            for (int i = 0; i < 5; i++)
            {
                if (field.monsterZone[i].sprite == null)
                {
                    field.monsterZone.RemoveAt(i);
                    field.monsterZone.Insert(i, card);
                    break;
                }
            }
        }
    }
}
