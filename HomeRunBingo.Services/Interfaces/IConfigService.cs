using HomeRunBingo.Models.Domain;

namespace HomeRunBingo.Services
{
    public interface IConfigService
    {
        ConfigDomain SelectById(int Id);
    }
}
