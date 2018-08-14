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
            new Vector2(960, 696) //[1]
        };

        public void HandleInZone(Selector selector, List<Card> activeZone, List<Vector2> activeZonePositions,
                                SelectedState toUpArea, SelectedState toDownArea, List<Card> toUpZone, List<Card> toDownZone, 
                                List<Vector2> defaultUpPositions, List<Vector2> defaultDownPositions,
                                KeyboardState state, KeyboardState previousState)
        {
            // Handles setting the selected card in the zone
            if (activeZone[selector.index].sprite == null)
                selector.defaultPosition = activeZonePositions[selector.index];
            selector.selected = activeZone[selector.index];

            // Handles up and down
            HandleUpAndDown(selector, toUpArea, toUpZone, defaultUpPositions, toDownArea, toDownZone, defaultDownPositions, state, previousState);
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

        public void HandleUpAndDown(Selector selector, SelectedState toUpArea, List<Card> toUpZone, List<Vector2> defaultUpPositions,
                                                  SelectedState toDownArea, List<Card> toDownZone, List<Vector2> defaultDownPositions,
                                                  KeyboardState state, KeyboardState previousState)
        {
            // logic here to make navigating more natural (move to closest index in up/down zone
            if (state.IsKeyDown(Keys.Up) && previousState.IsKeyUp(Keys.Up))
            {
                selector.state = toUpArea;
                selector.index = FindClosestIndex(selector.index, toUpZone);
                selector.selected = toUpZone[selector.index];
                selector.defaultPosition = defaultUpPositions[selector.index];
            }
            else if (state.IsKeyDown(Keys.Down) && previousState.IsKeyUp(Keys.Down))
            {
                selector.state = toDownArea;
                selector.index = FindClosestIndex(selector.index, toDownZone);
                selector.selected = toDownZone[selector.index];
                selector.defaultPosition = defaultDownPositions[selector.index];
            }
        }

        // Helper method to make transitioning through zones much smoother
        private int FindClosestIndex(int selectorIndex, List <Card> toZone)
        {
            if (selectorIndex >= toZone.Count)
                return toZone.Count - 1;
            return selectorIndex;
        }
    }
}
