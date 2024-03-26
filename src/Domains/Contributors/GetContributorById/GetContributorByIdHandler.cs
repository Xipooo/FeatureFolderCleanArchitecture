using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.Contributors.Domain.GetContributorById;

/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetContributorByIdHandler(IReadRepository<Contributor> _repository)
  : IQueryHandler<GetContributorByIdQuery, Result<ContributorDTO>>
{
  public async Task<Result<ContributorDTO>> Handle(GetContributorByIdQuery request, CancellationToken cancellationToken)
  {
    var spec = new GetContributorByIdSpec(request.ContributorId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new ContributorDTO(entity.Id, entity.Name, entity.PhoneNumber?.Number ?? "");
  }
}
