using System.Globalization;
namespace WebApi;


public readonly struct StrictlyRoundedDecimal : IEquatable<StrictlyRoundedDecimal>
{
    private static readonly int MaxPrecision = 6;
    private readonly decimal _value;

    private StrictlyRoundedDecimal(decimal value)
        => _value = Math.Round(value, MaxPrecision);

    private StrictlyRoundedDecimal(float value)
        => _value = Math.Round(Convert.ToDecimal(value), MaxPrecision);

    private StrictlyRoundedDecimal(double value)
        => _value = Math.Round(Convert.ToDecimal(value), MaxPrecision);

    public static implicit operator StrictlyRoundedDecimal(decimal value) => new(value);
    public static implicit operator StrictlyRoundedDecimal(float value) => new(value);
    public static implicit operator StrictlyRoundedDecimal(double value) => new(value);

    public static implicit operator decimal(StrictlyRoundedDecimal value) => value._value;
    public static implicit operator float(StrictlyRoundedDecimal value) => (float) value._value;
    public static implicit operator double(StrictlyRoundedDecimal value) => Convert.ToDouble(value._value);

    #region Arithmetic

    public static StrictlyRoundedDecimal operator +(StrictlyRoundedDecimal val1, StrictlyRoundedDecimal val2)
        => new(val1._value + val2._value);

    public static StrictlyRoundedDecimal operator -(StrictlyRoundedDecimal val1, StrictlyRoundedDecimal val2)
        => new(val1._value - val2._value);

    public static StrictlyRoundedDecimal operator *(StrictlyRoundedDecimal val1, StrictlyRoundedDecimal val2)
        => new(val1._value * val2._value);

    public static StrictlyRoundedDecimal operator /(StrictlyRoundedDecimal val1, StrictlyRoundedDecimal val2)
    {
        if (val2._value == 0)
            throw new DivideByZeroException("attempted to divide by zero.");

        return new StrictlyRoundedDecimal(val1._value / val2._value);
    }

    #endregion

    #region Operators

    public static bool operator ==(StrictlyRoundedDecimal left, StrictlyRoundedDecimal right)
        => left._value == right._value;

    public static bool operator !=(StrictlyRoundedDecimal left, StrictlyRoundedDecimal right)
        => !(left == right);

    public static bool operator <(StrictlyRoundedDecimal left, StrictlyRoundedDecimal right)
        => left._value < right._value;

    public static bool operator >(StrictlyRoundedDecimal left, StrictlyRoundedDecimal right)
        => left._value > right._value;

    public static bool operator <=(StrictlyRoundedDecimal left, StrictlyRoundedDecimal right)
        => left._value <= right._value;

    public static bool operator >=(StrictlyRoundedDecimal left, StrictlyRoundedDecimal right)
        => left._value >= right._value;

    #endregion
    
    

    public override string ToString()
    {
        return _value.ToString(CultureInfo.InvariantCulture);
    }
    
    public bool Equals(StrictlyRoundedDecimal other)
    {
        return _value == other._value;
    }

    public override bool Equals(object? obj)
    {
        return obj is StrictlyRoundedDecimal other && Equals(other);
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }
}