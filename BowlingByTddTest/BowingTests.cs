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

    [Fact]
    public void All_Miss_Game()
    {
        NumberOfKnockoutsInOneFrame(5, 0);
        NumberOfKnockoutsInOneFrame(8, 0);
        NumberOfKnockoutsInOneFrame(6, 0);
        NumberOfKnockoutsInOneFrame(0, 7);
        NumberOfKnockoutsInOneFrame(7, 0);
        NumberOfKnockoutsInOneFrame(0, 9);
        NumberOfKnockoutsInOneFrame(5, 0);
        NumberOfKnockoutsInOneFrame(8, 0);
        NumberOfKnockoutsInOneFrame(0, 9);
        NumberOfKnockoutsInOneFrame(9, 0);

        _bowing.Score().Should().Be(73);
    }

    [Fact]
    public void Clean_Game()
    {
        NumberOfKnockoutsInOneFrame(5, 5);
        NumberOfKnockoutsInOneFrame(8, 2);
        NumberOfKnockoutsInOneFrame(6, 4);
        NumberOfKnockoutsInOneFrame(7, 3);
        NumberOfKnockoutsInOneFrame(7, 3);
        NumberOfKnockoutsInOneFrame(9, 1);
        NumberOfKnockoutsInOneFrame(5, 5);
        NumberOfKnockoutsInOneFrame(8, 2);
        NumberOfKnockoutsInOneFrame(9, 1);
        NumberOfKnockoutsInOneFrame(9, 1);
        _bowing.Roll(10);
        
        _bowing.Score().Should().Be(178);
    }
    
    [Fact]
    public void Roll_Strike_And_7_And_1_Get_26()
    {
        _bowing.Roll(10);
        NumberOfKnockoutsInOneFrame(7, 1);
        _bowing.Score().Should().Be(26);
    }
    
    [Fact]
    public void Roll_1_Strike_And_1_Spare_And_5_And_3_Get_43()
    {
        _bowing.Roll(10);
        NumberOfKnockoutsInOneFrame(7, 3);
        NumberOfKnockoutsInOneFrame(5, 3);
        _bowing.Score().Should().Be(43);
    }
    
    [Fact]
    public void Roll_3_Strike_And_4_And_4_Get_80()
    {
        _bowing.Roll(10);
        _bowing.Roll(10);
        _bowing.Roll(10);
        NumberOfKnockoutsInOneFrame(4, 4);
        _bowing.Score().Should().Be(80);
    }
    
    [Fact]
    public void Strike_Spare_Game()
    {
        _bowing.Roll(10);
        NumberOfKnockoutsInOneFrame(9, 1);
        _bowing.Roll(10);
        NumberOfKnockoutsInOneFrame(7, 3);
        _bowing.Roll(10);
        NumberOfKnockoutsInOneFrame(2, 8);
        _bowing.Roll(10);
        NumberOfKnockoutsInOneFrame(5, 5);
        _bowing.Roll(10);
        NumberOfKnockoutsInOneFrame(1, 9);
        _bowing.Roll(10);
        _bowing.Score().Should().Be(200);
    }
    
    [Fact]
    public void Perfect_Game()
    {
        _bowing.Roll(10);
        _bowing.Roll(10);
        _bowing.Roll(10);
        _bowing.Roll(10);
        _bowing.Roll(10);
        _bowing.Roll(10);
        _bowing.Roll(10);
        _bowing.Roll(10);
        _bowing.Roll(10);
        _bowing.Roll(10);
        _bowing.Roll(10);
        _bowing.Roll(10);
        _bowing.Score().Should().Be(300);
    }

    private void NumberOfKnockoutsInOneFrame(int first, int second)
    {
        _bowing.Roll(first);
        _bowing.Roll(second);
    }
}

