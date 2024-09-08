namespace Blackjack;

public class Hand {
    public List<Card> Cards { get; } = [];

    public Hand(Deck deck) => Cards.AddRange(deck.Deal(2));

    public void Hit(Deck deck) => Cards.Add(deck.Deal());

    public int Value {
        get {
            int value = Cards.Sum(c => c.Value);
            if (value + 10 <= 21 && Cards.Any(c => c.Rank == Rank.Ace))
                value += 10;
            return value;
        }
    }

    public override string ToString() => string.Join(", ", Cards);
}