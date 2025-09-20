using ConsoleMaze.Classes;

namespace ConsoleMaze.Services;

public class MoveRight : IMovable
{
    public void MakeMove(Player player)
    {
        player.SetNewPosition(player.PlayerRow , player.PlayerCol + 1);
    }
}
