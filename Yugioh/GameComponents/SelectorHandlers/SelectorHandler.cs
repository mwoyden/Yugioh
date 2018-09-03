using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Yugioh.Cards;

namespace Yugioh.GameComponents.SelectorHandlers
{
    abstract class SelectorHandler
    {
        // Selector constants
        public static readonly List<Vector2> selectorPositions = new List<Vector2>()
        {
            new Vector2(810, 696), //[0]
            new Vector2(960, 696), //[1]
            new Vector2(810, 726), //[2]
        };

        public void HandleInZone(PositionController c)
        {
            // Handles setting the selected card in the zone
            if (c.activeZone[c.selector.index].sprite == null)
                c.selector.defaultPosition = c.activeZonePositions[c.selector.index];
            c.selector.selected = c.activeZone[c.selector.index];

            // Handles up and down
            HandleUpAndDown(c);
        }

        public void HandleLeftRightWithMaxIndex(Selector selector, KeyboardState state, KeyboardState previousState, int max)
        {
            if (state.IsKeyDown(Keys.Right) && previousState.IsKeyUp(Keys.Right))
            {
                if (selector.index == max)
                    selector.index = 0;
                else
                    selector.index++;
            }
            else if (state.IsKeyDown(Keys.Left) && previousState.IsKeyUp(Keys.Left))
            {
                if (selector.index == 0)
                    selector.index = max;
                else
                    selector.index--;
            }
        }

        public void HandleLeftRightWithFieldZone(Selector selector, KeyboardState state, KeyboardState previousState)
        {
            if (state.IsKeyDown(Keys.Right) && previousState.IsKeyUp(Keys.Right))
            {
                if (selector.index == 4)
                    selector.state = SelectedState.P1_FIELD_ZONE;
                else
                    selector.index++;
            }
            else if (state.IsKeyDown(Keys.Left) && previousState.IsKeyUp(Keys.Left))
            {
                if (selector.index == 0)
                    selector.state = SelectedState.P1_FIELD_ZONE;
                else
                    selector.index--;
            }
        }

        public void HandleUpAndDown(PositionController c)
        {
            // logic here to make navigating more natural (move to closest index in up/down zone
            if (c.state.IsKeyDown(Keys.Up) && c.previousState.IsKeyUp(Keys.Up))
            {
                c.selector.state = c.toUpArea;
                c.selector.index = FindClosestIndex(c.selector.index, c.toUpZone);
                c.selector.selected = c.toUpZone[c.selector.index];
                c.selector.defaultPosition = c.defaultUpPositions[c.selector.index];
            }
            else if (c.state.IsKeyDown(Keys.Down) && c.previousState.IsKeyUp(Keys.Down))
            {
                c.selector.state = c.toDownArea;
                c.selector.index = FindClosestIndex(c.selector.index, c.toDownZone);
                c.selector.selected = c.toDownZone[c.selector.index];
                c.selector.defaultPosition = c.defaultDownPositions[c.selector.index];
            }
        }

        public void HandlePhaseTransitions(Player p1)
        {
            if (p1.currentPhase.Equals(Phase.BATTLE))
                p1.currentPhase = Phase.MAIN_2;
        }

        // Helper method to make transitioning through zones much smoother
        private int FindClosestIndex(int selectorIndex, List <Card> toZone)
        {
            if (selectorIndex >= toZone.Count)
                return toZone.Count - 1;
            return selectorIndex;
        }

        // Used for readability in HandleUpAndDown (switching zones)
        internal class PositionController
        {
            public Selector selector;
            public List<Card> activeZone;
            public List<Vector2> activeZonePositions;
            public SelectedState toUpArea;
            public SelectedState toDownArea;
            public List<Card> toUpZone;
            public List<Card> toDownZone;
            public List<Vector2> defaultUpPositions;
            public List<Vector2> defaultDownPositions;
            public KeyboardState state;
            public KeyboardState previousState;

            internal class Builder
            {
                public PositionController controller = new PositionController();

                public Builder WithSelector(Selector selector)
                {
                    controller.selector = selector;
                    return this;
                }

                public Builder WithActiveZone(List<Card> activeZone)
                {
                    controller.activeZone = activeZone;
                    return this;
                }

                public Builder WithActiveZonePositions(List<Vector2> activeZonePositions)
                {
                    controller.activeZonePositions = activeZonePositions;
                    return this;
                }

                public Builder WithUpArea(SelectedState toUpArea)
                {
                    controller.toUpArea = toUpArea;
                    return this;
                }

                public Builder WithDownArea(SelectedState toDownArea)
                {
                    controller.toDownArea = toDownArea;
                    return this;
                }

                public Builder WithUpZone(List<Card> toUpZone)
                {
                    controller.toUpZone = toUpZone;
                    return this;
                }

                public Builder WithDownZone(List<Card> toDownZone)
                {
                    controller.toDownZone = toDownZone;
                    return this;
                }

                public Builder WithUpPositions(List<Vector2> upPositions)
                {
                    controller.defaultUpPositions = upPositions;
                    return this;
                }

                public Builder WithDownPositions(List<Vector2> downPositions)
                {
                    controller.defaultDownPositions = downPositions;
                    return this;
                }

                public Builder WithCurrentState(KeyboardState state)
                {
                    controller.state = state;
                    return this;
                }

                public Builder WithPreviousState(KeyboardState previousState)
                {
                    controller.previousState = previousState;
                    return this;
                }

                public PositionController Build()
                {
                    return this.controller;
                }
            }
        }
    }
}
