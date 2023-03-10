using AutoMapper;
using FinanceApp.Api.Application;
using FinanceApp.Api.Models;
using FinanceApp.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Api.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService,
                          IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> AddAsync(UserViewModel user)
    {
        return Ok(await _userService.AddAsync(_mapper.Map<User>(user)));
    }

    [HttpGet]
    public async Task<ActionResult> FindAllAsync()
    {
        return Ok(await _userService.FindAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult> FindByIdAsync(Guid id)
    {
        return Ok(await _userService.FindByIdAsync(id));
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync(UserViewModel user)
    {
        await _userService.UpdateAsync(_mapper.Map<User>(user));

        return Ok(await _userService.FindByIdAsync(user.Id));
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        return Ok(await _userService.DeleteAsync(id));
    }
}
