using System;
using System.Linq;

namespace FantasyBattle
{
    public class Player : Target
    {
        public Equipment Equipment { get; }
        public Stats Stats { get; }

        public Player(Equipment equipment, Stats stats)
        {
            Equipment = equipment;
            Stats = stats;
        }

        public Damage CalculateDamage(Target other)
        {
            int baseDamage = CalculateBaseDamage();
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
                soak = (int)Math.Round(
                    simpleEnemy.Armor.DamageSoak *
                    (
                        simpleEnemy.Buffs.Select(x => x.SoakModifier).Sum() + 1
                    ), 0
                );
            }
            return soak;
        }

        private float CalculateDamageModifier() {
            Item leftHand = Equipment.LeftHand;
            Item rightHand = Equipment.RightHand;
            Item head = Equipment.Head;
            Item feet = Equipment.Feet;
            Item chest = Equipment.Chest;
            float strengthModifier = Stats.Strength * 0.1f;
            return strengthModifier +
                   leftHand.DamageModifier +
                   rightHand.DamageModifier +
                   head.DamageModifier +
                   feet.DamageModifier +
                   chest.DamageModifier;
        }

        private int CalculateBaseDamage() {
            Item leftHand = Equipment.LeftHand;
            Item rightHand = Equipment.RightHand;
            Item head = Equipment.Head;
            Item feet = Equipment.Feet;
            Item chest = Equipment.Chest;
            return leftHand.BaseDamage +
                   rightHand.BaseDamage +
                   head.BaseDamage +
                   feet.BaseDamage +
                   chest.BaseDamage;
        }
    }
}