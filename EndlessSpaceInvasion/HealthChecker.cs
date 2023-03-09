namespace EndlessSpaceInvasion
{
    public static class HealthChecker
    {
        public static bool IsDead(int currentHealth)
            => currentHealth < 1;
    }
}
