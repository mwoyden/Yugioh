﻿using Microsoft.Xna.Framework.Input;
using Yugioh.Cards;

namespace Yugioh.GameComponents.SelectorHandlers
{
    class HandleInP1MonsterZone : SelectorHandler, ISelectorHandler
    {
        public void Handle(Selector selector, Player p1, Player p2, Field p1Field, Field p2Field,
            KeyboardState state, KeyboardState previousState)
        {
            // Handles left and right (DO I WANT THIS??? vv)
            //HandleLeftRightWithFieldZone(selector, state, previousState);
            // Instead of this vv
            // Handles left and right
            HandleLeftRightWithMaxIndex(selector, state, previousState, 4);
            if (p1Field.monsterZone[selector.index].sprite == null)
                selector.defaultPosition = p1Field.monsterPositions[selector.index];
            selector.selected = p1Field.monsterZone[selector.index];

            // Handles all necessary actions in the given zone (including up and down)
            PositionController.Builder builder = new PositionController.Builder();
            PositionController controller = builder.WithSelector(selector)
                .WithActiveZone(p1Field.monsterZone)
                .WithActiveZonePositions(p1Field.monsterPositions)
                .WithUpArea(SelectedState.P2_MONSTER_ZONE)
                .WithUpZone(p2Field.monsterZone)
                .WithUpPositions(p2Field.monsterPositions)
                .WithDownArea(SelectedState.P1_MAGIC_AND_TRAP_ZONE)
                .WithDownZone(p1Field.magicAndTrapZone)
                .WithDownPositions(p1Field.magicAndTrapPositions)
                .WithCurrentState(state)
                .WithPreviousState(previousState)
                .Build();
            HandleInZone(controller);

            // Handle Battle decisions
            if (state.IsKeyDown(Keys.Enter) && previousState.IsKeyUp(Keys.Enter) && selector.selected.sprite != null)
            {
                selector.state = SelectedState.BATTLE_SELECT;
                selector.action = SelectedAction.ATTACK;
                selector.selected = (MonsterCard)selector.selected;
                selector.defaultPosition = selectorPositions[0];
            }
        }
    }
}
