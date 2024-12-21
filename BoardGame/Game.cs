namespace Gameplay;


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

class Dice
{
    static public int RollMoveDice()
    {
        return new Random().Next(0, 7);
    }

    static public int RollAttackMultiply()
    {
        return new Random().Next(0, 7);
    }
    

}