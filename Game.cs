using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace MovePlayerStart
{
    /// <summary>
    /// Represents the game itself.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Turtle turtle;
        /// <summary>
        /// Create a new game.
        /// </summary>
        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        /// <summary>
        /// Called by the MonoGame system when the game first starts.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }
        /// <summary>
        /// Called by the MonoGame system to load game content after Initialize.
        /// </summary>
        protected override void LoadContent()
        {   
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // Load image files.
            Texture2D turtleTexture = Content.Load<Texture2D>("turtle2");

            // turtle position
            Vector2 position = new Vector2(_graphics.PreferredBackBufferWidth / 2,
                _graphics.PreferredBackBufferHeight / 2);
            
            // Create the turtle.
            turtle = new Turtle(turtleTexture, position);
            Debug.WriteLine("height: " + _graphics.PreferredBackBufferHeight);
            Debug.WriteLine("width: " + _graphics.PreferredBackBufferWidth);            
        }
        /// <summary>
        /// Called by the MonoGame system to update the game state. Called once per frame.
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update all game objects.
            turtle.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            // Draw all game objects.
            turtle.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
