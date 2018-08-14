using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using Yugioh.Cards;
using Yugioh.Cards.GenericCardComponents;
using Yugioh.Cards.MagicAndTrapCardComponents;
using Yugioh.Cards.MagicCards;
using Yugioh.Cards.MonsterCardComponents;
using Yugioh.Cards.MonsterCards;
using Yugioh.Cards.TrapCards;
using Yugioh.GameComponents;
using Yugioh.GameComponents.SelectorHandlers;

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

        // Selector constants
        private static readonly List<Vector2> selectorPositions = new List<Vector2>()
        {
            new Vector2(810, 696), //[0]
            new Vector2(960, 696)  //[1]
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

        // Selector / handlers
        Selector selector;
        KeyboardState previousState;
        HandleInP1Hand handleInP1Hand;
        HandleInP1MagicAndTrapZone handleInP1MagicAndTrapZone;
        HandleInP1MonsterZone handleInP1MonsterZone;
        HandleInP1FieldZone handleInP1FieldZone;
        HandleSummoning handleSummoning;
        HandleSettingMonster handleSettingMonster;
        HandleSettingMagic handleSettingMagic;
        HandleSettingTrap handleSettingTrap;
        HandleSummonOrSet handleSummonOrSet;
        HandleSetOrActivate handleSetOrActivate;
        Dictionary<SelectedState, ISelectorHandler> selectionHandlers;

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

            p2Deck = new List<Card>();
            Field.Builder p2FieldBuilder = new Field.Builder();
            p2Field = p2FieldBuilder
                .WithDeckSpriteAndPosition(spriteManager.cardBack, p2DeckPosition)
                .WithDeck(p2Deck)
                .Build();

            // Begin stuff?
            DrawCard.Apply(p1, p1Field);
            DrawCard.Apply(p1, p1Field);
            DrawCard.Apply(p1, p1Field);
            DrawCard.Apply(p1, p1Field);
            DrawCard.Apply(p1, p1Field);
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
            selector = new Selector(spriteBatch, p1.hand[0]); // start the selector at the first card position
            previousState = Keyboard.GetState(); // for dealing with single-key-press movements 
        }

        private void InitSelectorHandlers()
        {
            // initialize the handlers
            handleInP1Hand = new HandleInP1Hand();
            handleInP1MagicAndTrapZone = new HandleInP1MagicAndTrapZone();
            handleInP1MonsterZone = new HandleInP1MonsterZone();
            handleInP1FieldZone = new HandleInP1FieldZone();
            handleSummoning = new HandleSummoning();
            handleSettingMonster = new HandleSettingMonster();
            handleSettingMagic = new HandleSettingMagic();
            handleSettingTrap = new HandleSettingTrap();
            handleSummonOrSet = new HandleSummonOrSet();
            handleSetOrActivate = new HandleSetOrActivate();

            selectionHandlers = new Dictionary<SelectedState, ISelectorHandler>()
            {
                { SelectedState.P1_HAND, handleInP1Hand },
                { SelectedState.P1_MAGIC_AND_TRAP_ZONE, handleInP1MagicAndTrapZone },
                { SelectedState.P1_MONSTER_ZONE, handleInP1MonsterZone },
                { SelectedState.P1_FIELD_ZONE, handleInP1FieldZone },
                { SelectedState.SUMMONING, handleSummoning },
                { SelectedState.SETTING_MONSTER, handleSettingMonster },
                { SelectedState.SETTING_MAGIC, handleSettingMagic },
                { SelectedState.SETTING_TRAP, handleSettingTrap },
                { SelectedState.SUMMON_OR_SET, handleSummonOrSet },
                { SelectedState.SET_OR_ACTIVATE, handleSetOrActivate }
            };
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

            // initialize the selector handlers (for handling your input dipshit)
            InitSelectorHandlers();

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

            // Update selector
            selectionHandlers[selector.state].Handle(selector, p1, p2, p1Field, p2Field, state, previousState);

            // for testing
            if (state.IsKeyDown(Keys.D) && previousState.IsKeyUp(Keys.D))
                DrawCard.Apply(p1, p1Field);

            // Update keyboard state
            previousState = state;

            base.Update(gameTime);
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

            // Draw the selected card in the draw area. Also handles the small square selector.
            selector.DrawSelectedCard(spriteBatch, spriteManager);

            // Close spriteBatch
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
