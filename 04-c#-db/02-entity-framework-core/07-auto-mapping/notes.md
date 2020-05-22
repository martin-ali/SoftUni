# Auto-mapping

## Information

- DTO(Data Transfer Object) a.k.a ViewModel
    - Remove unnecessary stuff
    - Reduce network traffic
    - Remove circular references(important to not break serialization)
    - Flatten object
- Result view
- UI should not directly communicate with DB(use service layer)
- Automapper
    - Use instance version
    - v8 deprecates the static version
    - v9 removes static version
- Automapper.Collection
    - Creates deep copy
- Exceptions are thrown
 - When mapping DTO -> Model
 - Not when mapping Model -> DTO (default values are used)
 - Inheritance mapping

## Functionality

- Additional package at ~1:20
- Mapper
    - Initialize()
        - CreateMap()
        - ForMember()
                - MapFrom()
        - ReverseMap()
        - EqualityComparison<BookDTO, Book>()
    - Map()
- context.Posts.ProjectTo<PostDTO>();
    - Uses IQueryable like EF
    - Only selects necessary properties

## Example

```c#
Mapper.Initialize(configuration=>
{
    configuration
    .CreateMap<Book, BookDTO>()
    .ForMember
    (
        destination => destination.Name,
        options => options.MapFrom(src => src.Title)
    )
    .ReverseMap()
})

var bookModel = new Book();
var bookDto = Mapper.Map<BookDTO>(bookModel);
```
