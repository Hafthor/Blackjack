namespace Blackjack;

public class Card(Suit suit, Rank rank) {
    public Suit Suit { get; } = suit;
    public Rank Rank { get; } = rank;
    public int Value { get; } = (int)rank > 10 ? 10 : (int)rank;

    public override string ToString() =>
        (Rank is > Rank.Ace and < Rank.Ten ? ((int)Rank).ToString() : Rank.ToString()[..1]) +
        Suit.ToString().ToLower()[0];
}