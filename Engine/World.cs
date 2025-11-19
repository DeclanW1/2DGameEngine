using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MiniGame.Engine
{
    public class World
    {
        //all game objects in the world
        private readonly List<GameObject> _objects = new List<GameObject>();

        public void Add(GameObject obj)
        {
            _objects.Add(obj);
        }

        public void Update(GameTime gameTime)
        {
            foreach (var obj in _objects)
            {
                if (obj.IsActive)
                {
                    obj.Update(gameTime);
                }
            }

            HandlePlayerWallCollisions();
            HandleBouncerWallCollisions();
        }

        //draw all the active objects
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var obj in _objects)
            {
                if (obj.IsActive)
                {
                    obj.Draw(spriteBatch);
                }
            }
        }

        // COLLISIONS -- Player + Wall
        private void HandlePlayerWallCollisions()
        {
            var players = new List<Player>();
            var walls = new List<Wall>();

            //objects categorised into players and walls
            foreach (var obj in _objects)
            {
                if (obj is Player p)
                    players.Add(p);
                else if (obj is Wall w)
                    walls.Add(w);
            }

            //check collisions
            foreach (var player in players)
            {
                foreach (var wall in walls)
                {
                    ResolveCollision(player, wall);
                }
            }
        }

        //push the player out of any wall they overlap
        private void ResolveCollision(Player player, Wall wall)
        {
            Rectangle p = ToRect(player);
            Rectangle w = ToRect(wall);

            if (!p.Intersects(w))
                return;

            Vector2 pCenter = new Vector2(p.Center.X, p.Center.Y);
            Vector2 wCenter = new Vector2(w.Center.X, w.Center.Y);

            float dx = pCenter.X - wCenter.X;
            float dy = pCenter.Y - wCenter.Y;

            //overlap amount on each axis
            float overlapX = (p.Width / 2f + w.Width / 2f) - Math.Abs(dx);
            float overlapY = (p.Height / 2f + w.Height / 2f) - Math.Abs(dy);

            if (overlapX <= 0 || overlapY <= 0)
                return;

            if (overlapX < overlapY)
            {
                if (dx < 0)
                    player.Position.X -= overlapX;
                else
                    player.Position.X += overlapX;
            }
            else
            {
                if (dy < 0)
                    player.Position.Y -= overlapY;
                else
                    player.Position.Y += overlapY;
            }
        }

        // COLLISIONS -- Bouncer + Wall
        private void HandleBouncerWallCollisions()
        {
            var bouncers = new List<Bouncer>();
            var walls = new List<Wall>();

            foreach (var obj in _objects)
            {
                if (obj is Bouncer b)
                    bouncers.Add(b);
                else if (obj is Wall w)
                    walls.Add(w);
            }

            foreach (var bouncer in bouncers)
            {
                foreach (var wall in walls)
                {
                    ResolveBouncerCollision(bouncer, wall);
                }
            }
        }

        //pushes the bouncer off any wall it overlaps and flips its velocity
        private void ResolveBouncerCollision(Bouncer bouncer, Wall wall)
        {
            Rectangle b = ToRect(bouncer);
            Rectangle w = ToRect(wall);

            if (!b.Intersects(w))
                return;

            Vector2 bCenter = new Vector2(b.Center.X, b.Center.Y);
            Vector2 wCenter = new Vector2(w.Center.X, w.Center.Y);

            float dx = bCenter.X - wCenter.X;
            float dy = bCenter.Y - wCenter.Y;

            float overlapX = (b.Width / 2f + w.Width / 2f) - Math.Abs(dx);
            float overlapY = (b.Height / 2f + w.Height / 2f) - Math.Abs(dy);

            if (overlapX <= 0 || overlapY <= 0)
                return;

            if (overlapX < overlapY)
            {
                if (dx < 0)
                    bouncer.Position.X -= overlapX;
                else
                    bouncer.Position.X += overlapX;

                var v = bouncer.Velocity;
                v.X *= -1;
                bouncer.Velocity = v;
            }
            else
            {
                if (dy < 0)
                    bouncer.Position.Y -= overlapY;
                else
                    bouncer.Position.Y += overlapY;

                var v = bouncer.Velocity;
                v.Y *= -1;
                bouncer.Velocity = v;
            }
        }

        //converts GameObject into rectangle
        private Rectangle ToRect(GameObject obj)
        {
            return new Rectangle(
                (int)obj.Position.X,
                (int)obj.Position.Y,
                (int)obj.Size.X,
                (int)obj.Size.Y
            );
        }
    }
}
