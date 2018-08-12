using Yugioh.GameComponents;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCardComponents
{
    class SetMonster : MonsterCard
    {
        public new void Apply(Player player)
        {
            player.Play(this);
        }

        public new void Apply(Field field)
        {
            field.monsterZone.Add(this);
        }

        public new void Apply(MonsterCard monster)
        {
            monster.mode = MonsterPosition.FACE_DOWN_DEFENSE;
        }
    }
}
