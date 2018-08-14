using Microsoft.Xna.Framework.Input;

namespace Yugioh.GameComponents.SelectorHandlers
{
    class HandleSetOrActivate : SelectorHandler, ISelectorHandler
    {
        public void Handle(Selector selector, Player p1, Player p2, Field p1Field, Field p2Field,
            KeyboardState state, KeyboardState previousState)
        {
            if (state.IsKeyDown(Keys.Right) && previousState.IsKeyUp(Keys.Right))
            {
                selector.action = SelectedAction.ACTIVATE;
                selector.defaultPosition = selectorPositions[1];
            }
            else if (state.IsKeyDown(Keys.Left) && previousState.IsKeyUp(Keys.Left))
            {
                selector.action = SelectedAction.SET;
                selector.defaultPosition = selectorPositions[0];
            }
            //else if (up or down do nothing rn)

            // Select Action
            if (state.IsKeyDown(Keys.Enter) && previousState.IsKeyUp(Keys.Enter))
            {
                if (selector.action.Equals(SelectedAction.SET))
                    selector.state = SelectedState.SETTING_MAGIC;
                else if (selector.action.Equals(SelectedAction.ACTIVATE))
                    // Activate card? hilarious behavior right now though lul

                    selector.selected = p1Field.magicAndTrapZone[0];
                selector.defaultPosition = p1Field.magicAndTrapPositions[0];
            }
        }
    }
}
