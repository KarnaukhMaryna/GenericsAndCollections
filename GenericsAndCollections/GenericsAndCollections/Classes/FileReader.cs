using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GenericsAndCollections.Classes
{
    public class FileReader<T> where T : FormatBase, new()
    {
        public IEnumerable<T> Read(string filePath, bool hasHeaders)
        {
            var objects = new List<T>();
            using (var sr = new StreamReader(filePath))
            {
                bool headersRead = false;
                string line;
                do
                {
                    line = sr.ReadLine();

                    if (line != null && headersRead)
                    {
                        var obj = new T();
                        var propertyValues = line.Split(',');
                        obj.AssignValuesFromFormat(propertyValues);
                        objects.Add(obj);
                    }
                    if (!headersRead)
                    {
                        headersRead = true;
                    }
                } while (line != null);
            }
            return objects;
        }


      
    }
}
