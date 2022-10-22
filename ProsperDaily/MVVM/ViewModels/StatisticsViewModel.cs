using PropertyChanged;
using ProsperDaily.MVVM.Models;
using System.Collections.ObjectModel;

namespace ProsperDaily.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class StatisticsViewModel
    {
        public ObservableCollection<TransactionsSummary> Summary { get; set; }

        public ObservableCollection<Transaction> SpendingList { get; set; }

        public void GetTransactionsSummary()
        {
            var data = App.TransactionRepo.GetItems();

            var result = new List<TransactionsSummary>();

            var groupedTransactions = data.GroupBy(x => x.OperationDate);

            foreach (var group in groupedTransactions)
            {
                var transactionSummary = new TransactionsSummary
                {
                    TransactionsDate = group.Key,
                    TransactionsTotal = group.Sum(t => t.Income ? t.Amount : -t.Amount),
                    ShownDate = group.Key.ToString("MM/dd")
                };

                result.Add(transactionSummary);
            }

            result = result.OrderBy(x => x.ShownDate).ToList();

            Summary = new ObservableCollection<TransactionsSummary>(result);

            var spendingList = data.Where(x => x.Income == false);

            SpendingList = new ObservableCollection<Transaction>(spendingList);
        }
    }
}
