namespace Characters;
class Player
{
    private string Name { get; set; }
    private int Position = 0;
    private int Score = 0;
    public ICharacterType Character { get; set; }

    public Player(string name)
    {
        Name = name;
        Position = new Random().Next(0, 25);
        Character = ChooseCharacter();
    }

    private void UpdateScore(int addScore)
    {
        Score += addScore;
    }

    private int characterMove(int diceOutcome)
    {
        Position += diceOutcome;
        if (Position > 25)
        {
            Position -= 25;
        }

        return Position;
    }

    private ICharacterType ChooseCharacter()
    {
        Console.WriteLine("Wybierz klasę swojej postaci: Mage, Warrior, Healer");
        string input = Console.ReadLine();
        switch (input)
        {
            case "Mage":
                return new Mage();
            case "Warrior":
                return new Warrior();
            case "Healer":
                return new Healer();
            default:
                Console.WriteLine("Nie ma takiej postaci. Wybrano domyślnie Warrior.");
                return new Warrior();
        }
    }


}
