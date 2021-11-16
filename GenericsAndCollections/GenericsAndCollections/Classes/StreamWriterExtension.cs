using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GenericsAndCollections.Classes
{
    public static class StreamWriterExtension
    { 
        public static void AddData(this StreamWriter streamWriter, int[] array, char symbol)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                streamWriter.Write(array[i]);
                if (!(i == array.Length - 1))
                {
                    streamWriter.Write(symbol);
                }
            }
            streamWriter.WriteLine();
            streamWriter.Flush();            
        }

        public static void MultiplyOfNumbers(this StreamWriter streamWriter, List<int> outList, char symbol)
        {
            var multiply = 1;
            foreach (var number in outList)
            {
                multiply *= number;
            }
            streamWriter.Write($"{multiply}{symbol}");
        }

        public static void SumOfNumbers(this StreamWriter streamWriter, List<int> outList, char symbol)
        {
            var sumOfNumbers = 0;
            foreach (var number in outList)
            {
                sumOfNumbers += number;
            }
            streamWriter.Write($"{sumOfNumbers}{symbol}");

        }

    }
}
