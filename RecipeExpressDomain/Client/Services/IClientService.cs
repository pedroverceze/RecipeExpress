using c = RecipeExpressDomain.Client.Entities;

namespace RecipeExpressDomain.Client.Services
{
    public interface IClientService
    {
        void EnrollClient(c.Client client);
    }
}