using HomeRunBingo.Models.Domain;
using HomeRunBingo.Models.Requests;

namespace HomeRunBingo.Services
{
    public interface IBingoService
    {
        string GetCardById(int id);
    }
}
