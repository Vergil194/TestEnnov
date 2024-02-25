using System.Text.Json.Serialization;
using System.Text.Json;
public record CompanyInfoDto(
    string Name,
    string Uid,
    string LegalSeat,
    int RegistryOfCommerceId,
    string SogcDate,
    List<CompanyShortDto> HeadOffices,
    LegalFormDto LegalForm,
    AddressDto Address
)
{
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalData { get; init; }
};
public record CompanyShortDto(
    string Description,
    string Name,
    int Ehraid,
    string Uid,
    string Chid,
    int LegalSeatId,
    string LegalSeat,
    int RegistryOfCommerceId,
    LegalFormDto LegalForm,
    string? Status,
    string SogcDate,
    string DeletionDate
);

public record LegalFormDto(
    int Id,
    string Uid,
    NameDto Name,
    NameDto ShortName
);

public record AddressDto(
    string Organisation,
    string CareOf,
    string Street,
    string HouseNumber,
    string Addon,
    string PoBox,
    string City,
    string SwissZipCode
);

public record NameDto(
    string De,
    string Fr,
    string It,
    string En
);
