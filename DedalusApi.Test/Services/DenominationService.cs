using DedalusApi.Services;

namespace DedalusApi.Test.Services;

public class DenominationServiceTests
{
    private readonly DenominationService _denominationService = new();

    [Fact]
    public void Calculate_234_23_ReturnsCorrectDenominations()
    {
        var result = _denominationService.Calculate(234.23m);

        Assert.Equal(200m, result[0].Value); 
        Assert.Equal(1, result[0].Count);

        Assert.Equal(20m,  result[1].Value); 
        Assert.Equal(1, result[1].Count);

        Assert.Equal(10m,  result[2].Value); 
        Assert.Equal(1, result[2].Count);

        Assert.Equal(2m,   result[3].Value); 
        Assert.Equal(2, result[3].Count);

        Assert.Equal(0.20m,result[4].Value); 
        Assert.Equal(1, result[4].Count);

        Assert.Equal(0.02m,result[5].Value); 
        Assert.Equal(1, result[5].Count);

        Assert.Equal(0.01m,result[6].Value); 
        Assert.Equal(1, result[6].Count);
    }

    [Fact]
    public void Calculate_MinimumAmount_ReturnsOneCent()
    {
        var result = _denominationService.Calculate(0.01m);

        Assert.Single(result);
        Assert.Equal(0.01m, result[0].Value);
        Assert.Equal(1, result[0].Count);
    }

    [Theory]
    [InlineData(0.01)]
    [InlineData(0.02)]
    [InlineData(0.05)]
    [InlineData(0.10)]
    [InlineData(0.20)]
    [InlineData(0.50)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    [InlineData(50)]
    [InlineData(100)]
    [InlineData(200)]
    public void Calculate_ExactDenomination_ReturnsSingleItem(decimal amount)
    {
        var result = _denominationService.Calculate(amount);

        Assert.Single(result);
        Assert.Equal(1, result[0].Count);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Calculate_NotSufficientAmount_ThrowsArgumentExceptionAndMessage(decimal amount)
    {
        var exception = Assert.Throws<ArgumentException>(() => _denominationService.Calculate(amount));
        Assert.Equal("Amount must be greater than 0.", exception.Message);
    }

    [Theory]
    [InlineData(0.004)]
    [InlineData(232.232)]
    public void Calculate_InvalidAmount_ThrowsArgumentException(decimal amount)
    {
        var exception = Assert.Throws<ArgumentException>(() => _denominationService.Calculate(amount));
        Assert.Equal("Amount can't have more than 2 decimal places.", exception.Message);
    }
}