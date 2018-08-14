using Microsoft.Xna.Framework.Input;

namespace Yugioh.GameComponents.SelectorHandlers
{
    class HandleInP1MagicAndTrapZone : SelectorHandler, ISelectorHandler
    {
        public void Handle(Selector selector, Player p1, Player p2, Field p1Field, Field p2Field,
            KeyboardState state, KeyboardState previousState)
        {            
            // Handles left and right
            HandleLeftRightWithMaxIndex(selector, state, previousState, 4);
            // Handles all necessary actions in the given zone (including up and down)
            HandleInZone(selector, p1Field.magicAndTrapZone, p1Field.magicAndTrapPositions, SelectedState.P1_MONSTER_ZONE, SelectedState.P1_HAND, 
                p1Field.monsterZone, p1.hand, p1Field.monsterPositions, p1.handPositions, state, previousState);
        }
    }
}
