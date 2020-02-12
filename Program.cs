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


      // Cards are shuffled - playersFinalDeck 
      // deal cards to 2 people
      // make a list of dealt cards

      var player1 = new List<string>();
      var player2 = new List<string>();

      var leftToDeal = playersFinalCards.Count;

      var PlayerToGetCard = 1;

      while (leftToDeal > 0)
      {
        //Console.WriteLine(playersFinalCards[0]);

        if (PlayerToGetCard == 1)
        {
          player1.Add(playersFinalCards[0]);
          //Console.WriteLine($"Player 1 was dealt {playersFinalCards[0]}");
          PlayerToGetCard = 2;
        }

        else if (PlayerToGetCard == 2)
        {
          player2.Add(playersFinalCards[0]);
          //Console.WriteLine($"Player 2 was dealt {playersFinalCards[0]}");
          PlayerToGetCard = 1;
        }
        playersFinalCards.RemoveAt(0);

        leftToDeal--;
      }
      var running = true;

      while (running)
      {

        Console.WriteLine("Would you like to see the players cards?  (Y) or (N)");
        var input = Console.ReadLine();

        if (input.ToLower() == "y")
        {
          Console.WriteLine("Which players cards would you like to see? 1 or 2");
          var input2 = Console.ReadLine();

          var isValid = int.TryParse(input2, out int playerSelection);

          while (isValid == false)
          {
            Console.WriteLine("That is not a number");
            input2 = Console.ReadLine();
            playerSelection = int.Parse(input2);
          }

          if (playerSelection == 1)
          {
            var i = 0;
            var howManyCards = player1.Count;
            while (i < howManyCards)
            {
              Console.WriteLine(player1[i]);
              i++;
            }
          }

          else if (playerSelection == 2)
          {
            var i = 0;
            var howManyCards = player2.Count;
            while (i < howManyCards)
            {
              Console.WriteLine(player2[i]);
              i++;
            }
          }

        }

        else if (input.ToLower() == "n")
        {
          running = false;
        }
      }









      // ----------------

      // int showDeck = 0;
      // var nextCard = playersFinalCards[showDeck];
      // Console.WriteLine($"Your First card is: {nextCard}");

      // var isRunning = true;

      // while (isRunning)
      // {

      //   Console.WriteLine("Do you want to see your next card? (Y) or (N)");
      //   var input = Console.ReadLine();

      //   if (input.ToLower() == "y")
      //   {
      //     showDeck++;
      //     nextCard = playersFinalCards[showDeck];
      //     Console.WriteLine($"Your next card is: {nextCard}");
      //   }

      //   if (input.ToLower() == "n")
      //   {
      //     isRunning = false;
      //     Console.WriteLine("Thanks for playing.");
      //   }

    }
  }
}

