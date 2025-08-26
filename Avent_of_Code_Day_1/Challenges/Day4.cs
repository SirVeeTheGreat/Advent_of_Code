namespace Advent_of_Code.Challenges;

internal class Day4 : Common
{
    private readonly char[,] _grid;
    private readonly string keyword = "XMAS";
    private string[] _lines;

    public Day4()
    {
        //_lines =
        //[
        //    "MMMSXXMASM",
        //    "MSAMXMSMSA",
        //    "AMXSXMAAMM",
        //    "MSAMASMSMX",
        //    "XMASAMXAMM",
        //    "XXAMMXXAMA",
        //    "SMSMSASXSS",
        //    "SAXAMASAAA",
        //    "MAMMMXMMMM",
        //    "MXMXAXMASX"
        //];

        GetInputData("input#day4");
        _grid = new char[_lines[0].Length, _lines.Length];
        ConvertLinesToGrid();
    }

    protected sealed override void GetInputData(string fileName)
    {
        _lines = [];
        var inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", $"{fileName}.txt");
        var sr = new StreamReader(inputFilePath);
        var inputTextLine = sr.ReadLine();
        while (inputTextLine != null)
        {
            _lines = _lines.Append(inputTextLine).ToArray();

            inputTextLine = sr.ReadLine();
        }
    }


    private void ConvertLinesToGrid()
    {
        for (var i = 0; i < _lines.Length; i++)
        for (var j = 0; j < _lines[i].Length; j++)
            _grid[i, j] = _lines[i][j];
    }

    public void FindWords()
    {
        int[] rowDirections = [-1, -1, -1, 0, 0, 1, 1, 1];
        int[] colDirections = [-1, 0, 1, -1, 1, -1, 0, 1];

        var rows = _grid.GetLength(0);
        var cols = _grid.GetLength(1);
        var count = 0;


        for (var row = 0; row < _grid.GetLength(0); row++)
        for (var col = 0; col < _grid.GetLength(1); col++)
            if (_grid[row, col] == keyword[0])
                for (var dir = 0; dir < 8; dir++)
                {
                    int rr = row, cc = col;
                    int k;
                    for (k = 0; k < keyword.Length; k++)
                    {
                        if (rr < 0 || rr >= rows || cc < 0 || cc >= cols) //we are checking the boundaries
                            break;

                        if (_grid[rr, cc] != keyword[k])
                            break;

                        rr += rowDirections[dir];
                        cc += colDirections[dir];
                    }

                    if (k == keyword.Length)
                        count++;
                }


        Console.WriteLine($"Part => {keyword} was found {count} times");
    }


    public void FindWordXMas()
    {
        var rows = _grid.GetLength(0);
        var cols = _grid.GetLength(1);
        var count = 0;


        for (var row = 1; row < rows- 1; row++)
        for (var col = 1; col < cols - 1; col++)

            if (_grid[row, col] == 'A')
            {
                var dia1 = $"{_grid[row - 1, col - 1]}A{_grid[row + 1, col + 1]}";
                var dia2 = $"{_grid[row - 1, col + 1]}A{_grid[row + 1, col - 1]}";


                if ((dia1 == "MAS" || dia1 == "SAM") &&
                    (dia2 == "MAS" || dia2 == "SAM"))
                    count++;
            }
        Console.WriteLine($"Part two => MAS was found {count} times");
    }
}