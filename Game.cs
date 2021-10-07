using System;

namespace Spaceman
{
  internal class Game
  {
    //FIELDS
    Ufo u = new Ufo();
    
    //PROPERTIES
    private string CodeWord{ set; get; }
    private string[] CodeWords{ set; get; }
    private string CurrentWord{ set; get; }
    private int MaxGuesses{ set; get; }
    private int WrongGuesses{ set; get; }

    //CONSTRUCTOR
    public Game(){
      Random rnd = new Random();
      CodeWords = new string[] {"alien", "cat", "orange"};
      CodeWord = CodeWords[rnd.Next(0, CodeWords.Length)];
      MaxGuesses = 5;
      WrongGuesses = 0;
      CurrentWord = "";
      for(int i=0 ; i<CodeWord.Length ;i++){
        CurrentWord+="_";
      }
    }

    //METHODS
    public void Greet(){
      Console.WriteLine("Welcome! Find the secret word to save our friend.");
    }

    public void Ask(){
      int indexLetter;
      Console.Write("Write a letter: ");
      string aLetter = Console.ReadLine();
      string comodinWord = CodeWord;

      if(aLetter.Length==1){
        char letter = Convert.ToChar(aLetter);
        if(comodinWord.Contains(letter)){
          while(comodinWord.IndexOf(letter)>=0){
            indexLetter = comodinWord.IndexOf(letter);
            CurrentWord = CurrentWord.Remove(indexLetter, 1).Insert(indexLetter, aLetter);
            comodinWord = comodinWord.Remove(indexLetter, 1).Insert(indexLetter, "_");
          }
        }else{
          WrongGuesses++;
          u.AddPart();
        }
      }
      else{
        Console.WriteLine("You must type 1 letter!");
      }
    }//end of ask



    public void Display(){
      Console.WriteLine(u.Stringify());
      Console.WriteLine($"You have {MaxGuesses-WrongGuesses} wrong guesses left.");
      Console.WriteLine("Current Word: "+CurrentWord);
    }

    public  bool DidWin(){
      return CodeWord.Equals(CurrentWord);
    }

    public  bool DidLose(){
      return WrongGuesses>=MaxGuesses;
    }

  }
}
