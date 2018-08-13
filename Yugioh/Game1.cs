using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Yugioh.Cards;
using Yugioh.Cards.GenericCardComponents;
using Yugioh.Cards.MagicAndTrapCardComponents;
using Yugioh.Cards.MagicCards;
using Yugioh.Cards.MonsterCardComponents;
using Yugioh.Cards.MonsterCards;
using Yugioh.Cards.TrapCards;
using Yugioh.GameComponents;

namespace Yugioh
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        // Game controllers
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SpriteManager spriteManager;

        // Window details
        private static readonly int WIDTH = 1147;
        private static readonly int HEIGHT = 841;

        // Field specific variables (should move somewhere else)
        private static readonly Vector2 p1DeckPosition = new Vector2(WIDTH * 0.6103f, HEIGHT * 0.645f);
        private static readonly Vector2 p2DeckPosition = new Vector2(WIDTH * 0.0192f, HEIGHT * 0.0238f);
        private static readonly Vector2 p1GraveYardPosition = new Vector2(WIDTH * 0.612f, HEIGHT * 0.462f);
        private static readonly Vector2 p1FieldZonePosition = new Vector2(WIDTH * 0.0210f, HEIGHT * 0.4625f);
        private static readonly List<Vector2> p1HandPositions = new List<Vector2>()
        {
            new Vector2(WIDTH * 0.0427f, HEIGHT * 0.8383f),
            new Vector2(WIDTH * 0.1333f, HEIGHT * 0.8383f),
            new Vector2(WIDTH * 0.2240f, HEIGHT * 0.8383f),
            new Vector2(WIDTH * 0.3112f, HEIGHT * 0.8383f),
            new Vector2(WIDTH * 0.4028f, HEIGHT * 0.8383f),
            new Vector2(WIDTH * 0.4926f, HEIGHT * 0.8383f),
            new Vector2(WIDTH * 0.5798f, HEIGHT * 0.8383f)
        };
        private static readonly List<Vector2> p1MonsterPositions = new List<Vector2>()
        {
            new Vector2(WIDTH * 0.1203f, HEIGHT * 0.4625f),
            new Vector2(WIDTH * 0.2188f, HEIGHT * 0.4625f),
            new Vector2(WIDTH * 0.3165f, HEIGHT * 0.4625f),
            new Vector2(WIDTH * 0.4150f, HEIGHT * 0.4625f),
            new Vector2(WIDTH * 0.5126f, HEIGHT * 0.4625f),
        };
        private static readonly List<Vector2> p1MagicAndTrapPositions = new List<Vector2>()
        {
            new Vector2(WIDTH * 0.1203f, HEIGHT * 0.6467f),
            new Vector2(WIDTH * 0.2188f, HEIGHT * 0.6467f),
            new Vector2(WIDTH * 0.3165f, HEIGHT * 0.6467f),
            new Vector2(WIDTH * 0.4150f, HEIGHT * 0.6467f),
            new Vector2(WIDTH * 0.5126f, HEIGHT * 0.6467f),
        };

        // Stuff in the game
        Frame startFrame;
        Frame currentFrame;
        Player p1;
        Player p2;
        Field p1Field;
        Field p2Field;
        List<Card> p1Deck;
        List<Card> p2Deck;
        // Selector
        Selector selector;
        KeyboardState previousState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = WIDTH,  // set this value to the desired width of your window
                PreferredBackBufferHeight = HEIGHT,   // set this value to the desired height of your window
                PreferredDepthStencilFormat = DepthFormat.Depth24Stencil8
            };
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// Initializes both sides of the field.
        private void InitField()
        {
            HumanPlayer.Builder p1Builder = new HumanPlayer.Builder();
            p1 = p1Builder
                .WithHandPositions(p1HandPositions)
                .Build();

            DarkMagician darkMagician = new DarkMagician(spriteManager);
            AncientElf ancientElf = new AncientElf(spriteManager);
            FeralImp feralImp = new FeralImp(spriteManager);
            GreatWhite greatWhite = new GreatWhite(spriteManager);
            DarkHole darkHole = new DarkHole(spriteManager);
            CastleWalls castleWalls = new CastleWalls(spriteManager);

            p1Deck = new List<Card>
            {
                ancientElf,
                feralImp,
                darkMagician,
                greatWhite,
                darkHole,
                castleWalls
            };

            Field.Builder p1FieldBuilder = new Field.Builder();
            p1Field = p1FieldBuilder
                .WithDeck(p1Deck)
                .WithDeckSpriteAndPosition(spriteManager.cardBack, p1DeckPosition)
                .WithGraveYardPosition(p1GraveYardPosition)
                .WithMonsterPositions(p1MonsterPositions)
                .WithMagicAndTrapPositions(p1MagicAndTrapPositions)
                .WithFieldCardPosition(p1FieldZonePosition)
                .Build();

            // Begin stuff?
            DrawCard.Apply(p1, p1Field);
            DrawCard.Apply(p1, p1Field);
            DrawCard.Apply(p1, p1Field);
            DrawCard.Apply(p1, p1Field);
            DrawCard.Apply(p1, p1Field);

            // TEST FUNCTIONALITY
            //DrawCard.Apply(p1, p1Field);
            //Summon.Apply(p1, p1Field, (MonsterCard)p1.hand[0]);
            //DrawCard.Apply(p1, p1Field);
            //SetMonster.Apply(p1, p1Field, (MonsterCard)p1.hand[0]);
            //DrawCard.Apply(p1, p1Field);
            //DrawCard.Apply(p1, p1Field);
            //DrawCard.Apply(p1, p1Field);
            //SetMagic.Apply(p1, p1Field, p1.hand[2]);
            //Sacrifice.Apply(p1, p1Field, (MonsterCard)p1Field.monsterZone[0]);
            //Sacrifice.Apply(p1, p1Field, (MonsterCard)p1Field.monsterZone[1]);
            //SetMonster.Apply(p1, p1Field, (MonsterCard)p1.hand[0]);
            //DiscardCard.Apply(p1, p1Field, p1.hand[1]);
            //DrawCard.Apply(p1, p1Field);
            //SetTrap.Apply(p1, p1Field, p1.hand[0]);

            p2Deck = new List<Card>();
            Field.Builder p2FieldBuilder = new Field.Builder();
            p2Field = p2FieldBuilder
                .WithDeckSpriteAndPosition(spriteManager.cardBack, p2DeckPosition)
                .WithDeck(p2Deck)
                .Build();
        }

        // Still testing this
        private void InitFrames()
        {
            startFrame = new Frame(spriteManager);
            startFrame.components.Add(p1Field);
            startFrame.components.Add(p1);
            startFrame.components.Add(p2Field);
            startFrame.components.Add(selector);
            currentFrame = startFrame;
        }

        // Initialize the UI 
        private void InitSelector(SpriteBatch spriteBatch) 
        {
            selector = new Selector(spriteBatch, p1.hand[0]);
            previousState = Keyboard.GetState();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // initialize content
            spriteManager = new SpriteManager(Content);

            // ORDER OF INITS MATTERS HERE
            // initialize the field
            InitField();

            // initialize the selector thing
            InitSelector(spriteBatch);

            // initialize the startFrame and set it to the currentFrame
            InitFrames();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            base.UnloadContent();
            spriteBatch.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for events, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || state.IsKeyDown(Keys.Escape))
                Exit();

            UpdateSelector(state);

            if (state.IsKeyDown(Keys.D) && previousState.IsKeyUp(Keys.D))
                DrawCard.Apply(p1, p1Field);

            // Update keyboard state
            previousState = state;

            base.Update(gameTime);
        }

        private void UpdateSelector(KeyboardState state)
        {
            if (selector.area.Equals(SelectedArea.P1_HAND))
                HandleInP1Hand(state);
            else if (selector.area.Equals(SelectedArea.P1_MAGIC_AND_TRAP_ZONE))
                HandleInP1MagicAndTrapZone(state);
            else if (selector.area.Equals(SelectedArea.P1_MONSTER_ZONE))
                HandleInP1MonsterZone(state);
            else if (selector.area.Equals(SelectedArea.P1_FIELD_ZONE))
                HandleInP1FieldZone(state);
        }

        private void HandleInP1Hand(KeyboardState state)
        {
            // Handles left and right
            HandleLeftRightWithMaxIndex(state, 6);
            if (p1.hand[selector.index].sprite == null)
                selector.defaultCardPosition = p1.handPositions[selector.index];
            selector.selected = p1.hand[selector.index];

            // Handles up and down
            HandleUpAndDown(state, SelectedArea.P1_MAGIC_AND_TRAP_ZONE, p1Field.magicAndTrapZone, p1Field.magicAndTrapPositions,
                                    SelectedArea.P2_MAGIC_AND_TRAP_ZONE, p2Field.magicAndTrapZone, p2Field.magicAndTrapPositions);
        }

        private void HandleInP1MagicAndTrapZone(KeyboardState state)
        {
            // Handles left and right
            HandleLeftRightWithMaxIndex(state, 4);
            if (p1Field.magicAndTrapZone[selector.index].sprite == null)
                selector.defaultCardPosition = p1Field.magicAndTrapPositions[selector.index];
            selector.selected = p1Field.magicAndTrapZone[selector.index];

            // Handles up and down
            HandleUpAndDown(state, SelectedArea.P1_MONSTER_ZONE, p1Field.monsterZone, p1Field.monsterPositions,
                                    SelectedArea.P1_HAND, p1.hand, p1.handPositions);
        }

        private void HandleInP1MonsterZone(KeyboardState state)
        {
            // Handles left and right
            HandleLeftRightWithFieldZone(state);
            if (p1Field.monsterZone[selector.index].sprite == null)
                selector.defaultCardPosition = p1Field.monsterPositions[selector.index];
            selector.selected = p1Field.monsterZone[selector.index];

            // Handles up and down
            HandleUpAndDown(state, SelectedArea.P2_MONSTER_ZONE, p2Field.monsterZone, p2Field.monsterPositions,
                                    SelectedArea.P1_MAGIC_AND_TRAP_ZONE, p1Field.magicAndTrapZone, p1Field.magicAndTrapPositions);
        }

        private void HandleInP1FieldZone(KeyboardState state)
        {
            if (state.IsKeyDown(Keys.Left) && previousState.IsKeyUp(Keys.Left))
            {
                selector.area = SelectedArea.P1_MONSTER_ZONE;
                selector.index = 4;
            }
            else if (state.IsKeyDown(Keys.Right) && previousState.IsKeyUp(Keys.Right))
            {
                selector.area = SelectedArea.P1_MONSTER_ZONE;
                selector.index = 0;
            }
            if (p1Field.fieldZone.sprite == null)
                selector.defaultCardPosition = p1Field.fieldCardPosition;
            selector.selected = p1Field.fieldZone;
        }

        private void HandleLeftRightWithFieldZone(KeyboardState state)
        {
            if (state.IsKeyDown(Keys.Right) && previousState.IsKeyUp(Keys.Right))
            {
                if (selector.index == 4)
                    selector.area = SelectedArea.P1_FIELD_ZONE;
                else
                    selector.index++;
            }
            else if (state.IsKeyDown(Keys.Left) && previousState.IsKeyUp(Keys.Left))
            {
                if (selector.index == 0)
                    selector.area = SelectedArea.P1_FIELD_ZONE;
                else
                    selector.index--;
            }
        }

        private void HandleLeftRightWithMaxIndex(KeyboardState state, int max)
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

        private void HandleUpAndDown(KeyboardState state, SelectedArea toUpArea, List<Card> toUpZone, List<Vector2> defaultUpPositions,
                                                  SelectedArea toDownArea, List<Card> toDownZone, List<Vector2> defaultDownPositions)
        {
            if (state.IsKeyDown(Keys.Up) && previousState.IsKeyUp(Keys.Up))
            {
                selector.area = toUpArea;
                selector.index = 0;
                selector.selected = toUpZone[0];
                selector.defaultCardPosition = defaultUpPositions[0];
            }
            else if (state.IsKeyDown(Keys.Down) && previousState.IsKeyUp(Keys.Down))
            {
                selector.area = toDownArea;
                selector.index = 0;
                selector.selected = toDownZone[0];
                selector.defaultCardPosition = defaultDownPositions[0];
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //begins sprite drawing through regular view
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, null);

            // Draw everything in the current frame. Should represent a full snapshot of what's on screen.
            currentFrame.Draw(spriteBatch);

            // Close spriteBatch
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
