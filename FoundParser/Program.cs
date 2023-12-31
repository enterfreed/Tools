﻿using FoundParser.Extensions;

namespace FoundParser;

public static class Program
{
    public const string fileName = @"C:\Users\boris\Desktop\xdfgdfg.txt";

    private const int SpacesPerLevel = 4;
    private const int FirstLevelTabCount = 2;
    public static void Main()
    {
        var strArray = FileParser.GetFileContent(fileName);
        var result = new List<FilePublisher>();
        
        string searchedSubStr = "Publish("; 
        string searchedExtension = "GpnDs";
        
        var dirList = new List<(string path, int level)>();

        for (int i = 0; i < strArray.Length; i++)
        {
            if (!strArray[i].Take(SpacesPerLevel * FirstLevelTabCount).All(x => x == ' '))
            {
                continue; //  первый уровень
            }
            
            int currentLevel = (strArray[i].Length - strArray[i].TrimStart().Length)/SpacesPerLevel;
            if (StringHelpers.IsStartsWithNum(strArray[i], out var lineNum))
            {
                result.Add(new FilePublisher()
                {
                    LineAddress = lineNum,
                    PathElems = dirList.Select(x => x.path).ToList(),
                });
            }
            // else if (dirList.Last().level == currentLevel)
            // {
            //     dirList.RemoveAt(dirList.Count - 1); 
            //     dirList.Add((strArray[i], currentLevel));
            // }
            else if (dirList.Any() && dirList.Last().level >= currentLevel)
            {
                if (currentLevel == 2)
                {
                    dirList.Clear();
                }
                else
                {
                    for (int j = 0; j <= dirList.Last().level - currentLevel+1; j++)
                    {
                        dirList.RemoveAt(dirList.Count - 1); 
                    }
                }

                dirList.Add((StringHelpers.GetClearedString(strArray[i]), currentLevel));
            }
            else
            {
                dirList.Add((StringHelpers.GetClearedString(strArray[i]), currentLevel));
            }
            
        }

        foreach (var VARIABLE in result)
        {
            Console.WriteLine($"line {VARIABLE.LineAddress}  path {VARIABLE.GetFullPath()}");
        }
    }
}