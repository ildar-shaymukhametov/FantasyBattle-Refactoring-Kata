using System.Collections.Generic;

namespace FantasyBattle
{
    public class SimpleEnemy : Target
    {
        public Armor Armor { get; }
        public List<Buff> Buffs { get; }

        public SimpleEnemy(Armor armor, List<Buff> buffs)
        {
            Armor = armor;
            Buffs = buffs;
        }

        public int CalculateSoak()
        {
            return (int)Math.Round(Armor.DamageSoak * (Buffs.Select(x => x.SoakModifier).Sum() + 1), 0);
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