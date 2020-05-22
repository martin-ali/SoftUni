namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    using Data;
    using ViewModels.Orders;
    using FastFood.Models;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;

    public class OrdersController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public OrdersController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            var viewOrder = new CreateOrderViewModel
            {
                Items = this.context.Items
                        .ProjectTo<CreateOrderItemViewModel>(this.mapper.ConfigurationProvider)
                        .ToList(),
                Employees = this.context.Employees
                            .ProjectTo<CreateOrderEmployeeViewModel>(this.mapper.ConfigurationProvider)
                            .ToList(),
            };

            return this.View(viewOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction(nameof(HomeController.Error), "Home");
            }

            // Hacky way of doing stuff
            var order = this.mapper.Map<Order>(model);
            var orderItem = this.mapper.Map<OrderItem>(model);

            order.OrderItems = new List<OrderItem>();
            order.OrderItems.Add(orderItem);

            this.context.Orders.Add(order);

            this.context.SaveChanges();

            return this.RedirectToAction(nameof(OrdersController.All), "Orders");
        }

        public IActionResult All()
        {
            var orders = this.context.Orders
                            .ProjectTo<OrderAllViewModel>(this.mapper.ConfigurationProvider)
                            .ToList();

            return this.View(orders);
        }
    }
}
