using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MiniGame.Engine
{
    public class Player : GameObject
    {
        public Texture2D Texture;

        public override void Update(GameTime gameTime)
        {
            //WASD arrow key movement for the player
            var keyboard = Keyboard.GetState();

            float speed = 200f; // pixels per second
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keyboard.IsKeyDown(Keys.W) || keyboard.IsKeyDown(Keys.Up))
                Position.Y -= speed * dt;

            if (keyboard.IsKeyDown(Keys.S) || keyboard.IsKeyDown(Keys.Down))
                Position.Y += speed * dt;

            if (keyboard.IsKeyDown(Keys.A) || keyboard.IsKeyDown(Keys.Left))
                Position.X -= speed * dt;

            if (keyboard.IsKeyDown(Keys.D) || keyboard.IsKeyDown(Keys.Right))
                Position.X += speed * dt;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Texture != null)
            {
                spriteBatch.Draw(
                    Texture,
                    new Rectangle(
                        (int)Position.X,
                        (int)Position.Y,
                        (int)Size.X,
                        (int)Size.Y
                    ),
                    Color.White
                );
            }
        }
    }
}