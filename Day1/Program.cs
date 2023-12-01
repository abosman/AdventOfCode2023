var input = File.ReadAllLines(@"Input.txt");

Part1();
Part2();

void Part1()
{
    Console.WriteLine("Part 1");
    var sumOfCalibrationValues = 0;
    foreach (var line in input)
    {
        var firstCalibrationChar = line.First(char.IsDigit);
        var lastCalibrationChar = line.Last(char.IsDigit);
        var calibrationString = firstCalibrationChar + lastCalibrationChar.ToString();
        var calibrationValue = int.Parse(calibrationString);
        sumOfCalibrationValues += calibrationValue;
    }

    Console.WriteLine($"Sum of calibration values: {sumOfCalibrationValues}"); //55172
}

void Part2()
{
    Console.WriteLine("Part 2");

    var sumOfCalibrationValues = 0;
    var digits = new Dictionary<string, char>
    {
        { "one", '1' },
        { "two", '2' },
        { "three", '3' },
        { "four", '4' },
        { "five", '5' },
        { "six", '6' },
        { "seven", '7' },
        { "eight", '8' },
        { "nine", '9' }
    };

    foreach (var line in input)
    {
        // first digit
        var calibrationChar = line.FirstOrDefault(char.IsDigit);
        (int, char) firstCalibrationValue = (line.IndexOf(calibrationChar) == -1 ? line.Length-1: line.IndexOf(calibrationChar), calibrationChar);
        foreach (var digit in digits)
        {
            var index = line.IndexOf(digit.Key);
            if (index == -1) continue;
            if (index < firstCalibrationValue.Item1)
            {
                firstCalibrationValue = (index, digit.Value);
            }
        }

        // second digit
        calibrationChar = line.LastOrDefault(char.IsDigit);
        (int, char) lastCalibrationValue = (line.LastIndexOf(calibrationChar) == -1 ? 0 : line.LastIndexOf(calibrationChar), calibrationChar);
        foreach (var digit in digits)
        {
            var index = line.LastIndexOf(digit.Key);
            if (index == -1) continue;
            if (index > lastCalibrationValue.Item1)
            {
                lastCalibrationValue = (index, digit.Value);
            }
        }

        var calibrationString = firstCalibrationValue.Item2 + lastCalibrationValue.Item2.ToString();
        var calibrationValue = int.Parse(calibrationString);
        sumOfCalibrationValues += calibrationValue;
    }

    Console.WriteLine($"Sum of calibration values: {sumOfCalibrationValues}"); // 54925
}