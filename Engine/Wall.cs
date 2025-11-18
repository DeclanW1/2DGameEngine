using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MiniGame.Engine
{
    public class Wall : GameObject
    {
        private readonly Texture2D _texture; //texture used to draw the wall
        private readonly Color _color; //wall colour 

        public Wall(Texture2D texture, Vector2 position, Vector2 size, Color? color = null)
        {
            _texture = texture;
            Position = position;
            Size = size;
            _color = color ?? Color.Gray;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsActive)
                return;
            // converts position and size into rectangle for drawing 
            var rect = new Rectangle(
                (int)Position.X,
                (int)Position.Y,
                (int)Size.X,
                (int)Size.Y
            );

            //draws a rectabgle using 1x1 texture
            spriteBatch.Draw(_texture, rect, _color);
        }
    }
}