namespace Advent_of_Code.Challenges;

internal class Day5 : Common
{
    private readonly List<(int X, int Y)> _rules;
    private readonly List<List<int>> _pageNumbers;

    public Day5()
    {
        //_rules = new List<(int, int)>();
        //_pageNumbers = new List<List<int>>();


        //_rules.Add((47, 53));
        //_rules.Add((97, 13));
        //_rules.Add((97, 61));
        //_rules.Add((97, 47));
        //_rules.Add((75, 29));
        //_rules.Add((61, 13));
        //_rules.Add((75, 53));
        //_rules.Add((29, 13));
        //_rules.Add((97, 29));
        //_rules.Add((53, 29));
        //_rules.Add((61, 53));
        //_rules.Add((97, 53));
        //_rules.Add((61, 29));
        //_rules.Add((47, 13));
        //_rules.Add((75, 47));
        //_rules.Add((97, 75));
        //_rules.Add((47, 61));
        //_rules.Add((95, 61));
        //_rules.Add((47, 61));
        //_rules.Add((75, 29));
        //_rules.Add((53, 13));



        //_pageNumbers.Add([75, 47, 61, 53, 29]);
        //_pageNumbers.Add([97, 61, 53, 29, 13]);
        //_pageNumbers.Add([75, 29, 12]);
        //_pageNumbers.Add([75, 97, 47, 61, 53]);
        //_pageNumbers.Add([61, 13, 29]);
        //_pageNumbers.Add([97, 13, 75, 29, 47]);


        //GetInputData("input#day5");
    }

    protected sealed override void GetInputData(string fileName)
    {
        var inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", $"{fileName}.txt");
        using var sr = new StreamReader(inputFilePath);

       
        string inputTextLine = sr.ReadLine();
        while (inputTextLine != null)
        {
            var parts = inputTextLine.Split('|');
            if(parts.Length == 1 && String.IsNullOrEmpty(parts[0]))break;
            _rules.Add((Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1])));
            inputTextLine = sr.ReadLine();
        }


        inputTextLine = sr.ReadLine();
        while (inputTextLine != null)
        {
            var pages = inputTextLine.Split(',').Select(int.Parse).ToList();
            _pageNumbers.Add(pages);
            inputTextLine = sr.ReadLine();
        }
    }

    public void GetMiddlePageFromOrderedPages()
    {
        int sum = _pageNumbers
            .Where(IsPageOrderValid)
            .Select(page => page[page.Count / 2])
            .Sum();

        Console.WriteLine($"Part one => the Sum of middle pages from those correctly-ordered = {sum}");
    }

    private bool IsPageOrderValid(List<int> page)
    {
        var position = page
            .Select((value, index) => new { value, index })
            .ToDictionary(x => x.value, x => x.index);

        foreach (var (left, right) in _rules)
        {
            if (!position.ContainsKey(left) || !position.TryGetValue(right, out var yPos))
                continue;
            if (position[left] > yPos)
                return false;
        }
        return true;
    }
}
    

