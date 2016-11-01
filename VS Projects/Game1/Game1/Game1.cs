using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D playerTexture;
        Vector2 playerPos;

        Texture2D player2Texture;
        Vector2 player2Pos;
        int cd_1 = 1;
        int cd_2 = 1;      



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            // TODO: Add your initialization logic here

            playerPos = new Vector2(5,10);
            player2Pos = new Vector2(500,10);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            playerTexture = Content.Load<Texture2D>("player_base");
            player2Texture = Content.Load<Texture2D>("player_base_r");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            KeyboardState key = Keyboard.GetState();

            if (key.IsKeyDown(Keys.Up)) { if (cd_2 == 1) { Thread t2 = new Thread(animate_r); t2.Start(); } }
            if (key.IsKeyDown(Keys.Left)) { player2Pos.X -= 1;}
            if (key.IsKeyDown(Keys.Right)) { player2Pos.X += 1;}

            if (key.IsKeyDown(Keys.W)) { if (cd_1 == 1) { Thread t = new Thread(animate); t.Start(); } }
            if (key.IsKeyDown(Keys.A)) { playerPos.X -= 1;}
            if (key.IsKeyDown(Keys.D)) { playerPos.X += 1;}

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(playerTexture, playerPos, Color.White);
            spriteBatch.Draw(player2Texture, player2Pos, Color.White);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public void animate_r()
        {
            if (cd_2 == 1)
            {
                cd_2 = 0;
                player2Texture = Content.Load<Texture2D>("player_punch_r");
                for (int i = 0; i < 15; i++)
                {
                    if ((player2Pos.X - playerPos.X) < 150 && player2Pos.Y < 100)
                    {
                        playerPos.Y = 100;
                    }
                    Thread.Sleep(1);
                }
                player2Texture = Content.Load<Texture2D>("player_base_r");
                Thread.Sleep(1000);
            }
            cd_2 = 1;
        }

        public void animate()
        {
            if (cd_1 == 1)
            {
                cd_1 = 0;
                playerTexture = Content.Load<Texture2D>("player_punch");
                for (int i = 0; i < 15; i++)
                {
                    if ((player2Pos.X - playerPos.X) < 150 && playerPos.Y < 100)
                    {
                        player2Pos.Y = 100;
                    }
                    Thread.Sleep(1);
                }
                playerTexture = Content.Load<Texture2D>("player_base");
                Thread.Sleep(1000);
            }
            cd_1 = 1;
          }
        

    }
}
