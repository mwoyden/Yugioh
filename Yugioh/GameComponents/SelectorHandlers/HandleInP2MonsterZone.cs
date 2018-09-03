using Microsoft.Xna.Framework.Input;
using Yugioh.Cards;

namespace Yugioh.GameComponents.SelectorHandlers
{
    class HandleInP2MonsterZone : SelectorHandler, ISelectorHandler
    {
        public void Handle(Selector selector, Player p1, Player p2, Field p1Field, Field p2Field,
            KeyboardState state, KeyboardState previousState)
        {
            // Handles left and right (DO I WANT THIS???)
            //HandleLeftRightWithFieldZone(selector, state, previousState);
            // Instead of this vv
            // Handles left and right
            HandleLeftRightWithMaxIndex(selector, state, previousState, 4);
            if (p2Field.monsterZone[selector.index].sprite == null)
                selector.defaultPosition = p2Field.monsterPositions[selector.index];
            selector.selected = p2Field.monsterZone[selector.index];

            // Handles all necessary actions in the given zone (including up and down)
            PositionController.Builder builder = new PositionController.Builder();
            PositionController controller = builder.WithSelector(selector)
                .WithActiveZone(p2Field.monsterZone)
                .WithActiveZonePositions(p2Field.monsterPositions)
                .WithUpArea(SelectedState.P2_MAGIC_AND_TRAP_ZONE)
                .WithUpZone(p2Field.magicAndTrapZone)
                .WithUpPositions(p2Field.magicAndTrapPositions)
                .WithDownArea(SelectedState.P1_MONSTER_ZONE)
                .WithDownZone(p1Field.monsterZone)
                .WithDownPositions(p1Field.monsterPositions)
                .WithCurrentState(state)
                .WithPreviousState(previousState)
                .Build();
            HandleInZone(controller);

            // Handle Battle decisions
            if (state.IsKeyDown(Keys.Enter) && previousState.IsKeyUp(Keys.Enter) && selector.selected.sprite != null)
            {
    
            }
        }
    }
}
