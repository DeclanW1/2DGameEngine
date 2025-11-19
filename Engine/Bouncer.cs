using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MiniGame.Engine
{
    public class Bouncer : GameObject
    {
        private readonly Texture2D _texture;
        private readonly Color _color;
        private Vector2 _velocity;

        //public so the world can adjust it on collision
        public Vector2 Velocity
        {
            get => _velocity;
            set => _velocity = value;
        }

        //bounds of the playable area
        private readonly float _minX = 60f;
        private readonly float _maxX = 720f;
        private readonly float _minY = 60f;
        private readonly float _maxY = 400f;

        public Bouncer(Texture2D texture, Vector2 position, Vector2 size, Vector2 velocity, Color color)
        {
            _texture = texture;
            Position = position;
            Size = size;
            _velocity = velocity;
            _color = color;
        }

        public override void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Position += _velocity * dt;

            //bounce off the inner bounds of the box
            if (Position.X < _minX)
            {
                Position.X = _minX;
                _velocity.X *= -1;
            }
            else if (Position.X + Size.X > _maxX)
            {
                Position.X = _maxX - Size.X;
                _velocity.X *= -1;
            }

            if (Position.Y < _minY)
            {
                Position.Y = _minY;
                _velocity.Y *= -1;
            }
            else if (Position.Y + Size.Y > _maxY)
            {
                Position.Y = _maxY - Size.Y;
                _velocity.Y *= -1;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!IsActive)
                return;

            var rect = new Rectangle(
                (int)Position.X,
                (int)Position.Y,
                (int)Size.X,
                (int)Size.Y
            );

            spriteBatch.Draw(_texture, rect, _color);
        }
    }
}