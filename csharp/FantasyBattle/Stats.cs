namespace FantasyBattle
{
    public class Stats
    {
        // TODO add dexterity that will both help with soak and damage.
        //  but half of what strength gives.
        private int strength { get; }
        private int dexterity { get; }

        public Stats(int strength = 0, int dexterity = 0)
        {
            this.strength = strength;
            this.dexterity = dexterity;
        }

        public float GetDamageModifier()
        {
            return strength * 0.1f + ((dexterity * 0.1f) / 2);
        }
    }
}