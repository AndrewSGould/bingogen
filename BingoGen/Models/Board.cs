using System;
using System.Collections.Generic;

namespace BingoGen
{
  public class Board
  {
    public int Id { get; set; } // unique board id
    public string Seed { get; set; } // the seed to share for someone else to generate their card
    public string CreatedBy { get; set; } // this is who initiated the initial board creation / generated the original board seed
    public List<Prediction> Predictions { get; set; } // the pool of predictions to use when generating cards
    public List<Card> Cards { get; set; } // unlimited amount of cards generated from this board
  }
}
