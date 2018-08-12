using Yugioh.GameComponents;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCardComponents
{
    class Sacrifice : MonsterCard
    {
        public new void Apply(Player player)
        {
            player.Sacrifice(this);
        }

        public new void Apply(Field field)
        {
            field.monsterZone.Remove(this);
            field.graveYard.Add(this);
        }

        public new void Apply(MonsterCard monster)
        {
            monster.mode = MonsterPosition.NONE;
        }
    }
}
