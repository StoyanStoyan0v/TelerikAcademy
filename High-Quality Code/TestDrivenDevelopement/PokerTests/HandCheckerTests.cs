using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTests
{
    [TestClass]
    public class HandCheckerTests
    {
        //Hand validation tests...
        [TestMethod]
        public void TestNotDuplicateCards()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsTrue(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestDuplicateCards()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestTooMuchCards()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void TestLesserCards()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.King, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Jack, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsValidHand(hand));
        }

        //Straigth validation tests...
        [TestMethod]
        public void TestStraigth()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Three, CardSuit.Spades));
            cards.Add(new Card(CardFace.Four, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsTrue(checker.IsStraight(hand));
        }

        [TestMethod]
        public void TestStraigth2()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Six, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Three, CardSuit.Spades));
            cards.Add(new Card(CardFace.Four, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsTrue(checker.IsStraight(hand));
        }

        [TestMethod]
        public void TestNotStraigth()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Seven, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Three, CardSuit.Spades));
            cards.Add(new Card(CardFace.Four, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsStraight(hand));
        }

        [TestMethod]
        public void TestFlush()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Seven, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Three, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsTrue(checker.IsFlush(hand));
        }

        [TestMethod]
        public void TestNotFlush()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Three, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsFlush(hand));
        }

        [TestMethod]
        public void TestStraightFlush()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Six, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Seven, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Nine, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsTrue(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestStraightFlush2()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Three, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsTrue(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestNotStraightFlush()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestNotStraightFlush2()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Three, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Four, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void TestFourOfKind()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsTrue(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestFourOfKind2()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsTrue(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestNotFourOfKind()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestNotFourOfKind2()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestThreeOfKind()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsTrue(checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void TestNotThreeOfKind()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void TestNotThreeOfKind2()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Three, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void TestNotThreeOfKind3()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void TestPair()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsTrue(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestNotPair()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestNotPair2()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestNotPair3()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestNotPair4()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void TestTwoPairs()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Seven, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsTrue(checker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TestNotTwoPairs()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TestNotTwoPairs2()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TestNotTwoPairs3()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TestNotTwoPairs4()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsTwoPair(hand));
        }

        [TestMethod]
        public void TestFullHouse()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Five, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsTrue(checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestFullHouse2()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Two, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsTrue(checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestNotFullHouse()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Six, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestNotFullHouse2()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Two, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Two, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestNotFullHouse3()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void TestHighCard()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Queen, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Seven, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Six, CardSuit.Spades));
            cards.Add(new Card(CardFace.Five, CardSuit.Hearts));
            IHand hand = new Hand(cards);
            Assert.IsTrue(checker.IsHighCard(hand));
        }

        [TestMethod]
        public void TestNotHighCard()
        {
            IPokerHandsChecker checker = new PokerHandsChecker();
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Ace, CardSuit.Spades));
            cards.Add(new Card(CardFace.King, CardSuit.Spades));
            cards.Add(new Card(CardFace.Queen, CardSuit.Spades));
            cards.Add(new Card(CardFace.Jack, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            IHand hand = new Hand(cards);
            Assert.IsFalse(checker.IsHighCard(hand));
        }
    }
}