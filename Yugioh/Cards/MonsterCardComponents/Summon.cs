using Yugioh.GameComponents;
using Yugioh.Cards.CardProperties;
using System;

namespace Yugioh.Cards.MonsterCardComponents
{
    class Summon : MonsterCard
    {
        public new void Apply(Player player)
        {
            player.Play(this);
        }

        public new void Apply(Field field)
        {
            if (field.monsterZone.Count < 5)
                field.monsterZone.Add(this);
            else
                Console.WriteLine("Already 5 monsters on the field.");
        }

        public new void Apply(MonsterCard monster)
        {
            monster.mode = MonsterPosition.ATTACK;
        }
    }
}
