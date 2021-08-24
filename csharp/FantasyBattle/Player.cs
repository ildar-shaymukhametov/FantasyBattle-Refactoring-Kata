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
            return new Damage(Math.Max(0, GetTotalDamage() - other.GetSoak()));
        }

        private int GetTotalDamage()
        {
            return (int)Math.Round(equipment.GetBaseDamage() * CalculateDamageModifier(), 0);
        }

        public override int GetSoak()
        {
            return stats.GetSoak();
        }

        private float CalculateDamageModifier() {
            return stats.GetDamageModifier() + equipment.GetDamageModifier();
        }
    }
}