using Microsoft.VisualBasic.Devices;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;

namespace louqman_ali_183
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
// Model class for a simple entity
public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    // Add other properties as needed
}
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly List<Item> _items = new List<Item>(); // Simulated in-memory database

    [HttpGet]
    public ActionResult<IEnumerable<Item>> Get()
    {
        return _items;
    }

    [HttpGet("{id}")]
    public ActionResult<Item> Get(int id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        if (item == null)
        {
            return NotFound();
        }
        return item;
    }

    [HttpPost]
    public ActionResult<Item> Post(Item item)
    {
        _items.Add(item);
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Item item)
    {
        var existingItem = _items.FirstOrDefault(i => i.Id == id);
        if (existingItem == null)
        {
            return NotFound();
        }
        existingItem.Name = item.Name;
        existingItem.Price = item.Price;
        // Update other properties as needed
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        if (item == null)
        {
            return NotFound();
        }
        _items.Remove(item);
        return NoContent();
    }
}
@page "/courses"

<h3>Courses</h3>

@if (courses != null)
{
    < table class= "table" >
        < thead >
            < tr >
                < th > Title </ th >
                < th > Description </ th >
                < !--Add other columns here -->
            </tr>
        </thead>
        <tbody>
            @foreach (var course in courses)
            {
                < tr >
                    < td > @course.Title </ td >
                    < td > @course.Description </ td >
                    < !--Display other properties -->
                </ tr >
            }
        </ tbody >
    </ table >
}
else
{
    < p > Loading...</ p >
}

@code {
    private List<Course> courses;

protected override async Task OnInitializedAsync()
{
    // Fetch courses from API and assign to 'courses'
    // You'd need to make HTTP requests to your LMS API here
    // Example:
    // courses = await httpClient.GetFromJsonAsync<List<Course>>("https://yourapi.com/api/courses");
}
}
