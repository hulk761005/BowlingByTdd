namespace BowlingByTdd;

public class Bowing
{
    private bool isNewFrames = true;
    private int _firstHand;
    private int _bonus;
    private int _bonusTime;
    private int _score;
    private int _frame;
    public void Roll(int pins)
    {
        if (_bonusTime > 0)
        {
            _bonus += pins;
            _bonusTime--;
        }

        if (isNewFrames)
        {
            _firstHand = pins;
            _frame++;
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
        isNewFrames = !isNewFrames;
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