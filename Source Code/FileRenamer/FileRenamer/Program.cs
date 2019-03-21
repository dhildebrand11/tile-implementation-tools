using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileRenamer
{
	class Program
	{
		static void Main(string[] args)
		{
            string startPath = "C:\\Tiles";
            bool open = true;
                //File Renamer
                Console.WriteLine("Commonwealth Tile Rename Tool\n");
                Console.WriteLine("Please ensure that your map tiles are located in the same folder and they are all the same zoom level before renaming\n");
                bool isNum = false;
                int number = 0;

                do
                {
                    Console.WriteLine("- Type 'y' to display pubspec output");
                    Console.WriteLine("- Type a number between 1 and 24 to rename folders");
                    Console.WriteLine("- Type 'c' to change tile folder location (default is C:\\Tiles)");
                    Console.Write("Please choose an option: ");
                    
                    string input = Console.ReadLine();

                    if (input == "y")
                    {
                        Console.Write("Enter the city name used in your assets folder (case sensitive): ");
                        string city = Console.ReadLine();
                        string filePaths = "";
                        var directories = Directory.GetDirectories(startPath);

                        foreach (string folder in directories)
                        {
                            string primeFolder = new DirectoryInfo(folder).Name;

                            var subdirectories = Directory.GetDirectories(folder);
                            foreach (string subfolder in subdirectories)
                            {
                                string subFolder = new DirectoryInfo(subfolder).Name;
                                filePaths += "    - assets/" + city + "/map/" + primeFolder + "/" + subFolder + "/\n";
                            }
                            filePaths.Replace('\\', '/');
                            
                        }
                        Console.WriteLine(filePaths);
                        Console.WriteLine("\nCopy the above and paste it into the pubspec.yaml");
                    }
                    else if (input == "c")
                    {
                        Console.Write("Enter your tile folder path: ");
                        string tempPath = Console.ReadLine();
                        if (Directory.Exists(tempPath))
                        {
                            startPath = tempPath;
                            Console.WriteLine("Tile folder path set (this will be reset upon program restart)");
                        }
                        else
                        {
                            Console.WriteLine("Tile folder path not found");
                        }

                    }
                    else
                    {
                        isNum = Int32.TryParse(input, out number);
                        if (!isNum) Console.WriteLine("Please input a valid number between 10 and 24");
                        else
                        {
                            string zoomLevel = number.ToString();
                        string zoomDir = startPath + "\\" + zoomLevel;
                        Directory.CreateDirectory(zoomDir);

                            DirectoryInfo d = new DirectoryInfo(startPath);
                            FileInfo[] filesInDir = d.GetFiles("tile_" + zoomLevel + "*.*");
                            string currFolder;
                            string tempFolder = "0";
                            string destFolder = "0";
                            foreach (FileInfo f in filesInDir)
                            {
                                currFolder = f.Name.Remove(0, 8);
                                int delete = currFolder.IndexOf("_");
                                string newName = currFolder.Substring(delete + 1);
                                currFolder = currFolder.Substring(0, delete);
                                if (currFolder != tempFolder)
                                {
                                    tempFolder = currFolder;
                                    Directory.CreateDirectory(zoomDir + "\\" + tempFolder);
                                    destFolder = zoomDir + "\\" + tempFolder + "\\";
                                }
                                //Console.WriteLine(destFolder + newName);

                                f.MoveTo(destFolder + newName);
                            }



                            Console.WriteLine("Folders made, press enter to return to start");
                            
                        }
                    }
                    Console.WriteLine("--Press enter to return to start--");
                Console.ReadLine();
            } while (open);
		}
	}
}
