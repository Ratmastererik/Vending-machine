using System.Runtime.CompilerServices;

namespace VendingMachine.Tests;

public class UnitTest1
{

    [Fact]
    public void AcceptMultipalCoinsTest()
    {
        // Arrange
        int coinValue;
        string coin = "Quarter";
        int expected = 25;
        VendingMachine newVendingmachine = new();

        // Act
        coinValue = newVendingmachine.identifyCoins(coin);

        // Assert
        Assert.Equal(expected, coinValue);
    }

    [Fact]
    public void RejectPennysTest()
    {
        // Arrange
        VendingMachine newVendingmachine = new();
        string penny = "Penny";
        int coinValue;
        int expected = 0;

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
        
        // Assert
        Assert.Equal(testMachine.onDisplay, expected);
    }

    [Fact]
    public void ThankYouMessageTest()
    {
        // Arrange
        VendingMachine testMachine = new();
        string expected = "THANK YOU";

        // Act
        string actual = testMachine.ThankYouMessage();

        // Assert
        Assert.Equal(actual, expected);
    }

    [Theory]
    [InlineData(110, 110, "INSERT COIN")]
    [InlineData(100, 100, "INSERT COIN")]
    [InlineData(70, 70, "INSERT COIN")]
    public void CancelReturnCoinsTest(int money, int expectedChange, string expectedDisplayMessage)
    {
        {
            // Arrange
            VendingMachine testMachine = new();
            testMachine.InsertedCoins = money;

            // Act
            int actualChange = testMachine.Cancel();
            string actualDispalyMessage = testMachine.onDisplay;

            // Assert
            Assert.Equal(expectedChange, actualChange );
            Assert.Equal(expectedDisplayMessage, actualDispalyMessage);
        }
    }

    [Theory]
    [InlineData(0, 110, 10)]
    [InlineData(1, 100, 50)]
    [InlineData(2, 70, 5)]
    public void ReturnChangeTest(int productID, int money, int expectedChange)
    {
        {
            // Arrange
            VendingMachine testMachine = new();
            testMachine.SelectProduct(productID, money);

            // Act
            int actualChange = testMachine.InsertedCoins;

            // Assert
            Assert.Equal(expectedChange, actualChange);
        }
    }

    [Theory]
    [InlineData(0, 100)]
    [InlineData(1, 50)]
    [InlineData(2, 65)]
    public void SuccesfulProductSelect(int productID, int money)
    {
        {
            // Arrange
            VendingMachine testMachine = new();
            string [] expectedItem = ["Cola", "Chips", "Candy"];

            // Act
            string actualItem = testMachine.SelectProduct(productID, money);

            // Assert
            Assert.Contains(expectedItem[productID], actualItem);
        }
    }
    
    [Theory]
    [InlineData(0, 50)]
    [InlineData(1, 50)]
    [InlineData(2, 65)]
    public void FailedProductSelect(int productID, int money)
    {
        {
            // Arrange
            VendingMachine testMachine = new();
            string [] expectedItem = ["INSERT COIN", "Chips", "Candy"];

            // Act
            string actualItem = testMachine.SelectProduct(productID, money);

            // Assert
            Assert.Contains(expectedItem[productID], actualItem);
        }
    }

    [Theory]
    [InlineData(0, 200, "SOLD OUT")]
    public void ProductsStockTest(int productID, int money, string expected )
    {
        {
            // Arrange
            VendingMachine testMachine = new();

            // Act
            testMachine.SelectProduct(productID, money);
            string actual = testMachine.SelectProduct(productID, money);

            // Assert
            Assert.Contains(expected, actual);
        }
    }
}