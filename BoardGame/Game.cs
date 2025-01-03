using System.ComponentModel;

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
        ShowScore(players);
        
        
    }

    public static void Fight(Player player, Monster monster)
    {
        Console.WriteLine($"{player.Name} walczy z potworem!");
        Console.WriteLine("kliknij enter aby rzucić kotką");
        Console.ReadLine();
        Random random = new Random();
        int playerRoll = random.Next(1, 7);
        int monsterRoll = random.Next(1, 7);

        Console.WriteLine($"{player.Name} wyrzucił: {playerRoll}");
        Console.WriteLine($"Potwór wyrzucił: {monsterRoll}");

        if (playerRoll > monsterRoll)
        {
            Console.WriteLine($"{player.Name} pokonał potwora!");
            int reward = monster.RewardPoints;
            player.UpdateScore(reward);
            Console.WriteLine($"{player.Name} zdobywa {reward} punktów! Aktualny wynik: {player.Score}");
        }
        else if (playerRoll < monsterRoll)
        {
            Console.WriteLine($"{player.Name} został pokonany przez potwora!");
            int damage = monster.ATK;
            if (player.Character.TakeDamage(damage) == 0)
            {
                Console.WriteLine($"{player.Name} został pokonany. Gracz traci połowe punktów i odzyskuje HP");
                player.UpdateScore(-(player.Score/2));
                player.Character.Defeat();

            }
            else
            {
                Console.WriteLine($"{player.Name} traci {damage} zdrowia! Pozostałe zdrowie: {player.Character.TakeDamage(damage)}");
            }
            
        }
        else
        {
            Console.WriteLine("Remis! Nikt nie wygrywa.");
        }
    }

    static public void Move(List<Player> players, Dictionary<int,int> debuffPoints,Dictionary<int,int> bonusPoints, Dictionary<int,Monster> monsterFields, int i)
    {
        var position = players[i].CharacterMove(Dice.RollMoveDice(players[i].Name));

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
            Console.WriteLine($"Otrzymano {debuffPoints[position]} punktów. ");
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
            Fight(players[i], monsterFields[position]);
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


    


    static public void ShowScore(List<Player> players)
    {
        var sortedPlayers = players.OrderByDescending(p => p.Score);
        int i = 1;
        foreach (var player in sortedPlayers)
        {
            Console.WriteLine($"{i}. {player.Name} z wynikiem: {player.Score}");
            i++;
        }
    }

}

class Dice
{
    static public int RollMoveDice(string name)
    {
        var dice = new Random().Next(0,7);
        Console.WriteLine($"{name} kliknij enter aby rzucić kotką");
        Console.ReadLine();
        Console.WriteLine($"Wyrzuciłeś: {dice}");
        return dice;

    }

    static public int RollAttackMultiply()
    {
        var multiplier = new Random().Next(0, 5);
        Console.WriteLine("kliknij enter aby rzucić kotką");
        Console.ReadLine();
        Console.WriteLine($"Twój mnożnik ataku wynosi: {multiplier}");
        return multiplier;
    }
    

}