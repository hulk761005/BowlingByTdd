namespace BowlingByTdd;

public class Bowing
{
    private bool isNewFrames = true;
    private int _firstHand;
    private int _previous;
    private bool isSpare = false;
    public void Roll(int pins)
    {
        if (isNewFrames)
        {
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

        isNewFrames = !isNewFrames;
    }

    public int Score()
    {
        return _previous + _firstHand;
    }
}