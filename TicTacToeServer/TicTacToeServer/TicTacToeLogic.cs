using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToeServer
{
    public class TicTacToeLogic
    {
        public enum STATE_CELL { EMPTY, TIC, TOE};
        public enum VERDICT { ERROR, CONTINUE, DRAW, TIC_WINS, TOE_WINS, NONE};
        public const int MAX_TURN = 9;
        public const int MAX_COL = 3;
        public const int MAX_ROW = 3;

        public static void InitGame(int num_turn, STATE_CELL[,] GameArea)
        {
            for(int i = 0; i < MAX_ROW; i++)
            {
                for(int j = 0; j < MAX_COL; j++)
                {
                    GameArea[i, j] = STATE_CELL.EMPTY;
                }
            }
        }

        public static STATE_CELL WhoseTurn(int num_turn)
        {
            if(num_turn % 2 == 0)
            {
                return STATE_CELL.TIC;
            }

            return STATE_CELL.TOE;
        }

        public static VERDICT ToeMoved(int row, int col, int num_turn, STATE_CELL[,] GameArea)
        {
            STATE_CELL cur_state = GameArea[row, col];

            if(cur_state == STATE_CELL.EMPTY)
            {
                GameArea[row, col] = STATE_CELL.TOE;
                num_turn++;
                return DetermineVerdict(row, col, num_turn, GameArea);
            }
            else
            {
                return VERDICT.ERROR;
            }
        }

        public static VERDICT TickMoved(int row, int col, int num_turn, STATE_CELL[,] GameArea)
        {
            STATE_CELL cur_state = GameArea[row, col];

            if (cur_state == STATE_CELL.EMPTY)
            {
                GameArea[row, col] = STATE_CELL.TIC;
                num_turn++;
                return DetermineVerdict(row, col, num_turn, GameArea);
            }
            else
            {
                return VERDICT.ERROR;
            }
        }

        private static VERDICT DetermineVerdict(int row, int col, int num_turn, STATE_CELL[,] GameArea)
        {
            STATE_CELL cur_state = GameArea[row, col];

            if(row == 0 && col == 0)
            {
                if(GameArea[0, 1] == cur_state && GameArea[0, 2] == cur_state ||
                   GameArea[1, 0] == cur_state && GameArea[2, 0] == cur_state ||
                   GameArea[1, 1] == cur_state && GameArea[2, 2] == cur_state)
                {
                    if(cur_state == STATE_CELL.TIC)
                    {
                        return VERDICT.TIC_WINS;
                    }

                    return VERDICT.TOE_WINS;
                }
            }

            if (row == 0 && col == 1)
            {
                if (GameArea[0, 0] == cur_state && GameArea[0, 2] == cur_state ||
                    GameArea[1, 1] == cur_state && GameArea[2, 1] == cur_state )
                {
                    if (cur_state == STATE_CELL.TIC)
                    {
                        return VERDICT.TIC_WINS;
                    }

                    return VERDICT.TOE_WINS;
                }
            }

            if (row == 0 && col == 2)
            {
                if (GameArea[0, 0] == cur_state && GameArea[0, 1] == cur_state ||
                   GameArea[1, 2] == cur_state && GameArea[2, 2] == cur_state ||
                   GameArea[1, 1] == cur_state && GameArea[2, 0] == cur_state)
                {
                    if (cur_state == STATE_CELL.TIC)
                    {
                        return VERDICT.TIC_WINS;
                    }

                    return VERDICT.TOE_WINS;
                }
            }

            if (row == 1 && col == 0)
            {
                if (GameArea[0, 0] == cur_state && GameArea[2, 0] == cur_state ||
                    GameArea[1, 1] == cur_state && GameArea[1, 2] == cur_state)
                {
                    if (cur_state == STATE_CELL.TIC)
                    {
                        return VERDICT.TIC_WINS;
                    }

                    return VERDICT.TOE_WINS;
                }
            }

            if (row == 1 && col == 1)
            {
                if (GameArea[0, 0] == cur_state && GameArea[2, 2] == cur_state ||
                    GameArea[0, 2] == cur_state && GameArea[2, 0] == cur_state ||
                    GameArea[0, 1] == cur_state && GameArea[2, 1] == cur_state ||
                    GameArea[1, 0] == cur_state && GameArea[1, 2] == cur_state)
                {
                    if (cur_state == STATE_CELL.TIC)
                    {
                        return VERDICT.TIC_WINS;
                    }

                    return VERDICT.TOE_WINS;
                }
            }

            if (row == 1 && col == 2)
            {
                if (GameArea[0, 2] == cur_state && GameArea[2, 2] == cur_state ||
                    GameArea[1, 1] == cur_state && GameArea[1, 0] == cur_state)
                {
                    if (cur_state == STATE_CELL.TIC)
                    {
                        return VERDICT.TIC_WINS;
                    }

                    return VERDICT.TOE_WINS;
                }
            }

            if (row == 2 && col == 0)
            {
                if (GameArea[0, 0] == cur_state && GameArea[1, 0] == cur_state ||
                    GameArea[2, 1] == cur_state && GameArea[2, 2] == cur_state ||
                    GameArea[1, 1] == cur_state && GameArea[0, 2] == cur_state)
                {
                    if (cur_state == STATE_CELL.TIC)
                    {
                        return VERDICT.TIC_WINS;
                    }

                    return VERDICT.TOE_WINS;
                }
            }

            if (row == 2 && col == 1)
            {
                if (GameArea[1, 1] == cur_state && GameArea[0, 1] == cur_state ||
                    GameArea[2, 0] == cur_state && GameArea[2, 2] == cur_state)
                {
                    if (cur_state == STATE_CELL.TIC)
                    {
                        return VERDICT.TIC_WINS;
                    }

                    return VERDICT.TOE_WINS;
                }
            }

            if (row == 2 && col == 2)
            {
                if (GameArea[2, 1] == cur_state && GameArea[2, 0] == cur_state ||
                    GameArea[1, 2] == cur_state && GameArea[0, 2] == cur_state ||
                    GameArea[1, 1] == cur_state && GameArea[0, 0] == cur_state)
                {
                    if (cur_state == STATE_CELL.TIC)
                    {
                        return VERDICT.TIC_WINS;
                    }

                    return VERDICT.TOE_WINS;
                }
            }

            if (num_turn < MAX_TURN)
            {
                return VERDICT.CONTINUE;
            }

            return VERDICT.DRAW;
        }
    }
}