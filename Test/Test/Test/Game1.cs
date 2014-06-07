using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace Test
{
    enum DrawTarget
    { 
        GameBoard, EndScreen, LostScreen
    };
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //
        GameBoard gameBoard;
        int moveDelay;
        Texture2D background;
        Texture2D[] tileTexture = new Texture2D[15];
        DrawTarget drawTarget = DrawTarget.GameBoard;
        SpriteFont spriteFont;
        readonly int winScore = 2048;
        //

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsFixedTimeStep = false;
            IsMouseVisible = true;
        }

        
        protected override void Initialize()
        {
            gameBoard = new GameBoard();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            spriteFont = Content.Load<SpriteFont>("SpriteFont1");
            background = Content.Load<Texture2D>("Background");

            graphics.PreferredBackBufferHeight = background.Height;
            graphics.PreferredBackBufferWidth = background.Width;
            graphics.ApplyChanges();

            for (int i = 0; i < 11; i++)
            {
                tileTexture[i] = Content.Load<Texture2D>(Math.Pow(2, (i + 1)).ToString());
            }
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) this.Exit();

            else if (gameBoard.MaxTile() == winScore)
            {
                drawTarget = DrawTarget.EndScreen;
            }

            else if (moveDelay > 0) moveDelay--;

            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    gameBoard.MoveTiles(Move.Up);
                    moveDelay = 30;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    gameBoard.MoveTiles(Move.Right);
                    moveDelay = 30;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    gameBoard.MoveTiles(Move.Down);
                    moveDelay = 30;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    gameBoard.MoveTiles(Move.Left);
                    moveDelay = 30;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.R))
                {
                    if ((drawTarget == DrawTarget.EndScreen) || (drawTarget == DrawTarget.LostScreen))
                    {
                        drawTarget = DrawTarget.GameBoard;
                    }
                    
                    gameBoard = new GameBoard();
                    moveDelay = 30;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Q))
                {
                    drawTarget = DrawTarget.LostScreen;
                }
            }
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            if (drawTarget == DrawTarget.GameBoard)
            {
                spriteBatch.Draw(background, Vector2.Zero, Color.White);
                spriteBatch.DrawString(spriteFont, "Score: " + gameBoard.GetScore().ToString(), Vector2.Zero, Color.White);
                
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (gameBoard.GetTile(i, j) != 0)
                        spriteBatch.Draw(tileTexture[gameBoard.GetTile(i, j) - 1], new Vector2(32 + (128 * j), 32 + (128 * i)), Color.White);
                    }
                }
            }
            else if (drawTarget == DrawTarget.EndScreen)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                spriteBatch.DrawString(spriteFont, EndScreenText (gameBoard.GetScore(), gameBoard.GetMoveCount()), Vector2.Zero, Color.White);
            }
            else if (drawTarget == DrawTarget.LostScreen)
            {
                GraphicsDevice.Clear(Color.Pink);
                spriteBatch.DrawString(spriteFont, LostScreenText(gameBoard.GetScore(), gameBoard.GetMoveCount()), Vector2.Zero, Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

        String EndScreenText(int score, int moveCount)
        {
            return ("Congrats! Your final score is " + score.ToString() + " points in " + moveCount.ToString() + " moves!");
        }

        String LostScreenText(int score, int moveCount)
        {
            return ("You lost! Your final score is " + score.ToString() + " points in " + moveCount.ToString() + " moves!");
        }
    }
}
