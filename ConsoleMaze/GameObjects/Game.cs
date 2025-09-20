namespace ConsoleMaze.Classes;

public class Game
{
    private Maze maze;
    private Player player;
    private bool gameIsGoing;

    public void GameInit()
    {
        maze = new Maze();
        maze.InitMapsList();
        maze.SelectRandomMap();
        player = new Player(maze.GetCurrentMap());
        player.SetStartPosition();
        gameIsGoing = true;
    }

    public void GameStart()
    {
        GameInit();
        while (gameIsGoing)
        {
            Console.Clear();
            PrintMapWithPlayer();
            HandleManage();
            CheckExit();
        }
    }

    private void PrintMapWithPlayer()
    {
        char[,] currentMap = maze.GetCurrentMap();
        var (playerRow, playerCol) = player.GetCurrentPosition();

        for (int r = 0; r < currentMap.GetLength(0); r++)
        {
            for (int c = 0; c < currentMap.GetLength(1); c++)
            {
                if (r == playerRow && c == playerCol)
                {
                    Console.Write('@');
                }
                else
                {
                    char symbol = currentMap[r, c];
                    char displaySymbol = GetSymbol(symbol);
                    Console.Write(displaySymbol);
                }
            }
            Console.WriteLine();
        }
    }

    private char GetSymbol(char symbol)
    {
        switch (symbol)
        {
            case '#':
                return '█';
            case 'E':
                return 'S';
            default:
                return symbol;
        }
    }

    private void HandleManage()
    {
        ConsoleKeyInfo pushedKey = Console.ReadKey();
        switch (pushedKey.Key)
        {
            case ConsoleKey.LeftArrow:
                player.Move(ConsoleKey.LeftArrow);
                break;
            case ConsoleKey.RightArrow:
                player.Move(ConsoleKey.RightArrow);
                break;
            case ConsoleKey.UpArrow:
                player.Move(ConsoleKey.UpArrow);
                break;
            case ConsoleKey.DownArrow:
                player.Move(ConsoleKey.DownArrow);
                break;
            case ConsoleKey.Q:
                gameIsGoing = false;
                break;
            default: return;
        }
    }

    public void CheckExit()
    {
        var playerPos = player.GetCurrentPosition();
        int row = playerPos.row;
        int col = playerPos.col;
        char[,] currentMap = maze.GetCurrentMap();
        if (currentMap[row, col] == 'X')
        {
            Console.WriteLine("Game Over!");
            gameIsGoing = false;
        }
    }
}
