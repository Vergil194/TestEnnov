using Application;
using Application.UseCases.Commands;
using Application.UseCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints
{
    public static class SwissBizInsightEndpoints
    {
        public static void ConfigureEndpoints(this WebApplication app)
        {
            app.MapGet("/companies/Add/{uid}", AddCompanyDetail);
            app.MapGet("/companies", GetAllCompanyList);
            app.MapDelete("/companies/delete/{uid}", DeleteCompany);
        }
        private async static Task<IResult> AddCompanyDetail(IMediator mediator, string uid)
            => HandleResult(await mediator.Send(new GetCompanyByUid.Query { Uid = uid }));
        private async static Task<IResult> GetAllCompanyList(IMediator mediator)
            => HandleResult(await mediator.Send(new GetAllRegisteredCompany.Query { }));

        private async static Task<IResult> DeleteCompany(IMediator mediator, string uid)
            => HandleResult(await mediator.Send(new RemoveCompany.Command { Uid= uid }));

        private static IResult HandleResult<T>(Result<T> result)
        {
            if (result == null) return Results.NotFound();

            if (result.IsSuccess && result.Value != null)
                return Results.Ok(result.Value);

            if (result.IsSuccess && result.Value == null)
                return Results.NotFound();

            return Results.BadRequest();
            /*var json = JsonConvert.DeserializeObject<ApiCallProblem>(result.Error.ToString());
            return StatusCode(json.ErrorDetails.Status, json);*/
        }
    }
}
