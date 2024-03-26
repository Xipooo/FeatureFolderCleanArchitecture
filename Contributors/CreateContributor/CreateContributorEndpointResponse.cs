namespace Clean.Architecture.Contributors.Domain.CreateContributor;

public class CreateContributorEndpointResponse(int id, string name)
{
  public int Id { get; set; } = id;
  public string Name { get; set; } = name;
}
