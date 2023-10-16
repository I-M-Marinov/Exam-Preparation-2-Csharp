
Queue<int> armors = new Queue<int>(Console.ReadLine().Split(",").Select(int.Parse));

Stack<int> strikes = new Stack<int>(Console.ReadLine().Split(",").Select(int.Parse));

int monstersKilled = 0;


while (armors.Any() && strikes.Any())
{
    int armor = armors.Dequeue();
    int strike = strikes.Pop();

    if (strike >= armor)
    {
        monstersKilled++;
        strike -= armor;

        if (strikes.Any())
        {
            int nextStrike = strikes.Pop();
            nextStrike += strike;
            strikes.Push(nextStrike);
        }
        else if (strike > 0)
        {
            strikes.Push(strike);
        }
    }
    else
    {
        armor -= strike;
        armors.Enqueue(armor);
    }

}

if (!armors.Any())
{
    Console.WriteLine("All monsters have been killed!");
}

if (!strikes.Any())
{
    Console.WriteLine("The soldier has been defeated.");
}

Console.WriteLine($"Total monsters killed: {monstersKilled}");
