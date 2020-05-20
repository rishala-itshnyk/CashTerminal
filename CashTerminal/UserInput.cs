    using System;
    using System.Collections.Generic;

    public class UserInput
    {
        public static int GetWithdrawalAmount()
        {
            Console.WriteLine("Введіть суму для зняття:");
            if (int.TryParse(Console.ReadLine(), out int amount))
            {
                return amount;
            }
            else
            {
                Console.WriteLine("Некоректна сума!");
                return GetWithdrawalAmount();
            }
        }

        public static bool AskForAutoSelection()
        {
            Console.WriteLine("Хочете автоматичний вибір купюр (1) чи ручний (2)?");
            string choice = Console.ReadLine();

            return choice == "1";
        }

        public static List<int> GetSelectedDenominations()
        {
            Console.WriteLine("Виберіть номінали для видачі (через кому):");
            string input = Console.ReadLine();
            var selectedDenominations = new List<int>();

            foreach (var denomination in input.Split(','))
            {
                if (int.TryParse(denomination.Trim(), out int denom))
                {
                    selectedDenominations.Add(denom);
                }
                else
                {
                    Console.WriteLine($"Некоректний номінал: {denomination}");
                }
            }

            return selectedDenominations;
        }
    }