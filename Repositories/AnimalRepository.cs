using AnimalApiCSharp.Data;
using AnimalApiCSharp.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalApiCSharp.Repositories
{
  public class AnimalRepository : IAnimalRepository
  {
    private readonly AnimalContext _context;
    
    public AnimalRepository(AnimalContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Animal>> GetAnimals()
    {
      return await _context.Animals.ToListAsync();
    }

    public async Task<Animal> GetAnimalById(Guid id)
    {
      return await _context.Animals.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Animal> GetAnimalByName(string commonName)
    {
      return await _context.Animals.Where(x => x.CommonName.ToLower() == commonName.ToLower()).FirstOrDefaultAsync();
    }

    public void AddAnimal(Animal animal)
    {
      _context.Add(animal);
    }

    public void EditAnimal(Animal animal)
    {
      _context.Update(animal);
    }

    public void DeleteAnimal(Animal animal)
    {
      _context.Animals.Remove(animal);
    }

    public async Task<bool> SaveChangesAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }
  }
}