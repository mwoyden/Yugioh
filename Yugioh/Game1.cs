using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Threading;
using Yugioh.Cards;
using Yugioh.Cards.GenericCardComponents;
using Yugioh.Cards.MagicCards.Cards;
using Yugioh.Cards.MonsterCardComponents;
using Yugioh.Cards.MonsterCards;
using Yugioh.Cards.TrapCards;
using Yugioh.Cards.TrapCards.Cards;
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
        // player 1
        private static readonly Vector2 p1DeckPosition = new Vector2(WIDTH * 0.6103f, HEIGHT * 0.645f);
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

        //player 2
        private static readonly Vector2 p2DeckPosition = new Vector2(WIDTH * 0.0192f, HEIGHT * 0.0262f);
        private static readonly Vector2 p2GraveYardPosition = new Vector2(WIDTH * 0.0192f, HEIGHT * 0.2069f);
        private static readonly Vector2 p2FieldZonePosition = new Vector2(WIDTH * 0.6112f, HEIGHT * 0.2069f);
        private static readonly List<Vector2> p2MonsterPositions = new List<Vector2>()
            {
                new Vector2(WIDTH * 0.1203f, HEIGHT * 0.2069f),
                new Vector2(WIDTH * 0.2188f, HEIGHT * 0.2069f),
                new Vector2(WIDTH * 0.3165f, HEIGHT * 0.2069f),
                new Vector2(WIDTH * 0.4150f, HEIGHT * 0.2069f),
                new Vector2(WIDTH * 0.5126f, HEIGHT * 0.2069f),
            };
        private static readonly List<Vector2> p2MagicAndTrapPositions = new List<Vector2>()
            {
                new Vector2(WIDTH * 0.1203f, HEIGHT * 0.0262f),
                new Vector2(WIDTH * 0.2188f, HEIGHT * 0.0262f),
                new Vector2(WIDTH * 0.3165f, HEIGHT * 0.0262f),
                new Vector2(WIDTH * 0.4150f, HEIGHT * 0.0262f),
                new Vector2(WIDTH * 0.5126f, HEIGHT * 0.0262f),
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
        Turn turn = Turn.P1;

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
        HandleAttacking handleAttacking;
        HandleBattleSelection handleBattleSelection;
        // Player 2 handlers
        HandleInP2MagicAndTrapZone handleInP2MagicAndTrapZone;
        HandleInP2MonsterZone handleInP2MonsterZone;
        //HandleInP1FieldZone handleInP1FieldZone;

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

            // ORDER OF INITS MATTERS HERE
            // initialize the field
            InitField();

            // initialize the selector thing
            InitSelector(spriteBatch);

            // initialize the selector handlers (for handling your input)
            InitSelectorHandlers();

            // initialize the startFrame and set it to the currentFrame
            InitFrames();
        }

        /// Initializes both sides of the field (has lots of testing material in it.
        private void InitField()
        {
            HumanPlayer.Builder p1Builder = new HumanPlayer.Builder();
            AIPlayer.Builder p2Builder = new AIPlayer.Builder();
            p1 = p1Builder
                .WithHandPositions(p1HandPositions)
                .Build();
            p2 = p2Builder
                .Build();
            p2.lifePoints = 500;

            p1Deck = new List<Card>
                {
                    new AncientElf(spriteManager),
                    new FeralImp(spriteManager),
                    new DarkMagician(spriteManager),
                    new GreatWhite(spriteManager),
                    new DarkHole(spriteManager),
                    new TrapHole(spriteManager)
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

            p2Deck = new List<Card>
                {
                    new AncientElf(spriteManager),
                    new FeralImp(spriteManager),
                    new DarkMagician(spriteManager),
                    new GreatWhite(spriteManager),
                    new DarkHole(spriteManager),
                    new CastleWalls(spriteManager)
                };
            Field.Builder p2FieldBuilder = new Field.Builder();
            p2Field = p2FieldBuilder
                .WithDeck(p2Deck)
                .WithDeckSpriteAndPosition(spriteManager.cardBack, p2DeckPosition)
                .WithGraveYardPosition(p2GraveYardPosition)
                .WithMonsterPositions(p2MonsterPositions)
                .WithMagicAndTrapPositions(p2MagicAndTrapPositions)
                .WithFieldCardPosition(p2FieldZonePosition)
                .Build();

            // Draw cards 
            DrawCard.Apply(p1, p1Field);
            DrawCard.Apply(p1, p1Field);
            DrawCard.Apply(p1, p1Field);
            DrawCard.Apply(p1, p1Field);
            DrawCard.Apply(p1, p1Field);

            DrawCard.Apply(p2, p2Field);
            DrawCard.Apply(p2, p2Field);
            DrawCard.Apply(p2, p2Field);
            DrawCard.Apply(p2, p2Field);
            DrawCard.Apply(p2, p2Field);
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
            handleAttacking = new HandleAttacking();
            handleBattleSelection = new HandleBattleSelection();
            //Player 2 areas
            handleInP2MagicAndTrapZone = new HandleInP2MagicAndTrapZone();
            handleInP2MonsterZone = new HandleInP2MonsterZone();

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
                    { SelectedState.SET_OR_ACTIVATE, handleSetOrActivate },
                    { SelectedState.ATTACKING, handleAttacking },
                    { SelectedState.BATTLE_SELECT, handleBattleSelection },
                    //Player 2 handlers
                    { SelectedState.P2_MAGIC_AND_TRAP_ZONE, handleInP2MagicAndTrapZone },
                    { SelectedState.P2_MONSTER_ZONE, handleInP2MonsterZone },
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
            // Update the keyboard state
            KeyboardState state = Keyboard.GetState();
            // Check for game exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || state.IsKeyDown(Keys.Escape))
                Exit();

            // Update turn and check for win/loss
            UpdateGame();
            UpdateTurn();

            // Upate player phase
            p1.Update(gameTime, p1Field);
            p2.Update(gameTime, p2Field);

            // Update traps for hooks (EARLY TESTING)
            KeyValuePair<TrapCard, int> hookedTrap = CheckHooksP1(gameTime, p1, p2, p1Field, p2Field);
            if (hookedTrap.Key != null)
            {
                hookedTrap.Key.effect.Activate(p1, p2, p1Field, p2Field, hookedTrap.Value);
            }

            // Update selector
            selectionHandlers[selector.state].Handle(selector, p1, p2, p1Field, p2Field, state, previousState);

            // for testing, draw with 'D'
            if (state.IsKeyDown(Keys.D) && previousState.IsKeyUp(Keys.D))
                DrawCard.Apply(p1, p1Field);

            // Update keyboard state
            previousState = state;

            // AI starts with monster for testing
            foreach (Card card in p1Field.magicAndTrapZone)
                if (card is TrapHole)
                    if (p2.hand[0] is MonsterCard)
                    {
                        p1.hooks.Add(TrapHook.NORMAL_SUMMON, 0);
                        Summon.Apply(p2, p2Field, (MonsterCard)p2.hand[0], 0);
                    }

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
            // Draw the overlaying UI
            currentFrame.DrawUI(spriteBatch, p1, p2, turn);

            // Draw the selected card in the draw area
            selector.DrawSelectedCard(spriteBatch, spriteManager);

            // Close spriteBatch
            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Checks if P1 is able to use trap cards based off hooks.
        /// </summary>
        /// <param name="gameTime">for timing</param>
        /// <param name="p1">player 1</param>
        /// <param name="p2">player 2</param>
        /// <param name="p1Field">player 1's field</param>
        /// <param name="p2Field">player 2's field</param>
        /// <returns>Trap card that was hooked and the card that hooked it.</returns>
        private KeyValuePair<TrapCard, int> CheckHooksP1(GameTime gameTime, Player p1, Player p2, Field p1Field, Field p2Field)
        {
            foreach (Card card in p1Field.magicAndTrapZone)
            {
                if (card is TrapCard)
                {
                    TrapCard trap = (TrapCard)card;
                    int hookedCardIndex = trap.HookTriggered(p1);
                    if (hookedCardIndex > -1) // Card was hooked
                        return new KeyValuePair<TrapCard, int>(trap, hookedCardIndex);
                }
            }
            return new KeyValuePair<TrapCard, int>(null, -1);
        }

        /// <summary>
        /// Ensures the game turn changes normally
        /// </summary>
        private void UpdateTurn()
        {
            if (turn.Equals(Turn.P1) && p1.currentPhase.Equals(Phase.END))
            {
                p1.currentPhase = Phase.NONE;
                turn = Turn.P2;
            }
            else if (turn.Equals(Turn.P2) && p2.currentPhase.Equals(Phase.END))
            {
                p2.currentPhase = Phase.NONE;
                turn = Turn.P1;
            }
            else if (turn.Equals(Turn.P1) && p1.currentPhase.Equals(Phase.NONE))
            {
                p1.currentPhase = Phase.DRAW;
            }
            else if (turn.Equals(Turn.P2) && p2.currentPhase.Equals(Phase.NONE))
            {
                p2.currentPhase = Phase.DRAW;
            }
        }

        /// <summary>
        /// Ensures lifepoints don't go below 0 and 0 lifepoints means you lose
        /// </summary>
        private void UpdateGame()
        {
            if (p1.lifePoints < 0)
                p1.lifePoints = 0;
            if (p2.lifePoints < 0)
                p2.lifePoints = 0;
            //make people lose
        }
    }
}
