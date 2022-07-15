namespace Game_X_and_O
{
    internal class Program
    {
        static void WriteTable(char[] table)
        {
            for (int i = 0; i < table.Length; i++)
            {
                if (i == 0 || i == 3 || i == 6)
                    Console.Write($"{Environment.NewLine}--------------{Environment.NewLine}|");
                switch (table[i])
                {
                    case 'O':
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 'X':
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    default: 
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                Console.Write($" {table[i]} ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|");
                if (i == 8)
                    Console.Write($"{Environment.NewLine}--------------{Environment.NewLine}|");

            }
        }
        static bool SearchFree(char[] table)
        {
            for (int i = 0; i < table.Length; i++)
            {
                try
                {
                    if (int.Parse((table[i]).ToString()) == i + 1) return true;
                }
                catch (Exception)
                {
                }
            }

            return false;
        }
        static int ReadMove(char[] table)
        {
            bool tryMove;
            int moveInt;
            do
            {
                var move = Console.ReadKey();
                tryMove = int.TryParse(move.KeyChar.ToString(), out moveInt);
                if (tryMove == false)
                Console.WriteLine($"{Environment.NewLine}Введённое значение не подходит. Введите новое значение:");
            }
            while (!tryMove || moveInt == 0 || table[moveInt - 1] == 'X' || table[moveInt - 1] == 'O');
            return moveInt;
        }
        
        static void Main(string[] args)
        {
            bool again = false;
            do
            {
                Console.WriteLine($"Привет, друг! Давай сыграем в Крестики-нолики! {Environment.NewLine}Крестики-нолики — логическая игра между двумя противниками на квадратном поле 3 на 3 клетки. Один из игроков играет {Environment.NewLine}«крестиками», второй — «ноликами».Цель игроков - выстроить линию из трёх своих символов. Они могут располагаться и {Environment.NewLine}по горизонтали, и по вертикали, и по диагонали. Ход игроков происходит по очереди. Начинается игра с хода «крестиков».");
                Console.WriteLine($"{Environment.NewLine}Давай познакомимся! Имя Игрока, ходящего за Х:");
                string? player1 = Console.ReadLine();
                Console.WriteLine($"{Environment.NewLine}Имя Игрока, ходящего за О:");
                string? player2 = Console.ReadLine();
                char[] table = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                WriteTable(table);
                bool win = true;

                while (win)
                {
                    if (SearchFree(table))
                    {
                        Console.WriteLine($"{Environment.NewLine}Ход {player1}. Напишите номер ячейки:");
                        int moveInt = ReadMove(table);
                        table[moveInt - 1] = 'X';
                        WriteTable(table);
                    }

                    if (SearchFree(table))
                    {
                        Console.WriteLine($"{Environment.NewLine}Ход {player2}. Напишите номер ячейки:");
                        int moveInt = ReadMove(table);
                        table[moveInt - 1] = 'O';
                        WriteTable(table);
                    }
                    win = ReadWin(table);
                }
                Console.WriteLine($"{Environment.NewLine}Хотите начать заново? {Environment.NewLine}Если да, то нажмите на клавишу 'y', если нет - 'n'");
                if ((Console.ReadKey()).KeyChar.ToString() == "y" || (Console.ReadKey()).KeyChar.ToString() == "Y")
                { 
                    Console.Clear();
                    again = true;
                }

                bool ReadWin(char[] table)
                {
                    bool X = false;
                    bool O = false;

                    if ((table[0] == table[1] && table[1] == table[2] && table[2] == 'X') || (table[3] == table[4] && table[4] == table[5] && table[5] == 'X') || (table[6] == table[7] && table[7] == table[8] && table[8] == 'X') || (table[0] == table[3] && table[3] == table[6] && table[6] == 'X') || (table[4] == table[1] && table[4] == table[7] && table[7] == 'X') || (table[2] == table[5] && table[5] == table[8] && table[8] == 'X') || (table[0] == table[4] && table[4] == table[8] && table[8] == 'X') || (table[6] == table[4] && table[4] == table[2] && table[2] == 'X'))
                        X = true;

                    if ((table[0] == table[1] && table[1] == table[2] && table[2] == 'O') || (table[3] == table[4] && table[4] == table[5] && table[5] == 'O') || (table[6] == table[7] && table[7] == table[8] && table[8] == 'O') || (table[0] == table[3] && table[3] == table[6] && table[6] == 'O') || (table[4] == table[1] && table[4] == table[7] && table[7] == 'O') || (table[2] == table[5] && table[5] == table[8] && table[8] == 'O') || (table[0] == table[4] && table[4] == table[8] && table[8] == 'O') || (table[6] == table[4] && table[4] == table[2] && table[2] == 'O'))
                        O = true;


                    if (X == true)
                    {
                        Console.WriteLine($"{Environment.NewLine}Победил {player1}. Поздравляем!");
                        return false;
                    }
                    else if (O == true)
                    {
                        Console.WriteLine($"{Environment.NewLine}Победил {player2}. Поздравляем!");
                        return false;
                    }
                    else if (X == O && X == true || !SearchFree(table))
                    {
                        Console.WriteLine($"{Environment.NewLine}Игра закончилась нечьёй!");
                        return false;
                    }
                    else return true;
                }
            }
            while (again);

            Console.ReadKey();
        }
    }
}