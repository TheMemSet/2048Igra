using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Test
{
    enum Move
    { 
        Up, Down, Left, Right
    };
    
    partial class GameBoard // (0, 0) je GORNJI LIJEVI UGAO!
    {
        Tile[,] boardTile = new Tile[4, 4];
        int score = 0, moveCount = 0;

        public GameBoard()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++) boardTile[i, j] = new Tile();
            }
            Random rand = new Random();

            int targetI, targetJ;
            targetI = rand.Next(0, 4);
            targetJ = rand.Next(0, 4);

            boardTile[targetI, targetJ].InitializeValue();

            int targetI2 = targetI, targetJ2 = targetJ;
            
            while ((targetI == targetI2) && (targetJ == targetJ2))
            {
                targetI2 = rand.Next(0, 4);
                targetJ2 = rand.Next(0, 4);
            }

            boardTile [targetI2, targetJ2].InitializeValue();
        }
        
        public void MoveTiles(Move move)
        {
            if (move == Move.Up)
            {
                MoveUp();
            }
            else if (move == Move.Right)
            {
                MoveRight();
            }
            if (move == Move.Down)
            {
                MoveDown();
            }
            if (move == Move.Left)
            {
                MoveLeft();
            }
        }

        public int GetTile(int i, int j)
        {
            return boardTile[i, j].GetValue();
        }

        void SetRandomNumber()
        {
            int emptyTiles = EmptyTiles();
            int targetI = 0, targetJ = 0;
            Random rand = new Random();
            
            if (emptyTiles == 0) return;
            else
            {
                emptyTiles = rand.Next(0, emptyTiles);
                
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (boardTile[i, j].GetValue() == 0)
                        {
                            if (emptyTiles == 0)
                            {
                                targetI = i;
                                targetJ = j;
                            }
                            emptyTiles--;
                        }
                    }
                }
            }

            boardTile[targetI, targetJ].InitializeValue();

            if (rand.Next(0, 10) == 5) boardTile[targetI, targetJ].DoubleValue();
        }

        int EmptyTiles()
        {
            int emptyTiles = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (boardTile[i, j].GetValue() == 0) emptyTiles++;
                }
            }

            return emptyTiles;
        }

        public int MaxTile()
        {
            int maxTile = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    maxTile = Math.Max(maxTile, boardTile[i, j].GetDisplayValue());
                }
            }

            return maxTile;
        }

        void SwapTile(ref Tile t1, ref Tile t2)
        {
            Tile temp = t1;
            t1 = t2;
            t2 = temp;
        }

        public int GetScore()
        {
            return score;
        }

        public int GetMoveCount()
        {
            return moveCount;
        }
    }
}
