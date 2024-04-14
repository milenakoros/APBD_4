using Microsoft.AspNetCore.Mvc;

namespace Klinika;

[ApiController]
[Route("[controller]")]
public class AnimalsController : ControllerBase
{
    // GET: api/Animals
    [HttpGet]
    public ActionResult<IEnumerable<Animal>> GetAnimals()
    {
        return DataStore.Animals;
    }

    // GET: api/Animals/5
    [HttpGet("{id}")]
    public ActionResult<Animal> GetAnimal(int id)
    {
        var animal = DataStore.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }
        return animal;
    }

    // POST: api/Animals
    [HttpPost]
    public ActionResult<Animal> PostAnimal(Animal animal)
    {
        DataStore.Animals.Add(animal);
        return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
    }

    // PUT: api/Animals/5
    [HttpPut("{id}")]
    public IActionResult PutAnimal(int id, Animal animal)
    {
        if (id != animal.Id)
        {
            return BadRequest();
        }

        var existingAnimal = DataStore.Animals.FirstOrDefault(a => a.Id == id);
        if (existingAnimal == null)
        {
            return NotFound();
        }

        existingAnimal.Name = animal.Name;
        existingAnimal.Category = animal.Category;
        existingAnimal.Weight = animal.Weight;
        existingAnimal.FurColor = animal.FurColor;

        return NoContent();
    }

    // DELETE: api/Animals/5
    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = DataStore.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }

        DataStore.Animals.Remove(animal);

        return NoContent();
    }
}

