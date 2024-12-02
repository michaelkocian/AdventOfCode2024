List<int[]> grid = [];

//ReadInput
while (true)
{
    string? input = Console.ReadLine();
    if (input is null or "" or "\n")
    {
        break;
    }

    string[] parsed = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

    int[] numbers = parsed.Select(p => int.Parse(p)).ToArray();
    grid.Add(numbers);
}

//traverse part1
int numberOfSafePaths = 0;
foreach (int[] numbers in grid)
{
    int previous = numbers[0];
    int previousSign = Math.Sign(previous - numbers[1]);
    bool isSafe = true;
    for (int i = 1; i < numbers.Length; i++)
    {
        int number = numbers[i];
        int diff = (previous - number);
        int absdiff = Math.Abs(diff);
        if (1 > absdiff || absdiff > 3)
        {
            isSafe = false;
            break;
        }
        int sign = Math.Sign(diff);
        if (sign != previousSign)
        {
            isSafe = false;
            break;
        }
        previousSign = sign;
        previous = number;
    }

    if (isSafe)
    {
        numberOfSafePaths++;
    }
}

Console.WriteLine("number of safe paths is: " + numberOfSafePaths);

//traverse part2
int numberOfSafePathsPart2 = 0;
foreach (int[] numbers in grid)
{
    var dampener = Enumerable.Range(-1, numbers.Length + 1);
    foreach (int r in dampener)
    {
        bool isSafe = true;
        bool isConsistent = false;
        List<int> subset = numbers.ToList();
        if (r >= 0)
        {
            subset.RemoveAt(r);
        }
        isConsistent = subset.OrderBy(x => x).SequenceEqual(subset)
            || subset.OrderByDescending(x => x).SequenceEqual(subset);

        if (!isConsistent)
        {
            continue;
        }

        int previous = 0;
        for (int i = 0; i < subset.Count; i++)
        {
            int num = subset[i];

            int diff = Math.Abs(previous - num);
            if (1 > diff || diff > 3)
            {
                if (i == 0)
                {
                    previous = num;
                    continue;
                }

                isSafe = false;
                break;
            }
            previous = num;
        }

        if (isSafe && isConsistent)
        {
            numberOfSafePathsPart2++;
            break;
        }
    }
}

Console.WriteLine("number of safe paths with dampener is: " + numberOfSafePathsPart2);