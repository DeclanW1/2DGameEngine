using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MiniGame.Engine
{
    public class Player : GameObject
    {
        public Texture2D Texture;

        public override void Update(GameTime gameTime)
        {
            // Movement will be added later
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
