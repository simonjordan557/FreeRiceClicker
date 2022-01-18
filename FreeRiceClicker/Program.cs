// See https://aka.ms/new-console-template for more information

using GregsStack.InputSimulatorStandard;

Console.Title = "FreeRice Clicker";
Console.BackgroundColor = ConsoleColor.DarkCyan;
Console.ForegroundColor = ConsoleColor.Yellow;
Console.Clear();

InputSimulator inputSimulator = new InputSimulator();
Random rng = new Random();

int clicks = 0;
List<int> whenToClickBackToGame = new List<int>();

double screenX = 950;
double screenY;
double backToGameY = 540;
List<double> screenYList = new List<double>() { 290, 350, 410, 470 };



while (true)
{
   
    Thread.Sleep(1000);

    if (clicks % 400 == 0 && clicks != 0)
    {
        Console.WriteLine($"MULTIPLE OF 400? {clicks % 400}: {clicks % 400 == 0}.");
        whenToClickBackToGame.Clear();

        for (int i = clicks; i <= clicks + 100; i += 10)
        {
            whenToClickBackToGame.Add(i);
            Console.WriteLine($"ADDING {i} TO LIST...");
        }
    }

    screenY = (whenToClickBackToGame.Contains(clicks)) ? backToGameY : screenYList[rng.Next(0, 4)];
    
    inputSimulator.Mouse.MoveMouseTo(ConvertToX(screenX), ConvertToY(screenY));
    Console.WriteLine($"MOVE! (Y = {screenY})");
    Thread.Sleep(600);
    inputSimulator.Mouse.LeftButtonClick();
    clicks++;
    Console.WriteLine($"CLICK {clicks}!");
    Thread.Sleep(3000);
}

double ConvertToX(double startX)
{
    return startX * 65535 / 1919;
}

double ConvertToY(double startY)
{
    return startY * 65535 / 1079;
}


