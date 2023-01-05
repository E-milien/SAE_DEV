﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;

namespace SAE_DEV_PROJ
{
    public class DeadScreen : GameScreen
    {
        private SpriteBatch _spriteBatch;
        private Game1 _myGame;
        private SpriteFont _police;


        public DeadScreen(Game1 game) : base(game)
        {
            _police = Content.Load<SpriteFont>("Font");
            _myGame = game;
        }
        public override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            _myGame._actif = true;
        }
        public override void Draw(GameTime gameTime)
        {

            _myGame.GraphicsDevice.Clear(Color.DarkRed); // on utilise la reference vers Game1 pour chnager le graphisme
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_police, "You're dead", new Vector2(20, 20), Color.White);
            _spriteBatch.DrawString(_police, "Press ENTER to play again", new Vector2(500, 500), Color.Black);
            _spriteBatch.DrawString(_police, "Press Q to quit", new Vector2(500, 530), Color.Black);
            _spriteBatch.End();
        }
    }
}
