namespace Advent_of_Code.Challenges;

internal class Day3 : Common
{
    private readonly List<string> _corruptedMemory;
    private readonly List<List<int>> _fixedMemory;

    public Day3()
    {
        _corruptedMemory = new List<string>();
        _fixedMemory = new List<List<int>>();
        //_corruptedMemory.Add("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))");
        GetInputData("input#day3");
    }

    protected sealed override void GetInputData(string fileName)
    {
        var inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input", $"{fileName}.txt");
        var sr = new StreamReader(inputFilePath);
        var inputTextLine = sr.ReadLine();
        while (inputTextLine != null)
        {
            _corruptedMemory.Add(inputTextLine);
            inputTextLine = sr.ReadLine();
        }
    }


    public void ScanMemory()
    {
        var allowMul = true;
        foreach (var memory in _corruptedMemory)
            for (var index = 0; index < memory.Length; index++)
                if ((!string.IsNullOrEmpty(memory[index].ToString()) && memory[index] == 'm') || memory[index] == 'd')
                {
                    var segment = memory.Substring(index, 7);
                    if (segment.Contains("don't()", StringComparison.OrdinalIgnoreCase))
                        allowMul = false;

                    if (segment.Substring(0, 4).Contains("do()"))
                        allowMul = true;

                    var m = memory.Substring(index, 3);

                    if (m != "mul") continue;

                    var firstMudValueAsString = string.Empty;
                    var secondMudValueAsString = string.Empty;

                    if (memory[index + 3] != '(')
                        continue;
                    var isValidValue = false;
                    for (var i = index + 4; i < memory.Length; i++)
                    {
                        var x = memory[i];
                        if (!char.IsDigit(memory[i])) continue;
                        do
                        {
                            if (!char.IsDigit(memory[i])) break;

                            firstMudValueAsString += memory[i];
                            i++;
                        } while (memory[i] != ',');

                        i++;
                        do
                        {
                            secondMudValueAsString += memory[i];
                            i++;
                        } while (char.IsDigit(memory[i]));

                        if (memory[i] == ')')
                            isValidValue = true;
                        break;
                    }

                    if (string.IsNullOrEmpty(firstMudValueAsString) || string.IsNullOrEmpty(secondMudValueAsString) ||
                        !isValidValue) continue;

                    if (!allowMul) continue;

                    var firstMudValue = int.Parse(firstMudValueAsString);
                    var secondMudValue = int.Parse(secondMudValueAsString);
                    _fixedMemory.Add([
                        firstMudValue,
                        secondMudValue
                    ]);
                    allowMul = true; //reset for next segment
                }

        var calculatedValues = new List<int>();
        foreach (var fm in _fixedMemory) calculatedValues.Add(fm[0] * fm[1]);
        Console.WriteLine("Part One => if you add up all of the results of the multiplications is? {0}",
            calculatedValues.Sum());
    }
}