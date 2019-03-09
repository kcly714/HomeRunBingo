using HomeRunBingo.Models.Domain;
using HomeRunBingo.Models.Requests;
using System.Collections.Generic;

namespace HomeRunBingo.Services
{
    public interface IBingoService
    {
        BingoCardDomain GetCardById(int id);
        BingoCardDomain SelectByUserId(int UserId);
        int CreateBingoCard(BingoCardDomain BingoCardmodel);
    }
}
