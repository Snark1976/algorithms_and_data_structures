Random random = new();
int number = 10;
int[] array = new int[100].Select(x => random.Next(number)).ToArray(); 
Console.WriteLine($"[{string.Join("; ",array)}]");
int[] counters = new int[number];
foreach (int element in array)
    counters[element]++;
for (int i = 0, j = 0; i < counters.Length; i++ )  
    for (int k = 0; k < counters[i]; k++)
    array[j++] = i;
Console.WriteLine($"[{string.Join("; ",array)}]");
