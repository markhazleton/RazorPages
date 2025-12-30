using WiredBrainCoffee.Models;

namespace WiredBrainCoffee.Api.Services
{
    public class MenuService : IMenuService
    {
        private static readonly List<MenuItem> _menuItems = new()
        {
            new MenuItem()
            {
                Id = 1,
                Name = "Frosted Pumpkin Bread",
                Slug = "pumpkin-bread",
                ShortDescription = "A seasonal delight we offer every autumn.  Pumpkin bread with just a bit of spice, cream cheese frosting with just a hint of home.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "images/menu/pumpkinbread.png",
                Price = 4,
                Category = "Food"
            },
            new MenuItem()
            {
                Id = 2,
                Name = "Granola with Nuts",
                Slug = "granola",
                ShortDescription = "It's not flashy, but it sure is healthy.  Perfect for when you need the calories, but not the guilt.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "images/menu/granola.png",
                Price = 3,
                Category = "Food"
            },
            new MenuItem()
            {
                Id = 3,
                Name = "Chocolate Chip Cookies",
                Slug = "cookies",
                ShortDescription = "They're made fresh every day, and they taste like it.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "images/menu/cookies.png",
                Price = 2,
                Category = "Food"
            },
            new MenuItem()
            {
                Id = 4,
                Name = "Fresh Bagels",
                Slug = "bagels",
                ShortDescription = "They're just as round as donuts, but far more healthy! Freshly made every morning before sunrise.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "images/menu/bagel.png",
                Price = 5,
                Category = "Food"
            },
            new MenuItem()
            {
                Id = 5,
                Name = "Fresh Fruit",
                Slug = "fresh-fruit",
                ShortDescription = "We've got strawberries, blueberries, apples, bananas - we could list them all, but we'd prefer you come take a look!",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "images/menu/strawberries.png",
                Price = 5,
                Category = "Food"
            },
            new MenuItem()
            {
                Id = 6,
                Name = "Cupcake",
                Slug = "cupcake",
                ShortDescription = "Vanilla cupcakes with the perfect level of sweetness.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "images/menu/cupcake.png",
                Price = 4,
                Category = "Food"
            },
            new MenuItem()
            {
                Id = 7,
                Name = "Muffin",
                Slug = "muffin",
                ShortDescription = "A freshly baked chocolate chip muffin - the perfect way to start a Monday morning.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "images/menu/muffin.png",
                Price = 3,
                Category = "Food"
            },
            new MenuItem()
            {
                Id = 8,
                Name = "Chocolate Bites",
                Slug = "chocolate",
                ShortDescription = "Rich and sweet chocolate bites for those in need of a special treat.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "images/menu/chocolate.png",
                Price = 5,
                Category = "Food"
            },
            new MenuItem()
            {
                Id = 11,
                Name = "Dark Brewed Coffee",
                Slug = "dark-brew",
                ShortDescription = "A classic, refreshing original.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "images/menu/ground.png",
                Price = 2,
                Category = "Coffee"
            },
            new MenuItem()
            {
                Id = 12,
                Name = "Americano",
                Slug = "americano",
                ShortDescription = "Still classic, but a little more sophisticated.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "images/menu/beans.jpg",
                Price = 3.5M,
                Category = "Coffee"
            },
            new MenuItem()
            {
                Id = 13,
                Name = "Latte",
                Slug = "latte",
                ShortDescription = "More than just coffee, but still just coffee.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "images/menu/cappucino.png",
                Price = 3,
                Category = "Coffee"
            },
            new MenuItem()
            {
                Id = 14,
                Name = "Cappuccino",
                Slug = "cappuccino",
                ShortDescription = "Rich and foamy, it's the perfect comfort-coffee.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "images/menu/cup.png",
                Price = 4.5M,
                Category = "Coffee"
            },
            new MenuItem()
            {
                Id = 15,
                Name = "Designer Espresso",
                Slug = "espresso",
                ShortDescription = "Caffeine has never looked so stunning.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "images/menu/design.png",
                Price = 6.5M,
                Category = "Coffee"
            }
        };

        public List<MenuItem> GetMenuItems()
        {
            return _menuItems;
        }

        public MenuItem? GetMenuItemById(int id)
        {
            return _menuItems.FirstOrDefault(m => m.Id == id);
        }

        public MenuItem? GetMenuItemBySlug(string slug)
        {
            return _menuItems.FirstOrDefault(m => m.Slug == slug);
        }

        public List<MenuItem> GetMenuItemsByCategory(string category)
        {
            return _menuItems.Where(m => m.Category?.Equals(category, StringComparison.OrdinalIgnoreCase) == true).ToList();
        }
    }
}
