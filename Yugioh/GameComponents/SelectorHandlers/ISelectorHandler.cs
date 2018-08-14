using Microsoft.Xna.Framework.Input;

namespace Yugioh.GameComponents.SelectorHandlers
{
    interface ISelectorHandler
    {
        void Handle(Selector selector, Player p1, Player p2, Field p1Field, Field p2Field,
            KeyboardState state, KeyboardState previousState);
    }
}
