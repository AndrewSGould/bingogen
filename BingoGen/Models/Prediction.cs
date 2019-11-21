namespace BingoGen
{
  public class Prediction
  {
    public int Id { get; set; } // unique prediction id
    public string PredictionText { get; set; } // the words along with the prediction, not required/nullable
    public int Difficulty { get; set; } // The higher the number, the harder it is
    public string ImageUri { get; set; } // required
    public string CreatedBy { get; set; } // No sign-in, so should this just be original author and those invited?
    //TODO: Something to consider. When guests add predictions, should it weigh those more heavily when generating the card?
  }
}
