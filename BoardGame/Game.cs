namespace Gameplay;
using Gameplay;
using  Characters;


class Game
{
    private List<Player> CreateGame(int playersNumber)
    {
        
            var players = new List<Player>();
            for (int i = 1; i <= playersNumber; i++)
            {
                Console.WriteLine($"Podaj imie postaci gracza {i} : ");
                string name = Console.ReadLine();
                players.Add(new Player(name));
            }
            return players;
           
    }


    private void PlayGame(int playersNumber)
    {
        var bonusPoints = Board.BonusPoints();
        var debuffPoints = Board.Debuff(bonusPoints);
        var monsterFields = Board.MonsterFields(bonusPoints, debuffPoints);
        var players = CreateGame(playersNumber);
        int tury = 0;
        while (tury < 5)
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].CharacterMove(Dice.RollMoveDice());

            }

            tury++;
        }

        // gra trwa 5 tur while (tury <5)
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