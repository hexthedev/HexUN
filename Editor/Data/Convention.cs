using HexCS.Data.Persistence;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

namespace HexUN.Data
{
    public static class Convention
    {
        public static Dictionary<string, ConventionArgs> ConventionArgs
        {
            get
            {
                UnityPath conventionPath = "Assets/Data/Yaml/Config/Convention.yaml";

                if (!conventionPath.AbsolutePath.TryAsFileInfo(out FileInfo file)) return null;
                if (!file.Exists) return null;

                Deserializer des = new Deserializer();
                Dictionary<string, ConventionArgs> dict = des.Deserialize<Dictionary<string, ConventionArgs>>(file.ReadAllText());
                return dict;

            }
        }

        public static ConventionArgs GetConvention(string conv)
        {
            if (!ConventionArgs.TryGetValue(conv, out ConventionArgs args)) return null;
            return args;
        }
    }

    public class ConventionArgs
    {
        public string Location;
        public string Convention;
    }
}