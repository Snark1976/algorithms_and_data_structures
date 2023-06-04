namespace home_work_4
{
    public class Progaram
    {
        public static void Main(string[] args)
        {
            Tree<int> tree = new();

            tree.Add(10);
            tree.Add(71);
            tree.Add(2);
            tree.Add(13);
            tree.Add(24);
            tree.Add(15);
            Console.WriteLine(string.Join(' ', tree.Bfs()));
            tree.Remove(10);
            Console.WriteLine(string.Join(' ', tree.Bfs()));
            Console.WriteLine(string.Join(' ', tree.Dfs()));
        }
    }
}
