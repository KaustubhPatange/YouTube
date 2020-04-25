using System;
using IniParser;
using IniParser.Model;
using static SettingsDemo.SettingsHelper;

namespace SettingsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read Settings
            var key = Settings.Current.stringKey;
            var keyInt = Settings.Current.intkey;
            var keyBool = Settings.Current.boolkey;
            var newKey = Settings.Current.newKey;

            // Update Settings
            Settings.Current.stringKey = "modified key";
            Settings.Current.boolkey = false;

            Settings.WriteSettings();


            Console.WriteLine(key);
            Console.WriteLine(newKey);
            Console.WriteLine(keyInt);
            Console.WriteLine(keyBool);
            Console.ReadKey();
        }
    }
}
