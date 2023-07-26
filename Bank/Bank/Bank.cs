using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using ClassLibrary1;
using BankProcessingLibrary;
using Bank.InputBlocks;
using Bank.UserInputBlocks;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using Bank.DataInputBlocks;
using Bank.BankProcessBackend;

namespace Bank
{
    public class Bank
    {
        BankProcessing bp;
        IRead iread;

        public Bank(BankProcessing bp )
        {
            this.bp = bp;
        }
        

        static int MainMenuDisplay(Menu mainMenu)
        {
            int choice = -1;
            try
            {
                choice = mainMenu.MenuDisplayAndSelect();
            }
            catch {
                Console.WriteLine("Invalid input try Again !");
                Thread.Sleep(1000);
                MainMenuDisplay(mainMenu);
            }
            return choice;
        }

        static void AddNewAccountFromConsole(Account newAccount) {
            try{
                IAddAccount readFromConsole = new ReadfromConsole(newAccount.AccountNumber, newAccount.customer.Name, newAccount.Balance, newAccount.Currency);
                readFromConsole.AddAccount();
                Console.WriteLine("\nAccount Added ");
            }
            catch (AccountAlreadyExistsException e)
            {
                Console.WriteLine("Account Already Exist !");
            }
            Console.ReadLine();
            
        }

        static void AddNewAccountFromFile(string filePath) {
            int noOfAddedAccounts = 0;
            try
            {
                IRead readFromFile = new ReadFromFile(filePath);
                noOfAddedAccounts  = readFromFile.AddAccount();
            }
            catch (AccountAlreadyExistsException E)
            {
                Console.WriteLine($"\nAccount Already Exists");
                
            }
            catch (Exception E) {
                Console.WriteLine("Try Again !");
                
            }
            Console.WriteLine($"{noOfAddedAccounts} Accounts Added Successfullly ");
            Console.ReadLine();
        }

        static void WithdrawAmount(WithdrawInput withdrawInput) {
            try{
                IBankProcess withdraw = new Withdraw(withdrawInput.accountNumber, withdrawInput.withdrawAmount);
                withdraw.Process();
                Console.WriteLine("\nWithdraw Successful "); 
            }
            catch (InvalidAccountNumberException E){
                Console.WriteLine($"{E.Message}");
            }
            catch (InsufficientBalanceException E){
                Console.WriteLine($"{E.Message}");
            }
            Console.ReadLine();
        }


        static void DepositAmount(CreditInput creditInput) {
            try{
                Deposit deposit = new Deposit(creditInput.accountNumber, creditInput.creditAmt);
            }
            catch (InvalidAccountNumberException E)
            {
                Console.WriteLine($"\nInvalid Accout number !!");
                
            }
            Console.ReadLine();

        }

        static void TransferAmount(TransferInputData transferInputData) {
            try
            {
                IBankProcess transfer = new Transfer(transferInputData.senderAccNumber, transferInputData.recipentAccNumber, transferInputData.transferAmt);
            }
            catch (InvalidAccountNumberException E)
            {
                Console.WriteLine($"Invalid account number {E.Message}");
             
            }
            catch (InsufficientBalanceException E)
            {
                Console.WriteLine($"Insufficient Balance in account : {E.Message}");
            }
            Console.ReadLine();

        }

        static void UserDetails(long accNumber) {
            try
            {
                IGetDetails getDetails = new GetDetailsConsole(accNumber);
                Account account = getDetails.GetDetail();
                Console.WriteLine($"Details:\nName : {account.customer.Name}\nAcc Number : {account.AccountNumber}\nBalance : {account.Balance}\n");
                
            }
            catch (InvalidAccountNumberException E)
            {
                Console.WriteLine("Invalid Account Number!!");
            }
            Console.ReadLine();
        }


        public static void Main(string[] args)
        {
            Menu mainMenu = new Menu() { MenuListItems = { "ADD ACCOUNT FROM CONSOLE", "ADD USER FROM FILE", "WITHDRAW", "DEPOSIT", "TRANSFER", "DISPLAY USER DETAILS","EXIT" }, menuTitle = "ADMIN PAGE" };
            
            
            InputBlockTransferInterface<WithdrawInput> withdrawInputReader = new WithdrawInputReader<WithdrawInput>();
            InputBlockTransferInterface<CreditInput> creditInputReader = new CreditInputReader<CreditInput>();
            InputBlockTransferInterface<TransferInputData> transferInputReader = new TransferInputReader<TransferInputData>();
            InputBlockTransferInterface<long> userDetailFetcherInputBlock = new UserDetailFetcherInputBlock<long>();

            UserInputProvider<Account> consoleUserProfile = new ConsoleDataFetcher<Account>();
            UserInputProvider<string> fileDataFetcher = new FileDataFetcher<string>();
            


            Bank bank = new Bank(new BankProcessing());


            while (true)
            {
                int choice = MainMenuDisplay(mainMenu);
                switch (choice)
                {
                    case 1:
                        Account newAccount = consoleUserProfile.GetUserData();
                        AddNewAccountFromConsole(newAccount);
                        break;

                    case 2:
                        string filePath = fileDataFetcher.GetUserData();
                        AddNewAccountFromFile(filePath);
                        break;

                    case 3:
                        WithdrawInput withdrawInput = withdrawInputReader.GetTransactionInputBlock();
                        WithdrawAmount(withdrawInput);
                        break;

                    case 4:
                        CreditInput creditInput = creditInputReader.GetTransactionInputBlock();
                        DepositAmount(creditInput);
                        break;

                    case 5:
                        TransferInputData transferInputData = transferInputReader.GetTransactionInputBlock();
                        TransferAmount(transferInputData);
                        break;

                    case 6:
                        long accNumber = userDetailFetcherInputBlock.GetTransactionInputBlock();
                        UserDetails(accNumber);
                        break;

                    case 7:
                        Environment.Exit(0);
                        break;
                  
                }

            }

        }
    }
}
