using System;

namespace Spaceman
{
  class Program
  {
    static void Main(string[] args)
    {
      Game myGame = new Game();
      myGame.Greet();
      do{
        Console.Clear();
        myGame.Display();
        myGame.Ask();
      }while(!myGame.DidLose() && !myGame.DidWin());
      Console.WriteLine(myGame.DidWin() ? "YOU WON!!!" : "You loose. GAME OVER");
    }
  }
}
