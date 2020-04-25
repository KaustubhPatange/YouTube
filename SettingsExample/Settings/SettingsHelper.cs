using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace SettingsDemo
{
    public sealed class SettingsHelper
    {
        private const string SETTINGS = "SETTINGS";

        private static string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private string SettingsPath = Path.Combine(BaseDirectory, "config.ini");

        private FileIniDataParser parser = new FileIniDataParser();
        private IniData data;

        private static SettingsHelper Instance;
        public static SettingsHelper Settings
        {
            get
            {
                if (Instance != null)
                    return Instance;
                Instance = new SettingsHelper();
                return Instance;
            }
        }
        public SettingsModel Current { get; } = new SettingsModel();
        private SettingsHelper()
        {
            if (!File.Exists(SettingsPath))
                DefaultSettings();
            else
                ReadSettings();
        }

        private void ReadSettings()
        {
            data = parser.ReadFile(SettingsPath);

            Current.stringKey = data[SETTINGS][nameof(Current.stringKey)];
            Current.intkey = Convert.ToInt32(data[SETTINGS][nameof(Current.intkey)]);
            Current.boolkey = Convert.ToBoolean(data[SETTINGS][nameof(Current.boolkey)]);
        }

        private void DefaultSettings()
        {
            Current.stringKey = "value of string";
            Current.newKey = "default value";
            Current.intkey = 10;
            Current.boolkey = true;

            File.Create(SettingsPath).Close();

            WriteSettings();
        }

        public void WriteSettings()
        {
            data = parser.ReadFile(SettingsPath);

            data[SETTINGS][nameof(Current.stringKey)] = Current.stringKey;
            data[SETTINGS][nameof(Current.newKey)] = Current.newKey;
            data[SETTINGS][nameof(Current.intkey)] = Current.intkey.ToString();
            data[SETTINGS][nameof(Current.boolkey)] = Current.boolkey.ToString();

            parser.WriteFile(SettingsPath, data);
        }
    }
}
