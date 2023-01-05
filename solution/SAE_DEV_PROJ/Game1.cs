﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using System;

namespace SAE_DEV_PROJ
{
    public class Game1 : Game
    {
        private readonly ScreenManager _screenManager;
        private GraphicsDeviceManager _graphics;
        HomeScreen _homeScreen;
        PlayScreen _playScreen;
        DeadScreen _deadScreen;
        WinScreen _winScreen;
        private bool _loaded;
        public bool _screenDeathOk;
        public bool _screenWinOk;
        public bool _actif;



        public SpriteBatch SpriteBatch { get; set; }

        public Game1()
        {
            _screenManager = new ScreenManager();
            Components.Add(_screenManager);

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _actif = false;
            _screenDeathOk = false;
            _screenWinOk = false;
            _loaded = false;
            SetupWindow();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _homeScreen = new HomeScreen(this); // en leur donnant une référence au Game
            _playScreen = new PlayScreen(this);
            _deadScreen = new DeadScreen(this);
            _winScreen = new WinScreen(this);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        { 
            KeyboardState keyboardState = Keyboard.GetState();
            if (!_loaded)
            {
                _screenManager.LoadScreen(_homeScreen, new FadeTransition(GraphicsDevice, Color.Black));
                _loaded = true;
            }
            if (_actif)
            {
                if (keyboardState.IsKeyDown(Keys.Back))
                {
                    _screenManager.LoadScreen(_homeScreen, new FadeTransition(GraphicsDevice, Color.Black));
                }
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    _screenManager.LoadScreen(_playScreen, new FadeTransition(GraphicsDevice, Color.Black));
                    
                }
                if (keyboardState.IsKeyDown(Keys.Q))
                {
                    Exit();
                }
            }
            if (!_playScreen._alive && !_screenDeathOk)
            {
                _screenManager.LoadScreen(_deadScreen, new FadeTransition(GraphicsDevice, Color.Black));
                _screenDeathOk = true;
            }
            if (!_playScreen._bossAlive && !_screenWinOk)
            {
                _screenManager.LoadScreen(_winScreen, new FadeTransition(GraphicsDevice, Color.Black));
                _screenWinOk = true;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public void SetupWindow()
        {
            _graphics.PreferredBackBufferWidth = Constantes._LARGEUR_FENETRE;
            _graphics.PreferredBackBufferHeight = Constantes._HAUTEUR_FENETRE;
            _graphics.ApplyChanges();
        }

    }
}