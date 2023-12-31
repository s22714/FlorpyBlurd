using Game;

Console.Title = "FLORPY BLURD";

var Menu = new MainMenu();
Menu.OpenMainMenu();

int origRow;
int origCol;

int score = 0;

void WriteAt(string s, int x, int y)
{
    Console.SetCursorPosition(origCol + x, origRow + y);
    Console.Write(s);
}

Console.Clear();
origRow = Console.CursorTop;
origCol = Console.CursorLeft;

int width = 120;
int height = 28;

Console.SetWindowSize(1, 1);
Console.SetBufferSize(width, height);
Console.SetWindowSize(width, height);

var rnd = new Random();

string[,] sciany = new string[width,2];

sciany[width - 1,0] = "#";
sciany[width - 1, 1] = "4";

int interval = 40;
int drawWall = 0;

int pos = 10;

Thread t = new Thread(new ThreadStart(PlayerPos));
t.Start();

Thread t2 = new Thread(new ThreadStart(PlayerFall));
t2.Start();

int last = 10;

while (true)
{

    DrawScreen();

    drawWall++;
    
    for(int i = 0; i < width; i++)
    {
        if (sciany[i,0] == "#")
        {
            if(i == 0)
            {
                sciany[i, 0] = "";
                sciany[i, 1] = "";
            }
            else
            {
                sciany[i - 1, 0] = sciany[i, 0];
                sciany[i - 1, 1] = sciany[i, 1];

                sciany[i, 0] = "";
                sciany[i, 1] = "";
            }
        }
    }

    if(interval == drawWall)
    {
        drawWall = 0;
        sciany[width - 1, 0] = "#";
        sciany[width - 1, 1] = rnd.Next(12,height-8).ToString();
    }
    
}

void DrawScreen()
{

    if(pos >= height || pos < 0)
    {
        Menu.GameOver(score);
        t.Interrupt();
        t2.Interrupt();
    }

    for (int x = 0; x < width; x++)
    {
        for (int y = 0; y < height; y++)
        {
            if (x == pos && y == 10)
            {
                WriteAt("@", 10, pos);
            }
            if (y == height - 1 || y == 0)
            {
                WriteAt("_", x, y);
            }
        }
    }
    Console.WriteLine("SCORE: " + score.ToString());
    for (int x = 0; x < width; x++)
    {
        if (sciany[x, 0] == "#")
        {

            for (int y = height - 1; y > 0; y--)
            {
                if(!(y <= height - Int32.Parse(sciany[x, 1]) - 1 && y >= height - Int32.Parse(sciany[x, 1]) - 1 - 4 ))
                    WriteAt("#", x, y);
            }
            if(x == 10)
            {
                if (!(pos <= height - Int32.Parse(sciany[x, 1]) - 1 && pos >= height - Int32.Parse(sciany[x, 1]) - 1 - 6))
                {
                    Menu.GameOver(score);
                    t.Interrupt();
                    t2.Interrupt();
                }
                else score++;
            }
        }
    }
    
    Thread.Sleep(10);
    Console.Clear();
    origRow = Console.CursorTop;
    origCol = Console.CursorLeft;
}

void PlayerPos()
{
    while (true)
    {
        if (Console.ReadKey().Key == ConsoleKey.Spacebar) pos-=4;
    }
    
}

void PlayerFall()
{
    while (true)
    {
        pos++;
        Thread.Sleep(100);
    }
}