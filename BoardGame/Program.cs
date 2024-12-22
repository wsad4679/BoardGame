// See https://aka.ms/new-console-template for more information
using System;
using System.Resources;
using Characters;
using Gameplay;



internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Podaj liczbę graczy od 1 do 4: ");
        var inputNumber = Console.ReadLine();
        var playersNumber = CheckIsInt(inputNumber);
        Game.PlayGame(playersNumber);
        
    }
    
    public static int CheckIsInt(string inputNumber)
    {
        while (true)
        {
            bool tryParseScore = int.TryParse(inputNumber, out int number);

            if (!tryParseScore)
            {
                Console.WriteLine("Podano nieprawidłowy wynik. Podaj wynik ponownie: ");
                inputNumber = Console.ReadLine();
            }
            else if (number <= 0 || number > 4)
            {
                Console.WriteLine("Podano zadużą liczbę graczy, podaj liczbę ponownie: ");
                inputNumber = Console.ReadLine();
            }

            else
            {
                return number;
                break;
            }
            
        }

    }
}



