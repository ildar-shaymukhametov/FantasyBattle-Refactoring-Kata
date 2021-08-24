using System.Collections.Generic;

namespace FantasyBattle
{
    public class SimpleEnemy : Target
    {
        public Armor Armor { get; }
        public List<Buff> Buffs { get; }

        public SimpleEnemy(Armor armor = null, List<Buff> buffs = null)
        {
            Armor = armor;
            Buffs = buffs;
        }

        public int CalculateSoak()
        {
            return (int)Math.Round(GetArmorDamageSoak() * (GetBuffsSoakModifier() + 1), 0);
        }

        private float GetBuffsSoakModifier()
        {
            return Buffs?.Select(x => x.SoakModifier).Sum() ?? 0;
        }

        private int GetArmorDamageSoak()
        {
            return Armor?.DamageSoak ?? 0;
        }
    }

    public interface Buff
    {
        float SoakModifier { get; }
        float DamageModifier { get; }
    }

    public interface Armor
    {
        int DamageSoak { get; }
    }
}