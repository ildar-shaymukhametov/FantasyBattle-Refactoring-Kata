namespace FantasyBattle
{
    public class Stats
    {
        // TODO add dexterity that will both help with soak and damage.
        //  but half of what strength gives.
        private int strength { get; }

        public Stats(int strength)
        {
            this.strength = strength;
        }

        public float GetDamageModifier()
        {
            return strength * 0.1f;
        }
    }
}