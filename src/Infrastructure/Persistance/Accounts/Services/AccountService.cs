using System.Security.Claims;
using Application.Account.Enums;
using Application.Persistance.Interfaces.Account;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Roles;
using Infrastructure.Persistance.Accounts.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Accounts.Services;

public class AccountService : IAccountService
{
    private readonly OccurrensDbContext _context;
    private readonly UserManager<Account> _userManager;

    public AccountService(OccurrensDbContext context, UserManager<Account> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    
    public async Task<Guid> CreateUserAsync(Account user, string password, EnumRole role, CancellationToken cancellationToken)
    {
        var isEmailExist = await _userManager.Users.AnyAsync(x => x.Email == user.Email, cancellationToken);
        if (isEmailExist) throw new BadRequestException("Wrong email!");

        var createUser = await _userManager.CreateAsync(user, password);
        if (!createUser.Succeeded) throw new CreateUserException(createUser.Errors);

        IdentityResult addUserRole;
        if (role == EnumRole.Doctor)
        {
            addUserRole = await _userManager.AddToRoleAsync(user, UserRoles.Doctor);
        }
        else
        {
            addUserRole = await _userManager.AddToRoleAsync(user, UserRoles.Patient);
        }

        if (!addUserRole.Succeeded) throw new BadRequestException("Add role filed!");

        var addClaim =
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        if (!addClaim.Succeeded) throw new BadRequestException("Add claim failed");

        await _context.SaveChangesAsync(cancellationToken);
        
        return user.Id;
    }
}