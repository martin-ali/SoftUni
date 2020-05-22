namespace FastFood.Web.MappingConfiguration
{
    using AutoMapper;
    using Models;

    using ViewModels.Positions;
    using ViewModels.Employees;
    using ViewModels.Orders;
    using ViewModels.Categories;
    using ViewModels.Items;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionId, y => y.MapFrom(s => s.Id))
                .ForMember(x => x.PositionName, y => y.MapFrom(s => s.Name));

            // Categories
            this.CreateMap<Category, CategoryAllViewModel>();

            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));

            // Employees
            this.CreateMap<RegisterEmployeeInputModel, Employee>();

            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(x => x.Position, y => y.MapFrom(s => s.Position.Name));

            // Items
            this.CreateMap<CreateItemInputModel, Item>();

            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(s => s.Id))
                .ForMember(x => x.CategoryName, y => y.MapFrom(s => s.Name));

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x => x.Category, y => y.MapFrom(s => s.Category.Name));

            // Orders
            this.CreateMap<CreateOrderInputModel, Order>();

            this.CreateMap<CreateOrderInputModel, OrderItem>();

            this.CreateMap<Item, CreateOrderItemViewModel>();

            this.CreateMap<Employee, CreateOrderEmployeeViewModel>();

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(x => x.OrderId, y => y.MapFrom(s => s.Id))
                .ForMember(x => x.Employee, y => y.MapFrom(s => s.Employee.Name));
        }
    }
}
