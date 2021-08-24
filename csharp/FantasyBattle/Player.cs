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
            var damageModifier = stats.GetDamageModifier() + equipment.GetDamageModifier();
            var totalDamage = (int)Math.Round(equipment.GetBaseDamage() * damageModifier, 0);
            return new Damage(Math.Max(0, totalDamage - other.GetSoak()));
        }

        public override int GetSoak()
        {
            return stats.GetSoak();
        }
    }
}