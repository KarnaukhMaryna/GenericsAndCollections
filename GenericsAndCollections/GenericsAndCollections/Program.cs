using GenericsAndCollections.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace GenericsAndCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename1 = "input1_" + DateTime.Today.ToString("yyyy_MM_dd", CultureInfo.InvariantCulture);
            string filename2 = "input2_" + DateTime.Today.ToString("yyyy_MM_dd", CultureInfo.InvariantCulture);
            string filename3 = "output_" + DateTime.Today.ToString("yyyy_MM_dd", CultureInfo.InvariantCulture);
            int[] array1 = { 10, 5, 1 };
            int[] array2 = { 1, 2, 3 };
            List<int> outArray = new List<int>();
            char symbolTxt = ' ';

            if (!Directory.Exists("D:\\Project"))
                Directory.CreateDirectory("D:\\Project");

                using (StreamWriter streamWriterTxt = new StreamWriter($"D:\\Project\\{filename1}.txt"))
            {
                streamWriterTxt.AddData( array1, symbolTxt);
                streamWriterTxt.AddData( array2, symbolTxt);
            }
            using (StreamReader streamReaderTxt = new StreamReader($"D:\\Project\\{filename1}.txt"))
                streamReaderTxt.ReadData(symbolTxt, ref outArray);
            using (StreamWriter streamWriterTxt = new StreamWriter($"D:\\Project\\{filename2}.txt"))
            {
                streamWriterTxt.AddData(array2, symbolTxt);
                streamWriterTxt.AddData(array1, symbolTxt);
            }
            using (StreamReader streamReaderTxt = new StreamReader($"D:\\Project\\{filename2}.txt"))
                streamReaderTxt.ReadData(symbolTxt, ref outArray);
            Console.WriteLine();
            using (StreamWriter streamWriterTxt = new StreamWriter($"D:\\Project\\{filename3}.txt"))
            {
                streamWriterTxt.MultiplyOfNumbers(outArray, symbolTxt);
                streamWriterTxt.SumOfNumbers(outArray, symbolTxt);
            }

            //Generic Part
            var person1 = new Person("Anna", 33);
            var person2 = new Person("Kate", 33);
            var person3 = new Person("Dan", 33);
            var people = new List<Person>();
            people.Add(person1);
            people.Add(person2);
            people.Add(person3);
            var cw = new FileWriter<Person>();
            cw.Write(people, "D:\\Project\\person.csv");
            var cr = new FileReader<Person>();
            var csvPeople = cr.Read("D:\\Project\\person.csv", false);
            foreach (var person in csvPeople)
            {
                Console.WriteLine(person);
            }
        }
    }
}
