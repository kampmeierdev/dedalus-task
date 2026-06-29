using DedalusApi.Dtos;

namespace DedalusApi.Services;

public class DenominationService : IDenominationService
{
    private static readonly decimal[] _denominations = 
    [200m, 100m, 50m, 20m, 10m, 5m, 2m, 1m, 0.50m, 0.20m, 0.10m, 0.05m, 0.02m, 0.01m];

    public DenominationOutput[] Calculate(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Amount must be greater than 0.");

        if (decimal.Round(amount, 2) != amount) throw new ArgumentException("Amount can't have more than 2 decimal places.");

        var result = new List<DenominationOutput>();
        decimal remaining = amount;
        foreach (var denomination in _denominations)
        {
            int count = (int)(remaining / denomination);
            if (count > 0)
            {
                result.Add(new DenominationOutput(denomination, count));
                remaining -= count * denomination;
            }
        }
        return result.ToArray();
    }
}