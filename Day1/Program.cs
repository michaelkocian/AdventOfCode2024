List<int> left = [];
List<int> right = [];

Console.WriteLine("Enter inputs, terminate by double enter");

//ReadInput
while (true)
{
    string? input = Console.ReadLine();
    if (input is null or "" or "\n")
    {
        break;
    }
    string[] parsed = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    left.Add(int.Parse(parsed[0]));
    right.Add(int.Parse(parsed[1]));
}

//Similarity score
int totalSimilarityScore = 0;
foreach (int number in left)
{
    var score = right.Count(r => r == number);
    totalSimilarityScore += number * score;
}


//Total distance (destructive)
int totalDistance = 0;
while (left.Any() && right.Any())
{
    int minLeft = GetMinAndRemoveIt(left);
    int minRight = GetMinAndRemoveIt(right);

    int distance = Math.Abs(minLeft - minRight);
    totalDistance += distance;
}

Console.WriteLine("total distance is: " + totalDistance);
Console.WriteLine("total similarity score is: " + totalSimilarityScore);


static int GetMinAndRemoveIt(List<int> list)
{
    int minValue = list.Min();
    int index = list.IndexOf(minValue);
    list.RemoveAt(index);
    return minValue;
}