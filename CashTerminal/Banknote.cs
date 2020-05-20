public class Banknote
{
    public int Denomination { get; set; }
    public int Quantity { get; set; }

    public Banknote(int denomination, int quantity)
    {
        Denomination = denomination;
        Quantity = quantity;
    }
}