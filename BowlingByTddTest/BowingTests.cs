using BowlingByTdd;
using FluentAssertions;
namespace BowlingByTddTest;

public class BowingTests
{
    [Fact]
    public void Roll_1_And_Get_1_Score()
    {
        var pins = 1;
        var bowing = new Bowing();
        bowing.Roll(pins);

        bowing.Score().Should().Be(1);
    }

    [Fact]
    public void Roll_1_And_2_Get_3_Score()
    {
        var first = 1;
        var second = 2;
        var bowing = new Bowing();
        bowing.Roll(first);
        bowing.Roll(second);

        bowing.Score().Should().Be(3);
    }

    [Fact]
    public void Roll_Spare_And_3_And_5_Get_21_Score()
    {
        var first = 6;
        var second = 4;
        var third = 3;
        var fourth = 5;
        
        var bowing = new Bowing();
        bowing.Roll(first);
        bowing.Roll(second);
        bowing.Roll(third);
        bowing.Roll(fourth);

        bowing.Score().Should().Be(21);
    }
    
    [Fact]
    public void Roll_Two_Spare_And_7_And_1_Get_43_Score()
    {
        var first = 5;
        var second = 5;
        var third = 8;
        var fourth = 2;
        var fifth = 6;
        var sixth = 3;

        var bowing = new Bowing();
        bowing.Roll(first);
        bowing.Roll(second);
        bowing.Roll(third);
        bowing.Roll(fourth);
        bowing.Roll(fifth);
        bowing.Roll(sixth);

        bowing.Score().Should().Be(43);
    }

}

