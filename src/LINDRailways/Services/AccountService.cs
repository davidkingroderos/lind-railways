﻿using LINDRailways.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINDRailways.Services
{
    public class AccountService
    {
        private static SQLiteAsyncConnection Database;

        private static async Task Init()
        {
            if (Database is not null)
                return;

            string databaseFilename = "Accounts";
            string databasePath = Path.Combine(FileSystem.AppDataDirectory, databaseFilename);

            SQLite.SQLiteOpenFlags flags =
                SQLite.SQLiteOpenFlags.ReadWrite |
                SQLite.SQLiteOpenFlags.Create |
                SQLite.SQLiteOpenFlags.SharedCache;

            Database = new SQLiteAsyncConnection(databasePath, flags);

            await Database.CreateTableAsync<Account>();
        }

        public static async Task AddAccountAsync(Account account)
        {
            await Init();

            await Database.InsertAsync(account);
        }

        public static async Task RemoveAccountAsync(string username)
        {
            await Init();

            await Database.DeleteAsync<Account>(username);
        } 

        public static async Task<Account> GetAccountAsync(string username)
        {
            await Init();

            var account = await Database.GetAsync<Account>(username);

            return account;
        }

        public static async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            await Init();

            var account = await Database.Table<Account>().ToListAsync();

            return account;
        }

        public static async Task UpdateAccountAsync(Account account)
        {
            await Init();

            await Database.UpdateAsync(account);
        }
    }
}
