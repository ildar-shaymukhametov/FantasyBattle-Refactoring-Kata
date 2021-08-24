using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FantasyBattle
{
    public class PlayerTest
    {
        [Fact]
        public void DamageCalculations()
        {
            var rightHand = new BasicItem("sword", 10, 1);
            var leftHand = new BasicItem("shield", 0, 1.5f);
            var feet = new BasicItem("boots", 0, 0.1f);
            var head = new BasicItem("helmet", 0, 1.2f);
            var chest = new BasicItem("breastplate", 0, 1.4f);
            var equipment = new Equipment(rightHand, leftHand, head, feet, chest);
            var armor = new SimpleArmor(5);
            var buffs = new List<Buff> { new BasicBuff(1, 1) };
            var enemy = new SimpleEnemy(armor, buffs);
            var damage = CreateSut(equipment).CalculateDamage(enemy);

            var expectedDamage = 42;
            Assert.Equal(expectedDamage, damage.Amount);
        }

        private static Player CreateSut(Equipment equipment = null, Stats stats = null)
        {
            return new Player(equipment, stats ?? new Stats(0));
        }
    }
}
