namespace Blackjack;

public class Game {
    private readonly Deck _deck;
    private readonly Hand _player, _dealer;

    public Game(Deck deck) {
        _deck = deck;
        _player = new Hand(deck);
        _dealer = new Hand(deck);
    }

    public void Play() {
        const int blackjack = 21, dealerLimit = 16;
        Console.WriteLine("Dealer: " + _dealer.Cards[0] + ", ??");
        Console.Write("Player: " + _player + " - ");
        while (_player.Value < blackjack) {
            Console.Write("Hit? ");
            string response = (Console.ReadLine() ?? "").ToLower();
            if (response.StartsWith('y') || response.StartsWith('h')) {
                _player.Hit(_deck);
                Console.Write("Player: " + _player + " - ");
            } else if (response.StartsWith('n') || response.StartsWith('s'))
                break;
        }

        if (_player.Value == blackjack) {
            if (_player.Cards.Count == 2)
                Console.Write("Blackjack - ");
            Console.WriteLine("Player wins");
        } else if (_player.Value > blackjack)
            Console.WriteLine("Player busts");
        else {
            while (_dealer.Value <= dealerLimit) {
                Console.WriteLine("Dealer: " + _dealer + " - Dealer hits");
                _dealer.Hit(_deck);
            }
            Console.Write("Dealer: " + _dealer + " - ");
            if (_dealer.Value > blackjack)
                Console.WriteLine("Dealer busts");
            else if (_dealer.Value > _player.Value)
                Console.WriteLine("Dealer wins");
            else if (_dealer.Value < _player.Value)
                Console.WriteLine("Player wins");
            else
                Console.WriteLine("Push");
        }
    }
}