using System.Collections.Generic;

namespace BattleCards.ViewModels.Cards
{
    public class CardListViewModel
    {
        public IEnumerable<CardViewModel> Cards { get; set; }
    }
}