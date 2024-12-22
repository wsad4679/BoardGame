namespace Gameplay;
using Gameplay;
using  Characters;


class Game
{
    static private List<Player> CreateGame(int playersNumber)
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


    static public void PlayGame(int playersNumber)
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
                Move(players, debuffPoints, bonusPoints, monsterFields, i);

            }

            tury++;
        }
        
    }

    static private void Fight()
    {
    }

    static public void Move(List<Player> players, Dictionary<int,int> debuffPoints,Dictionary<int,int> bonusPoints, Dictionary<int,Monster> monsterFields, int i)
    {
        var position = players[i].CharacterMove(Dice.RollMoveDice());

        if (bonusPoints.ContainsKey(position))
        {
            players[i].UpdateScore(bonusPoints[position]);
            Console.WriteLine($"Otrzymano {bonusPoints[position]} punktów. ");
            if (players[i].Character is Mage)
            {
                if (players[i].Character.SpecialPower() == 1)
                {
                    Move(players, debuffPoints, bonusPoints, monsterFields, i);
                }
            }
        }
        else if (debuffPoints.ContainsKey(position))
        {
            players[i].UpdateScore(debuffPoints[position]);
            Console.WriteLine($"Otrzymano {bonusPoints[position]} punktów. ");
            if (players[i].Character is Mage)
            {
                if (players[i].Character.SpecialPower() == 1)
                {
                    Move(players, debuffPoints, bonusPoints, monsterFields, i);
                }
            }
        }
                
        else if (monsterFields.ContainsKey(position))
        {
            Fight();
            if (players[i].Character is Mage)
            {
                if (players[i].Character.SpecialPower() == 1)
                {
                    Move(players, debuffPoints, bonusPoints, monsterFields, i);
                }
            }
        }

        else
        {
            Console.WriteLine($"Trafiłeś na pole bez akcji.");
            if (players[i].Character is Mage)
            {
                if (players[i].Character.SpecialPower() == 1)
                {
                    Move(players, debuffPoints, bonusPoints, monsterFields, i);
                }
            }
        }

        if (players[i].Character is Healer)
        {
            players[i].Character.PassiveSkill();
        }
    }

}

class Dice
{
    static public int RollMoveDice()
    {
        var dice = new Random().Next(0,7);
        Console.WriteLine($"Wyrzuciłeś: {dice}");
        return dice;

    }

    static public int RollAttackMultiply()
    {
        var multiplier = new Random().Next(0, 5);
        Console.WriteLine($"Twój mnożnik ataku wynosi: {multiplier}");
        return multiplier;
    }
    

}