using System.Collections.Generic;

namespace FantasyBattle
{
    public class SimpleEnemy : Target
    {
        private Armor armor { get; }
        private List<Buff> buffs { get; }

        public SimpleEnemy(Armor armor = null, List<Buff> buffs = null)
        {
            this.armor = armor;
            this.buffs = buffs;
        }

        public override int GetSoak()
        {
            return (int)Math.Round(GetArmorDamageSoak() * (GetBuffsSoakModifier() + 1), 0);
        }

        private float GetBuffsSoakModifier()
        {
            return buffs?.Select(x => x.SoakModifier).Sum() ?? 0;
        }

        private int GetArmorDamageSoak()
        {
            return armor?.DamageSoak ?? 0;
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