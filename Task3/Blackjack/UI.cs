namespace Task3.Blackjack
{
    internal class UI
    {
        public UI()
        {
            Console.Clear();
        }

        public char PlayerTurnMessage(Player mainPlayer, Player dealer)
        {
            PrintHands(mainPlayer, dealer);
            Console.Write($"Do you want to draw(d) or stay(s)? (d/s): ");

            return GetPlayerResponse();
        }

        public char PrintEndScreen(Player mainPlayer, Player dealer, bool victory)
        {
            PrintHands(mainPlayer, dealer);

            if (victory)
            {
                Console.Write($"YOU WON! :)\tPress y to play again or any other key to quit: ");
            } else
            {
                Console.Write($"You lost... :(\tPress y to play again or any other key to quit: ");
            }

            return GetPlayerResponse();
        }

        private void PrintHands(Player mainPlayer, Player dealer)
        {
            string dealerSum;

            if (dealer.CardHand[0].Hidden)
            {
                dealerSum = "???";
            } else
            {
                dealerSum = dealer.SumCards().ToString();
            }

            Console.Clear();

            Console.Write(
                $"Dealer:\t\t{FormatHand(dealer, true)}\tsum: {dealerSum}\n" +
                $"Player:\t\t{FormatHand(mainPlayer, false)}\tsum: {mainPlayer.SumCards()}\n");
        }

        private string FormatHand(Player player, bool firstCardHidden)
        {
            string cardsFormated = "";

            for (int i = 0; i < player.CardHand.Count; i++)
            {
                if (!player.CardHand[i].Hidden)
                {
                    cardsFormated += $"|{player.CardHand[i].Value} of {player.CardHand[i].Suit}| ";
                } 
                else
                {
                    cardsFormated += "|<Value hidden>| ";
                }
            }

            return cardsFormated;
        }

        private char GetPlayerResponse()
        {
            return Console.ReadKey().KeyChar;
        }
    }
}
