using AutoMapper;
using FinanceApp.Api.Application;
using FinanceApp.Api.Models;
using FinanceApp.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Api.Controllers;

[ApiController]
[Route("api/v1/categories")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryService categoryService,
                              IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync(CategoryViewModel category)
    {
        return Ok(await _categoryService.AddAsync(_mapper.Map<Category>(category)));
    }

    [HttpGet]
    public async Task<ActionResult> FindAllAsync()
    {
        return Ok(await _categoryService.FindAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> FindByIdAsync(Guid id)
    {
        return Ok(await _categoryService.FindByIdAsync(id));
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync(CategoryViewModel category)
    {
        await _categoryService.UpdateAsync(_mapper.Map<Category>(category));

        return Ok(await _categoryService.FindByIdAsync(category.Id));
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        return Ok(await _categoryService.DeleteAsync(id));
    }
}
