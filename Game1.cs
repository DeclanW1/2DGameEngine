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


            //TEST WALLS
            var wall1 = new Wall(
                _pixel,
                new Vector2(200f, 150f),   // position
                new Vector2(200f, 20f),    // width + height
                Color.DarkGray
            );
            _world.Add(wall1);

            var wall2 = new Wall(
                _pixel,
                new Vector2(80f, 220f),
                new Vector2(20f, 200f),
                Color.DarkGray
            );
            _world.Add(wall2);
            //TEST WALLS   
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
