namespace Blackjack;

public static class Program {
    public static void Main() {
        Random rand = new();
        for (;;) {
            Deck deck = new();
            deck.Shuffle(rand);
            int limit = deck.Cards.Count / 2;
            while (deck.Cards.Count > limit) {
                Game g = new(deck);
                g.Play();
                Console.WriteLine();
            }
            Console.WriteLine("new deck + shuffle");
        }
    }
}