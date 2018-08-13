using System;
using Yugioh.GameComponents;

namespace Yugioh.Cards.MagicAndTrapCardComponents
{
    class SetMagic : MagicCard
    {
        public static new void Apply(Player player, Field field, Card card)
        {
            bool canSet = true;

            // Order of application here is important.
            // Apply to player
            canSet = player.Play(card);
            if (!canSet)
            {
                return;
            }

            // Apply to field
            // Check for full magic and trap zone
            int count = 0;
            foreach (Card c in field.magicAndTrapZone)
                if (c.sprite != null)
                    count++;
            if (count == 5)
            {
                canSet = false;
                throw new Exception("Shouldn't be setting cards fren");
            }
            // Adequate field space?
            if (!canSet)
            {
                player.Draw(card); // Reverse set in case of failure
                return;
            }

            // If it's not full, summon at leftmost position
            for (int i = 0; i < 5; i++)
            {
                if (field.magicAndTrapZone[i].sprite == null)
                {
                    field.magicAndTrapZone.RemoveAt(i);
                    field.magicAndTrapZone.Insert(i, card);
                    break;
                }
            }
        }
    }
}
