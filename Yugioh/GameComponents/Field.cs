using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Yugioh.Cards;
using Yugioh.Cards.TrapCards;

namespace Yugioh.GameComponents
{
    class Field : IDrawable
    {
        // Actual field objects
        public List<Card> monsterZone;
        public List<Card> magicAndTrapZone;
        public List<Card> deck;
        public List<Card> graveYard;
        public List<Card> fusionDeck;
        public Card fieldZone;

        // Details for drawing the field
        public Card deckSprite;
        public Vector2 fieldCardPosition;
        public Vector2 graveYardPosition;
        public Vector2 fusionDeckPosition;
        public List<Vector2> monsterPositions = new List<Vector2>(5);
        public List<Vector2> magicAndTrapPositions = new List<Vector2>(5);

        /// <summary>
        /// All things you would find on a field, as defined by the universal player mat.
        /// </summary>
        public Field()
        {
            monsterZone = new List<Card>()
            {
                new Card(),
                new Card(),
                new Card(),
                new Card(),
                new Card(),
            };
            magicAndTrapZone = new List<Card>()
            {
                new Card(),
                new Card(),
                new Card(),
                new Card(),
                new Card(),
            };
            deck = new List<Card>();
            deckSprite = null;
            graveYard = new List<Card>();
            fusionDeck = new List<Card>();
            fieldZone = new Card();
        }

        /// <summary>
        /// Alternate constructor that I might use to instantiate a field with a players deck, idk we'll see.
        /// </summary>
        /// <param name="deck"></param>
        public Field(List<Card> deck) : this()
        {
            this.deck = deck;
        }

        /// <summary>
        /// Handles the drawing of all the components on the field.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            DrawMonsters(spriteBatch);
            DrawMagicAndTraps(spriteBatch);
            DrawDeck(spriteBatch);
            DrawFieldZone(spriteBatch);
            DrawGraveYard(spriteBatch);
        }

        private void DrawMonsters(SpriteBatch spriteBatch)
        {
            var monstersWithPositions = monsterZone.Zip(monsterPositions, (c, p) => new { Card = c, Position = p });
            foreach (var pair in monstersWithPositions)
            {
                if (pair.Card != null)
                {
                    pair.Card.position = pair.Position;
                    if (pair.Card is MonsterCard)
                    {
                        MonsterCard monster = (MonsterCard)pair.Card;
                        monster.Draw(spriteBatch);
                    }
                    else
                        pair.Card.Draw(spriteBatch);
                }
            }
        }

        private void DrawMagicAndTraps(SpriteBatch spriteBatch)
        {
            var spellsWithPositions = magicAndTrapZone.Zip(magicAndTrapPositions, (c, p) => new { Card = c, Position = p });
            foreach (var pair in spellsWithPositions)
            {
                if (pair.Card != null)
                {
                    pair.Card.position = pair.Position;
                    pair.Card.Draw(spriteBatch);
                }
            }
        }

        private void DrawDeck(SpriteBatch spriteBatch)
        {
            if (deck.Count > 0)
            {
                deckSprite.Draw(spriteBatch);
            }
        }

        private void DrawFieldZone(SpriteBatch spriteBatch)
        {
            if (fieldZone != null)
                fieldZone.Draw(spriteBatch);
        }

        private void DrawGraveYard(SpriteBatch spriteBatch)
        {
            if (graveYard.Count > 0)
            {
                Card topCard = graveYard[graveYard.Count - 1];
                topCard.position = graveYardPosition;
                topCard.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Algorithm used to shuffle the deck.
        /// </summary>
        public void Shuffle()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = deck.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                //List<Card> deckAsArray = deck.ToList();
                Card card = deck[k];
                deck[k] = deck[n];
                deck[n] = card;
                //deck = new Stack<Card>(deckAsArray);
            }
        }

        public bool HasMonsters()
        {
            foreach (Card card in monsterZone)
                if (card is MonsterCard)
                    return true;
            return false;
        }

        /// <summary>
        /// Customer builder with some special building properties and initialization.
        /// </summary>
        internal class Builder
        {
            public Field field = new Field();

            public Builder WithDeck(List<Card> deck)
            {
                field.deck = deck;
                return this;
            }

            public Builder WithMonsterPositions(List<Vector2> positions)
            {
                field.monsterPositions = positions;
                return this;
            }

            public Builder WithMagicAndTrapPositions(List<Vector2> positions)
            {
                field.magicAndTrapPositions = positions;
                return this;
            }

            public Builder WithDeckSpriteAndPosition(Texture2D sprite, Vector2 position)
            {
                field.deckSprite = new CardBack(sprite, position);
                return this;
            }

            public Builder WithGraveYardPosition(Vector2 position)
            {
                field.graveYardPosition = position;
                return this;
            }

            public Builder WithFusionDeckPosition(Vector2 position)
            {
                field.fusionDeckPosition = position;
                return this;
            }

            public Builder WithFieldCardPosition(Vector2 position)
            {
                field.fieldCardPosition = position;
                return this;
            }

            public Field Build()
            {
                return this.field;
            }
        }
    }
}
