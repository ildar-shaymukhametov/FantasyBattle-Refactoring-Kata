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
        private readonly Item leftHand;
        private readonly Item rightHand;
        private readonly Item head;
        private readonly Item feet;
        private readonly Item chest;

        public Equipment(Item leftHand, Item rightHand, Item head, Item feet, Item chest)
        {
            this.leftHand = leftHand;
            this.rightHand = rightHand;
            this.head = head;
            this.feet = feet;
            this.chest = chest;
        }

        public float CalculateDamageModifier()
        {
            return leftHand.DamageModifier +
                   rightHand.DamageModifier +
                   head.DamageModifier +
                   feet.DamageModifier +
                   chest.DamageModifier;
        }

        public int CalculateBaseDamage()
        {
            return leftHand.BaseDamage +
                   rightHand.BaseDamage +
                   head.BaseDamage +
                   feet.BaseDamage +
                   chest.BaseDamage;
        }
    }

    public interface Item
    {
        int BaseDamage { get; }
        float DamageModifier { get; }
    }
}