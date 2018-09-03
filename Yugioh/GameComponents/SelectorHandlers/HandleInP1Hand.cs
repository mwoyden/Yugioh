using Microsoft.Xna.Framework.Input;
using Yugioh.Cards;

namespace Yugioh.GameComponents.SelectorHandlers
{
    class HandleInP1Hand : SelectorHandler, ISelectorHandler
    {
        public void Handle(Selector selector, Player p1, Player p2, Field p1Field, Field p2Field,
            KeyboardState state, KeyboardState previousState)
        {
            // Handles left and right
            HandleLeftRightWithMaxIndex(selector, state, previousState, 6);
            if (p1.hand[selector.index].sprite == null)
                selector.defaultPosition = p1.handPositions[selector.index];
            selector.selected = p1.hand[selector.index];

            // Handles up and down
            PositionController.Builder builder = new PositionController.Builder();
            PositionController controller = builder.WithSelector(selector)
                .WithUpArea(SelectedState.P1_MAGIC_AND_TRAP_ZONE)
                .WithUpZone(p1Field.magicAndTrapZone)
                .WithUpPositions(p1Field.magicAndTrapPositions)
                .WithDownArea(SelectedState.P2_MAGIC_AND_TRAP_ZONE)
                .WithDownZone(p2Field.magicAndTrapZone)
                .WithDownPositions(p2Field.magicAndTrapPositions)
                .WithCurrentState(state)
                .WithPreviousState(previousState)
                .Build();
            HandleUpAndDown(controller);

            // Handles actions
            if (state.IsKeyDown(Keys.Enter) && previousState.IsKeyUp(Keys.Enter))
            {
                if (selector.selected is MonsterCard)
                {
                    selector.state = SelectedState.SUMMON_OR_SET;
                    selector.action = SelectedAction.SUMMON;
                    selector.summoning = (MonsterCard)selector.selected;
                    selector.index = 0;
                    selector.defaultPosition = selectorPositions[0];
                }
                else if (selector.selected is MagicCard)
                {
                    selector.state = SelectedState.SET_OR_ACTIVATE;
                    selector.action = SelectedAction.SET;
                    selector.settingMagic = (MagicCard)selector.selected;
                    selector.index = 0;
                    selector.defaultPosition = selectorPositions[0];
                }
                else if (selector.selected is TrapCard)
                {
                    selector.state = SelectedState.SETTING_TRAP;
                    selector.settingTrap = (TrapCard)selector.selected;
                    selector.index = 0;
                    selector.selected = p1Field.magicAndTrapZone[0];
                    selector.defaultPosition = p1Field.magicAndTrapPositions[0];
                }
            }
        }
    }
}
