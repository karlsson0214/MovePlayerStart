using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace MovePlayerStart
{
    /// <summary>
    /// A turtle that can move in four directions.
    /// </summary>
    internal class Turtle
    {
        // The image representing the turtle.
        private Texture2D texture;
        private Vector2 position;
        private float speed = 400f;
        // rotation in degrees
        // 0 = right, 90 = down, 180 = left, 270 = up
        private float rotation = 0f;

        /// <summary>
        /// Create a new turtle, with specified image and postion.
        /// </summary>
        /// <param name="texture">The image as a texture.</param>
        /// <param name="position"></param>
        public Turtle(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }
        /// <summary>
        /// Called by Game each frame to update the turtle's position and rotation.
        /// </summary>
        /// <param name="gameTime">An object representing the time in the game.</param>
        internal void Update(GameTime gameTime)
        {
            // Move the turtle based on input
            var keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                rotation = 180; // left
                position.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                rotation = 90; // down
                position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                
            }
            // Wrap around the screen vertically.
            if (position.Y > 480)
            {
                position.Y = 0;
            }
        }
        /// <summary>
        /// Called by Game each frame to draw the turtle.
        /// </summary>
        /// <param name="spriteBatch"></param>
        internal void Draw(SpriteBatch spriteBatch)
        {
            // Draw the turtle, centered on the position.
            spriteBatch.Draw(texture,
                position,
                null,
                Color.White,
                rotation * MathF.PI / 180f, // Convert to radians
                new Vector2(texture.Width / 2, texture.Height / 2), // Center image on position
                Vector2.One,
                SpriteEffects.None,
                0f);
        }
    }
}
