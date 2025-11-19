using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MiniGame.Engine;

namespace EngineDemo
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics; //controls game window and graphics
        private SpriteBatch _spriteBatch; // draws textures
        private World _world; // holds all game objects
        private Player _player; // test player
        private Texture2D _pixel; // 1x1 white texture

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Create world and add basic player
            _world = new World();

            _player = new Player
            {
                Position = new Vector2(100, 100),
                Size = new Vector2(32, 32)
            };

            _world.Add(_player);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //create a 1x1 white texture
            _pixel = new Texture2D(GraphicsDevice, 1, 1);
            _pixel.SetData(new[] { Color.White });

            //Gives the texture to the player
            _player.Texture = _pixel;

            //---------------------------------------------------------------------------------------
            //GAME WALLS -- Used ChatGPT to create me a wall layout
            var wall1 = new Wall(
                _pixel,
                new Vector2(40f, 40f),     // top wall
                new Vector2(720f, 20f),
                Color.DarkGray
            );
            _world.Add(wall1);

            var wall2 = new Wall(
                _pixel,
                new Vector2(40f, 420f),    // bottom wall
                new Vector2(720f, 20f),
                Color.DarkGray
            );
            _world.Add(wall2);

            var wall3 = new Wall(
                _pixel,
                new Vector2(40f, 40f),     // left wall
                new Vector2(20f, 400f),
                Color.DarkGray
            );
            _world.Add(wall3);

            var wall4 = new Wall(
                _pixel,
                new Vector2(740f, 40f),    // right wall
                new Vector2(20f, 400f),
                Color.DarkGray
            );
            _world.Add(wall4);

            // Central horizontal wall
            var wall5 = new Wall(
                _pixel,
                new Vector2(200f, 220f),
                new Vector2(400f, 20f),
                Color.DarkGray
            );
            _world.Add(wall5);

            // Short vertical wall above center
            var wall6 = new Wall(
                _pixel,
                new Vector2(380f, 140f),
                new Vector2(20f, 80f),
                Color.DarkGray
            );
            _world.Add(wall6);

            // Short vertical wall below center
            var wall7 = new Wall(
                _pixel,
                new Vector2(380f, 240f),
                new Vector2(20f, 80f),
                Color.DarkGray
            );
            _world.Add(wall7);

            // Left-side vertical wall
            var wall8 = new Wall(
                _pixel,
                new Vector2(140f, 120f),
                new Vector2(20f, 200f),
                Color.DarkGray
            );
            _world.Add(wall8);

            // Right-side vertical wall
            var wall9 = new Wall(
                _pixel,
                new Vector2(640f, 120f),
                new Vector2(20f, 200f),
                Color.DarkGray
            );
            _world.Add(wall9);

            // Small block in top-left area
            var wall10 = new Wall(
                _pixel,
                new Vector2(200f, 100f),
                new Vector2(80f, 20f),
                Color.DarkGray
            );
            _world.Add(wall10);

            // Small block in bottom-left area
            var wall11 = new Wall(
                _pixel,
                new Vector2(200f, 340f),
                new Vector2(80f, 20f),
                Color.DarkGray
            );
            _world.Add(wall11);

            //small block in bottom-right area
            var wall12 = new Wall(
                _pixel,
                new Vector2(560f, 340f),
                new Vector2(80f, 20f),
                Color.DarkGray
            );
            _world.Add(wall12);                   
            //WALLS

            //bouncer- moving object in game
            var bouncer = new Bouncer(
                _pixel,
                new Vector2(400f, 240f),      //start position - centre-ish of the map
                new Vector2(24f, 24f),        //size of square
                new Vector2(150f, 120f),      //velocity (x,y)
                Color.OrangeRed               //colour
            );
            _world.Add(bouncer);

        }

        protected override void Update(GameTime gameTime)
        {
            //ESC to quit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            _world.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _world.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
