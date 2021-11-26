using System;
using System.Linq;
using FluentAssertions;
using Helpers;
using Xunit;

namespace UnitTests;

public class AnyTests
{
    [Fact]
    public void Generate_random_fixed_length_string()
    {
        var length = new Random().Next(maxValue: 100);

        var rndString = Any.String(length);

        rndString.Length.Should().Be(length);
    }

    [Fact]
    public void Generate_random_string_except_provided()
    {
        var exclusions = new[] { "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        var rndString = Enumerable.Range(0, 100)
            .Select(_ => Any.String(1).Except(exclusions));

        rndString.Should().OnlyContain(i => !exclusions.Contains(i));
    }

    [Fact]
    public void Generate_string_only_from_provided_list()
    {
        var source = new[] { "F", "G", "H", "I", "J", "K", "L", "M", "N" };

        var generatedStrings = Enumerable.Range(0, 100)
            .Select(_ => Any.String(1).From(source));

        generatedStrings.Should().OnlyContain(i => source.Contains(i));
    }

    [Fact]
    public void Generate_random_int()
    {
        var rndIntegers = Enumerable.Range(0, 100).Select(_ => Any.Int());

        rndIntegers.Should().OnlyContain(i => i >= Any.IntMinValue && i <= Any.IntMaxValue);
    }

    [Fact]
    public void Generate_random_int_except_provided()
    {
        var exclusions = new[] { 1, 2, 3, 4, 5, 6, 7 };
        var rndIntegers = Enumerable.Range(0, 100)
            .Select(_ => Any.Int(0, 10).Except(exclusions));

        rndIntegers.Should().OnlyContain(i => !exclusions.Contains(i));
    }

    [Fact]
    public void Generate_int_from_provided_list()
    {
        var source = new[] { 1, 2, 3 };
        var rndIntegers = Enumerable.Range(0, 100)
            .Select(_ => Any.Int().From(source));

        rndIntegers.Should().OnlyContain(i => source.Contains(i));
    }

    [Fact]
    public void Generate_random_int_greater_than_zero()
    {
        var rndIntegers = Enumerable.Range(0, 100)
            .Select(_ => Any.PositiveInt());

        rndIntegers.Should().OnlyContain(i => i > 0);
    }

    [Fact]
    public void Generate_random_int_less_than_zero()
    {
        var rndIntegers = Enumerable.Range(0, 100)
            .Select(_ => Any.NegativeInt());

        rndIntegers.Should().OnlyContain(i => i < 0);
    }

    [Fact]
    public void Generate_random_guid()
    {
        var guids = Enumerable.Range(0, 100)
            .Select(_ => Any.Guid());

        guids.Should().OnlyHaveUniqueItems();
    }
}