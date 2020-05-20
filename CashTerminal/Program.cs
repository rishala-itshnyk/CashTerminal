using System;

namespace CashTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            CashTerminal cashTerminal = new CashTerminal();

            cashTerminal.ShowAvailableDenominations();

            int withdrawalAmount = UserInput.GetWithdrawalAmount();

            bool autoSelect = UserInput.AskForAutoSelection();

            if (autoSelect)
            {
                // Виконуємо автоматичну видачу
                cashTerminal.DispenseOptimizedCash(withdrawalAmount);
            }
            else
            {
                var selectedDenominations = UserInput.GetSelectedDenominations();

                // Виконуємо видачу грошей за вибором користувача
                cashTerminal.DispenseCustomCash(withdrawalAmount, selectedDenominations);
            }
        }
    }
}