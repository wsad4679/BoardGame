namespace Characters;
class Player
{
    public string Name { get; set; }
    public int Position = 0;
    public int Score = 0;
    //public int HP = ;//nie wiem jak dodac hp z klasy characters
    public ICharacterType Character { get; set; }

    public Player(string name)
    {
        Name = name;
        Position = new Random().Next(0, 25);
        Character = ChooseCharacter();
    }

    public void UpdateScore(int addScore)
    {
        Score += addScore;
    }

    public int CharacterMove(int diceOutcome)
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
        string newInput =  input.ToUpper();
        switch (newInput)
        {
            case "MAGE":
                return new Mage();
            case "WARIOR":
                return new Warrior();
            case "HEALER":
                return new Healer();
            default:
                Console.WriteLine("Nie ma takiej postaci. Wybrano domyślnie Warrior.");
                return new Warrior();
        }
    }


}
