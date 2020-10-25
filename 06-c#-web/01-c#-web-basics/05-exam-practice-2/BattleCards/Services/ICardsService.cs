using System.Collections.Generic;
using BattleCards.ViewModels.Cards;

namespace BattleCards.Services
{
    public interface ICardsService
    {
        void Create(AddCardInputModel input);

        void AddCardToUserCollection(string userId, int cardId);

        void RemoveCardFromUserCollection(string userId, int cardId);

        public CardListViewModel GetByUserId(string userId);

        public CardListViewModel GetAll();
    }
}