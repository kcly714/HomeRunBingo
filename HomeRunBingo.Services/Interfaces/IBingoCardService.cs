using HomeRunBingo.Models.Domain;
using HomeRunBingo.Models.Requests;
using System.Collections.Generic;

namespace HomeRunBingo.Services
{
    public interface IBingoCardService
    {
        //BingoCardDomain GetCardById(int id);
        List<BingoCardDomain> SelectByUserId(int UserId);
        int CreateBingoCard(BingoCardDomain BingoCardmodel);
    }
}
