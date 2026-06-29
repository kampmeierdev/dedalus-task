using DedalusApi.Dtos;

namespace DedalusApi.Services;

public interface IDenominationService
{
    public DenominationOutput[] Calculate(decimal amount);
}