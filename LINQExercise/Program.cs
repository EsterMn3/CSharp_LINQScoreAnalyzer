using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Specify the data source.
        List<int> scores = new List<int> { 97, 92, 81, 60, 90, 77, 64 };

        //to find all the scores that are over 80

        /*//The method below is doing it manually
        for (int i = 0; i < scores.Count; i++)
        {
            if(scores[i]>80){
                Console.WriteLine($"Found a score over 80 {scores[i]}");
            }
        }
        */
        //we can use LINQ thats better

        // Define the query expression.
        //we use IEnumerable, not a list (it doesnt know what the next one is, until you ask for it, it just knows that is something that can be counted )
        //this is a deferred execution, so the scorequery is not the answer but its a question
        //what popsup from this is not explicitly a list of events
        IEnumerable<int> scoreQuery =//we do not give a formula how, we just express what we want to have
            from score in scores //like the foreach, look at all the scores, find the ones that are over 80, and give me that score
            where score > 80
            orderby score descending
            select score;

        int count = scoreQuery.Count();
        Console.WriteLine($"There are {count} scores that are over 80. ");

        // Output the scores that are over 80
        // Execute the query.
        Console.WriteLine("\nThe scores that are over 80: ");
        List<int> myScores = scoreQuery.ToList();

        foreach (var score in myScores)
        {
            Console.Write(score + " ");
        }

        Console.WriteLine("\nThe scores that are over 80 (using lambda expression): ");

        //same as the above lines but without from and select. this is called query
        var scoreQuery3 = scores.Where(s => s > 80).
                            OrderByDescending(s => s);

        foreach (var score in scoreQuery3)
        {
            Console.Write(score + " ");
        }


        Console.WriteLine("\n\nThe scores that are over 80 (making a projection into string list): ");

        //i can even make a projection to transform integers incoming to a list of strings
        IEnumerable<string> scoreQuery2 = //query variable
            from score in scores //required
            where score > 80 //optional
            orderby score descending //optional
            select $"The score is {score}"; //must end with select or group

        // Output the scores that are over 80
        // Execute the query.
        foreach (string s in scoreQuery2)
        {
            Console.WriteLine(s);
        }
        // the query expression to calculate the average score
        var averageScoreQuery = (from score in scores
                                 select score).Average();

        // Round the average to two decimal places
        double roundedAverage = Math.Round(averageScoreQuery, 2);

        Console.WriteLine($"\nThe average score is: {roundedAverage}");

        // Query expression to filter even numbers
        IEnumerable<string> evenOddNumQuery =
                        from num in scores
                        select num % 2 == 0 ? $"Even number: {num}" : $"Odd number: {num}";

        // specifying the even and odd numbers in the list 
        Console.WriteLine("\n--Even and Odd Numbers--");
        foreach (string s in evenOddNumQuery)
        {
            Console.WriteLine(s);
        }

        //finding the maximum number in the list
        IEnumerable<int> maxNumber =
            from score in scores
            select score;

        var highScore = maxNumber.Max();
        Console.WriteLine($"\nThe maximum score is: {highScore}");

        //finding the numbers that are greater than 70 and smaller then 93

        IEnumerable<int> numbersQuery =
            from score in scores
            where score is > 70 and < 93
            orderby score ascending 
            select score;
        Console.WriteLine("\nThe numbers between 70 and 93 are:");

        foreach (int score  in numbersQuery){
        Console.Write($"{score}  ");

        }

    }
}
