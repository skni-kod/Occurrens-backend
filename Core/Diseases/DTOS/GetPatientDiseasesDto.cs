namespace Core.Diseases.DTOS;

public class GetPatientDiseasesDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Medicines { get; set; }
    public DateOnly Date { get; set; }
}