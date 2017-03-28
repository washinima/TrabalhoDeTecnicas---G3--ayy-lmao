﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Windoes_Size_Project
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        #region Class variables defined to be globally accessible!!
        // for drawing support
        // Convention: staticClassVariable names begin with "s"
        /// <summary>
        /// sGraphicsDevice - reference to th graphics device for current display size
        /// sSpriteBatch - reference to the SpriteBatch to draw all of the primitives
        /// sContent - reference to the ContentManager to load the textures
        /// </summary>
        static public SpriteBatch sSpriteBatch;  // Drawing support
        static public ContentManager sContent;   // Loading textures
        static public GraphicsDeviceManager sGraphics; // Current display size
        static public Random sRan; // For generating random numbers
        #endregion

        #region Preferred Window Size
        // Prefer window size
        // Convention: "k" to begin constant variable names
        const int kWindowWidth = 1280;
        const int kWindowHeight = 720;
        #endregion 

        GameState mTheGame;

        const int kNumObjects = 4;

        public Game1()
        {
            // Content resource loading support
            Content.RootDirectory = "Content";
            Game1.sContent = Content;

            // Create graphics device to access window size
            Game1.sGraphics = new GraphicsDeviceManager(this);
            // set prefer window size
            Game1.sGraphics.PreferredBackBufferWidth = kWindowWidth;
            Game1.sGraphics.PreferredBackBufferHeight = kWindowHeight;
            Game1.sRan = new Random();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            Game1.sSpriteBatch = new SpriteBatch(GraphicsDevice);

            // Create the primitives
            mTheGame = new GameState();

            // NOTE: Since the creation of TextruedPrimitive involves loading of textures
            // The creation should occure in or after LoadContent()
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            // Allows the game to exit
            if (InputWrapper.Buttons.Back == ButtonState.Pressed)
                this.Exit();

            mTheGame.UpdateGame();
            if (InputWrapper.Buttons.A == ButtonState.Pressed)
                mTheGame = new GameState();

            #region Toggle full screen and window size
            // "A" to toggle full screen
            if (InputWrapper.Buttons.A == ButtonState.Pressed)
            {
                if (!Game1.sGraphics.IsFullScreen)
                {
                    Game1.sGraphics.IsFullScreen = true;
                    Game1.sGraphics.ApplyChanges();
                }
            }

            // "B" toggles back to window
            if (InputWrapper.Buttons.B == ButtonState.Pressed)
            {
                if (Game1.sGraphics.IsFullScreen)
                {
                    Game1.sGraphics.IsFullScreen = false;
                    Game1.sGraphics.ApplyChanges();
                }
            }
            #endregion



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Clear to background color
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Game1.sSpriteBatch.Begin(); // Initialize drawing support

            // Loop over and draw each primitive

            // Print out text message to echo status

            mTheGame.DrawGame();
            Game1.sSpriteBatch.End(); // inform graphics system we are done drawing

            
            base.Draw(gameTime);
        }
    }
}
