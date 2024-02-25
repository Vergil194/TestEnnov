namespace Application.DTOs;

public record RegistryOfCommerceDTo
{
    public int RegistryOfCommerceId { get; init; }
    public string Canton { get; init; }
    public string Address1 { get; init; }
    public string Address2 { get; init; }
    public string Address3 { get; init; }
    public string Address4 { get; init; }
    public string Homepage { get; init; }
    public string Url2 { get; init; }
    public string Url3 { get; init; }
    public string Url4 { get; init; }
    public string Url5 { get; init; }
}
