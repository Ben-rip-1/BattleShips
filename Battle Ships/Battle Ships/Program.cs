int GridSize = 10;
bool PlayAgain = true;
while (PlayAgain)
{
    int[,] seaP1 = new int[GridSize, GridSize];
    bool[,] hitsP1 = new bool[GridSize, GridSize];
    int[,] seaP2 = new int[GridSize, GridSize];
    bool[,] hitsP2 = new bool[GridSize, GridSize];
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    int across, down, P1row = -1, P1column = 0, i = 0;
    char input = ' ';
    string Sinput = "", P1, P2;
    bool parsed = false, left = false, right = false, up = false, Down = false, loop = true, taken = true, P1first, GameWon = false, P1Won = false, P2Won = false;
    Console.Write("Player 1     Enter name here: ");
    P1 = Console.ReadLine();
    Console.Write("Player 2     Enter name here: ");
    P2 = Console.ReadLine();
    void generalinput(int size, int[,] sea, string Player)
    {
        bool invalid = true;
        while (invalid)
        {
            taken = true;
            while (taken)
            {
                Console.WriteLine(Player + "'s turn");
                generaldisplay(sea);
                left = false; right = false; up = false; Down = false;
                P1row = -1;
                P1column = -1;
                i = 0;
                Console.WriteLine("where do you want to place the first end of your size " + size + " ship");
                while (!parsed || P1column >= GridSize || P1column < 0)
                {
                    Console.Write("Column (letter from A to J) : ");
                    parsed = char.TryParse(Console.ReadLine().ToUpper(), out input);
                    Console.WriteLine((int)input - 65);
                    P1column = (int)input - 65;
                }
                while (!parsed || P1row >= GridSize || P1row < 0)
                {
                    Console.Write($"Row (number 1 to {GridSize}) : ");
                    parsed = Int32.TryParse(Console.ReadLine(), out P1row);
                    P1row--;
                    Console.WriteLine(P1row);
                }
                if (sea[P1column, P1row] != 0)
                {
                    taken = true;
                    Console.WriteLine("Spot taken");
                    Console.ReadKey();
                }
                else
                {
                    taken = false;
                }
            }
            bool valid;
            loop = true;
            while (loop)
            {
                if (P1column >= size)
                {
                    left = true;
                    for (int beta = 0; beta < size; beta++)
                    {
                        if (sea[P1column - beta, P1row] != 0)
                        {
                            left = false;
                        }
                    }
                    if (left)
                    {
                        Console.WriteLine("Left (L)");
                        i++;
                    }
                }
                if (P1column <= (GridSize - size))
                {
                    right = true;
                    for (int beta = 0; beta < size; beta++)
                    {
                        if (sea[P1column + beta, P1row] != 0)
                        {
                            right = false;
                        }
                    }
                    if (right)
                    {
                        Console.WriteLine("Right (R)");
                        i++;
                    }
                }
                if (P1row >= size)
                {
                    up = true;
                    for (int beta = 0; beta < size; beta++)
                    {
                        if (sea[P1column, P1row - beta] != 0)
                        {
                            up = false;
                        }
                    }
                    if (up)
                    {
                        Console.WriteLine("Up (U)");
                        i++;
                    }
                }
                if (P1row <= (GridSize - size))
                {
                    Down = true;
                    for (int beta = 0; beta < size; beta++)
                    {
                        if (sea[P1column, P1row + beta] != 0)
                        {
                            Down = false;
                        }
                    }
                    if (Down)
                    {
                        Console.WriteLine("Down (D)");
                        i++;
                    }
                }
                if (i == 0)
                {
                    invalid = true;
                    Console.WriteLine("No valid directions to go in");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadKey();
                    loop = false;
                }
                else
                {
                    Console.WriteLine("what direction do you want the ship to go in");
                    invalid = false;
                    valid = true;
                    Sinput = Console.ReadLine().ToUpper();
                    switch (Sinput)
                    {
                        case "D":
                            if (!Down)
                            {
                                loop = true;
                                break;
                            }
                            else
                            {
                                for (int p = 0; p < size; p++)
                                {
                                    if (sea[P1column, P1row + p] != 0)
                                    {
                                        valid = false;
                                    }
                                }
                                if (valid)
                                {
                                    for (int i = 0; i < size; i++)
                                    {
                                        sea[P1column, P1row + i] = size;
                                    }
                                    loop = false;
                                }
                                else
                                {
                                    loop = true;
                                    Console.WriteLine("Invalid orientation");
                                    generaldisplay(sea);
                                    break;
                                }
                            }
                            break;
                        case "U":
                            if (!up)
                            {
                                loop = true;
                                break;
                            }
                            else
                            {
                                for (int p = 0; p < size; p++)
                                {
                                    if (sea[P1column, P1row - p] != 0)
                                    {
                                        valid = false;
                                    }
                                }
                                if (valid)
                                {
                                    for (int i = 0; i < size; i++)
                                    {
                                        sea[P1column, P1row - i] = size;
                                    }
                                    loop = false;
                                }
                                else
                                {
                                    loop = true;
                                    Console.WriteLine("Invalid orientation");
                                    generaldisplay(sea);
                                    break;
                                }
                            }
                            break;
                        case "L":
                            if (!left)
                            {
                                loop = true;
                                break;
                            }
                            else
                            {
                                for (int p = 0; p < size; p++)
                                {
                                    if (sea[P1column - p, P1row] != 0)
                                    {
                                        valid = false;
                                    }
                                }
                                if (valid)
                                {
                                    for (int i = 0; i < size; i++)
                                    {
                                        sea[P1column - i, P1row] = size;
                                    }
                                    loop = false;
                                }
                                else
                                {
                                    loop = true;
                                    Console.WriteLine("Invalid orientation");
                                    generaldisplay(sea);
                                    break;
                                }
                            }
                            break;
                        case "R":
                            if (!right)
                            {
                                loop = true;
                                break;
                            }
                            else
                            {
                                for (int p = 0; p < size; p++)
                                {
                                    if (sea[P1column + p, P1row] != 0)
                                    {
                                        valid = false;
                                    }
                                }
                                if (valid)
                                {
                                    for (int i = 0; i < size; i++)
                                    {
                                        sea[P1column + i, P1row] = size;
                                    }
                                    loop = false;
                                }
                                else
                                {
                                    loop = true;
                                    Console.WriteLine("Invalid orientation");
                                    generaldisplay(sea);
                                    break;
                                }
                            }
                            break;
                        default:
                            loop = true;
                            break;
                    }
                }
            }
        }
    }
    void generaldisplay(int[,] sea)
    {
        Console.WriteLine("Press enter to continue...");
        Console.ReadKey();
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        for (down = 0; down <= GridSize - 1; down++)
        {
            for (across = 0; across <= GridSize - 1; across++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(across * 2 + 5, 0);
                Console.WriteLine((char)(across + 65));
                Console.SetCursorPosition(0, down + 2);
                Console.WriteLine(down + 1);
                Console.SetCursorPosition(across * 2 + 5, down + 2);
                if (sea[across, down] == 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("░░");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("▀");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("▀");
                }
            }
        }
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Gray;
    }
    bool CheckWinner(int[,] sea, bool[,] hits)
    {
        for (int row = 0; row < GridSize; row++)
        {
            for (int col = 0; col < GridSize; col++)
            {
                // If there's a ship tile (non-zero) that hasn't been hit, return false
                if (sea[col, row] != 0 && !hits[col, row])
                {
                    return false;
                    break;
                }
            }
        }
        return true; // All ship tiles have been hit
    }
    bool attackGeneral(string Player, int[,] seaP, bool[,] hitsP, int[,] seaO)
    {
        bool hitloop = true;
        while (hitloop)
        {
            generaldisplayattack(Player, hitsP, seaO);
            P1row = -1;
            P1column = -1;
            Console.WriteLine("Choose where to attack");
            while (!parsed || P1column >= GridSize || P1column < 0)
            {
                Console.Write("Column (letter from A to J) : ");
                parsed = char.TryParse(Console.ReadLine().ToUpper(), out input);
                P1column = (int)input - 65;
            }
            while (!parsed || P1row >= GridSize || P1row < 0)
            {
                Console.Write($"Row (number 1 to {GridSize}) : ");
                parsed = Int32.TryParse(Console.ReadLine(), out P1row);
                P1row--;
            }
            if (!hitsP[P1column, P1row])
            {
                hitsP[P1column, P1row] = true;
                hitloop = false;
                if (seaO[P1column, P1row] != 0)
                {
                    hitloop = true;
                    Console.WriteLine("Successful hit on an enemy ship");
                    if (CheckWinner(seaO, hitsP))
                    {
                        return true; // Player has won
                    }
                }
                else
                {
                    Console.WriteLine("Bro really mmissed in 2024 actually massive L and giant skill issue and loser behaviour.");
                }
            }
            else
            {
                Console.WriteLine("Already been hit. Re-input coordinates.");
            }
        }
        return false;
    }
    void generaldisplayattack(string Player, bool[,] hits, int[,] seaO)
    {
        Console.WriteLine(Player + "'s turn");
        Console.WriteLine("Press enter to continue...");
        Console.ReadKey();
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        for (down = 0; down <= GridSize - 1; down++)
        {
            for (across = 0; across <= GridSize - 1; across++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(across * 2 + 5, 0);
                Console.WriteLine((char)(across + 65));
                Console.SetCursorPosition(0, down + 2);
                Console.WriteLine(down + 1);
                Console.SetCursorPosition(across * 2 + 5, down + 2);
                if (!hits[across, down])
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("()");
                }
                else
                {
                    if (seaO[across, down] == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("  ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("💥💥");
                    }
                }
            }
        }
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Gray;

    }
    #region Setting pieces up
    //generalinput(6, seaP1, P1);
    //generalinput(5, seaP1, P1);
    //generalinput(4, seaP1, P1);
    //generalinput(3, seaP1, P1);
    //generalinput(3, seaP1, P1);
    generalinput(2, seaP1, P1);
    generaldisplay(seaP1);
    Console.WriteLine("Press enter to continue...");
    Console.ReadKey();
    Console.Clear();
    //generalinput(6, seaP2, P2);
    //generalinput(5, seaP2, P2);
    //generalinput(4, seaP2, P2);
    //generalinput(3, seaP2, P2);
    //generalinput(3, seaP2, P2);
    generalinput(2, seaP2, P2);
    generaldisplay(seaP2);
    Console.WriteLine("Press enter to continue...");
    Console.ReadKey();
    #endregion
    #region name checks
    Console.Clear();
    Console.WriteLine("Now that both of you young players have set up your pieces its time to battle.");
    Thread.Sleep(1000);
    Console.WriteLine("I'll flip a coin to see who goes first");
    Thread.Sleep(1000);
    if (P1.ToLower() == "darryn" || P1.ToLower() == "charlotte" || P1.ToLower() == "erika" || P1.ToLower() == "alfie")
    {
        Console.WriteLine("Actually because " + P1 + " is such a beta name ill let " + P2 + " go first");
        P1first = false;
    }
    else if (P2.ToLower() == "darryn" || P2.ToLower() == "charlotte" || P2.ToLower() == "erika" || P2.ToLower() == "alfie")
    {
        Console.WriteLine("Actually because " + P2 + " is such a beta name ill let " + P1 + " go first");
        P1first = true;
    }
    else if (P1.ToLower() == "senor surf horse")
    {
        Console.WriteLine("But because senor surf horse is a really cool name ill let them go first instead");
        P1first = true;
    }
    else if (P2.ToLower() == "senor surf horse")
    {
        Console.WriteLine("But because senor surf horse is a really cool name ill let them go first instead");
        P1first = false;
    }
    else
    {
        Random random = new Random();
        if (random.Next(1, 3) == 1)
        {
            P1first = true;
            Console.WriteLine(P1 + " will start");
        }
        else
        {
            P1first = false;
            Console.WriteLine(P2 + " will start");
        }
    }
    #endregion

    while (!GameWon)
    {
        if (P1first)
        {
            if (attackGeneral(P1, seaP1, hitsP1, seaP2))
            {
                GameWon = true;
                Console.WriteLine(P1 + " won!");
            }
            else if (attackGeneral(P2, seaP2, hitsP2, seaP1))
            {
                GameWon = true;
                Console.WriteLine(P2 + " won!");
            }
        }
        else
        {
            if (attackGeneral(P2, seaP2, hitsP2, seaP1))
            {
                GameWon = true;
                Console.WriteLine(P2 + " won!");
            }
            else if (attackGeneral(P1, seaP1, hitsP1, seaP2))
            {
                GameWon = true;
                Console.WriteLine(P1 + " won!");
            }
        }
    }
    bool exit = false;
    Sinput = "";
    Console.WriteLine("Would you like to play again? (Y/N)");
    while (!exit)
    {
        Sinput = Console.ReadLine().ToUpper();
        if (Sinput == "Y" || Sinput == "N")
        {
            exit = true;
            if (Sinput == "N")
            {
                PlayAgain = false;
            }
            else
            {
                PlayAgain = true;
            }
        }
    }
}