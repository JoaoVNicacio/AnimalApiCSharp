using AnimalApiCSharp.Models;
using AnimalApiCSharp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AnimalApiCSharp.Controllers
{

  [ApiController]
  [Route("api/v1/Animals")]
  public class AnimalsController : ControllerBase
  {
    private readonly IAnimalRepository _repository;

    public AnimalsController(IAnimalRepository repository)
    {
      _repository = repository;
    }

    // GET:
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var animals = await _repository.GetAnimals();

      return animals.Any() ? Ok(animals) : NoContent();
    }

    // GET by Id:
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
      var animal = await _repository.GetAnimalById(id);
      return animal != null
                       ? Ok(animal)
                       : NotFound("Animal not found!");
    }

    // GET by Common Name:
    [HttpGet("name/{commonName}")]
    public async Task<IActionResult> GetByName(string commonName)
    {
      var animal = await _repository.GetAnimalByName(commonName);
      return animal != null
                       ? Ok(animal)
                       : NotFound("Animal not found!");
    }

    // POST:
    [HttpPost]
    public async Task<IActionResult> Post(Animal animal)
    {
      _repository.AddAnimal(animal);

      return await _repository.SaveChangesAsync()
                                ? Ok($"{animal.CommonName} was added!")
                                : BadRequest("Oops, your request body isn't in the right format.");
    }

    // PUT by Id:
    [HttpPut("id/{id}")]
    public async Task<IActionResult> PutById(Guid id, Animal animal)
    {
      var foundAnimal = await _repository.GetAnimalById(id);

      if (animal == null) return NotFound("Animal not found!");

      foundAnimal.CommonName = animal.CommonName ?? foundAnimal.CommonName;
      foundAnimal.GenericName = animal.GenericName ?? foundAnimal.GenericName;
      foundAnimal.SpeciesName = animal.SpeciesName ?? foundAnimal.SpeciesName;
      foundAnimal.SubspeciesName = animal.SubspeciesName ?? foundAnimal.SubspeciesName;


      _repository.EditAnimal(foundAnimal);

      return await _repository.SaveChangesAsync()
                              ? Ok($"{foundAnimal.CommonName} edited succesfully!")
                              : BadRequest("Bad Request, couldn't edit the animal");
    }

    // PUT by Name
    [HttpPut("name/{commonName}")]
    public async Task<IActionResult> PutByName(string commonName, Animal animal)
    {
      var foundAnimal = await _repository.GetAnimalByName(commonName);

      if (animal == null) return NotFound("Animal not found!");

      foundAnimal.CommonName = animal.CommonName ?? foundAnimal.CommonName;
      foundAnimal.GenericName = animal.GenericName ?? foundAnimal.GenericName;
      foundAnimal.SpeciesName = animal.SpeciesName ?? foundAnimal.SpeciesName;
      foundAnimal.SubspeciesName = animal.SubspeciesName ?? foundAnimal.SubspeciesName;

      _repository.EditAnimal(foundAnimal);

      return await _repository.SaveChangesAsync()
                              ? Ok($"{foundAnimal.CommonName} edited succesfully!")
                              : BadRequest("Bad Request, couldn't edit the Animal");
    }

    // DELETE by Id
    [HttpDelete("id/{id}")]
    public async Task<IActionResult> DeleteById(Guid id)
    {
      var foundAnimal = await _repository.GetAnimalById(id);

      if (foundAnimal == null) return NotFound("Animal not found!");

      _repository.DeleteAnimal(foundAnimal);

      return await _repository.SaveChangesAsync()
                              ? Ok($"{foundAnimal.CommonName} removed succesfully!")
                              : BadRequest("Bad Request, couldn't remove the Animal");
    }

    // DELETE by Common Name:
    [HttpDelete("name/{commonName}")]
    public async Task<IActionResult> DeleteByName(string commonName)
    {
      var foundAnimal = await _repository.GetAnimalByName(commonName);

      if (foundAnimal == null) return NotFound("Animal not found!");

      _repository.DeleteAnimal(foundAnimal);

      return await _repository.SaveChangesAsync()
                              ? Ok($"{foundAnimal.CommonName} removed succesfully!")
                              : BadRequest("Bad Request, couldn't remove the Animal");
    }

  }
}