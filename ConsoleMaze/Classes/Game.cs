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
            maze.PrintMap();

        }
    }
}
