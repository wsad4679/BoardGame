// See https://aka.ms/new-console-template for more information

interface CharacterType
{
   public void SpecialPower();

}

class Mage : CharacterType
{
    public void SpecialPower()
    {
        throw new NotImplementedException();
    }


}

class Warrior : CharacterType
{
    public void SpecialPower()
    {
        throw new NotImplementedException();
    }


}

class Healer : CharacterType
{
    public void SpecialPower()
    {
        throw new NotImplementedException();
    }

    public void PassiveSkill()
    {
        throw new NotImplementedException();
    }
}




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

class Board
{
    //1 rozmiar planszy x
    //2 rozmiar planszy y
    //3 romiar planszy z
    
    // 1, 2, 3 to metody tworzące plansze z losowymi zdarzeniami

    private void BonusPoints()
    {
        // zwraca liczbę punktów z jakiegoś zakresu jakie będą na tych polach
    }

    private void Debuff()
    {
        // gracz traci liczbę punktów z jakiegoś zakresu
    }

    private void Monster()
    {
        // gracz spotyka potwora ze statystykami z losowego zakresu 
    }

}


class Game
{
    private void StartGame(int playersNumber)
    {
        // dla 1 gracza 

        //dla 2 - 4 graczy
    }


    private void PlayGame()
    {
        // gra trwa 10 tur while (tury <10)
        //for (i = 1; i<=liczba graczy; i++)
        //{tutaj całe metody funkcje gry}
        //funkca po wszystkim na wyświetlenie wyników
    }

    private void Fight()
    {
    }

}
