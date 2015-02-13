/*
 * Anna Calvert
 * Cpts323
 * C# Program Hw1
 */

using System;                           //using System.IO
using System.IO;                        //parse
using System.Linq;                      //parse
using System.Text.RegularExpressions;   //tokenize regular expression

namespace Project1
{
    class Proj
    {
        static void Main(string[] args)                                                                                      //main function
        {
            string[] fileContent;
            Console.WriteLine("\nNumber of command line parameters = {0}", args.Length);                                     //number cmd line args

            for (int i = 0; i < args.Length; i++) {                                                                          //cmd line args
                Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);
            }
            Console.WriteLine("\n");

            if (args.Length == 0) {                                                                                         //if no cmd args, error
                Console.WriteLine("ERROR: must enter file name.");
            }

            string fileName = args[0];
            var doesExist = System.IO.File.Exists(fileName); 
            if (!doesExist) {
                Console.WriteLine("The file does not exist.");                                                              //error if file does not exist
                return;
            }
            fileContent = System.IO.File.ReadAllLines(fileName);
            bool targetPresent = args.Length == 3 ? true : false;                                                          //Terniary operator: if 3 args then true, else false

            if (args.Length > 1)
            {
                char[] delimiterChar = { '=' };
                string[] words;
                switch (args[1])
                {
                    case "PRINT":
                        if (targetPresent)                                                                                 //if target info present
                        {
                            bool found = false;
                            string target = "Name=" + args[2];
                            //Console.WriteLine("Target = {0}", target);                        
                            for (int i = 0; i < fileContent.Length; i++)                                                   //search text file
                            {
                                if (fileContent[i].EndsWith(target))                                                       //when find target name 
                                {
                                    for (int j = i; (fileContent[j] != "[Target]") && (j < fileContent.Length); j++) {     //print current target data
                                        Console.WriteLine(fileContent[j]);
                                    }
                                    found = true;
                                    break;
                                }
                            }
                            if (!found) {
                                Console.WriteLine("Target does not exist.\n");                                              //if not found, message
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("List lines containing 'Name=' :");
                            for (int i = 0; i < fileContent.Length; i++)
                            {
                                if (fileContent[i].Contains("Name=")) {                                                     //print target names
                                    words = fileContent[i].Split(delimiterChar);
                                    Console.WriteLine(words.Last());
                                }

                            }
                        }
                        break;
                    case "CONVERT":
                        if (targetPresent) {                                                                                //convert
                        }
                        else {
                            Console.WriteLine("ERROR: file name not provided.");
                        }
                        break;
                    case "ISFRIEND":                                                                                        //isfriend
                        if (targetPresent) {
                            bool found = false;
                            string target = "Name=" + args[2];
                            for (int i = 0; i < fileContent.Length; i++)
                            {
                                if (fileContent[i].EndsWith(target))                                                        //find target name
                                {
                                    for (int j = i; (fileContent[j] != "[Target]") && (j < fileContent.Length); j++)
                                    {
                                        if (fileContent[j] == "Friend=true") {                                              //if target Friend=true is found
                                            Console.WriteLine("Aye Captain!");
                                            found = true;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                            if (!found) {
                                Console.WriteLine("Nay, Scallywag!");                                                       //else is a foe
                            }
                        }
                        else {
                            Console.WriteLine("ERROR: Target name not provided.");
                        }
                        break;
                    case "EXIT":                                                                                            //exit
                        break;
                    default:
                        Console.WriteLine("ERROR: Invalid command.");
                        break;
                }//end switch
                //return; //remove
            }//end if
        }//end main
    }//end class proj
}//end namespace 
