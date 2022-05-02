using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {

        public static int MIN_NUM = 1;
        public static int MAX_NUM = 101;
        public static int MAX_DIFF = 10;

        static void Main(string[] args)
        {

            bool game_res = false;
            int difficulty = 0;

            //ConsoleColor background = Console.BackgroundColor;
            //ConsoleColor foreground = Console.ForegroundColor;
            //Console.ForegroundColor = ConsoleColor.White;
            //Console.BackgroundColor = ConsoleColor.Red;
            //return;

            //קליטת רמת קושי
            while (difficulty <= 0 || difficulty > MAX_DIFF)
            {
                difficulty = get_difficulty();
                Console.WriteLine("Difficulty Level : ");
                Console.WriteLine(difficulty.ToString());
            }

            // אתחול מערך המספרים רנדומלים
            int[] rnd_list = generate_sequence(difficulty);

            // ניקוי מסך
            Console.Clear();

            //Console.WriteLine("ARRAY");
            //Console.WriteLine(rnd_list.Length.ToString());

            // קליטת מספרים מהמשתמש
            int[] usr_list = get_list_from_user(difficulty);

            Console.WriteLine("ARRAY 2");
            Console.WriteLine(usr_list.Length.ToString());
            Console.WriteLine("ARRAY VALUES");

            // מיון מערכים
            Array.Sort(usr_list);
            Array.Sort(rnd_list);

            // הדפסץ שני המערכים
            for (int x = 0; x < difficulty; x++)
            {
                Console.WriteLine("***********************************");
                Console.WriteLine(rnd_list[x].ToString());
            }

            Console.WriteLine("***********************************************************************************************");

            for (int x = 0; x < difficulty; x++)
            {
                Console.WriteLine("***********************************");
                Console.WriteLine(usr_list[x].ToString());
            }

            if (areEqual(rnd_list, usr_list))
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Clear();
                    System.Threading.Thread.Sleep(500);
                    Console.WriteLine("Yes!!!!!!!!  You Won!!!!!!!!!!!!");
                    System.Threading.Thread.Sleep(500);

                }
                
            }
            else
                Console.WriteLine("No");


        }



        // ***********************************************************************************
        // בדיקה האם המערכים זהים
        public static bool areEqual(int[] arr_rnd, int[] arr_usr)
        {
            int n = arr_rnd.Length;
            int m = arr_usr.Length;

            // If lengths of array are not
            // equal means array are not equal
            if (n != m)
                return false;

            // Linearly compare elements
            for (int i = 0; i < n; i++)
                if (arr_rnd[i] != arr_usr[i])
                    return false;

            // If all elements were same.
            return true;
        }
        // ***********************************************************************************


        // ***********************************************************************************
        // קליטת רשימת מספרים מהמשתמש

        public static int[] get_list_from_user(int difficulty)
        {
            int lst_count = 1;
            string val;
            int user_num;
            bool isNumber = true;
            int[] usr_list = new int[difficulty];

            if (difficulty > 0)
            {
                while (lst_count <= difficulty)
                {
                    Console.WriteLine("Please enter number " + " between " + MIN_NUM.ToString() + " to " + (MAX_NUM - 1).ToString() + ":");
                    val = Console.ReadLine();
                    Console.WriteLine(val);
                    isNumber = int.TryParse(val, out user_num);

                    while (!isNumber)
                    {
                        val = Console.ReadLine();
                        Console.WriteLine(val);
                        isNumber = int.TryParse(val, out user_num);
                    }

                    Console.WriteLine(isNumber.ToString());

                    usr_list[lst_count - 1] = user_num;
                    lst_count++;
                }
            }

            //int[] a = new int[5];
            return usr_list;

        }

        // ***********************************************************************************



        // ***********************************************************************************
        public static int[] generate_sequence(int difficulty)
        {

            int lst_count = 1;
            int[] rnd_list = new int[difficulty];

            if (difficulty > 0)
            {
                while (lst_count <= difficulty)
                {
                    int x = GetRandomNumberInRange(MIN_NUM, MAX_NUM);
                    rnd_list[lst_count - 1] = x;
                    Console.WriteLine(x.ToString());
                    // השהייה לתצוגת המספרים
                    System.Threading.Thread.Sleep(2300);

                    lst_count++;
                }
            }
            return rnd_list;
        }
        // ***********************************************************************************


        // ***********************************************************************************
        // יצירת מספר רנדומלי בטווח שהוגדר
        public static int GetRandomNumberInRange(int minNumber, int maxNumber)
        {
            return new Random().Next((maxNumber - minNumber) + minNumber);
        }

        // ***********************************************************************************


        // ***********************************************************************************
        // קליטת רמת משחק
        public static int get_difficulty()
        {
            string val;
            Console.WriteLine("get difficulty level between 1 to 10: ");
            val = Console.ReadLine();
            bool isNumber = int.TryParse(val, out int dif);
            if (isNumber)
            {
                return dif;
            }
            return 0;
        }
        // ***********************************************************************************



    }
}
