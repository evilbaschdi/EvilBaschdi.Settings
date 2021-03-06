﻿using System.IO;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json;

namespace EvilBaschdi.Settings.Internal
{
    /// <inheritdoc />
    public class WritableJsonConfigurationProvider : JsonConfigurationProvider
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="source"></param>
        public WritableJsonConfigurationProvider(JsonConfigurationSource source)
            : base(source)
        {
        }

        /// <inheritdoc />
        public override void Set(string key, string value)
        {
            base.Set(key, value);

            //Get Whole json file and change only passed key with passed value. It requires modification if you need to support change multi level json structure
            var fileFullPath = Source.FileProvider.GetFileInfo(Source.Path).PhysicalPath;
            var json = File.ReadAllText(fileFullPath);
            dynamic jsonObj = JsonConvert.DeserializeObject(json);
            if (jsonObj == null)
            {
                return;
            }

            jsonObj[key] = value;
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(fileFullPath, output);
        }
    }
}