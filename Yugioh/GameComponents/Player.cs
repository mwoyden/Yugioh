using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
    abstract class Player : IDrawable
    {
        // Actual player attributes
        public String name;
        public int lifePoints = 8000;
        public List<Card> hand = new List<Card>();
        public List<MonsterCard> sacrificed = new List<MonsterCard>();

        // Draw helper variables
        public List<Vector2> handPositions = new List<Vector2>(7);

        /// <summary>
        /// Pair each card in hand with its respective position on the screen and draw.
        /// https://stackoverflow.com/questions/1955766/iterate-two-lists-or-arrays-with-one-foreach-statement-in-c-sharp
        /// </summary>
        /// <param name="spriteBatch">Sprite drawer.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            var handWithPositions = hand.Zip(handPositions, (c, p) => new { Card = c, Position = p });
            foreach (var pair in handWithPositions)
            {
                if (pair.Card != null)
                {
                    pair.Card.position = pair.Position;
                    pair.Card.Draw(spriteBatch);
                }
            }
            // Above is equal to this vv
            //for (int i = 0; i < hand.Count; i++)
            //{
            //    hand[i].position = handPositions[i];
            //    hand[i].Draw(spriteBatch);
            //    throw new Exception();
            //}
        }

        public void Draw(Card card)
        {
            int count = 0;
            foreach (Card c in hand)
            {
                if (c.sprite != null)
                    count++;
            }
            if (count == 7)
                throw new Exception("Shouldn't be drawing cards fren");
            for (int i = 0; i < 7; i++)
            {
                if (hand[i].sprite == null)
                {
                    hand.Insert(i, card);
                    break;
                }
            }
            
            if (!hand.Contains(card))
                throw new EntryPointNotFoundException("Could not Draw card?");
        }

        public void Discard(Card card)
        {
            int index = hand.IndexOf(card);
            hand.RemoveAt(index);
            hand.Insert(index, new Card());
        }

        /// <summary>
        /// Play method for summoning/setting monster cards.
        /// </summary>
        /// <param name="monster">Monster card to summon/set.</param>
        public bool Play(MonsterCard monster)
        {
            int index = hand.IndexOf(monster);
            if (index == -1)
                throw new FieldAccessException("Cannot find " + monster.name + " in hand?");
            if (monster.stars <= 4)
                return Play(index);
            else if (monster.stars == 5 || monster.stars == 6)
            {
                if (sacrificed.Count >= 1)
                    return Play(index);
                else
                    return false; // not enough sacrifices
            }
            else if (monster.stars >= 7)
            {
                if (sacrificed.Count >= 2)
                    return Play(index);
                else
                    return false; // not enough sacrifices
            }
            if (hand.Contains(monster))
            {
                Console.WriteLine("Some shit happened, probably not enough sacrifices! " + sacrificed.Count);
                return false;
            }
            return false; // How'd we get here? idk.
        }

        private bool Play(int index)
        {
            hand.RemoveAt(index);
            hand.Insert(index, new Card());
            return true;
        }

        /// <summary>
        /// Play method for magic and trap cards.
        /// </summary>
        /// <param name="card">Magic or Trap card to play.</param>
        public bool Play(Card card)
        {
            int index = hand.IndexOf(card);
            if (index == -1)
                throw new FieldAccessException("Cannot find " + card.name + " in hand?");
            Play(index);
            return true;
        }

        public void Sacrifice(MonsterCard monster)
        {
            sacrificed.Add(monster);
        }
    }
}
