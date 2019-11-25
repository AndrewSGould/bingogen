using System.Collections.Generic;

namespace BingoGen
{
  public class Card
  {
    public int Id { get; set; } // unique card id
    public float Difficulty { get; set; } // the average difficulty of the card
    public string GeneratedBy { get; set; } // this is essentially who the card is 'assigned' to. 
    public List<Prediction> Predictions { get; set; } // list of exactly 25 predictions that the card itself has. pulls these from the board at random
  }
}
