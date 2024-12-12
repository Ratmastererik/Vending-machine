namespace VendingMachine.Tests;

public class UnitTest1
{

    [Fact]
    public void AcceptMultipalCoinsTest()
    {
        // Arrange
        int coinValue;
        List<string> coins = ["Quarter", "Dime", "Nickle", "Penny"];
        int expected = 40;
        VendingMachine newVendingmachine = new();

        // Act
        coinValue = newVendingmachine.identifyCoins(coins);

        // Assert
        Assert.Equal(expected, coinValue);
    }

    [Fact]
    public void RejectPennysTest()
    {
        // Arrange
        int coinValue;
        List<string> penny = ["Penny"];
        int expected = 0;
        VendingMachine newVendingmachine = new();

        // Act
        coinValue = newVendingmachine.identifyCoins(penny);

        // Assert
        Assert.Equal(expected, coinValue);
    }
    [Fact]
    public void Dispalay_INSERTCOIN_WhenBalanceIsZero()
    {
        // Arrange
        VendingMachine testMachine = new();
        string expected = "INSERT COIN";
        // Act
        testMachine.balance = 0;
        // Assert
        Assert.Equal(testMachine.onDisplay, expected);
    }
}