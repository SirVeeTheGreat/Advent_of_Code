namespace Advent_of_Code.Challenges;

internal class Day2 : Common
{
    private readonly List<List<int>> _allReports;
    private readonly List<List<int>> _safeReports;


    public Day2()
    {
        _allReports = new List<List<int>>();
        _safeReports = new List<List<int>>();

        //_allReports.Add([7, 6, 4, 2, 1]);
        //_allReports.Add([1, 2, 7, 8, 9]);
        //_allReports.Add([9, 7, 6, 2, 1]);
        //_allReports.Add([1, 3, 2, 4, 5]);
        //_allReports.Add([8, 6, 4, 4, 1]);
        //_allReports.Add([1, 3, 6, 7, 9]);
        //_allReports.Add([1, 3, 4, 5, 2]);
        GetInputData("input#day2");
    }


    protected sealed override void GetInputData(string fileName)
    {
        var inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", $"{fileName}.txt");
        var sr = new StreamReader(inputFilePath);
        var inputTextLine = sr.ReadLine();
        while (inputTextLine != null)
        {
            var splitValues = inputTextLine.Split(" ");
            var line = Array.ConvertAll(splitValues, int.Parse);
            _allReports.Add(line.ToList());
            inputTextLine = sr.ReadLine();
        }
    }


    public void FindSafeReports()
    {
        foreach (var report in _allReports)
        {
            var reportLevels = GetReportLevelsDifferential(report);
            TryAddWhenReportIsSafe(reportLevels, report);
        }

        Console.WriteLine("Part One => Number of safe reports is: {0} out of {1} reports", _safeReports.Count(),
            _allReports.Count());
    }

    public void TryRemoveUnsafeLevelsAndCalculateNewSafeReport()
    {
        foreach (var report in _allReports)
        {
            if (_safeReports.Contains(report)) continue;
            TryMakeReportSafe(report);
        }

        Console.WriteLine("Part Two => Number of new safe reports is: {0} out of {1} reports", _safeReports.Count(),
            _allReports.Count());
    }

    private void TryMakeReportSafe(List<int> report)
    {
        for (var i = 0; i < report.Count; i++)
        {
            var potentialSafeReport = report.Where((_, level) => level != i).ToList();
            var levels = GetReportLevelsDifferential(potentialSafeReport);
            var safeCountBefore = _safeReports.Count;
            TryAddWhenReportIsSafe(levels, potentialSafeReport);

            if (_safeReports.Count > safeCountBefore) break;
        }
    }


    private void TryAddWhenReportIsSafe(int[] levels, List<int> report)
    {
        var flags = new bool[levels.Length];
        var direction = 0;
        for (var index = 0; index < levels.Length; index++)
        {
            if (index == levels.Length)
                break;
            var next = report[index + 1];
            var currentLevel = report[index];

            // 0 increase, 1 decrease
            if (index == 0)
                direction = GetReportLevelDirection(currentLevel, next);

            if (IsReportLevelDifferentialInAcceptedRange(levels[index]))
            {
                if (!IsLevelChangingDirections(report[index], report[index + 1], ref direction))
                    flags[index] = true;
                else
                    flags[index] = false;
            }
            else
            {
                flags[index] = false;
            }
        }

        if (flags.All(a => a))
            _safeReports.Add(report);
    }


    private bool IsLevelChangingDirections(int current, int next, ref int direction)
    {
        if (current <= next)
            if (direction == 0)
                return false;

        if (current >= next)
            if (direction == 1)
                return false;

        return true;
    }

    private int[] GetReportLevelsDifferential(List<int> report)
    {
        var levels = new int[report.Count - 1];

        for (var i = 0; i < report.Count; i++)
        {
            if (i == report.Count - 1)
                break;

            var current = report[i];
            var next = report[i + 1];

            if (current == next)
            {
                levels[i] = 0;
                continue;
            }

            var dif = 0;
            if (current < next)
                dif = next - current;
            else dif = current - next;

            levels[i] = dif;
        }

        return levels;
    }


    private bool IsReportLevelDifferentialInAcceptedRange(int level)
    {
        return level is > 0 and <= 3;
    }

    private int GetReportLevelDirection(int current, int next)
    {
        if (current < next)
            return 0; //Increasing levels
        return 1; //Decreasing levels
    }

  
}