using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace PokerTests
{
    [TestClass]
    public class HandsComparisonTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ComparisonTest()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            cards.Clear();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand otherHand = new Hand(cards);
            int result = checker.CompareHands(hand, otherHand);
        }


        [TestMethod]
        public void ComparisonTest2()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Queen, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            IHand otherHand = new Hand(cards);
            Assert.AreEqual(checker.CompareHands(hand, otherHand), -1);
        }


        [TestMethod]
        public void ComparisonTest4()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Three, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            IHand otherHand = new Hand(cards);
            Assert.AreEqual(checker.CompareHands(hand, otherHand), -1);
        }

        [TestMethod]
        public void ComparisonTest5()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Three, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Four, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            IHand otherHand = new Hand(cards);
            Assert.AreEqual(checker.CompareHands(hand, otherHand), 0);
        }

        [TestMethod]
        public void ComparisonTest6()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Three, CardSuit.Spades));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Nine, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Four, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            IHand otherHand = new Hand(cards);
            Assert.AreEqual(checker.CompareHands(hand, otherHand), -1);
        }

        [TestMethod]
        public void ComparisonTest7()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Three, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Nine, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Six, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand otherHand = new Hand(cards);
            Assert.AreEqual(checker.CompareHands(hand, otherHand), -1);
        }

        [TestMethod]
        public void ComparisonTest8()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Six, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Nine, CardSuit.Hearts));
            IHand otherHand = new Hand(cards);
            Assert.AreEqual(checker.CompareHands(hand, otherHand), -1);
        }

        [TestMethod]
        public void ComparisonTest9()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Four, CardSuit.Spades));
            cards.Add(new Card(CardFace.Six, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Jack, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Nine, CardSuit.Hearts));
            IHand otherHand = new Hand(cards);
            Assert.AreEqual(checker.CompareHands(hand, otherHand), -1);
        }

        [TestMethod]
        public void ComparisonTest10()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Nine, CardSuit.Hearts));
            IHand otherHand = new Hand(cards);
            Assert.AreEqual(checker.CompareHands(hand, otherHand), 1);
        }

        [TestMethod]
        public void ComparisonTest11()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Nine, CardSuit.Hearts));
            IHand otherHand = new Hand(cards);
            Assert.AreEqual(checker.CompareHands(hand, otherHand), 1);
        }
    }
}