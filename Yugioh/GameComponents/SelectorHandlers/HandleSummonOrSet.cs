using Microsoft.Xna.Framework.Input;

namespace Yugioh.GameComponents.SelectorHandlers
{
    class HandleSummonOrSet : SelectorHandler, ISelectorHandler
    {
        public void Handle(Selector selector, Player p1, Player p2, Field p1Field, Field p2Field,
            KeyboardState state, KeyboardState previousState)
        {
            if (state.IsKeyDown(Keys.Right) && previousState.IsKeyUp(Keys.Right))
            {
                selector.action = SelectedAction.SET;
                selector.defaultPosition = selectorPositions[1];
            }
            else if (state.IsKeyDown(Keys.Left) && previousState.IsKeyUp(Keys.Left))
            {
                selector.action = SelectedAction.SUMMON;
                selector.defaultPosition = selectorPositions[0];
            }
            //else if (up or down do nothing rn)

            // Select Action
            if (state.IsKeyDown(Keys.Enter) && previousState.IsKeyUp(Keys.Enter) && p1.canNormalSummon)
            {
                if (selector.action.Equals(SelectedAction.SUMMON))
                    selector.state = SelectedState.SUMMONING;
                else if (selector.action.Equals(SelectedAction.SET))
                    selector.state = SelectedState.SETTING_MONSTER;

                selector.selected = p1Field.monsterZone[0];
                selector.defaultPosition = p1Field.monsterPositions[0];
            }
            else if (state.IsKeyDown(Keys.Back) && previousState.IsKeyUp(Keys.Back))
            {
                selector.state = SelectedState.P1_HAND;
                selector.action = SelectedAction.NONE;
                selector.index = p1.hand.IndexOf(selector.summoning);
                selector.selected = selector.summoning;
                selector.summoning = null;
            }
        }
    }
}
