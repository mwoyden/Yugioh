using Yugioh.GameComponents;

namespace Yugioh.Cards.TrapCards
{
    interface ITrapEffect
    {
        void Activate(Player p1, Player p2, Field p1Field, Field p2Field, int index);
    }
}
