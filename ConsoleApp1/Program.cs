using ConsoleApp1.Models;
using System;

namespace DateFormatExample;

class UserIn
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
}

class Program
{
    public DateTime RequestDate { get; set; }

    static void Main(string[] args)
    {
        var userIn = new UserIn()
        {
            UserName = "saim1"
        };

        var user = new User()
        {
            Name = "saim"
        };

        Console.WriteLine(user.Name);
        Console.WriteLine(userIn.UserName);
    }
}