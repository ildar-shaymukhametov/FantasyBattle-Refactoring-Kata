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
            return new Damage(Math.Max(0, CalculateTotalDamage() - other.GetSoak()));
        }

        public override int GetSoak()
        {
            return (int)Math.Round(equipment.GetBaseDamage() * stats.GetSoakModifier(), 0);
        }

        private int CalculateTotalDamage()
        {
            var damageModifier = stats.GetDamageModifier() + equipment.GetDamageModifier();
            return (int)Math.Round(equipment.GetBaseDamage() * damageModifier, 0);
        }
    }
}