namespace Domain.DTOs.Dossiers.CreateDossier;

public class CreateDossierResponse
{
    public int DossierId { get; private set; }

    public CreateDossierResponse(int dossierId)
    {
        DossierId = dossierId;
    }
}