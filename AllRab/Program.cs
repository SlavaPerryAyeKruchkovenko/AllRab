using System;
using System.Collections.Generic;
using System.IO;


namespace textCalculate
{
	class Program
	{
		public static string SearchMath(string answer)
		{
			string owner="";
			string[] numb = new string[2];
			if (answer.Contains("+"))
			{
				numb = answer.Split('+');
				owner = Counting(numb[0], numb[1], '+');

			}
			else if (answer.Contains("*"))
			{
				numb = answer.Split('*');
				owner = Counting(numb[0], numb[1], '+');
			}
			else if (answer.Contains("/"))
			{
				numb = answer.Split('/');
				owner = Counting(numb[0], numb[1], '+');
			}
			else if (answer.Contains("-"))
			{
				numb = answer.Split('-');
				owner = Counting(numb[0], numb[1], '+');
			}
			else
				return "Это нельзя подсчитать";
			
			return owner;
		}
		public static string Counting(string numb1,string numb2,char letter)
		{
			if (Double.TryParse(numb1, out _) && Double.TryParse(numb1, out _))
				switch(letter)
				{
					case '+':
						{
							return (Convert.ToDouble(numb1) + Convert.ToDouble(numb2)).ToString();								
						}
					case '-':
						{
							return (Convert.ToDouble(numb1) - Convert.ToDouble(numb2)).ToString();
						}
					case '*':
						{
							return (Convert.ToDouble(numb1) * Convert.ToDouble(numb2)).ToString();
						}
					case '/':
						{
							return (Convert.ToDouble(numb1) / Convert.ToDouble(numb2)).ToString();
						}
				}
			else
				return "Это нельзя подсчитать";
			return "";
		}
		static void Main(string[] args)
		{
			//Environment.CurrentDirectory = Environment.GetEnvironmentVariable("windir");
			//File.Create("C:\\proga\\text.txt");
			StreamWriter textNew = new StreamWriter("C:\\proga\\text.txt");
			string text = Environment.CurrentDirectory + "\\calculate.txt";
			string[] operations;
			string answer;			
			operations = File.ReadAllLines(text);
			for (int i = 0; i < operations.Length; i++)
			{
				answer = operations[i].Trim();
				textNew.WriteLine($"Answer {i} : {SearchMath(answer)}");
				Console.WriteLine(SearchMath(answer));
			}			
		}
	}
}
