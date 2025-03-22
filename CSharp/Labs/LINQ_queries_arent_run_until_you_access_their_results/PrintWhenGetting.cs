namespace LINQ_queries_arent_run_until_you_access_their_results
{
    class PrintWhenGetting 
    {
        private int number;
        public PrintWhenGetting(int number)
        {
            this.number = number;
        }
        
        public int Number
        {
            get
            {
                Console.WriteLine($"Getting #{number}");
                return number;
            }
        }
    }

}