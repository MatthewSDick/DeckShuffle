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
      static int getCardNumber(string incoming)
      {
        switch (incoming)
        {
          case "Ace":
            return 14;

          case "Two":
            return 2;

          case "Three":
            return 3;

          case "Four":
            return 4;

          case "Five":
            return 5;

          case "Six":
            return 6;

          case "Seven":
            return 7;

          case "Eight":
            return 8;

          case "Nine":
            return 9;

          case "Ten":
            return 10;

          case "Jack":
            return 11;

          case "Queen":
            return 12;

          case "King":
            return 13;
        }
        return 0;
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

      //Console.WriteLine("Top Deck of cards " + deckOfCards.Count);

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
      Console.WriteLine($"Player 1 has {player1.Count} cards.  Player 2 has {player2.Count} cards.");
      Console.WriteLine("Do you want to play  game? (Y) or (N)");
      var input3 = Console.ReadLine();

      if (input3.ToLower() == "y")
      {
        // Play game info goes here
        // var start = myString.IndexOf("%");
        // var spaceIndex = myString.IndexOf(" ", start)
        var gameOver = false;
        var inATie = false;
        int numberOfCards = 1;

        while (gameOver == false)
        {

          if (inATie == false)
          {

            //Console.WriteLine(player1[0]);
            var p1SpaceIndex = player1[0].IndexOf(" ");
            //Console.WriteLine(spaceIndex);
            string p1CardName = player1[0].Substring(0, p1SpaceIndex);
            //Console.WriteLine(cardNumber);
            var p1CardNumber = getCardNumber(p1CardName);
            //Console.WriteLine($"card number function: {cardNumber}");

            //Console.WriteLine(player2[0]);
            var p2SpaceIndex = player2[0].IndexOf(" ");
            //Console.WriteLine(p2SpaceIndex);
            string p2CardName = player2[0].Substring(0, p2SpaceIndex);
            //Console.WriteLine(cardNumber);
            var p2CardNumber = getCardNumber(p2CardName);
            //Console.WriteLine($"card number function: {p2CardNumber}");

            var whoWon = "";

            if (p1CardNumber > p2CardNumber)
            {
              whoWon = "Player 1 won this hand.";
              player1.Add(player2[0]);
              player2.RemoveAt(0);
              var cardToBack = player1[0];
              player1.RemoveAt(0);
              player1.Add(cardToBack);
              inATie = false;
              Console.WriteLine($"Player one has a {p1CardName} and Player 2 has a {p2CardName}. {whoWon}");
              Console.WriteLine($"Player 1 has {player1.Count} cards.  Player 2 has {player2.Count} cards.");
            }
            else if (p1CardNumber < p2CardNumber)
            {
              whoWon = "Player 2 won this hand.";
              player2.Add(player1[0]);
              player1.RemoveAt(0);
              var cardToBack = player2[0];
              player2.RemoveAt(0);
              player2.Add(cardToBack);
              inATie = false;
              Console.WriteLine($"Player one has a {p1CardName} and Player 2 has a {p2CardName}. {whoWon}");
              Console.WriteLine($"Player 1 has {player1.Count} cards.  Player 2 has {player2.Count} cards.");
            }
            else if (p1CardNumber == p2CardNumber)
            {
              whoWon = "Tie.";
              inATie = true;
              Console.WriteLine($"Player one has a {p1CardName} and Player 2 has a {p2CardName}. {whoWon}");
            }

            if (player1.Count == 0 | player2.Count == 0)
            {
              gameOver = true;
            }

          }
          else if (inATie == true)
          {
            var canDoTie = true;
            if (player1.Count < 3)
            {
              canDoTie = false;
              gameOver = true;
              Console.WriteLine("Player 1 does not have enough cards for war.  He looses.");
            }

            if (player2.Count < 3)
            {
              canDoTie = false;
              gameOver = true;
              Console.WriteLine("Player 2 does not have enough cards for war.  He looses.");
            }

            if (canDoTie == true)
            {


              var whoWon2 = "";
              //Console.WriteLine($"numberOfCards = {numberOfCards}");
              numberOfCards = numberOfCards + 2;
              //Console.WriteLine($"numberOfCards = {numberOfCards}");
              Console.WriteLine("Player 1 puts a card face down.");
              Console.WriteLine("Player 2 puts a card face down.");

              //Console.WriteLine(player1[0]);
              var p1SpaceIndex = player1[numberOfCards].IndexOf(" ");
              //Console.WriteLine(spaceIndex);
              string p1CardName = player1[numberOfCards].Substring(0, p1SpaceIndex);
              //Console.WriteLine(cardNumber);
              var p1CardNumber = getCardNumber(p1CardName);
              //Console.WriteLine($"card number function: {cardNumber}");

              //Console.WriteLine(player2[0]);
              var p2SpaceIndex = player2[numberOfCards].IndexOf(" ");
              //Console.WriteLine(p2SpaceIndex);
              string p2CardName = player2[numberOfCards].Substring(0, p2SpaceIndex);
              //Console.WriteLine(cardNumber);
              var p2CardNumber = getCardNumber(p2CardName);
              //Console.WriteLine($"card number function: {p2CardNumber}");

              if (p1CardNumber > p2CardNumber)
              {
                whoWon2 = "Player 1 won this hand.";

                var m = numberOfCards;
                //Console.WriteLine($"Going in M={m}");
                while (m > 0)
                {
                  player1.Add(player2[0]);
                  player2.RemoveAt(0);
                  var cardToBack = player1[0];
                  player1.RemoveAt(0);
                  player1.Add(cardToBack);
                  m--;
                  //Console.WriteLine($"After decrement M={m}");
                }
                inATie = false;
                numberOfCards = 1;
              }

              else if (p1CardNumber < p2CardNumber)
              {
                whoWon2 = "Player 2 won this hand.";

                var m = numberOfCards;
                while (m > 0)
                {
                  player2.Add(player1[0]);
                  player1.RemoveAt(0);
                  var cardToBack = player2[0];
                  player2.RemoveAt(0);
                  player2.Add(cardToBack);
                  m--;
                }
                inATie = false;
                numberOfCards = 1;
              }
              else if (p1CardNumber == p2CardNumber)
              {
                whoWon2 = "Tie.";
                inATie = true;
              }

              Console.WriteLine($"Player one has a {p1CardName} and Player 2 has a {p2CardName}. {whoWon2}");
              Console.WriteLine($"Player 1 has {player1.Count} cards.  Player 2 has {player2.Count} cards.");
            }
          }
        }

      }
      else if (input3.ToLower() == "n")
      {
        Console.WriteLine("You are no fun !!!");
      }
    }
  }
}












