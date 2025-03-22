namespace LINQ_works_with_objects;

class Program
{
    static void Main(string[] args)
    {
        //TSD2491 - LAB10:
        // IEnumerable<Comic> mostExpensive =
        var mostExpensive =
            from comic in Comic.Catalog
            where Comic.Prices[comic.Issue] > 500
            orderby Comic.Prices[comic.Issue] descending
            select comic;

        foreach (Comic comic in mostExpensive)
        {
            Console.WriteLine($"{comic} is worth {Comic.Prices[comic.Issue]:c}");
        }

    
   //TSD2491 - Lamda syntax =>
    Console.WriteLine("evenNumbers: ");
   //1. **Filtrering med `Where`**:
   List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
   var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
   //Utskrift på en linje med forEach og lambda =>:
   evenNumbers.ForEach(n => Console.Write(n + " "));
   // Resultat: { 2, 4, 6 }
   Console.WriteLine();
 

   //2. **Uttrekk med `Select`**:
   List<string> names = new List<string> { "Alice", "Bob", "Charlie" };
   var nameLengths = names.Select(name => name.Length).ToList();
   nameLengths.ForEach(length => Console.Write("Length:" + length + " "));
   Console.WriteLine("\nSorted numbers:");

   //3. **Sortering med `OrderBy`**:
   List<int> numbers2 = new List<int> { 5, 3, 8, 1, 2 };
   var sortedNumbers = numbers2.OrderBy(n => n).ToList();
   sortedNumbers.ForEach(num => Console.Write(num + " "));
   // Resultat: { 1, 2, 3, 5, 8 }
   
   Console.WriteLine();

   //4. **Gruppering med `GroupBy`**:
   List<string> names2 = new List<string> { "Alice", "Bob", "Charlie", "David", "Eve" };
   var groupedNames = names2.GroupBy(name2 => name2.Length);
   foreach (var group in groupedNames)
   {
       Console.WriteLine($"\nLength: {group.Key}");
       foreach (var name in group)
       {
           Console.WriteLine(name);
       }
   }
   // Resultat:
   // Length: 3
   // Bob
   // Eve
   // Length: 5
   // Alice
   // David
   // Length: 7
   // Charlie
   

   //5. **Aggregasjon med `Sum`**:
   List<int> numbers3 = new List<int> { 1, 2, 3, 4, 5 };
   int sum = numbers.Sum(n => n);
   Console.WriteLine("sum:" + sum);
   // Resultat: 15   

    }
}
