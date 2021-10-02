using System;

namespace Spaceman
{
  class Game
  {
    //FIELDS
    private string codeWord;
    private string[] codeWords = new string[] {"alien", "cat", "orange"};
    private string currentWord;
    private int maxGuesses;
    private int wrongGuesses;
    Ufo u = new Ufo();
    //CONSTRUCTOR
    public Game(){
      Random rnd = new Random();
      codeWord = codeWords[rnd.Next(0, codeWords.Length)];
      maxGuesses = 5;
      wrongGuesses = 0;
      currentWord = "";
      for(int i=0 ; i<codeWord.Length ;i++){
        currentWord+="_";
      }
    }

    //METHODS
    public void Ask(){
      int indexLetter;
      Console.Write("Write a letter: ");
      string aLetter = Console.ReadLine();
      string comodinWord = codeWord;

      if(aLetter.Length==1)
      {
        char letter = Convert.ToChar(aLetter);
        if(comodinWord.Contains(letter)){
          while(comodinWord.IndexOf(letter)>=0){
            indexLetter = comodinWord.IndexOf(letter);
            currentWord = currentWord.Remove(indexLetter, 1).Insert(indexLetter, aLetter);
            comodinWord = comodinWord.Remove(indexLetter, 1).Insert(indexLetter, "_");
          }
        }else{
          wrongGuesses++;
          u.AddPart();
        }
      }
      else{
        Console.WriteLine("You must type 1 letter!");
      }
    }



    public void Display(){
      Ufo spaceship = new Ufo();
      Console.WriteLine(spaceship.Stringify());
      Console.WriteLine($"You have {maxGuesses-wrongGuesses} wrong guesses left.");
      Console.WriteLine("Current Word: "+currentWord);
    }
    public  bool DidWin(){
      return codeWord.Equals(currentWord);
    }
    public  bool DidLose(){
      return wrongGuesses>=maxGuesses;
    }
    public void Greet()
    {
      Console.WriteLine("Welcome! Find the secret word to save our friend.");
    }

    //PROPERTIES
    public string CodeWord{
      set; get;
    }
    public string[] CodeWords{
      set; get;
    }
    public string CurrentWord{
      private set; get;
    }
    public int MaxGuesses{
      set; get;
    }
    public int WrongGuesses{
      set; get;
    }
  }
}
