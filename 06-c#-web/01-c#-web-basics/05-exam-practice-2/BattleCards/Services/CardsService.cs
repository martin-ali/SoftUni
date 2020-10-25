using System;
using System.Collections.Generic;
using System.Linq;
using BattleCards.Data;
using BattleCards.Models;
using BattleCards.ViewModels.Cards;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext database;

        public CardsService(ApplicationDbContext database)
        {
            this.database = database;
        }

        public void Create(AddCardInputModel input)
        {
            var card = new Card
            (
                input.Name,
                input.Image,
                input.Keyword,
                input.Attack,
                input.Health,
                input.Description
            );

            this.database.Cards.Add(card);
            this.database.SaveChanges();
        }

        // Wokaround for issue I can't fix
        public CardListViewModel GetByUserId(string userId)
        {
            var cards = this.database.UserCards
                .Where(uc => uc.UserId == userId)
                .Select(uc => new CardViewModel
                {
                    Id = uc.CardId,
                    Name = uc.Card.Name,
                    ImageUrl = uc.Card.ImageUrl,
                    Keyword = uc.Card.Keyword,
                    Attack = uc.Card.Attack,
                    Health = uc.Card.Health,
                    Description = uc.Card.Description
                })
                .ToList();

            var cardsListViewModel = new CardListViewModel { Cards = cards }; ;

            return cardsListViewModel;
        }

        public CardListViewModel GetAll()
        {
            var cards = this.database.Cards
                .Select(c => new CardViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    ImageUrl = c.ImageUrl,
                    Keyword = c.Keyword,
                    Attack = c.Attack,
                    Health = c.Health,
                    Description = c.Description
                })
                .ToList();

            var cardsListViewModel = new CardListViewModel { Cards = cards }; ;

            return cardsListViewModel;
        }

        // public void AddCardToUserCollection(string userId, int cardId)
        // {
        //     var user = this.database.Users.Find(userId);
        //     var card = this.database.Cards.Find(cardId);

        //     if (user.UserCards.Any(uc => uc.CardId == cardId))
        //     {
        //         return;
        //     }

        //     var userCard = new UserCard
        //     {
        //         UserId = userId,
        //         CardId = cardId
        //     };

        //     user.UserCards.Add(userCard);
        //     this.database.SaveChanges();
        // }

        public void AddCardToUserCollection(string userId, int cardId)
        {
            if (this.database.UserCards.Any(x => x.UserId == userId && x.CardId == cardId))
            {
                return;
            }

            this.database.UserCards.Add(new UserCard
            {
                CardId = cardId,
                UserId = userId,
            });

            this.database.SaveChanges();
        }

        // public void RemoveCardFromUserCollection(string userId, int cardId)
        // {
        //     var user = this.database.Users.Find(userId);
        //     var userCard = user.UserCards.FirstOrDefault(uc => uc.CardId == cardId);

        //     this.database.UserCards.Remove(userCard);
        //     this.database.SaveChanges();
        // }

        public void RemoveCardFromUserCollection(string userId, int cardId)
        {
            var userCard = this.database.UserCards.FirstOrDefault(x => x.UserId == userId && x.CardId == cardId);
            if (userCard == null)
            {
                return;
            }

            this.database.UserCards.Remove(userCard);
            this.database.SaveChanges();
        }
    }
}