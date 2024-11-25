using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Occurrens.Application.DoctorWorkPlace.Dto;
using Occurrens.Application.DoctorWorkPlace.Extensions;
using Occurrens.Application.Persistance.Interfaces.DoctorWorkPlace;
using Occurrens.Domain.Entities;
using Occurrens.Domain.Exceptions;

namespace Occurrens.Infrastructure.Persistance.DoctorWorkPlace.Services;

public class DoctorWorkPlaceService : IDoctorWorkPlaceService
{
    private readonly OccurrensDbContext _context;
    private readonly UserManager<Account> _userManager;

    public DoctorWorkPlaceService(OccurrensDbContext context, UserManager<Account> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    
    public async Task<Guid> AddDoctorWorkPlace(Domain.Entities.DoctorWorkPlace workPlace, CancellationToken cancellationToken)
    {
        await _context.DoctorWorkPlaces.AddAsync(workPlace, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return workPlace.Id;
    }

    public async Task UpdateDoctorWorkPlace(Domain.Entities.DoctorWorkPlace updatedWorkPlace, Guid idPlaceToUpdate, Guid doctorId, CancellationToken cancellationToken)
    {
        var workPlaceToUpdate = await _context.DoctorWorkPlaces.FindAsync(idPlaceToUpdate, cancellationToken);

        if (workPlaceToUpdate == null || workPlaceToUpdate.AccountId != doctorId)
        {
            throw new BadRequestException("Wybierz poprawne miejsce do edycji!");
        }

        workPlaceToUpdate.Street = updatedWorkPlace.Street;
        workPlaceToUpdate.BuildingNumber = updatedWorkPlace.BuildingNumber;
        workPlaceToUpdate.ApartamentNumber = updatedWorkPlace.ApartamentNumber;
        workPlaceToUpdate.PostalCode = updatedWorkPlace.PostalCode;
        workPlaceToUpdate.City = updatedWorkPlace.City;
        workPlaceToUpdate.SetBaseEntity(doctorId);

        _context.DoctorWorkPlaces.Update(workPlaceToUpdate);
    }

    public async Task DeleteDoctorWorkPlace(Guid workPlaceId, Guid doctorId, CancellationToken cancellationToken)
    {
        var workPlaceToDelete = await _context.DoctorWorkPlaces.FindAsync(workPlaceId, cancellationToken);

        if (workPlaceToDelete == null || workPlaceToDelete.AccountId != doctorId)
        {
            throw new BadRequestException("Wybierz poprawne miejsce do usunięcia!");
        }

        _context.DoctorWorkPlaces.Remove(workPlaceToDelete);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<DisplayDoctorWorkPlaceDto>> GetWorkPlacesForSpecificDoctor(Guid doctorId, CancellationToken cancellationToken)
    {
        var doctorWorkPlaces = await _context.DoctorWorkPlaces.Where(x => x.AccountId == doctorId)
                                                                                .ToListAsync(cancellationToken);

        return doctorWorkPlaces.Select(x => x.DoctorWorkPlaceAsDto()).ToList();
    }
}