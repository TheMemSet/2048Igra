using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    partial class GameBoard // (0, 0) je GORNJI LIJEVI UGAO!
    {
        Boolean MoveUp()
        {
            Boolean moved = false;
            for (int column = 0; column < 4; column++)
            {
                for (int cascade = 0; cascade < 4; cascade++)
                {
                    for (int row = 0; row < 3; row++)
                    {
                        if ((boardTile[row, column].GetValue() == 0) && (boardTile[row + 1, column].GetValue() != 0))
                        {
                            SwapTile(ref boardTile[row, column], ref boardTile[row + 1, column]);

                            if (!moved) moveCount++;
                            
                            moved = true;
                        }
                    }
                }

                for (int row = 0; row < 3; row++)
                {
                    if ((boardTile[row, column].GetValue() != 0) && (boardTile[row, column].GetValue() == boardTile[row + 1, column].GetValue()))
                    {
                        score += boardTile[row, column].GetDisplayValue();
                        boardTile[row, column].DoubleValue();
                        boardTile[row + 1, column].ResetValue();

                        if (!moved) moveCount++;

                        moved = true;
                    }
                }

                for (int cascade = 0; cascade < 4; cascade++)
                {
                    for (int row = 0; row < 3; row++)
                    {
                        if ((boardTile[row, column].GetValue() == 0) && (boardTile[row + 1, column].GetValue() != 0))
                        {
                            SwapTile(ref boardTile[row, column], ref boardTile[row + 1, column]);
                            moved = true;
                        }
                    }
                }
            }

            if (moved) SetRandomNumber();
            return moved; 
        }

        Boolean MoveLeft()
        {
            Boolean moved = false;
            for (int row = 0; row < 4; row++)
            {
                for (int cascade = 0; cascade < 4; cascade++)
                {
                    for (int column = 0; column < 3; column++)
                    {
                        if ((boardTile[row, column].GetValue() == 0) && (boardTile[row, column + 1].GetValue() != 0))
                        {
                            SwapTile(ref boardTile[row, column], ref boardTile[row, column + 1]);

                            if (!moved) moveCount++;

                            moved = true;
                        }
                    }
                }

                for (int column = 0; column < 3; column++)
                {
                    if ((boardTile[row, column].GetValue() != 0) && (boardTile[row, column].GetValue() == boardTile[row, column + 1].GetValue()))
                    {
                        score += boardTile[row, column].GetDisplayValue();
                        boardTile[row, column].DoubleValue();
                        boardTile[row, column + 1].ResetValue();

                        if (!moved) moveCount++;

                        moved = true;
                    }
                }

                for (int cascade = 0; cascade < 4; cascade++)
                {
                    for (int column = 0; column < 3; column++)
                    {
                        if ((boardTile[row, column].GetValue() == 0) && (boardTile[row, column + 1].GetValue() != 0))
                        {
                            SwapTile(ref boardTile[row, column], ref boardTile[row, column + 1]);

                            if (!moved) moveCount++;

                            moved = true;
                        }
                    }
                }
            }

            if (moved) SetRandomNumber();
            return moved; 
        }

        Boolean MoveDown()
        {
            Boolean moved = false;
            for (int column = 0; column < 4; column++)
            {
                for (int cascade = 0; cascade < 4; cascade++)
                {
                    for (int row = 3; row > 0; row--)
                    {
                        if ((boardTile[row, column].GetValue() == 0) && (boardTile[row - 1, column].GetValue() != 0))
                        {
                            SwapTile(ref boardTile[row, column], ref boardTile[row - 1, column]);

                            if (!moved) moveCount++;

                            moved = true;
                        }
                    }
                }

                for (int row = 3; row > 0; row--)
                {
                    if ((boardTile[row, column].GetValue() != 0) && (boardTile[row, column].GetValue() == boardTile[row- 1, column].GetValue()))
                    {
                        score += boardTile[row, column].GetDisplayValue();
                        boardTile[row, column].DoubleValue();
                        boardTile[row - 1, column].ResetValue();

                        if (!moved) moveCount++;

                        moved = true;
                    }
                }

                for (int cascade = 0; cascade < 4; cascade++)
                {
                    for (int row = 3; row > 0; row--)
                    {
                        if ((boardTile[row, column].GetValue() == 0) && (boardTile[row - 1, column].GetValue() != 0))
                        {
                            SwapTile(ref boardTile[row, column], ref boardTile[row - 1, column]);
                            moved = true;
                        }
                    }
                }
            }

            if (moved) SetRandomNumber();
            return moved; 
        }

        Boolean MoveRight()
        {
            Boolean moved = false;
            for (int row = 0; row < 4; row++)
            {
                for (int cascade = 0; cascade < 4; cascade++)
                {
                    for (int column = 3; column > 0; column--)
                    {
                        if ((boardTile[row, column].GetValue() == 0) && (boardTile[row, column - 1].GetValue() != 0))
                        {
                            SwapTile(ref boardTile[row, column], ref boardTile[row, column - 1]);

                            if (!moved) moveCount++;

                            moved = true;
                        }
                    }
                }

                for (int column = 3; column > 0; column--)
                {
                    if ((boardTile[row, column].GetValue() != 0) && (boardTile[row, column].GetValue() == boardTile[row, column - 1].GetValue()))
                    {
                        score += boardTile[row, column].GetDisplayValue();
                        boardTile[row, column].DoubleValue();
                        boardTile[row, column - 1].ResetValue();

                        if (!moved) moveCount++;

                        moved = true;
                    }
                }

                for (int cascade = 0; cascade < 4; cascade++)
                {
                    for (int column = 3; column > 0; column--)
                    {
                        if ((boardTile[row, column].GetValue() == 0) && (boardTile[row, column - 1].GetValue() != 0))
                        {
                            SwapTile(ref boardTile[row, column], ref boardTile[row, column - 1]);

                            if (!moved) moveCount++;

                            moved = true;
                        }
                    }
                }
            }

            if (moved) SetRandomNumber();
            return moved; 
        }
    }
}
