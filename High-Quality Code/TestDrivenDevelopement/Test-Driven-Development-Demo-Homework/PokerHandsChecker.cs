using System;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                return false;
            }

            foreach (var item in hand.Cards)
            {
                if ((hand.Cards.Count((card) => card.Face == item.Face && card.Suit == item.Suit) > 1))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            return this.IsStraight(hand) && this.IsFlush(hand);
        }

        public bool IsFourOfAKind(IHand hand)
        {
            var cards = hand.Cards;
            return cards.Any(x => cards.Count(y => y.Face == x.Face) == 4);
        }
        
        public bool IsFullHouse(IHand hand)
        {
            var cards = hand.Cards;
            return cards.Any(x => cards.Count(y => y.Face == x.Face) == 2) &&
                   cards.Any(x => cards.Count(y => y.Face == x.Face) == 3);
        }

        public bool IsFlush(IHand hand)
        {
            CardSuit suit = hand.Cards[0].Suit;

            return hand.Cards.All(card => card.Suit == suit);
        }

        public bool IsStraight(IHand hand)
        {
            var cards = this.SortCards(hand);
            
            for (int i = 0; i < cards.Length - 1; i++)
            {
                if (i == cards.Length - 2 && cards[i + 1].Face - cards[i].Face == 9)
                {
                    return true;
                }

                if (cards[i + 1].Face - cards[i].Face != 1)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            var cards = hand.Cards;
            return cards.Any(x => cards.Count(y => y.Face == x.Face) == 3) &&
                   !cards.Any(x => cards.Count(y => y.Face == x.Face) == 2);
        }

        public bool IsTwoPair(IHand hand)
        {
            var cards = hand.Cards;
            var pairsCount = cards.Where(x => cards.Count(y => x.Face == y.Face) == 2).Count() / 2;
            if (pairsCount == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsOnePair(IHand hand)
        {
            var cards = hand.Cards;
            var pairsCount = cards.Where(x => cards.Count(y => x.Face == y.Face) == 2).Count() / 2;
            if (pairsCount == 1 && !cards.Any(x => cards.Count(y => y.Face == x.Face) == 3))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsHighCard(IHand hand)
        {
            return !(IsOnePair(hand) || IsTwoPair(hand) || IsThreeOfAKind(hand) || IsStraight(hand) ||
                     IsFlush(hand) || IsFullHouse(hand) || IsFourOfAKind(hand) || IsStraightFlush(hand));
        }
        
        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            if (!IsValidHand(firstHand) || !IsValidHand(secondHand) ||
                firstHand.Cards.Any(x => secondHand.Cards.Any(y => x.Face == y.Face && y.Suit == x.Suit)))
            {
                throw new InvalidOperationException("Invalid hands! One or more cards are duplicared in the hands or one of the hands had too many cards!");
            }
            var result= this.GetCategory(secondHand).CompareTo(GetCategory(firstHand));

            return result;
        }

        private HandCategory GetCategory(IHand hand)
        {
            if (IsOnePair(hand))
            {
                return HandCategory.OnePair;
            }
            if (IsTwoPair(hand))
            {
                return HandCategory.TwoPairs;
            }
            if (IsThreeOfAKind(hand))
            {
                return HandCategory.ThreeOfAKind;
            }
            if (IsStraight(hand))
            {
                return HandCategory.Straight;
            }
            if (IsFlush(hand))
            {
                return HandCategory.Flush;
            }
            if (IsFullHouse(hand))
            {
                return HandCategory.FullHouse;
            }
            if (IsFourOfAKind(hand))
            {
                return HandCategory.FourOfAKind;
            }
            if (IsStraightFlush(hand))
            { 
                return HandCategory.StraightFlush;
            }
            return HandCategory.HighCard;
        }

        private ICard[] SortCards(IHand hand)
        {
            var arr = hand.Cards.ToArray();
            Array.Sort(arr, (x, y) => x.Face.CompareTo(y.Face));
            return arr;
        }
    }
}