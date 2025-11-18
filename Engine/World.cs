using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MiniGame.Engine
{
    public class World
    {
        private readonly List<GameObject> objects = new List<GameObject>();

        public void Add(GameObject obj)
        {
            objects.Add(obj);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var obj in objects)
            {
                if (obj.IsActive)
                {
                    obj.Update(gameTime);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var obj in objects)
            {
                if (obj.IsActive)
                {
                    obj.Draw(spriteBatch);
                }
            }
        }
    }
}