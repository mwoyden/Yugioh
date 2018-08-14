using Microsoft.Xna.Framework.Input;
using Yugioh.Cards.MagicAndTrapCardComponents;

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

            // Handle Summon
            if (state.IsKeyDown(Keys.Enter) && previousState.IsKeyUp(Keys.Enter))
            {
                // Should provide selector logic for summon/set HERE

                selector.state = SelectedState.P1_MAGIC_AND_TRAP_ZONE;
                selector.selected = p1Field.magicAndTrapZone[selector.index];
                SetMagic.Apply(p1, p1Field, selector.settingMagic, selector.index);
                selector.settingMagic = null;
            }
        }
    }
}
