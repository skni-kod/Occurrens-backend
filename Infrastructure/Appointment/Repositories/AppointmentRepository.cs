using Core.Appointment.Repositories;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using occurrensBackend.Entities.DatabaseEntities;

namespace Infrastructure.Appointment.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly OccurrensDbContext _context;

    public AppointmentRepository(OccurrensDbContext context)
    {
        _context = context;
    }

    public async Task<bool> IsDoctorExist(Guid doctorId, CancellationToken cancellationToken)
    {
        return await _context.Doctors.AnyAsync(x => x.Id == doctorId, cancellationToken);
    }

    public async Task MakeAppointmentWithDoctor(Visit visit, CancellationToken cancellationToken)
    {
        await _context.Visits.AddAsync(visit,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}