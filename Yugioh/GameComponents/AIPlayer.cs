using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Yugioh.Cards;

namespace Yugioh.GameComponents
{
    /// <summary>
    /// Extension of the Player class that represents an AI
    /// </summary>
    class AIPlayer : Player
    {
        public AIPlayer()
        {
            name = "Yugi";
            lifePoints = 8000;
            hand = new List<Card>()
            {
                new Card(),
                new Card(),
                new Card(),
                new Card(),
                new Card(),
                new Card(),
                new Card()
            };
            sacrificed = new List<MonsterCard>();
        }

        internal class Builder
        {
            public AIPlayer player = new AIPlayer();

            public Builder WithHandPositions(List<Vector2> positions)
            {
                player.handPositions = positions;
                return this;
            }

            public AIPlayer Build()
            {
                return this.player;
            }
        }
    }
}
