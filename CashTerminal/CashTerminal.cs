    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace CashTerminal
    {
        public class CashTerminal
        {
            private List<Banknote> banknotes;

            public CashTerminal()
            {
                banknotes = new List<Banknote>
                {
                    new Banknote(500, 10),
                    new Banknote(200, 20),
                    new Banknote(100, 50),
                    new Banknote(50, 100),
                    new Banknote(20, 200)
                };
            }

            public void DispenseOptimizedCash(int amount)
            {
                Console.WriteLine("Видання оптимальних купюр:");
                foreach (var banknote in banknotes.OrderByDescending(b => b.Denomination))
                {
                    int neededNotes = amount / banknote.Denomination;
                    int notesToGive = Math.Min(neededNotes, banknote.Quantity);
                    amount -= notesToGive * banknote.Denomination;
                    banknote.Quantity -= notesToGive;

                    if (notesToGive > 0)
                    {
                        Console.WriteLine($"{notesToGive} x {banknote.Denomination} UAH");
                    }

                    if (amount == 0)
                        break;
                }

                if (amount > 0)
                {
                    Console.WriteLine("Неможливо видати точну суму цією комбінацією купюр.");
                }
                else
                {
                    Console.WriteLine("Видано всі гроші.");
                }
            }

            public void DispenseCustomCash(int amount, List<int> selectedDenominations)
            {
                Console.WriteLine("Вибір власних купюр:");
                foreach (var denomination in selectedDenominations.OrderByDescending(d => d))
                {
                    var banknote = banknotes.FirstOrDefault(b => b.Denomination == denomination);

                    if (banknote != null)
                    {
                        int neededNotes = amount / denomination;
                        int notesToGive = Math.Min(neededNotes, banknote.Quantity);
                        amount -= notesToGive * denomination;
                        banknote.Quantity -= notesToGive;

                        if (notesToGive > 0)
                        {
                            Console.WriteLine($"{notesToGive} x {denomination} UAH");
                        }
                    }

                    if (amount == 0)
                        break;
                }

                if (amount > 0)
                {
                    Console.WriteLine("Неможливо видати точну суму цією комбінацією купюр.");
                }
                else
                {
                    Console.WriteLine("Видано всі гроші.");
                }
            }

            public void ShowAvailableDenominations()
            {
                Console.WriteLine("Доступні номінали:");
                foreach (var banknote in banknotes)
                {
                    Console.WriteLine($"{banknote.Denomination} UAH");
                }
            }
        }
    }