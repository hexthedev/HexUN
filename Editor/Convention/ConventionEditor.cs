using HexCS.Data.Persistence;
using HexUN.Data;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

namespace HexUN.Convention
{
    /// <summary>
    /// Class dedicated to holding important constants and lookup functions related to hard conventions
    /// used within a project
    /// </summary>
    public static class ConventionEditor
    {
        private static readonly UnityPath _conventionPath = _conventionPath = "Assets/Data/Yaml/Config/Convention.yaml";

        private static ConventionYaml _yaml = null;

        private static UnityPath _gameplayDataYamlDirectory = null;
        private static UnityPath _gameplayDataSoDirectory = null;

        #region API
        /// <summary>
        /// The deserialized yaml object representing conventions
        /// </summary>
        public static ConventionYaml Yaml
        {
            get
            {
                if(_yaml == null)
                {
                    if (!_conventionPath.AbsolutePath.TryAsFileInfo(out FileInfo file)) return null;
                    if (!file.Exists) return null;

                    Deserializer des = new Deserializer();
                    _yaml = des.Deserialize<ConventionYaml>(file.ReadAllText());
                }

                return _yaml;
            }
        }

        /// <summary>
        /// All convention args in the project
        /// </summary>
        public static Dictionary<string, ConventionArgs> ConventionArgs
        {
            get
            {
                ConventionYaml yaml = Yaml;
                if (yaml == null) return null;
                return yaml.Conventions;
            }
        }

        /// <summary>
        /// The directory where gameplay yaml data is found
        /// </summary>
        public static UnityPath GamePlayDataYamlDirectory
        {
            get
            {
                if(_gameplayDataYamlDirectory == null)
                {
                    ConventionYaml yaml = Yaml;
                    if (yaml == null) return null;
                    _gameplayDataYamlDirectory = new UnityPath(yaml.GameplayDataYamlDirectory);
                }

                return _gameplayDataYamlDirectory;
            }
        }

        /// <summary>
        /// The directory where gameplay so data is found
        /// </summary>
        public static UnityPath GamePlayDataSoDirectory
        {
            get
            {
                if (_gameplayDataSoDirectory == null)
                {
                    ConventionYaml yaml = Yaml;
                    if (yaml == null) return null;
                    _gameplayDataSoDirectory = new UnityPath(yaml.GameplayDataSoDirectory);
                }

                return _gameplayDataSoDirectory;
            }
        }

        /// <summary>
        /// get a convention of a specific type
        /// </summary>
        /// <param name="conv"></param>
        /// <returns></returns>
        public static ConventionArgs GetConvention(string conv)
        {
            if (ConventionArgs == null || !ConventionArgs.TryGetValue(conv, out ConventionArgs args)) return null;
            return args;
        }
        #endregion
    }

    public class ConventionArgs
    {
        public string Location;
        public string Convention;
    }

    public class ConventionYaml
    {
        /// <summary>
        /// This is the project relative directory where all yaml gameplay data can be found
        /// </summary>
        public string GameplayDataYamlDirectory;

        /// <summary>
        /// This is the project relative directory where all gameplay data is found
        /// </summary>
        public string GameplayDataSoDirectory;

        /// <summary>
        /// These are all the conventions used throught the project
        /// </summary>
        public Dictionary<string, ConventionArgs> Conventions;
    }
}