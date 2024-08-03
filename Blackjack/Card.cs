namespace Blackjack;

public class Card {
    public Suit Suit { get; }
    public Rank Rank { get; }
    public int Value { get; }

    public Card(Suit suit, Rank rank) {
        Suit = suit;
        Rank = rank;
        Value = (int)rank > 10 ? 10 : (int)rank;
    }

    public override string ToString() =>
        (Rank is > Rank.Ace and < Rank.Ten ? ((int)Rank).ToString() : Rank.ToString()[..1]) +
        Suit.ToString().ToLower()[0];
}