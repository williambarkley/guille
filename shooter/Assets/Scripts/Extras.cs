using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;

//This class stores the constant values used in the program
public static class Constant
{
    public static int actual_score;

    public const string SCORE_FILE = "HighScores.txt";
    public const string MENU_SCENE = "Title";
    public const string GAME_SCENE = "Game";
    public const string GAMEOVER_SCENE = "GameOver";

    public const float MAX_X = 15;
    public const float MIN_X = -15;
    public const float MAX_Y = 15;
    public const float MIN_Y = -15;
    public const float LIMIT_OFFSET = 2;

    public const int MAX_HP = 3;
    public const int ASTEROID_HP = 4;

    public const float BULLET_SPEED = 10;
    public const float BIG_BULLET_SPEED = 7.5f;
    public const float COOLDOWN = 10;

    public const float ASTEROID_SPEED = 5;
    public const float ASTEROID_SPEED_VARIATION = 0.5f;
    public const int ASTEROID_SCORE = 50;

    public const float CAM_MAX_X = 6.5f;
    public const float CAM_MIN_X = -6.5f;
    public const float CAM_MAX_Y = 10.5f;
    public const float CAM_MIN_Y = -10.5f;
}

//This class stores some useful functions
public static class Functions
{
    //Algorithm to order an array of numbers
    public static void orderGTL<T>(ref T[] arr)
    {
        if (arr is double[] || arr is float[] || arr is int[])
        {
            int changes;

            //We check if any numbers are out of desired order (greater to lower)
            do
            {
                changes = 0;

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    //Little trick to compare generic types
                    double num1, num2;
                    double.TryParse(arr[i].ToString(), out num1);
                    double.TryParse(arr[i + 1].ToString(), out num2);

                    //if the element is lesser than the next one, swap them
                    if (num1 < num2)
                    {
                        swap(ref arr[i], ref arr[i + 1]);

                        //a change has been made
                        changes++;
                    }
                }
                //If no changes are made, the final array is ready
                //Otherwise, repeat; resetting the chages made counter
            } while (changes > 0);
        }
    }

    //Swaps the values of two variables
    public static void swap<T>(ref T a, ref T b)
    {
        T aux;
        aux = a;
        a = b;
        b = aux;
    }

    //Outputs a text file into an array of strings for each line, skipping a given number of them
    public static string[] readFile(string file, int skipLines)
    {
        //will store all the text file
        string[] lines;
        //will store only the output
        string[] final;

        //we read from the file
        lines = File.ReadAllLines(file);
        final = new string[lines.Length - skipLines];

        //we take the desired output
        for (int i = skipLines; i < lines.Length; i++)
            final[i - skipLines] = lines[i];

        return final;
    }

    //Adds a line to a text file
    public static void writeFileLine(string file, string text)
    {
        File.AppendAllText(file, "\n" + text);
    }

    //Creates a text file with an initial line
    public static void createFile(string file, string text)
    {
        File.WriteAllText(file, text);
    }

    static System.Random rng = new System.Random();

    //Returns random number between the ones given. For int input, int output; otherwise, double output.
    public static double rand(double min, double max)
    {
        return rng.NextDouble() * (max - min);
    }
    public static int rand(int min, int max)
    {
        return rng.Next(min, max);
    }

    public static float vectorLenght(Vector2 vector)
    {
        float result = (float)Math.Sqrt(Math.Pow(vector.x, 2) + Math.Pow(vector.y, 2));
        return result;
    }
}