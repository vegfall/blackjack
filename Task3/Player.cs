using System.Numerics;
using Task3.Cards;

namespace Task3
{
    internal class Player
    {
        public Player()
        {
            CardHand = new();
        }

        public List<Card> CardHand { get; private set; }

        public void DrawCard(DrawPile deck, int numberOfCards = 1)
        {
            for (int i = 0; i < numberOfCards; i++)
            {
                CardHand.Add(deck.DrawCard());
            }
        }

        public void DiscardHand(DiscardPile pile)
        {
            for (int i = 0; i < CardHand.Count; i++)
            {
                pile.AddCard(CardHand[i]);
                CardHand.RemoveAt(i);
            }
        }

        public int SumCards()
        {
            int sum = 0;

            foreach (Card card in CardHand)
            {
                if (card.Value == CardValue.Jack || card.Value == CardValue.Queen || card.Value == CardValue.King)
                {
                    sum += 10;
                } else
                {
                    sum += (int)card.Value;
                }
            }

            return sum;
        }
    }
}
