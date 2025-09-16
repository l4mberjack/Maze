using System.Drawing;
using ConsoleMaze;

public class Maze
{
    private Random random = new();
    private List<char[,]> maps = new();
    private char[,] currentMap;


    public void InitMapsList()
    {
        for (int i = 1; i < 6; i++)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Maps", $"maze{i}.txt");
            var lines = File.ReadAllLines(filePath);
            int rows = lines.Length;
            int cols = lines[0].Length;
            var maze = new char[rows, cols];

            for(int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
            {
                maze[r, c] = lines[r][c];
            }
            maps.Add(maze);
        }
    }

    public void SelectRandomMap()
    {
        currentMap = maps[random.Next(maps.Count)];
    }

    public char[,] GetCurrentMap()
    {
        return currentMap;
    }
}
