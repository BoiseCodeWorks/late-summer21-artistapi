using System.ComponentModel.DataAnnotations;

namespace artistapi.Models
{
  public class Artist
  {
    // this can be removed later
    public int Id { get; set; }
    public string Name { get; set; }
    [Required]
    public int BirthYear { get; set; }
    private bool _deceased;
    // Creates a flag to identify if the value of a bool was changed during creation [FromBody]
    internal bool DeceasedWasSet { get; private set; }
    public bool Deceased
    {
      get
      {
        return _deceased;
      }
      set
      {
        _deceased = value;
        DeceasedWasSet = true;
      }
    }
  }
}