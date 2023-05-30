namespace home_work_3
{
    public class Progaram
    {
        public static void Main(string[] args)
        {
            MyLinkedList myLinkedList = new();

            myLinkedList.Add(1);
            myLinkedList.Add(2);
            myLinkedList.Add(3);
            myLinkedList.Add(4);
            Console.WriteLine(myLinkedList);

            Console.WriteLine($"Размер: {myLinkedList.Size()}"); // размер
            Console.WriteLine(myLinkedList.Contains(3)); // найден элемент
            Console.WriteLine(myLinkedList.Contains(10)); // не найден элемент
            Console.WriteLine(myLinkedList.Reversed()); // перевернутый
        }
    }
}