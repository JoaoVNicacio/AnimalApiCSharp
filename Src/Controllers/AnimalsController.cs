using AnimalApiCSharp.Models;
using AnimalApiCSharp.Repositories;
using AnimalApiCSharp.Tools;
using Microsoft.AspNetCore.Mvc;

namespace AnimalApiCSharp.Controllers
{
  [ApiController]
  [Route("api/v1/animals")]
  public class AnimalsController : ControllerBase
  {
    private readonly IAnimalRepository _repository;

    public AnimalsController(IAnimalRepository repository)
    {
      _repository = repository;
    }

    // GET:
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(PagedResults<Animal>))]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Get(int pageIndex, int pageSize)
    {
      var animals = await _repository.GetAnimals(pageIndex, pageSize);

      bool hasNextPage = (await _repository.GetAnimals(pageIndex + 1, pageSize)).Any();

      return Ok(new PagedResults<Animal>(animals, hasNextPage, pageIndex, pageSize));
    }

    // GET by Id:
    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(Animal))]
    [ProducesResponseType(404, Type = typeof(string))]
    public async Task<IActionResult> GetById(Guid id)
    {
      var animal = await _repository.GetAnimalById(id);
      
      return animal != null ? Ok(animal)
                            : NotFound("Animal not found!");
    }

    // GET by Common Name:
    [HttpGet("name/{commonName}")]
    [ProducesResponseType(200, Type = typeof(Animal))]
    [ProducesResponseType(404, Type = typeof(string))]
    public async Task<IActionResult> GetByName(string commonName)
    {
      var animal = await _repository.GetAnimalByName(commonName);

      return animal != null ? Ok(animal)
                            : NotFound("Animal not found!");
    }

    // POST:
    [HttpPost]
    [ProducesResponseType(201, Type = typeof(string))]
    [ProducesResponseType(400, Type = typeof(string))]
    public async Task<IActionResult> Post(Animal animal)
    {
      _repository.AddAnimal(animal);

      return await _repository.SaveChangesAsync()
                              ? Created($"{animal.CommonName} was added!", animal)
                              : BadRequest("Oops, your request body isn't in the right format.");
    }

    // PUT by Id:
    [HttpPut("{id}")]
    [ProducesResponseType(200, Type = typeof(string))]
    [ProducesResponseType(400, Type = typeof(string))]
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
    [HttpDelete("{id}")]
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