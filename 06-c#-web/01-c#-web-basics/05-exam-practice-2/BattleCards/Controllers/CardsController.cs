using System;
using BattleCards.Services;
using SIS.HTTP;
using SIS.MvcFramework;
using BattleCards.Common;
using BattleCards.ViewModels.Cards;
using System.Linq;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardsService cardsService;

        public CardsController(ICardsService cardsService)
        {
            this.cardsService = cardsService;
        }

        public HttpResponse All()
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/");
            }

            var cardsListViewModel = this.cardsService.GetAll();
            return this.View(cardsListViewModel);
        }

        public HttpResponse Collection()
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/");
            }

            var cardsCollectionViewModel = this.cardsService.GetByUserId(this.User);
            return this.View(cardsCollectionViewModel);
        }

        public HttpResponse Add()
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddCardInputModel input)
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/");
            }

            var cardNameIsValid = string.IsNullOrWhiteSpace(input.Name) == false
                && input.Name.Length >= Constants.CardNameMinLength
                && input.Name.Length <= Constants.CardNameMaxLength;
            if (cardNameIsValid == false)
            {
                return this.Error(Messages.WrongLength("Card name", Constants.CardNameMinLength, Constants.CardNameMaxLength));
            }

            if (string.IsNullOrWhiteSpace(input.Image))
            {
                return this.Error(Messages.Invalid("Image URL"));
            }

            if (string.IsNullOrWhiteSpace(input.Keyword))
            {
                return this.Error(Messages.Invalid("Keyword"));
            }

            if (input.Attack < Constants.CardAttackMinValue)
            {
                return this.Error(Messages.LessThanAllowed("Attack", Constants.CardAttackMinValue));
            }

            if (input.Attack < Constants.CardHealthMinValue)
            {
                return this.Error(Messages.LessThanAllowed("Health", Constants.CardHealthMinValue));
            }

            if (string.IsNullOrWhiteSpace(input.Description))
            {
                return this.Error(Messages.Invalid("Description"));
            }

            if (input.Description.Length > Constants.CardDescriptionMaxLength)
            {
                return this.Error(Messages.OverAllowed("Description", Constants.CardDescriptionMaxLength));
            }

            this.cardsService.Create(input);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse AddToCollection(int cardId)
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/");
            }

            this.cardsService.AddCardToUserCollection(this.User, cardId);

            return this.Redirect("/Cards/All");
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (this.IsUserLoggedIn() == false)
            {
                return this.Redirect("/");
            }

            this.cardsService.RemoveCardFromUserCollection(this.User, cardId);

            return this.Redirect("/Cards/Collection");
        }
    }
}