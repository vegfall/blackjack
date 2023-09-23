using Task3.Cards;

namespace Task3.Blackjack
{
    internal class BlackjackApp
    {
        private Player mainPlayer;
        private Player dealer;
        private DrawPile drawPile;
        private DiscardPile discardPile;
        private UI ui;

        public void Start()
        {
            mainPlayer = new();
            dealer = new();
            drawPile = new();
            discardPile = new();
            ui = new();

            DrawStartHand();
            HideFirstCard(true);
            PlayerTurn();
        }

        private void PlayerTurn()
        {
            char playerResponse;
            
            playerResponse = ui.PlayerTurnMessage(mainPlayer, dealer);

            if (playerResponse == 'd')
            {
                mainPlayer.DrawCard(drawPile, 1);
            }

            if (CheckForOver21(mainPlayer) || playerResponse == 's')
            {
                HideFirstCard(false);
                DealerTurn();
            }
            else
            {
                PlayerTurn();
            }
        }

        private void DealerTurn()
        {
            if (dealer.SumCards() >= mainPlayer.SumCards() || CheckForOver21(mainPlayer))
            {
                End();
            } else
            {
                dealer.DrawCard(drawPile, 1);
                DealerTurn();
            }
        }

        private void End()
        {
            char playerResponse;

            if (CheckForOver21(dealer))
            {
                playerResponse = ui.PrintEndScreen(mainPlayer, dealer, true);
            } else
            {
                playerResponse = ui.PrintEndScreen(mainPlayer, dealer, false);
            }

            if (playerResponse == 'y')
            {
                Start();
            }
        }

        private void DrawStartHand()
        {
            mainPlayer.DrawCard(drawPile, 2);
            dealer.DrawCard(drawPile, 2);
        }

        private void HideFirstCard(bool hide)
        {
            dealer.CardHand[0].Hidden = hide;
        }

        private bool CheckForOver21(Player player)
        {
            bool overflow = false;

            if (player.SumCards() > 21)
            {
                overflow = true;
            }

            return overflow;
        }
    }
}