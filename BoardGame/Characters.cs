namespace Characters;
using Gameplay;
interface ICharacterType
{
    public int SpecialPower();
    public void PassiveSkill();

}

class Mage : ICharacterType
{
    public int HP = 300;
    public int ATK = 100;
    private int SPUse = 2;
    public int  SpecialPower()// throw spell
    {
        if (SPUse > 0)
        {
            Console.WriteLine(
                $"Czy chcesz użyć swojej umięjętności ponowny ruch (tak/nie). Zosatły ci {SPUse} użycia.");
            var isUsed = Console.ReadLine();
            if (isUsed == "tak")
            {
                SPUse--;
                return 1;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }

    }

    public void PassiveSkill()
    {
        //ja zakładam brak, chyba że znajdziesz jakiś pomysł
    }
}

class Warrior : ICharacterType
{
    public int HP = 500;
    public int ATK = 200;
    public int SpecialPower()// stronger attack
    {
        Console.WriteLine("Czy chcesz użyć: heroiczny atak (rzucasz kostką od 0 do 4, tyle ile wypadnie taki mnożnik twojego ataku) tak/nie");
        string choice = Console.ReadLine();

        if (choice == "tak")
        {
            int attackMultiply = Dice.RollAttackMultiply();
            return attackMultiply;
            
        }
        else
        {
            return 1;
        }
        
    }

    public void PassiveSkill()
    {
        //ja zakładam brak, chyba że znajdziesz jakiś pomysł
    }
}

class Healer : ICharacterType
{
    public int HP = 400;
    public int ATK = 50;
    public int SPUse = 1;
    public int SpecialPower()
    {
        Console.WriteLine("Użyto specjalnej umiejętności: łaska boga, przywrócono HP do 400");
        HP = 400;
        SPUse--;
        return 0;
    }

    public void PassiveSkill()
    {
        Console.WriteLine("Passywna umiejętność: zyskano 50 HP.");
        HP += 50;
    }
}


class Monster
{
    public int HP = new Random().Next(100, 500);
    public int ATK = new Random().Next(20, 100);
    public double points = new Random().Next(1,10);
}