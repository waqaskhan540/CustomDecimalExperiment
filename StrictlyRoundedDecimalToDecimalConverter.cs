using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebApi;

public class StrictlyRoundedDecimalToDecimalConverter : ValueConverter<StrictlyRoundedDecimal, decimal>
{
    public StrictlyRoundedDecimalToDecimalConverter()
        : base(
            v => v,
            v => v)
    {
    }
}