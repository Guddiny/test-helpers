![workflow status](https://github.com/Guddiny/test-helpers/actions/workflows/dotnet.yml/badge.svg?branch=main)

# test-helpers
Set of methods and classes to help work with tests

### Examples
```C#
[Fact]
public void Test1()
{
    var name1 = Any.String();
    var name2 = Any.String(12);
    var name3 = Any.String().Except("asd", "sds");
    var name4 = Any.String().From("asd", "sds", "Alex");

    var age1 = Any.Int();
    var age2 = Any.Int(1, 55);
    var age3 = Any.Int().Except(1, 222, 5467);
    var age4 = Any.Int().From(1, 222, 5467);
    var age5 = Any.PositiveInt();
    var age6 = Any.NegativeInt();

    var id = Any.Guid();

    User mc1 = new()
    {
        Id = Any.Guid(),
        Age = Any.Int(min:18, max: 100),
        Name = Any.String().Except("Alex"),
        LastName = Any.String(),
        NickName = Any.String().From("Zero Cool", "Lexer", "Ankle Bob", "Ja-ja")
    };

    var mc2 = mc1.Clone()
        .With(p => p.Age = Any.PositiveInt(max: 40))
        .With(p => p.Name = Any.String().Except("Bob"));
}
```
