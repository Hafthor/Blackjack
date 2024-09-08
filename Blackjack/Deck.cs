namespace Blackjack;

public class Deck {
    public List<Card> Cards { get; }

    public Deck(int decks = 1) {
        Array suits = Enum.GetValues(typeof(Suit)), ranks = Enum.GetValues(typeof(Rank));
        Cards = new List<Card>(decks * suits.Length * ranks.Length);
        for (int d = 0; d < decks; d++)
            foreach (Suit suit in suits)
                foreach (Rank rank in ranks)
                    Cards.Add(new Card(suit, rank));
    }

    public void Shuffle(Random rand = null) {
        rand ??= new Random();
        for (int n = Cards.Count - 1; n > 1; n--) {
            int k = rand.Next(n);
            if (k != n)
                (Cards[k], Cards[n]) = (Cards[n], Cards[k]);
        }
    }

    public List<Card> Deal(int count) {
        var hand = Cards.GetRange(Cards.Count - count, count);
        Cards.RemoveRange(Cards.Count - count, count);
        return hand;
    }

    public Card Deal() {
        var card = Cards[^1];
        Cards.RemoveAt(Cards.Count - 1);
        return card;
    }
}