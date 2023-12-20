using System;
using System.Windows.Forms;

namespace Data_protection
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var dbPath = "D:\\My_programms\\C#\\Dtat_protection_forms/database.db";
            var userRepository = new UserRepository(dbPath);
            var authService = new AuthService(userRepository);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dtat_protection_forms.Form1(authService, userRepository));
        }
    }
}