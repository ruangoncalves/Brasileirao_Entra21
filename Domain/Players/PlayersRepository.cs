using System.Collections.Generic;

namespace Domain.Players
{
    static class PlayersRepository
    {
        private static List<Player> _player = new List<Player>();
        public static IReadOnlyCollection<Player> Player => _player;

        public static void Add(Player player)
        {
            _player.Add(player);
        }
    }
}