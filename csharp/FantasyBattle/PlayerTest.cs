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
            var leftHand = new BasicItem("sword", 20, 1);
            var equipment = new Equipment(leftHand);
            var armor = new SimpleArmor(5);
            var buffs = new List<Buff> { new BasicBuff(1, 1) };
            var enemy = new SimpleEnemy(armor, buffs);
            var damage = CreateSut(equipment).CalculateDamage(enemy);

            var expectedDamage = 10;
            Assert.Equal(expectedDamage, damage.Amount);
        }

        private static Player CreateSut(Equipment equipment = null, Stats stats = null)
        {
            return new Player(equipment, stats ?? new Stats(0));
        }
    }
}
