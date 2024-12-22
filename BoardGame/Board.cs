using Characters;
namespace Gameplay;

class Board
{
    private int Fields = 24;
    private static Random random = new Random();
    static public Dictionary<int, int> BonusPoints()
    {
        int numbersOfBonusPoints = random.Next(5, 10);
        var bonusPointsFields = new Dictionary<int, int>();
        for (int i = 0; i <= numbersOfBonusPoints; i++)
        {
            
            int field = random.Next(1, 25);
            int points = random.Next(1,11);

            if (!bonusPointsFields.ContainsKey(field))
            {
                bonusPointsFields.Add(field, points);
            }
            
            
        }
        return bonusPointsFields;
    }

    static public Dictionary<int, int> Debuff(Dictionary<int, int> bonusPointsFields)
    {
        int numbersOfBonusPoints = random.Next(1, 10);
        var minusPointsFields = new Dictionary<int, int>();
        for (int i = 0; i <= numbersOfBonusPoints; i++)
        {
            int field = random.Next(1, 25);
            int points = random.Next(1,6);

            if (!bonusPointsFields.ContainsKey(field) && !minusPointsFields.ContainsKey(field))
            {
                minusPointsFields.Add(field, points);
            }
            
        }

        return minusPointsFields;
    }

    static public Dictionary<int, Monster> MonsterFields(Dictionary<int, int> bonusPointsFields, Dictionary<int, int> minusPointsFields)
    {
        var monsterFields = new Dictionary<int, Monster>();
        for (int i = 0; i <=5; i++)
        {
            int field = random.Next(1, 25);
            if (!monsterFields.ContainsKey(field) && !bonusPointsFields.ContainsKey(field) && !minusPointsFields.ContainsKey(field))
            {
                monsterFields.Add(field, new Monster());
            }
            else
            {
                i--;
            }
        }
        return monsterFields;
    }


}