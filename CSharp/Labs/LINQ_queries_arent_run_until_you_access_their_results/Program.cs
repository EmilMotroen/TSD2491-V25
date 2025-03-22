namespace LINQ_queries_arent_run_until_you_access_their_results {
    public class Program {
        public static void Main() {
            var listOfObjects = new List<PrintWhenGetting>();
            for (int i = 1; i < 5; i++)
                listOfObjects.Add(new PrintWhenGetting(i));

            Console.WriteLine("Set up the query");
            var result =
                from o in listOfObjects
                select o.Number;

            Console.WriteLine("Run the foreach");
            var immediate = result.ToList();
            foreach (var number in immediate)
                Console.WriteLine($"Writing #{number}");
        }
    }
}