using System;

namespace LongestRepeatedSubstring
{
    class Program
    {
		/*
		traverse the string
		extract a substring from the string starting from the beginning
		keep count of its length only if the substring can produce the input string after being repeated
		iterate again but increasing the substring length
		*/
		public static string StringPeriods(string str)
		{
			if (str.Length == 1)
			{
				return "-1";
			}

			string substring = "";
			string result = "";  // -1 or substring
			int current = 0;

			// Loop to traverse input string and compare substring
			while (current < str.Length / 2)
			{
				bool valid = true; // signal checking if the substring can complete the input string after repetitions
				substring += str[current]; // With each iteration the substring to check will increase

				for(int i = current + 1; i < str.Length; i += substring.Length)
				{
					// condition comparing the current substring to substring in our input string
					// If is not equal than this current substring is invalid
					if (substring != str.Substring(i, substring.Length))
					{
						valid = false;
						break;
					}
				}

				// Will update the largest substring that is valid
				if (valid && substring.Length > result.Length)
				{
					result = substring;
				}

				current++;
			}

			if (result.Length > 1)
			{
				return result;
			}
			else
			{
				return "-1";
			}
		}
		static void Main(string[] args)
        {
            Console.WriteLine(StringPeriods("abcababcababcab"));
            Console.WriteLine(StringPeriods("abcxabc"));
            Console.WriteLine(StringPeriods("affedaaffed"));
            Console.WriteLine(StringPeriods("abababababab"));
            Console.WriteLine(StringPeriods("gg"));
			Console.ReadLine();
		}
    }
}
