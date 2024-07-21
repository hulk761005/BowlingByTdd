namespace BowlingByTdd;

public class Bowing
{
    private bool isNewFrames = true;
    private int _firstHand;
    private int _previous;
    private bool isSpare;
    private int _frame;
    public void Roll(int pins)
    {
        if (_frame == 10 && isSpare)
        {
            _previous += pins;
        }
        else
        {
            if (isNewFrames)
            {
                _frame++;
                if (isSpare)
                {
                    _previous += pins;
                }

                _firstHand = pins;
            }
            else
            {
            
                isSpare = _firstHand + pins == 10;


                _previous += _firstHand + pins;
                _firstHand = 0;
            }
        }
        isNewFrames = !isNewFrames;
    }

    public int Score()
    {
        return _previous + _firstHand;
    }
}