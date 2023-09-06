using AnimalApiCSharp.Models;

namespace AnimalApiCSharp.Repositories
{
  public interface IAnimalRepository
  {
    Task<IEnumerable<Animal>> GetAnimals(int pageIndex, int pageSize);
    Task<Animal> GetAnimalById(Guid id);
    Task<Animal> GetAnimalByName(string commonName);
    void AddAnimal(Animal animal);
    void EditAnimal(Animal animal);
    void DeleteAnimal(Animal animal);
    Task<bool> SaveChangesAsync();
  }
}