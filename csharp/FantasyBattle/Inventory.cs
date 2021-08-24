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
        // TODO add a ring item that may be equipped
        //  that may also add damage modifier
        private readonly List<Item> items;

        public Equipment(Item leftHand = null, Item rightHand = null, Item head = null, Item feet = null, Item chest = null)
        {
            items = new List<Item> { leftHand, rightHand, head, feet, chest };
        }

        public float CalculateDamageModifier()
        {
            return items.Sum(x => x?.DamageModifier) ?? 1;
        }

        public int CalculateBaseDamage()
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