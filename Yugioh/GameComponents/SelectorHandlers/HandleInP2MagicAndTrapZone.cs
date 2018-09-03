using Microsoft.Xna.Framework.Input;

namespace Yugioh.GameComponents.SelectorHandlers
{
    class HandleInP2MagicAndTrapZone : SelectorHandler, ISelectorHandler
    {
        public void Handle(Selector selector, Player p1, Player p2, Field p1Field, Field p2Field,
            KeyboardState state, KeyboardState previousState)
        {            
            // Handles left and right
            HandleLeftRightWithMaxIndex(selector, state, previousState, 4);
            // Handles all necessary actions in the given zone (including up and down)
            PositionController.Builder builder = new PositionController.Builder();
            PositionController controller = builder.WithSelector(selector)
                .WithActiveZone(p2Field.magicAndTrapZone)
                .WithActiveZonePositions(p2Field.magicAndTrapPositions)
                .WithUpArea(SelectedState.P1_HAND)
                .WithUpZone(p1.hand)
                .WithUpPositions(p1.handPositions)
                .WithDownArea(SelectedState.P2_MONSTER_ZONE)
                .WithDownZone(p2Field.monsterZone)
                .WithDownPositions(p2Field.monsterPositions)
                .WithCurrentState(state)
                .WithPreviousState(previousState)
                .Build();
            HandleInZone(controller);
        }
    }
}
