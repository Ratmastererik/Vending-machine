namespace VendingMachine.Tests;

public class UnitTest1
{
    [Fact]
    public void AcceptNickleTest()
    {
        // Arrange
        int coinValue;
        List<string> nickle = ["Nickle"];
        int expected = 5;
        VendingMachine newVendingmachine = new();

        // Act
        coinValue = newVendingmachine.identifyCoins(nickle);

        // Assert
        Assert.Equal(expected, coinValue);
    }

    [Fact]
    public void AcceptDimeTest()
    {
        // Arrange
        int coinValue;
        List<string> dime = ["Dime"];
        int expected = 10;
        VendingMachine newVendingmachine = new();

        // Act
        coinValue = newVendingmachine.identifyCoins(dime);

        // Assert
        Assert.Equal(expected, coinValue);
    }

    [Fact]
    public void AcceptQuarterTest()
    {
        // Arrange
        int coinValue;
        List<string> quarter = ["Quarter"];
        int expected = 25;
        VendingMachine newVendingmachine = new();

        // Act
        coinValue = newVendingmachine.identifyCoins(quarter);

        // Assert
        Assert.Equal(expected, coinValue);
    }

    [Fact]
    public void AcceptMultipalCoinsTest()
    {
        // Arrange
        int coinValue;
        List<string> coins = ["Quarter", "Dime", "Nickle"];
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
}