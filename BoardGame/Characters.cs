namespace Characters;
using Gameplay;
interface ICharacterType
{
    public void SpecialPower();

}

class Mage : ICharacterType
{
    public int HP = 300;
    public int ATK = 100;
    public void SpecialPower()// throw spell
    {
        void MoveAgain()
        {
            //playerTurn()
        }
    }


}

class Warrior : ICharacterType
{
    public int HP = 500;
    public int ATK = 200;
    public void SpecialPower()// stronger attack
    {
        Console.WriteLine("Czy chcesz użyć: heroiczny atak (rzucasz kostką od 0 do 4, tyle ile wypadnie taki mnożnik twojego ataku) tak/nie");
        string choice = Console.ReadLine();

        if (choice == "tak")
        {
            int attackMultiply = Dice.RollAttackMultiply();
            //attack()
        }
        else
        {
            //attack()
        }
        
        
    }


}

class Healer : ICharacterType
{
    public int HP = 400;
    public int ATK = 50;
    public void SpecialPower()
    {
        Console.WriteLine("Użyto specjalnej umiejętności: łaska boga, przywrócono HP do 400");
        HP = 400;
    }

    public void PassiveSkill()
    {
        Console.WriteLine("Passywna umiejętność: zyskano 50 HP.");
        HP += 50;
    }
}
