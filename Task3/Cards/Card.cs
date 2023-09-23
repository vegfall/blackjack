namespace Task3.Cards
{
    internal class Card
    {
        public Card(CardSuit suit, CardValue value, bool hidden = false)
        {
            Suit = suit;
            Value = value;
            Hidden = hidden;
        }

        public CardSuit Suit { get; set; }
        public CardValue Value { get; set; }
        public bool Hidden { get; set; }

        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }
    }
}
