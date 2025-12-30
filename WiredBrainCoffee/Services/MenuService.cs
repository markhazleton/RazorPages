using WiredBrainCoffee.Models;

namespace WiredBrainCoffee.Services
{
    public class MenuService : IMenuService
    {
        public List<MenuItem> GetMenuItems()
        {
            return new List<MenuItem>()
            {
                new MenuItem()
                {
                    Id = 1,
                    Slug = "pumpkin-bread",
                    Name = "Frosted Pumpkin Bread",
                    ShortDescription =
                    "A seasonal delight we offer every autumn.  Pumpking bread with just a bit of spice, cream cheese frosting with just a hint of home.",
                    Description =
                    "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "pumpkinbread.png",
                    Price = 4,
                    Category = "Food"
                },
                new MenuItem()
                {
                    Id = 2,
                    Slug = "ground-coffee",
                    Name = "Ground to Go",
                    ShortDescription = "Love our coffee? Take it with you so you never have to be without!",
                    Description =
                    "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "ground.png",
                    Price = 8,
                    Category = "Coffee"
                },
                new MenuItem()
                {
                    Id = 3,
                    Slug = "granola",
                    Name = "Granola with Nuts",
                    ShortDescription =
                    "It's not flashy, but it sure is healthy.  Perfect for when you need the calories, but not the guilt.",
                    Description =
                    "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "granola.png",
                    Price = 3,
                    Category = "Food"
                },
                new MenuItem()
                {
                    Id = 4,
                    Slug = "coffee-beans",
                    Name = "Bean there, done that!",
                    ShortDescription = "Do you prefer to grind your own coffee? No problem, we'll give you the beans.",
                    Description =
                    "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "beans.jpg",
                    Price = 10,
                    Category = "Coffee"
                },
                new MenuItem()
                {
                    Id = 5,
                    Slug = "bagels",
                    Name = "Fresh Bagels",
                    ShortDescription =
                    "They're just as round as donuts, but far more healthy! Freshly made every morning before sunrise.",
                    Description =
                    "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "bagel.png",
                    Price = 5,
                    Category = "Food"
                },
                new MenuItem()
                {
                    Id = 6,
                    Slug = "fresh-fruit",
                    Name = "Fresh Fruit",
                    ShortDescription =
                    "We've got strawberries, blueberries, apples, bananas - we could list them all, but we'd prefer you come take a look!",
                    Description =
                    "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "strawberries.png",
                    Price = 4,
                    Category = "Food"
                }
            };
        }
    }
}