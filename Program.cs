using System;
using Npgsql;
using BankServer.DataModels; //this isn't needed if users uses same namespace 'BankServer' and not 'BankServer.DataModels'
//OOP can be broken down to a stuct pointed to other segs of memory or structs eventually getting to primivite data
// Class is a definition of what your struct is going to look like


namespace BankServer
{
    class Program
    {
        static void Main(string[] args)
        {
            User test = new User();
            //if not using <namespace>
            // BankServer.DataModels.User;
            // if not under same namespace ie BankServer.DataModels
            // call using namespace BankServe.DataModels;

            // connect to PostgreSQL database string
            const string cs = "Server=localhost;Port=5432;Password=hentai42069;Username=postgres;";

            // additonal use is 
            using var con = new NpgsqlConnection(cs);
            con.Open();

            var sql = "SELECT * FROM bank.bank_user;";

            //create query
            var command = new NpgsqlCommand(sql, con);

            // reading object reads all data
            NpgsqlDataReader results = command.ExecuteReader();
            Console.WriteLine($"Result of query: {sql} [BELOW]");

            while (results.Read())
            {
                for (int iter = 0; iter < results.FieldCount; iter++)
                {
                    Console.Write(results[iter]);
                    Console.Write("\t");
                }
            }

            con.Close();

        }

    }

}

/*
questions 
(C#)
- purpose of namespace? 
tool for orgainization, can be more detailed in nameing structure but can all fall under the same category

- deep dive into keyword 'using'
within the scope of your code it essentially deals with garbage collection

- is static void main still neccessary for the main funtion?

- best way to split up work? my ideas
    - class or method for user input retrival
    - class or method for DML based on user input
    - class or method for error handling ( or have that implemented into top classes or methods accordingly)
    handle within each class or method

- best data structure to use? my idea is a queue or an array? (ask alex)
- additional best practices?
(postgreSQL)
- any idea of when to use procedurces or functions?
- user privilages DCL 

phase 1: have user access account based on user id and make simple changes to it (deposit and withdrawal);
phase 2: add additional option to create and delete an account
phase 3: login and log out form
phase 4: add GUI changes to make it asthetically pleasing
phase 5: add employees so they can handle account creation and account deletion actions and disable user funcionality to do so
phase 6: add data analytics retrival to get info such as: new customers per month, quarter, etc and number of transactions and total money withheld in the bank and finally individual user analytics
phase 7: add concurrency so multiple users can access the server
phase 8: add data encryption (definitely need alex for this bad boy)
*/
