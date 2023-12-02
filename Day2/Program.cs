var input = File.ReadAllLines("Input.txt");
var games = new List<Game>();
foreach (var line in input)
{
    var parts = line.Split(":");
    var id = int.Parse(parts[0].Replace("Game ", ""));
    var game = new Game(id);
    var sets = parts[1].Split(";");
    foreach (var setString in sets)
    {
        var cubes = setString.Split(",");
        int red = 0;
        int green = 0;
        int blue = 0;
        foreach (var cube in cubes)
        {
            var cubeStrings = cube.Trim().Split(" ");
            var amount = int.Parse(cubeStrings[0]);
            var color = cubeStrings[1];
            
            switch (color)
            {
                case "red":
                    red = amount;
                    break;
                case "green":
                    green = amount;
                    break;
                case "blue":
                    blue = amount;
                    break;
            }
        }
        var set = new Set(red, green, blue);
        game.Sets.Add(set);
    }
    games.Add(game);
}

Part1();
Part2();

void Part1()
{
    var totalRed = 12;
    var totalGreen = 13;
    var totalBlue = 14;
    var sumOfPossibleGameIds = 0;
    foreach (var game in games)
    {
        var impossible = false;
        foreach (var set in game.Sets)
        {
            var red = set.Red;
            var green = set.Green;
            var blue = set.Blue;
            
            if (red > totalRed || green > totalGreen || blue > totalBlue)
            {
                Console.WriteLine($"Game {game.Id} impossible: Red: {red}, Green: {green}, Blue: {blue}");
                impossible = true;
                break;
            }
        }
        if (!impossible)
        {
            sumOfPossibleGameIds+=game.Id;

        }
    }
    Console.WriteLine($"Sum of possible game ids: {sumOfPossibleGameIds}"); // 2237 
}

void Part2()
{
    var sumOfPower = 0;
    foreach (var game in games)
    {
        var red = 0;
        var green = 0;
        var blue = 0;
        foreach (var set in game.Sets)
        {
            red = Math.Max(red, set.Red);
            green = Math.Max(green, set.Green);
            blue = Math.Max(blue, set.Blue);
        }
        var power = red * green * blue;
        sumOfPower += power;
        Console.WriteLine($"Game {game.Id} max: Red: {red}, Green: {green}, Blue: {blue}, Power: {power}");
    }
    Console.WriteLine($"Sum of power: {sumOfPower}"); // 66681
}

record Game(int Id)
{
    public List<Set> Sets { get; set; } = new();
}

record Set(int Red, int Green, int Blue);
