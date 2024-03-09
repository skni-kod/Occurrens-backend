using Core.DoctorInformations.DTOS;
using Core.DoctorInformations.Extensions;
using Core.DoctorInformations.Repositories;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using occurrensBackend.Entities.DatabaseEntities;

namespace Infrastructure.DoctorInformations.Repositories;

public class DoctorInfoRepository : IDoctorInfoRepository
{
    private readonly OccurrensDbContext _context;

    public DoctorInfoRepository(OccurrensDbContext context)
    {
        _context = context; 
    }
    
    public async Task SetSpecialization(Specialization specialization, CancellationToken cancellationToken)
    {
        await _context.AddAsync(specialization, cancellationToken);
        await _context.SaveChangesAsync(); 
    }

    public async Task SetAddress(Address address, CancellationToken cancellationToken)
    {
        await _context.Addresses.AddAsync(address, cancellationToken); 
        await _context.SaveChangesAsync();
    }

    public async Task<AddressDto> GetAddress(Guid addressId, CancellationToken cancellationToken)
    {
        var address = await _context.Addresses.FindAsync(addressId, cancellationToken);
        
        if (address is null)
        {
            return null; 
        }

        return address.AddressAsDto();
    }

    public async Task<bool> IsOpenedDataExists(Guid id, CancellationToken cancellationToken)
    {
        return await _context.IsOpeneds.AnyAsync(x => x.AddressId == id, cancellationToken); 
    }

    public async Task CreateOpenedInfo(Is_opened isOpened, CancellationToken cancellationToken)
    {
        await _context.IsOpeneds.AddAsync(isOpened, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken); 
    }

    public async Task<bool> UpdateSpecialization(Guid userId, Guid specializationId,string newSpecialization ,CancellationToken cancellationToken)
    {
        var result = await _context.Specializations.FindAsync(specializationId, cancellationToken);

        if (result != null && result.DoctorId == userId) 
        {
            result.Specjalization = newSpecialization;
            
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        return false;
    }

    public async Task<bool> UpdateOfficeInfo(ToUpdateOfficeDto dto, Guid userId, Guid officeId, CancellationToken cancellationToken)
    {
        var address = await _context.Addresses
            .FirstOrDefaultAsync(address => address.Id == officeId && address.DoctorId == userId, cancellationToken);
 
        if (address == null) return false;

        address.Street = dto.Street ?? address.Street;
        if (dto.BuildingNumber != 0) address.Building_number = (int)dto.BuildingNumber;
        if (dto.ApartamentNumber != 0) address.Apartament_number = (int)dto.ApartamentNumber;
        address.Postal_code = dto.PostalCode ?? address.Postal_code;

        await _context.SaveChangesAsync(cancellationToken);

        var openedData = await _context.IsOpeneds.FirstOrDefaultAsync(x => x.AddressId == address.Id, cancellationToken);

        if (openedData != null)
        {
            openedData.Monday = dto.Monday ?? openedData.Monday;
            openedData.Tuesday = dto.Tuesday ?? openedData.Tuesday;
            openedData.Wednesday = dto.Wednesday ?? openedData.Wednesday;
            openedData.Thursday = dto.Thursday ?? openedData.Thursday; 
            openedData.Fridady = dto.Fridady ?? openedData.Fridady;
            openedData.Saturday = dto.Saturday ?? openedData.Saturday;
            openedData.Sunday = dto.Sunday ?? openedData.Sunday;
        }

        await _context.SaveChangesAsync(cancellationToken);
        
        return true;
    }

    public async Task<bool> DaleteSpecialization(Guid id, Guid doctorId, CancellationToken cancellationToken)
    {
        var result = await _context.Specializations.FindAsync(id, cancellationToken);

        if (result == null || result.DoctorId != doctorId) return false;

        _context.Specializations.Remove(result);
        await _context.SaveChangesAsync(cancellationToken); 

        return true;
    }

    public async Task<bool> DeteleOfiice(Guid id, Guid userId, CancellationToken cancellationToken)
    {
        var office = await _context.Addresses.FindAsync(id, cancellationToken);

        if (office == null || office.DoctorId != userId) return false; 

        _context.Remove(office);

        var openedInfo = await _context.IsOpeneds.FirstOrDefaultAsync(x => x.AddressId == id, cancellationToken);

        if (openedInfo != null) _context.Remove(openedInfo);

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<GetSelfInfoDto?> GetSelfInfo(Guid userId, CancellationToken cancellationToken)
    {
        var doctor = await _context.Doctors
            .Include(x => x.spetializations)
            .Include(x => x.addresses) 
            .ThenInclude(x => x.is_opened)
            .SingleOrDefaultAsync(x => x.Id == userId, cancellationToken);
        
        if (doctor == null)
        {
            return null;
        }
        
        var selfInfoDto = doctor.SelfInfoAsDto();
        return selfInfoDto;
    }

}