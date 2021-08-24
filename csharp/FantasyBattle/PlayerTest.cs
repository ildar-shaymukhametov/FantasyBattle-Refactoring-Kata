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
            var ring = new BasicItem("ring", 0, 0.3f);
            var equipment = CreateEquipment(ring: ring);
            var damage = CreateSut(equipment).CalculateDamage(CreateEnemy());

            var expectedDamage = 16;
            Assert.Equal(expectedDamage, damage.Amount);
        }

        [Fact]
        public void Enemy_without_armor_and_buffs()
        {
            var equipment = CreateEquipment();
            var damage = CreateSut(equipment).CalculateDamage(new SimpleEnemy());

            var expectedDamage = 20;
            Assert.Equal(expectedDamage, damage.Amount);
        }

        [Fact]
        public void Friendly_fire()
        {
            var anotherPlayerDexterity = 10;
            var equipment = CreateEquipment();
            var damage = CreateSut(equipment).CalculateDamage(new Player(new Equipment(), new Stats(dexterity: anotherPlayerDexterity)));

            var expectedDamage = 10;
            Assert.Equal(expectedDamage, damage.Amount);
        }

        [Fact]
        public void Enemy_with_armor_and_buffs()
        {
            var equipment = CreateEquipment();
            var enemy = CreateEnemy();
            var damage = CreateSut(equipment).CalculateDamage(enemy);

            var expectedDamage = 10;
            Assert.Equal(expectedDamage, damage.Amount);
        }

        [Fact]
        public void Strength()
        {
            var strength = 10;
            var equipment = CreateEquipment();
            var enemy = CreateEnemy();
            var damage = CreateSut(equipment, new Stats(strength)).CalculateDamage(enemy);

            var expectedDamage = 30;
            Assert.Equal(expectedDamage, damage.Amount);
        }

        [Fact]
        public void Dexterity()
        {
            var dexterity = 10;
            var equipment = CreateEquipment();
            var enemy = CreateEnemy();
            var damage = CreateSut(equipment, new Stats(dexterity: dexterity)).CalculateDamage(enemy);

            var expectedDamage = 20;
            Assert.Equal(expectedDamage, damage.Amount);
        }

        private static Equipment CreateEquipment(Item ring = null)
        {
            var leftHand = new BasicItem("sword", 20, 1);
            return new Equipment(leftHand, ring: ring);
        }

        private static SimpleEnemy CreateEnemy()
        {
            var armor = new SimpleArmor(5);
            var buffs = new List<Buff> { new BasicBuff(1, 1) };
            return new SimpleEnemy(armor, buffs);
        }

        private static Player CreateSut(Equipment equipment = null, Stats stats = null)
        {
            return new Player(equipment, stats ?? new Stats());
        }
    }
}
