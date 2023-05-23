Random random = new();
const int NUMBER = 10;
int[] array = new int[100].Select(x => random.Next(NUMBER)).ToArray(); 
Console.WriteLine($"[{string.Join("; ",array)}]");
CountingSort(array);
Console.WriteLine($"[{string.Join("; ",array)}]");

void CountingSort(int[] array, int number = NUMBER) 
{
    int[] counters = new int[number];
    foreach (int element in array)
        counters[element]++;
    for (int i = 0, j = 0; i < counters.Length; i++ )  
        for (int k = 0; k < counters[i]; k++)
        array[j++] = i;
}