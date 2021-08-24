using System;
using System.Linq;

namespace FantasyBattle
{
    public class Player : Target
    {
        private Equipment equipment { get; }
        private Stats stats { get; }

        public Player(Equipment equipment, Stats stats)
        {
            this.equipment = equipment;
            this.stats = stats;
        }

        public Damage CalculateDamage(Target other)
        {
            int totalDamage = GetTotalDamage();
            int soak = other.GetSoak();
            return new Damage(Math.Max(0, totalDamage - soak));
        }

        private int GetTotalDamage()
        {
            int baseDamage = equipment.CalculateBaseDamage();
            float damageModifier = CalculateDamageModifier();
            return (int)Math.Round(baseDamage * damageModifier, 0);
        }

        public override int GetSoak()
        {
            // TODO: Not implemented yet
            //  Add friendly fire
            return GetTotalDamage();
        }

        private float CalculateDamageModifier() {
            float strengthModifier = stats.Strength * 0.1f;
            return strengthModifier + equipment.CalculateDamageModifier();
        }
    }
}