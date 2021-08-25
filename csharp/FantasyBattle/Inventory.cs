namespace FantasyBattle
{
    public class Inventory
    {
        public Equipment Equipment { get; }

        public Inventory(Equipment equipment)
        {
            Equipment = equipment;
        }
    }

    public class Equipment
    {
        private readonly List<Item> items;

        public Equipment(Item leftHand = null, Item rightHand = null, Item head = null, Item feet = null, Item chest = null, Item ring = null)
        {
            items = new List<Item> { leftHand, rightHand, head, feet, chest, ring };
        }

        public float GetDamageModifier()
        {
            return items.Sum(x => x?.DamageModifier) ?? 1;
        }

        public int GetBaseDamage()
        {
            return items.Sum(x => x?.BaseDamage) ?? 0;
        }
    }

    public interface Item
    {
        int BaseDamage { get; }
        float DamageModifier { get; }
    }
}