// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
namespace ReplaceString
{
    class Program
    {
        //static int counter;
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the string which you want to replace in the file : ");
            var replace_string = Console.ReadLine();
            Console.WriteLine("Enter the string from which you want to replace the above string : ");
            var replace_with_string = Console.ReadLine();
            Console.WriteLine("Enter the number of string you want to replace : ");
            int number_of_string = Convert.ToInt32(Console.ReadLine());

            string path = @"..\..\..\TextFile1.txt";
            string output_path = @"..\..\..\output.txt";

            var InputFromFile = GetTheData(path);
            //var TextWithReplaced = ReplaceStringWithDesired(InputFromFile, replace_string, replace_with_string, number_of_string);
            int counter = 0;
            counter = ReplaceStringWithDesired(InputFromFile, replace_string, replace_with_string, number_of_string);
            if (counter == 0)
            {
                Console.WriteLine("File does not contain the {0} string",replace_string);
            }
           
            else {
               
                WritetoFile(output_path,path,InputFromFile);
            }
            
            //Console.WriteLine(File.ReadAllText((path)));


        }
        public static string[] GetTheData(string path) {
            var result =  File.ReadAllText(path);
            return result.Split(" ");
        }
        public static int ReplaceStringWithDesired(string[] inputArray,string replace_string,string replace_with_string,int number_of_string) {

            int i,counter=0;
            for (i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] == replace_string)
                {
                    inputArray[i] = replace_with_string;
                    counter++;
                }

            }
            return counter;
            // return inputArray;
        }

        public static void WritetoFile(string output_path,string path,string[] InputFromFile) {
            var outputFile = new FileInfo(output_path).OpenWrite();
            var outputString = String.Join(" ", InputFromFile);
            outputFile.Write(System.Text.Encoding.ASCII.GetBytes(outputString));
            outputFile.Close();
            //File.Delete(path);
            File.Copy(output_path, path, true);
           

        }
       
    }
}
