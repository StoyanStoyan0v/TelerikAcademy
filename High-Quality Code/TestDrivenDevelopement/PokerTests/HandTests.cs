using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTests
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void HandToStringTest()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace,CardSuit.Hearts));
            cards.Add(new Card(CardFace.King,CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen,CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack,CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten,CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.AreEqual(hand.ToString(), "Ace of Hearts\nKing of Hearts\nQueen of Hearts\nJack of Hearts\nTen of Hearts");
        }

        [TestMethod]
        public void HandToStringTest2()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two,CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King,CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten,CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace,CardSuit.Spades));
            cards.Add(new Card(CardFace.Seven,CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.AreEqual(hand.ToString(), "Two of Diamonds\nKing of Clubs\nTen of Diamonds\nAce of Spades\nSeven of Hearts");        
        }

    }
}