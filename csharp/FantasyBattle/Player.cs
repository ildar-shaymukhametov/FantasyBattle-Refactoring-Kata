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
            int baseDamage = equipment.CalculateBaseDamage();
            float damageModifier = CalculateDamageModifier();
            int totalDamage = (int)Math.Round(baseDamage * damageModifier, 0);
            int soak = GetSoak(other, totalDamage);
            return new Damage(Math.Max(0, totalDamage - soak));
        }

        private int GetSoak(Target other, int totalDamage) {
            int soak = 0;
            if (other is Player) {
                // TODO: Not implemented yet
                //  Add friendly fire
                soak = totalDamage;
            } else if (other is SimpleEnemy simpleEnemy) {
                soak = simpleEnemy.CalculateSoak();
            }
            return soak;
        }

        private float CalculateDamageModifier() {
            float strengthModifier = stats.Strength * 0.1f;
            return strengthModifier + equipment.CalculateDamageModifier();
        }
    }
}