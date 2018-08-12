using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Yugioh.Cards;
using Yugioh.Cards.CardProperties;
using Yugioh.Cards.MonsterCardComponents;

namespace Yugioh.GameComponents
{
    /// <summary>
    /// Player class that defines properties that all players must have.
    /// </summary>
    abstract class Player
    {
        public String name;
        public int lifePoints = 8000;
        public List<Card> hand = new List<Card>();
        public List<MonsterCard> sacrificed = new List<MonsterCard>();

        public void Draw(Card card)
        {
            hand.Add(card);
        }

        public void Discard(Card card)
        {
            hand.Remove(card);
        }

        /// <summary>
        /// Play method for summoning/setting monster cards.
        /// </summary>
        /// <param name="monster">Monster card to summon/set.</param>
        public void Play(MonsterCard monster)
        {
            if (monster.stars <= 4)
                if (hand.Remove(monster))
                    return;
                else
                    throw new FieldAccessException("Cannot summon " + monster.name);
            else
                Console.WriteLine("Not enough sacrifices!");
        }

        /// <summary>
        /// Play method for magic and trap cards.
        /// </summary>
        /// <param name="card">Magic or Trap card to play.</param>
        public void Play(Card card)
        {
            hand.Remove(card);
        }

        public void Sacrifice(MonsterCard monster)
        {
            sacrificed.Add(monster);
        }
    }
}
