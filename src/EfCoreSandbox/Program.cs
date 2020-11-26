using System;
using System.Linq;
using EfCoreSandbox.Models;

namespace EfCoreSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsAffected;
            var accountId = "100002000";

            using(var context = new SandboxContext())
            {
                var existingAccount = context
                    .Accounts
                    .Where(a => a.Id == decimal.Parse(accountId))
                    .FirstOrDefault();

                if (existingAccount != null)
                {
                    Console.WriteLine("The account already exists.");
                    Console.ReadKey();
                }

                context.Accounts.Add(new Accounts
                {
                    Id = decimal.Parse(accountId),
                    FirstName = "Brandon",
                    LastName = "Avant"
                });

                rowsAffected = context.SaveChanges();


                Console.WriteLine($"Done. {rowsAffected} rows were affected.");
            }
        }
    }
}
