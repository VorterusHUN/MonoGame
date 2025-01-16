using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace InSchool
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Sprite sprite;
        public List<Sprite> _sprites;
        public AnimationManager ananimationManager;
        public Microsoft.Xna.Framework.Rectangle rectangle = new Rectangle(100, 100, 100, 100);
        int counter;
        int activeFrame;
        int numFrames;

        

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
            _sprites = new();
            Texture2D texture = Content.Load<Texture2D>("metro");
            sprite = new Sprite(texture, new Rectangle(100,100,200,200), Convert.ToInt32(1f));
            _sprites.Add(new Sprite(texture, new Rectangle(300,400,200,200), Convert.ToInt32(1f)));
            // TODO: use this.Content to load your game content here
            ananimationManager = new(4, 2, new System.Numerics.Vector2(8, 16));
           
        }

        protected override void Update(GameTime gameTime)
        {
            int playerPositionX =0;
            int playerPositionY =0;
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
            List<Sprite> killlist = new List<Sprite>();
            foreach (Sprite sp in _sprites)
            {   
                if (sp.position.Intersects(sprite.position))
                {
                    killlist.Add(sp);
                }
            }
            foreach (Sprite s in killlist)
            {
                _sprites.Remove(s);
            }

            // TODO: Add your update logic here
           ananimationManager.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(sprite.texture, rectangle,ananimationManager.GetFrame(), Color.White);
            for (int i = 0; i < _sprites.Count; i++)
            {
                _spriteBatch.Draw(_sprites[i].texture, _sprites[i].position, Color.White);
            }
          

            // _spriteBatch.Draw(_texture, new Rectangle(100,100,100,200),Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
