namespace Task3.Cards
{
    internal class DrawPile
    {
        public DrawPile()
        {
            Cards = new();
            FillDeck();
        }

        public List<Card> Cards { get; private set; }

        private void FillDeck()
        {
            for (int s = 0; s < Enum.GetNames(typeof(CardSuit)).Length; s++)
            {
                for (int v = 1; v < Enum.GetNames(typeof(CardValue)).Length; v++)
                {
                    Cards.Add(new((CardSuit)s, (CardValue)v));
                }
            }
        }

        public Card DrawCard()
        {
            Random random = new();
            int cardIndex = random.Next(Cards.Count);
            Card drawnCard = Cards[cardIndex];

            Cards.Remove(drawnCard);

            return drawnCard;
        }
    }
}
