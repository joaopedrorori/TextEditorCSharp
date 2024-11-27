using System;
using System.Runtime.InteropServices;
using System.IO;

namespace TextEditor
{
  class Program
  {
    static void Main(string[] args)
    {
      Menu();
    }
    static void Menu(){
      Console.Clear();
      Console.WriteLine("What do you want to do?");
      Console.WriteLine("1 - Open text file");
      Console.WriteLine("2 - Create a new text file");
      Console.WriteLine("0 - Exit");

      short option = short.Parse(Console.ReadLine());

      switch(option){
        case 0: System.Environment.Exit(0);
          break;
        case 1: Open();
          break;
        case 2: Edit();
          break;
        default: Menu();
          break;
      }
    }

    static void Open(){
      Console.Clear();
      Console.WriteLine("What is the path of the file?");
      string path = Console.ReadLine();

      using(var file = new StreamReader(path))
      {
        string text = file.ReadToEnd();
        Console.WriteLine(text);
      }

      Console.WriteLine("");
      Console.ReadLine();
      Menu();
    }

    static void Edit(){
      Console.Clear();
      Console.WriteLine("Type your text below | Press ESC to leave");
      Console.WriteLine("-----------------------------------------");
      string text = "";

      do //do this
      {
        text += Console.ReadLine();
        text += Environment.NewLine;
      }
      while(Console.ReadKey().Key != ConsoleKey.Escape);//While the esc is not pressed
    
      Save(text);
    }
    static void Save(string text){
      Console.Clear();
      Console.WriteLine("What is the path to save the file?");
      string path = Console.ReadLine();

      /*usign tag is Best way to read and write files in c#, it opens and closes the file*/
      using(var file = new StreamWriter(path))
      {
        file.Write(text);
      }

      Console.WriteLine($"File saved in {path} successfully.");
      Console.ReadLine();
      Menu();
    }
  }
}