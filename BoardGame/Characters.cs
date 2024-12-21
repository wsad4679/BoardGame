namespace Characters;

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
