int[] array = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();
Console.WriteLine($"[{string.Join("; ",array)}]");
for (int i = 0, j = 0; i< array.Length; i++)
    if (array[i] != array[j]) array[++j] = array[i];
Console.WriteLine($"[{string.Join("; ",array)}]");