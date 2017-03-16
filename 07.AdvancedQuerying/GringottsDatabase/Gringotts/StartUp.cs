namespace Gringotts
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var ctx = new GringottsContext();
			
            #region 19.	Deposits Sum for Ollivander Family
            //ctx.WizzardDeposits.Where(w => w.MagicWandCreator == "Ollivander family")
            //    .GroupBy(w => w.DepositGroup)
            //    .ToList()
            //    .ForEach(d =>
            //    {
            //        Console.WriteLine($"{d.Key} - {d.Sum(w => w.DepositAmount)}");
            //    });
            #endregion

            #region 20.	Deposits Filter
            //ctx.WizzardDeposits.Where(w => w.MagicWandCreator == "Ollivander family")
            //    .GroupBy(w => w.DepositGroup)
            //    .Where(d => d.Sum(w => w.DepositAmount.Value) < 150000)
            //    .OrderByDescending(d => d.Sum(w => w.DepositAmount))
            //    .ToList()
            //    .ForEach(d =>
            //    {
            //        Console.WriteLine($"{d.Key} - {d.Sum(w => w.DepositAmount)}");
            //    });
            #endregion

        }
    }
}
