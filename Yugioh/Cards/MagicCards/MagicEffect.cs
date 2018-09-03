using Yugioh.GameComponents;

namespace Yugioh.Cards.MagicCards
{
    interface MagicEffect
    {
        void Activate(Player p1, Player p2, Field p1Field, Field p2Field);
    }
}
