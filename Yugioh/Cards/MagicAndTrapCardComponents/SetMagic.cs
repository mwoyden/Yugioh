using System;
using Yugioh.GameComponents;

namespace Yugioh.Cards.MagicAndTrapCardComponents
{
    class SetMagic : MagicCard
    {
        public new void Apply(Player player)
        {
            player.Play(this);
        }

        public new void Apply(Field field)
        {
            if (field.magicAndTrapZone.Count < 5)
                field.magicAndTrapZone.Add(this);
            else
                Console.WriteLine("Already 5 Magic or Trap cards in play.");
        }

        public new void Apply(MagicCard card)
        {
            card.activated = false;
        }
    }
}
