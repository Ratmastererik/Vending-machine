namespace VendingMachine;

public class VendingMachine
{
    public static void Main()
    {

    }

    int Nickle = 5;
    int Dime = 10;
    int Quarter = 25;
    int Penny = 0;

    public int AcceptCoin(int coin)
    {
        switch (coin)
        {
            case (5):
                return coin;
            case (10):
                return coin;
            case (25):
                return coin;
            default:
                return coin;
        }
    }

    public int identifyCoins(List<string> coinType)
    {
        int totalAmount = 0;
        for (int i = 0; i < coinType.Count; i++)
        {
            switch (coinType[i])
            {
                case "Penny":
                    totalAmount = Penny;
                    break;
                case "Nickle":
                    totalAmount += AcceptCoin(Nickle);
                    break;
                case "Dime":
                    totalAmount += AcceptCoin(Dime);
                    break;
                case "Quarter":
                    totalAmount += AcceptCoin(Quarter);
                    break;
                default:
                    break;
            }
        }
        return totalAmount;
    }
}
