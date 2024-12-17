using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace VendingMachine;

public class VendingMachine
{
    public string onDisplay { get; set; }
    public string[] Products = ["Cola", "Chips", "Candy"];
    public int[] ProductsStock = [1, 5, 1000];
    public int[] prize = [100, 50, 65];
    public int InsertedCoins { get; set; }
    int Nickle = 5;
    int Dime = 10;
    int Quarter = 25;

    public VendingMachine()
    {
        onDisplay = "INSERT COIN";
    }

    public int identifyCoins(string coinType)
    {
            switch (coinType)
            {
                case "Nickle":
                    InsertedCoins += Nickle;
                    break;
                case "Dime":
                    InsertedCoins += Dime;
                    break;
                case "Quarter":
                    InsertedCoins += Quarter;
                    break;
                default:
                    break;
            }
        return InsertedCoins;
    }

    public string SelectProduct(int productID, int money)
    {   
        InsertedCoins = money;
        if (InsertedCoins >= prize[productID] && ProductsStock[productID] > 0)
        {
            Console.WriteLine(ThankYouMessage());
            InsertedCoins -= prize[productID];
            ProductsStock[productID] -= 1;
            ReturnChange(InsertedCoins);
            return Products[productID];
        }
        else if (ProductsStock[productID] == 0)
        {
            return "SOLD OUT";
        }
        else
        {   
            return onDisplay;
        }
    }

    public int Cancel()
    {   
        return InsertedCoins;
    }

    public void CheckDisplay()
    {
        Console.WriteLine(onDisplay);
    }

    // public bool CheckStock(int productID)
    // {
    //     if (ProductsStock[productID] == 0)
    //     {
    //         onDisplay = "SOLD OUT";
    //     }
    //     return onDisplay;
    // }

    public string ThankYouMessage()
    {
        onDisplay = "THANK YOU";
        return onDisplay;
    }

    public int ReturnChange(int change)
    {
        return change;
    }
}
