using FluentValidation;

namespace AnimalApiCSharp.Models
{
  public class AnimalValidator : AbstractValidator<Animal>
  {
    public AnimalValidator()
    {
      RuleFor(x => x.CommonName)
        .NotEmpty()
        .WithMessage("You should enter a valid name for your animal")
        .NotNull()
        .WithMessage("Your animal common name shouldn't be null");

      RuleFor(x => x.GenericName)
        .NotEmpty()
        .WithMessage("You should enter a valid genus name for your animal")
        .NotNull()
        .WithMessage("Your animal genus name shouldn't be null")
        .Must(word => String.IsNullOrEmpty(word) ? true : word.Substring(0, 1).ToUpper() == word.Substring(0, 1))
        .WithMessage("The first letter of a Genus name should be in uppercase!");

      RuleFor(x => x.SpeciesName)
        .NotNull()
        .WithMessage("Your animal species name shouldn't be null")
        .NotEmpty()
        .WithMessage("You should enter a valid species name for your animal")
        .Must(word => String.IsNullOrEmpty(word) ? true : word.Substring(0, 1).ToUpper() == word.Substring(0, 1))
        .WithMessage("The first letter of a Species name should be in uppercase!");

      RuleFor(x => x.SubspeciesName)
        .Must(word => String.IsNullOrEmpty(word) ? true : word.Substring(0, 1).ToUpper() == word.Substring(0, 1))
        .WithMessage("The first letter of a Subpecies name should be in uppercase!");
    }
  }
}
