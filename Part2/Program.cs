namespace Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var maps = new List<Map>();
            var lineGroup = new List<string>();
            foreach (var line in lines)
            {
                if(string.IsNullOrWhiteSpace(line))
                {
                    maps.Add(new Map(lineGroup));
                    lineGroup.Clear();
                    continue;
                }
                lineGroup.Add(line);
            }
            maps.Add(new Map(lineGroup));

            var sum1 = maps.Sum(m => m.GetVerticalMirror(0)) + maps.Sum(m => 100 * m.GetHorizontalMirror(0));
            var sum2 = maps.Sum(m => m.GetVerticalMirror(1)) + maps.Sum(m => 100 * m.GetHorizontalMirror(1));

            Console.WriteLine($"Part 1: {sum1}");
            Console.WriteLine($"Part 2: {sum2}");
        }
    }
}
