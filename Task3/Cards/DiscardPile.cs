namespace Task3.Cards
{
    internal class DiscardPile
    {
        public List<Card> Cards { get; private set; }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }
    }
}
