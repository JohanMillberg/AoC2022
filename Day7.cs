using System;
using System.Text;
using System.Text.RegularExpressions;

namespace AoC2022;

public class DaySeven: IDay
{
    public int partOne(string filePath)
    {
        Dictionary<string, Directory> allDirs = createFileTree(filePath);
        return getSizesOfDirectories(allDirs).Sum();
    }

    public int partTwo(string filePath)
    {
        Dictionary<string, Directory> allDirs = createFileTree(filePath);
        Dictionary<string, int> sizes = allDirs.ToDictionary(d => d.Key, d => d.Value.getSize());
        int currentlyUsed = sizes["/"];
        int currentlyFree = 70000000 - currentlyUsed;
        int requiredToFree = 30000000 - currentlyFree;

        int sizeOfDirectoryToDelete = sizes.Values.Where(s => s >= requiredToFree)
                                                  .OrderBy(s => s)
                                                  .First();

        return sizeOfDirectoryToDelete;
    }

    public Dictionary<string, Directory> createFileTree(string filePath)
    {
        var commands = File.ReadAllLines(filePath);
        Directory root = new Directory(commands[0].Split(" ")[2], null);
        Directory currentDirectory = root;

        Dictionary<string, Directory> allDirectories = new Dictionary<string, Directory>();
        allDirectories.Add(root.path, root);

        foreach (var command in commands.Skip(1))
        {
            var line = command.Split(" ");

            if (Regex.IsMatch(line[0], @"^\d+$"))
            {
                currentDirectory.addFile(line[1], int.Parse(line[0]));
            }

            else if (line[0] == "$" && line[1] == "cd")
            {
                currentDirectory = currentDirectory.changeDirectory(line[2]);
            }

            else if (line[0] == "dir")
            {
                var newDirectory = new Directory(line[1], currentDirectory);
                currentDirectory.childDirectories.Add(newDirectory.path, newDirectory);
                allDirectories.Add(newDirectory.path, newDirectory);
            }
        }

        return allDirectories;
    }

    public List<int> getSizesOfDirectories(Dictionary<string, Directory> directories)
    {
        return directories.Values.Select(d => d.getSize()).Where(s => s <= 100000).ToList();
    }
}

public class Directory
{
    public string directoryName {get; set;}
    public Directory? parentDirectory {get; set;}
    public Dictionary<string, Directory> childDirectories {get; set;}
    public HashSet<FileRecord> files {get; set;}
    public string path {get; set;}

    public Directory(string directoryName,
                     Directory? parentDirectory)
        {
            this.directoryName = directoryName;
            this.parentDirectory = parentDirectory;
            this.path = $"{parentDirectory?.path ?? string.Empty}{(parentDirectory == null || parentDirectory.path == "/" ? string.Empty : "/")}{directoryName}";
            this.childDirectories = new Dictionary<string, Directory> {};
            this.files = new HashSet<FileRecord> {};
        }

    public override string ToString()
    {
        return $"- {this.directoryName} (dir)";
    }

    public List<string> getDirs()
    {
        return this.childDirectories.Keys.ToList();
    }

    public int getSize()
    {
        int fileSize = this.files != null ? this.files.Select(f => f.size).Sum() : 0;
        int childrenSizes = this.childDirectories.Values.Select(d => d.getSize()).Sum();
        
        int totalFileSize = childrenSizes + fileSize;
        return totalFileSize;
    }

    public void addFile(string fileName, int fileSize)
    {
        this.files.Add(new FileRecord(fileName, fileSize));
    }

    public void addDirectory(string directoryName)
    {
    }

    public Directory changeDirectory(string newDirectoryName)
    {
        if (newDirectoryName == "..")
        {
            return this.parentDirectory != null ? this.parentDirectory : throw new NullReferenceException();
        }
        
        else
        {
            var matchingDir = this.childDirectories.Select(d => d.Value)
                                    .FirstOrDefault(d => d.directoryName
                                    .Contains(newDirectoryName));
            
            return matchingDir != null ? matchingDir : throw new NullReferenceException();
        }
    }

    public string print(int subDirectoryIndex)
    {
        StringBuilder builder = new StringBuilder();
        
        builder.Append(String.Concat(Enumerable.Repeat(" ", subDirectoryIndex)));
        builder.Append($"{this.ToString()}\n");

        foreach (var item in childDirectories.Select((value, i) => new {i, value}))
        {
            var directory = item.value;
            var index = item.i;

            builder.Append($"{directory.Value.print(index+1)}");
        }

        foreach (var file in files)
        {
            builder.Append(String.Concat(Enumerable.Repeat("\t", subDirectoryIndex+1)));
            builder.Append($"{file.ToString()}\n");
        }

        return builder.ToString();
    }
    
}

public record FileRecord(string fileName, int size)
{
    public override string ToString()
    {
        return $"- {fileName} (file, size={size})";
    }
}