using System;
using System.Linq;
using ecommercecase.Common;
using ecommercecase.Common.Models;
using ecommercecase.Domain;
using ecommercecase.Domain.Command;
using ecommercecase.Domain.Exceptions;

namespace ecommercecase
{
    class Program
    {
        static void Main(string[] args)
        {
            Context.Initialize();
            Console.WriteLine("Welcome to our eCommmerce console app.");
            Console.WriteLine("If you exit this program you should give me a this command: 'X'");
            Console.WriteLine();
            bool canExist = false;
            while (!canExist)
            {
                Console.Write("Please give me a command: ");
                string command = Console.ReadLine();
                if(command.ToLower() == "x")
                {
                    canExist = true;
                    Console.WriteLine("Good bye..");
                    continue;
                }

                string[] cmdValues = command.Split(' ');
                string cmd = cmdValues[0];
                try
                {
                    Command myCommand = Context.Commands.SingleOrDefault(i => i.Code == cmd.ToLower());
                    myCommand.Verify(cmdValues);
                    Console.WriteLine(myCommand.Run());
                }
                catch (CommandException ex)
                {
                    Console.WriteLine(ex.FriendlyMessage);
                }
                catch
                {
                    Console.WriteLine("Geçerli bir komut girmediniz.");
                }
            }
         
        }
    }
}
