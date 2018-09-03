using Microsoft.Xna.Framework.Input;
using Yugioh.Cards.MagicCards;

namespace Yugioh.GameComponents.SelectorHandlers
{
    class HandleSettingMagic : SelectorHandler, ISelectorHandler
    {
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
                SetMagic.Apply(p1, p1Field, selector.settingMagic, selector.index);
                selector.settingMagic = null;
                HandlePhaseTransitions(p1); // Moves phase to Main 2 if in battle phase
            }
            else if (state.IsKeyDown(Keys.Back) && previousState.IsKeyUp(Keys.Back))
            {
                selector.state = SelectedState.SET_OR_ACTIVATE;
                selector.action = SelectedAction.SET;
                selector.selected = selector.settingMagic;
                selector.index = 0;
                selector.defaultPosition = selectorPositions[0];
            }
        }
    }
}
