using ConsoleMaze.Classes;

namespace ConsoleMaze.Services;

public class MoveDown : IMovable
{
    public void MakeMove(Player player)
    {
        player.SetNewPosition(player.PlayerRow + 1, player.PlayerCol);
    }
}
