using ConsoleMaze.Services;

namespace ConsoleMaze.Classes;

public class Player
{
    public int PlayerRow { get; set; }
    public int PlayerCol { get; set; }
    private char[,] currentMap;
    private Dictionary<ConsoleKey, IMovable> moves;

    public Player(char[,] map)
    {
        currentMap = map;
        SetStartPosition();
        moves = new Dictionary<ConsoleKey, IMovable>
        {
            { ConsoleKey.UpArrow, new MoveUp() },
            { ConsoleKey.DownArrow, new MoveDown() },
            { ConsoleKey.LeftArrow, new MoveLeft() },
            { ConsoleKey.RightArrow, new MoveRight() },
        };
    }

    public void Move(ConsoleKey key)
    {
        if (moves.ContainsKey(key))
        {
            moves[key].MakeMove(this);
        }
    }

    public void SetStartPosition()
    {
        for (int r = 0; r < currentMap.GetLength(0); r++)
        {
            for (int c = 0; c < currentMap.GetLength(1); c++)
            {
                if (currentMap[r, c] == 'E')
                {
                    PlayerRow = r;
                    PlayerCol = c;
                    return;
                }
            }
        }
    }

    public (int row, int col) GetCurrentPosition()
    {
        return (PlayerRow, PlayerCol);
    }

    public void SetNewPosition(int newRow, int newCol)
    {
        if (IsMoveValid(newRow, newCol))
        {
            PlayerRow = newRow;
            PlayerCol = newCol;
        }
    }

    private bool IsMoveValid(int row, int col)
    {
        if (row < 0 || row >= currentMap.GetLength(0))
        {
            return false;
        }

        if (col < 0 || col >= currentMap.GetLength(1))
        {
            return false;
        }

        if (currentMap[row, col] == '#')
        {
            return false;
        }
        return true;
    }
}
