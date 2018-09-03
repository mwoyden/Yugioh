using System;
using Yugioh.GameComponents;

namespace Yugioh.Cards.MagicCards
{
    class SetMagic
    {
        public static void Apply(Player player, Field field, Card card, int index)
        {
            bool canSet = true;

            // Check for field space
            if (field.magicAndTrapZone[index].sprite != null)
                return;

            // Order of application here is important.
            // Apply to player
            canSet = player.Play(card);
            if (!canSet)
                return;

            // Apply to field
            field.magicAndTrapZone.RemoveAt(index);
            field.magicAndTrapZone.Insert(index, card);
        }
    }
}
