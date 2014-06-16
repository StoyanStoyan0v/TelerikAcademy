using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTests
{
    [TestClass]
    public class CardTests
    {

        [TestMethod]
        public void CardToStringTest()
        {
            ICard card = new Card(CardFace.Ace, CardSuit.Spades);
            Assert.AreEqual(card.ToString(), "Ace of Spades");            
        }

        [TestMethod]
        public void CardToStringTest2()
        {
            ICard card = new Card(CardFace.Two, CardSuit.Hearts);
            Assert.AreEqual(card.ToString(), "Two of Hearts");            
        }
    }
}
