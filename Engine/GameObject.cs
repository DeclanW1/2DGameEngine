using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MiniGame.Engine
{
    public abstract class GameObject
    {
        public Vector2 Position;
        public Vector2 Size;
        public bool IsActive = true;

        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}