using BowlingByTdd;
using FluentAssertions;
namespace BowlingByTddTest;

public class BowingTests
{
    private readonly Bowing _bowing = new();
    
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
        NumberOfKnockoutsInOneFrame(1, 2);

        _bowing.Score().Should().Be(3);
    }

    [Fact]
    public void Roll_Spare_And_3_And_5_Get_21_Score()
    {
        var first = 6;
        var second = 4;
        var third = 3;
        var fourth = 5;
        
        NumberOfKnockoutsInOneFrame(6, 4);
        NumberOfKnockoutsInOneFrame(3, 5);

        _bowing.Score().Should().Be(21);
    }
    
    [Fact]
    public void Roll_Two_Spare_And_7_And_1_Get_43_Score()
    {
        NumberOfKnockoutsInOneFrame(5, 5);
        NumberOfKnockoutsInOneFrame(8, 2);
        NumberOfKnockoutsInOneFrame(6, 3);

        _bowing.Score().Should().Be(43);
    }

    private void NumberOfKnockoutsInOneFrame(int first, int second)
    {
        _bowing.Roll(first);
        _bowing.Roll(second);
    }
}

