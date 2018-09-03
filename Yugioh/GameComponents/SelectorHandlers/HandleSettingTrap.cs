using Microsoft.Xna.Framework.Input;
using Yugioh.Cards.TrapCards;

namespace Yugioh.GameComponents.SelectorHandlers
{
    class HandleSettingTrap : SelectorHandler, ISelectorHandler
    {       
        // Basically trap and magic are the same, still looking for differences
        public void Handle(Selector selector, Player p1, Player p2, Field p1Field, Field p2Field,
            KeyboardState state, KeyboardState previousState)
        {           
            // Handles left and right
            HandleLeftRightWithMaxIndex(selector, state, previousState, 4);
            if (p1Field.magicAndTrapZone[selector.index].sprite == null)
                selector.defaultPosition = p1Field.magicAndTrapPositions[selector.index];
            selector.selected = p1Field.magicAndTrapZone[selector.index];

            // Handle setting
            if (state.IsKeyDown(Keys.Enter) && previousState.IsKeyUp(Keys.Enter))
            {
                selector.state = SelectedState.P1_MAGIC_AND_TRAP_ZONE;
                selector.selected = p1Field.magicAndTrapZone[selector.index];
                SetTrap.Apply(p1, p1Field, selector.settingTrap, selector.index);
                selector.settingTrap = null;
            }
            else if (state.IsKeyDown(Keys.Back) && previousState.IsKeyUp(Keys.Back))
            {
                selector.state = SelectedState.P1_HAND;
                selector.action = SelectedAction.NONE;
                selector.index = p1.hand.IndexOf(selector.settingTrap);
                selector.selected = selector.settingTrap;
                selector.settingTrap = null;
            }
        }
    }
}
