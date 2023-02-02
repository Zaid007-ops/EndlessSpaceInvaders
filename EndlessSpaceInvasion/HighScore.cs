using System;

namespace EndlessSpaceInvasion
{
    public class HighScore
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }
        public DateTime Created { get; set; }
    }
}
