using System;
using System.Collections.Generic;

namespace DeckShuffle
{
  class Program
  {
    static void Main(string[] args)
    {
      // Random
      static int randomGenerator(int i)
      {
        Random rnd = new Random();
        int x = rnd.Next(i);
        return x;
      }

      var deckOfCards = new List<string>();

      var suits = new List<string> { "Spades", "Hearts", "Clubs", "Diamonds" };
      var numbers = new List<string> { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

      for (var i = 0; i < suits.Count; i++)
      {
        var currentCard = suits[i];
        //Console.WriteLine(currentCard);

        for (var x = 0; x < numbers.Count; x++)
        {
          var currentNumber = numbers[x];
          //Console.WriteLine(currentNumber);
          //Console.WriteLine($"{currentNumber} of {currentCard} ");
          var newCard = ($"{currentNumber} of {currentCard}");
          deckOfCards.Add(newCard);
        }
      }

      var playersFinalCards = new List<string>();

      Console.WriteLine("Top Deck of cards " + deckOfCards.Count);

      var numberLeft = deckOfCards.Count;

      while (numberLeft > 0)
      {
        int randomCard = randomGenerator(numberLeft);

        var movingCard = deckOfCards[randomCard];
        //Console.WriteLine("Moving Card = " + movingCard);


        playersFinalCards.Add(movingCard);
        deckOfCards.RemoveAt(randomCard);
        //Console.WriteLine("Player deck of cards " + playersFinalCards.Count);
        //Console.WriteLine("After Deck of cards " + deckOfCards.Count);

        numberLeft--;

      }
      int showDeck = 0;
      var nextCard = playersFinalCards[showDeck];
      Console.WriteLine($"Your First card is: {nextCard}");

      var isRunning = true;

      while (isRunning)
      {

        Console.WriteLine("Do you want to see your next card? (Y) or (N)");
        var input = Console.ReadLine();

        if (input.ToLower() == "y")
        {
          showDeck++;
          nextCard = playersFinalCards[showDeck];
          Console.WriteLine($"Your next card is: {nextCard}");
        }

        if (input.ToLower() == "n")
        {
          isRunning = false;
          Console.WriteLine("Thanks for playing.");
        }

      }
    }
  }
}
