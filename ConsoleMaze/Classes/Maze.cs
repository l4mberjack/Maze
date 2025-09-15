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
            var filePath = @"C:\Users\mimit\RiderProjects\ConsoleMaze\ConsoleMaze\Maps\maze" +  i + ".txt";
            //var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Maps", $"maze{i}.txt");
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

    public void PrintMap()
    {
        var mapToPrint = maps[random.Next(maps.Count)];
        for (int r = 0; r < mapToPrint.GetLength(0); r++)
        {
            for (int c = 0; c < mapToPrint.GetLength(1); c++)
            {
                Console.Write(mapToPrint[r, c]);
            }
            Console.WriteLine();
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
