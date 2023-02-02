using System;

namespace EndlessSpaceInvasion
{
    internal static class RandomNameGenerator
    {
        private static string[] _firstNames = new[]
        {
            "Abraham",
            "Amigo",
            "Baby",
            "Champ",
            "Dingbat",
            "Minion",
            "Sloppy",
            "Tootsie"
        };

        private static string[] _lastNames = new[]
        {
            "Boomer",
            "Kiddo",
            "Nugget",
            "Oldie",
            "Scout",
            "Shortie",
            "Smarty",
            "Teacup",
        };

        public static string Create()
        {
            var ran = new Random(DateTime.Now.Second);

            var firstName = _firstNames[ran.Next(0, 7)];
            var lastName = _lastNames[ran.Next(0, 7)];

            return $"{firstName} {lastName}";
        }
    }
}
