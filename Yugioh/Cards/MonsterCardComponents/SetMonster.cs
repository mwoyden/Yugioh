using Yugioh.GameComponents;
using Yugioh.Cards.CardProperties;
using System;

namespace Yugioh.Cards.MonsterCardComponents
{
    class SetMonster : MonsterCard
    {
        public static new void Apply(Player player, Field field, MonsterCard card)
        {
            bool canSet = true;

            // Order of application here is important!!!!
            // Apply to player
            canSet = player.Play(card);
            if (!canSet)
                return;

            // Apply to card BEFORE setting to field.
            card.mode = MonsterPosition.FACE_DOWN_DEFENSE;

            // Apply to field
            // Check for full monster zone
            int count = 0;
            foreach (Card c in field.monsterZone)
                if (c.sprite != null)
                    count++;
            if (count == 5)
            {
                canSet = false;
                throw new Exception("Shouldn't be summoning cards fren");
            }
            // Adequate field space?
            if (!canSet)
            {
                player.Draw(card); // Reverse set in case of failure
                return;
            }

            // If it's not full, set at leftmost position
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
