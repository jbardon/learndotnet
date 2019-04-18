using System;
using System.IO;
using System.Reflection;

namespace SmartAdLibrary.Utils
{
    public class FileLoader
    {
        public static String LoadFile(string path)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(path))
            using (var reader = new StreamReader(stream))
            {
               return reader.ReadToEnd();
            }
        }
    }
}