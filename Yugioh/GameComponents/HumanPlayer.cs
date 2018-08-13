using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Yugioh.Cards;

namespace Yugioh.GameComponents
{
    /// <summary>
    /// Extension of the player class that represents you (or player 2?)
    /// </summary>
    class HumanPlayer : Player
    {
        public HumanPlayer()
        {
            name = "You";
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
            public HumanPlayer player = new HumanPlayer();

            public Builder WithHandPositions(List<Vector2> positions)
            {
                player.handPositions = positions;
                return this;
            }

            public HumanPlayer Build()
            {
                return this.player;
            }
        }
    }
}
