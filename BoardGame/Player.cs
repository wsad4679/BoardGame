namespace Characters;

class Player
{
    private string Name { get; set; }
    private int Position = 0;
    private int Score = 0;
    public int Character { get; set; }

    private void UpdateScore(int addScore)
    {
        Score += addScore;
    }

    private int characterMove(int diceOutcome)
    {
        Position += diceOutcome;
        //if position > rozmiar planszy
        //position = position - rozmiar planszy
        return Position;
    }

}
