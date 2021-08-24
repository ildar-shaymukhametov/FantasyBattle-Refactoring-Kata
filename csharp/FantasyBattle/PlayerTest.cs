using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FantasyBattle
{
    public class PlayerTest
    {
        [Fact]
        public void Empty_equipment()
        {
            var damage = CreateSut(new Equipment()).CalculateDamage(new SimpleEnemy());

            var expectedDamage = 0;
            Assert.Equal(expectedDamage, damage.Amount);
        }

        [Fact]
        public void Equip_ring()
        {
            var leftHand = new BasicItem("sword", 20, 1);
            var ring = new BasicItem("ring", 0, 0.3f);
            var equipment = new Equipment(ring: ring, leftHand: leftHand);
            var damage = CreateSut(equipment).CalculateDamage(CreateEnemy());

            var expectedDamage = 16;
            Assert.Equal(expectedDamage, damage.Amount);
        }

        [Fact]
        public void Enemy_without_armor_and_buffs()
        {
            var leftHand = new BasicItem("sword", 20, 1);
            var equipment = new Equipment(leftHand);
            var damage = CreateSut(equipment).CalculateDamage(new SimpleEnemy());

            var expectedDamage = 20;
            Assert.Equal(expectedDamage, damage.Amount);
        }

        [Fact]
        public void Enemy_with_armor_and_buffs()
        {
            var leftHand = new BasicItem("sword", 20, 1);
            var equipment = new Equipment(leftHand);
            var enemy = CreateEnemy();
            var damage = CreateSut(equipment).CalculateDamage(enemy);

            var expectedDamage = 10;
            Assert.Equal(expectedDamage, damage.Amount);
        }

        [Fact]
        public void Strength()
        {
            var strength = 10;
            var leftHand = new BasicItem("sword", 20, 1);
            var equipment = new Equipment(leftHand);
            var enemy = CreateEnemy();
            var damage = CreateSut(equipment, new Stats(strength)).CalculateDamage(enemy);

            var expectedDamage = 30;
            Assert.Equal(expectedDamage, damage.Amount);
        }

        private static SimpleEnemy CreateEnemy()
        {
            var armor = new SimpleArmor(5);
            var buffs = new List<Buff> { new BasicBuff(1, 1) };
            return new SimpleEnemy(armor, buffs);
        }

        private static Player CreateSut(Equipment equipment = null, Stats stats = null)
        {
            return new Player(equipment, stats ?? new Stats(0));
        }
    }
}
