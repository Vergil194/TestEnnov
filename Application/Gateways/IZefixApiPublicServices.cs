using Application.DTOs;

namespace Application.Gateways
{
    public interface IZefixApiPublicServices
    {
        Task<IEnumerable<CompanyInfoDto>?> GetCompanyByUid(string Uid);
        Task<IEnumerable<RegistryOfCommerceDTo>> GetRegistryOfCommerce();
    }

}
