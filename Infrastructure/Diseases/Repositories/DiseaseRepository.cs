using Core.Diseases.DTOS;
using Core.Diseases.Extensions;
using Core.Diseases.Repositories;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using occurrensBackend.Entities.DatabaseEntities;

namespace Infrastructure.Diseases.Repositories;

public class DiseaseRepository : IDiseaseRepository
{
    private readonly OccurrensDbContext _context;

    public DiseaseRepository(OccurrensDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> AddDisease(Guid userId, Disease disease, CancellationToken cancellationToken)
    {
        var isPatientExist = await _context.Patients.FindAsync(disease.PatientId, cancellationToken);

        if (isPatientExist is null) return false;

        await _context.Diseases.AddAsync(disease, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async  Task<bool> UpdateDisease(Guid userId, Guid diseaseId, ToUpdateDiseaseDto dto, CancellationToken cancellationToken)
    {
        var disease = await _context.Diseases.FindAsync(diseaseId, cancellationToken);

        if (disease is null || disease.CreatedByDoctor != userId) return false;

        disease.Name = dto.Name ?? disease.Name;
        disease.Description = dto.Description ?? disease.Description;
        disease.Medicines = dto.Medicines ?? disease.Medicines;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> DeleteDisease(Guid doctorId, Guid diseaseId, CancellationToken cancellationToken)
    {
        var result = await _context.Diseases.FindAsync(diseaseId, cancellationToken);

        if (result is null || result.CreatedByDoctor != doctorId) return false;

        _context.Diseases.Remove(result);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<GetPatientDiseasesDto>> GetPatientDiseases(Guid patientId, CancellationToken cancellationToken)
    {
        var result = await _context.Diseases.Where(x => x.PatientId == patientId).ToListAsync(cancellationToken);

        if (result == null) return null;

        var resultAsDto = result.Select(x => x.PatientDiseasesAsDto()).ToList();

        return resultAsDto;
    }
}