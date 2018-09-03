using Yugioh.GameComponents;

namespace Yugioh.Cards.MagicCards.Effects
{
    class DarkHoleEffect : MagicEffect
    {
        public void Activate(Player p1, Player p2, Field p1Field, Field p2Field)
        {
            Destroy(p1Field);
            Destroy(p2Field);
        }

        public void Destroy(Field field)
        {
            for (int i = 0; i < field.monsterZone.Count; i++)
            {
                if (field.monsterZone[i] is MonsterCard && !field.monsterZone[i].notAffectByMagicCards)
                {
                    field.graveYard.Add(field.monsterZone[i]);
                    field.monsterZone[i] = new Card();
                }
            }
        }
    }
}
