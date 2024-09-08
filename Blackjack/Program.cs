namespace Blackjack;

public static class Program {
    public static void Main() {
        for (Random rand = new();;) {
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