using Microsoft.Xna.Framework.Input;

namespace Yugioh.GameComponents.SelectorHandlers
{
    class HandleInP1FieldZone : SelectorHandler, ISelectorHandler
    {
        public void Handle(Selector selector, Player p1, Player p2, Field p1Field, Field p2Field,
            KeyboardState state, KeyboardState previousState)
        {
            if (state.IsKeyDown(Keys.Left) && previousState.IsKeyUp(Keys.Left))
            {
                selector.state = SelectedState.P1_MONSTER_ZONE;
                selector.index = 4;
            }
            else if (state.IsKeyDown(Keys.Right) && previousState.IsKeyUp(Keys.Right))
            {
                selector.state = SelectedState.P1_MONSTER_ZONE;
                selector.index = 0;
            }
            if (p1Field.fieldZone.sprite == null)
                selector.defaultPosition = p1Field.fieldCardPosition;
            selector.selected = p1Field.fieldZone;
        }
    }
}
