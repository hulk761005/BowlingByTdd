namespace BowlingByTdd;

public class Bowing
{
    private bool isNewFrames;
    private int _firstHand;
    private int _bonus;
    private int _bonusTime;
    private int _score;
    private int _frame;
    public void Roll(int pins)
    {
        if (_bonusTime > 0)
        {
            if (_frame < 11 && _bonusTime > 2)
            {
                _bonus += pins;
                _bonusTime--;
            }
            _bonus += pins;
            _bonusTime--;
        }
        isNewFrames = !isNewFrames;
        
        if (isNewFrames)
        {
            _frame++;
            if (IsStrike(pins))
            {
                _bonusTime += 2;
                isNewFrames = false;
                _firstHand = 0;
            }
            else
            {
                _firstHand = pins;
            }
        }
        else
        {
            if (IsSpare(_firstHand, pins))
            {
                _bonusTime += 1;
            }
        }

        if (_frame >= 11) return;
        _score += pins;
    }

    private static bool IsStrike(int pins)
    {
        return pins == 10;
    }

    private static bool IsSpare(int firstHand, int secondHand)
    {
        return firstHand + secondHand == 10;
    }

    public int Score()
    {
        return _score + _bonus;
    }
}