namespace AnimalApiCSharp.Models
{
  public class Animal
  {
    public Guid Id { get; set; }
    public string CommonName { get; set; }
    public string GenericName { get; set; }
    public string SpeciesName { get; set; }
    public string? SubspeciesName { get; set; }

  }
}