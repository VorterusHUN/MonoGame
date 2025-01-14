using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace InSchool
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Sprite sprite;
        //Texture2D _texture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //_texture = Content.Load<Texture2D>("metro");
            Texture2D texture = Content.Load<Texture2D>("metro");
            sprite = new Sprite(texture, Vector2.Zero, 1f);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                sprite.position.X += sprite.speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                sprite.position.X -= sprite.speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                sprite.position.Y -= sprite.speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                sprite.position.Y += sprite.speed;
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(sprite.texture, sprite.position, Color.White);
            // _spriteBatch.Draw(_texture, new Rectangle(100,100,100,200),Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
