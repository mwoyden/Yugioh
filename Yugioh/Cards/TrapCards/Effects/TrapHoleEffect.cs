using Yugioh.Cards.MonsterCards;
using Yugioh.GameComponents;

namespace Yugioh.Cards.TrapCards.Effects
{
    class TrapHoleEffect : ITrapEffect
    {
        public void Activate(Player trapHolder, Player trapped, Field trapField, Field trappedField, int index)
        {
            trappedField.graveYard.Add(trappedField.monsterZone[index]);
            trappedField.monsterZone[index] = new Card();
        }
    }
}
