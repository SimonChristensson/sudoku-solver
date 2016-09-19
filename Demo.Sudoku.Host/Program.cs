using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using Demo.Sudoku.Host.Configuration;

namespace Demo.Sudoku.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            const string address = "http://localhost:8080";
            var host = HostFactory.CreateHost(address);
            host.Open();

            Console.WriteLine("Service is up and running on address: {0}", address);
            Console.WriteLine("Press enter to quit ");
            Console.ReadLine();
            host.Close();

        }
    }
}