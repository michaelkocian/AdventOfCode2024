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

//traverse
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