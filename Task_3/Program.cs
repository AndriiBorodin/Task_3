
class Program

{
	static void Main(string[] args)
	{
		Console.Write("Select user mode: \n Command - press 'c' key button " +
		              " \n Dialog - press 'd' key button" +
		              "\n Exit - press 'q' key button: ");
		ConsoleKeyInfo user_input = default;
		do
		{
			user_input = Console.ReadKey();

			if (user_input.Key == ConsoleKey.C)
			{
				KeyInputCommand();
			}
			else if (user_input.Key == ConsoleKey.D)
			{
				KeyInputDialog();
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write("\nIncorrect input, try again: ");
				Console.ResetColor();
			}

		} while (user_input.Key != ConsoleKey.Q);
		Console.WriteLine("\nBye.");
		Environment.Exit(0);
	}

	static void KeyInputDialog()
	{
		int array_len = 0;
		Console.Write("\nEnter array length: ");
		try
		{
			array_len = int.Parse(Console.ReadLine());
			int[] array = new int[array_len];
			for (int i = 0; i < array.Length; i++)
			{
				Console.Write($"Enter value for element [{i}]: ");
				array[i] = int.Parse(Console.ReadLine());
			}
			ArrayStatisticDialog(array);
		}
		catch
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("\nIncorrect input, use integer only");
			Console.ResetColor();
		}
		finally
		{
			KeyInputDialog();
		}
	}

	static void KeyInputCommand()
	{
		int[] array = Array.Empty<int>();
		Console.WriteLine("\nEnter array values, separated by space: ");
		try
		{
			array = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
			ArrayStatisticCommand(array);
		}
		catch
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("\nIncorrect input, use integer only");
			Console.ResetColor();
		}
		finally
		{
			KeyInputCommand();
		}
	}

	static void ArrayStatisticDialog(int[] array)
	{
		Console.WriteLine("*************************************");
		Console.WriteLine("Array min element:         | {0, 1}", FindMinArrayElement(array));
		Console.WriteLine("Array max element:         | {0, 1}", FindMaxArrayElement(array));
		Console.WriteLine("Array elements sum:        | {0, 1}", FindArrayElementsSum(array));
		Console.WriteLine("Array standard devitation: | {0, 1}", FindArrayStandardDeviation(array));
		Console.WriteLine("*************************************");
		UserExitValidation();
	}
	
	static void ArrayStatisticCommand(int[] array)
	{
		Console.WriteLine("*************************************");
		Console.WriteLine("Array min element:         | {0, 1}", FindMinArrayElement(array));
		Console.WriteLine("Array max element:         | {0, 1}", FindMaxArrayElement(array));
		Console.WriteLine("Array elements sum:        | {0, 1}", FindArrayElementsSum(array));
		Console.WriteLine("Array standard devitation: | {0, 1}", FindArrayStandardDeviation(array));
		Console.WriteLine("*************************************");
		Environment.Exit(0);
	}

	static int FindMinArrayElement(int[] array)
	{
		int min = array[0];
		for (int i = 0; i < array.Length; i++)
		{
			if (min > array[i])
			{
				min = array[i];
			}
		}
		return min;
	}
	
	static int FindMaxArrayElement(int[] array)
	{
		int max = array[0];
		for (int i = 0; i < array.Length; i++)
		{
			if (max < array[i])
			{
				max = array[i];
			}
		}
		return max;
	}

	static int FindArrayElementsSum(int[] array)
	{
		int sum = 0;
		for (int i = 0; i < array.Length; i++)
		{
			sum = sum + array[i];
		}
		return sum;
	}
	
	static float FindArrayStandardDeviation(int[] array)
	{
		int sum = 0;
		float avg_rate = 0;
		float square_deviation = 0;
		float square_deviation_sum = 0;
		float dispersion = 0;

		for (int i = 0; i < array.Length; i++)
		{
			sum += array[i];
		}

		avg_rate = sum / array.Length;

		for (int j = 0; j < array.Length; j++)
		{
			square_deviation = (float) Math.Pow(array[j] - avg_rate, 2);
			square_deviation_sum += square_deviation;
		}

		dispersion = square_deviation_sum / avg_rate;
		return (float) Math.Sqrt(dispersion);
	}

	static void UserExitValidation()
	{
		Console.Write("For exit press 'q' key button, \n to continue press any key: ");
		ConsoleKeyInfo user_input = Console.ReadKey();
		Console.WriteLine("");
		while (user_input.Key != ConsoleKey.Q)
		{
			KeyInputDialog();
			UserExitValidation();
		}
		Console.WriteLine("Bye.");
		Environment.Exit(0);
	}
}