namespace Blackjack;

public class Game {
    private readonly Deck deck;
    private readonly Hand player, dealer;

    public Game(Deck deck) {
        this.deck = deck;
        player = new Hand(deck);
        dealer = new Hand(deck);
    }

    public void Play() {
        const int blackjack = 21, dealerLimit = 16;
        Console.WriteLine("Dealer: " + dealer.Cards[0] + ", ??");
        Console.Write("Player: " + player + " - ");
        while (player.Value < blackjack) {
            Console.Write("Hit? ");
            string response = (Console.ReadLine() ?? "").ToLower();
            if (response.StartsWith('y') || response.StartsWith('h')) {
                player.Hit(deck);
                Console.Write("Player: " + player + " - ");
            } else if (response.StartsWith('n') || response.StartsWith('s')) {
                break;
            }
        }

        if (player.Value == blackjack) {
            if (player.Cards.Count == 2) {
                Console.Write("Blackjack - ");
            }
            Console.WriteLine("Player wins");
        } else if (player.Value > blackjack) {
            Console.WriteLine("Player busts");
        } else {
            while (dealer.Value <= dealerLimit) {
                Console.WriteLine("Dealer: " + dealer + " - Dealer hits");
                dealer.Hit(deck);
            }
            Console.Write("Dealer: " + dealer + " - ");
            if (dealer.Value > blackjack) {
                Console.WriteLine("Dealer busts");
            } else if (dealer.Value > player.Value) {
                Console.WriteLine("Dealer wins");
            } else if (dealer.Value < player.Value) {
                Console.WriteLine("Player wins");
            } else {
                Console.WriteLine("Push");
            }
        }
    }
}