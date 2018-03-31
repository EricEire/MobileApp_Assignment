using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;

using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace MobileApp_Assignment.DataAccess
{
    class DBstore
    {
        public static string DBLocation
        {
            get;
        }

        static DBstore()
        {
            if (string.IsNullOrEmpty(DBLocation))
            {


                DBLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                                          "BakingApp.db3");

                InitDB();
            }
        }




        public static void InitDB()
        {
            try
            {
                using (SQLiteConnection cxn = new SQLiteConnection(DBLocation))
                {
                    cxn.DropTable<Recipe>();



                    cxn.CreateTable<Recipe>();
                    TableQuery<Recipe> query = cxn.Table<Recipe>();
                    if (query.Count() == 0)
                    {
                        Recipe NutellaBrownies = new Recipe()
                        {
                            RecipeID = 101,

                            RecipeTitle = "Nutella Brownies",

                            RecipeDescription = "Chewy gooey brownies with the delish taste of Nutella!",

                            RecipeIngredients = "75g unbleached all-purpose flour " + "1/4 tsp salt" + "2 Eggs" + "250ml Nutella" + "105g Brown Sugar" + "1 tsp Vanilla Extract" + "125ml melted unsalted butter, cooled",

                            RecipeSteps = "With the rack in the middle position, preheat the oven to 170°C. Line the bottom of an 8-inch (20 cm) square baking pan with parchment paper, letting the paper hang over two sides. Butter the two other sides. " +
                            "In a bowl, combine the flour and salt. Set aside " + "In another bowl, beat the eggs, hazelnut spread, brown sugar and vanilla extract with an electric mixer until smooth, about 2 minutes. With the mixer on low speed, add the flour mixture alternately with the melted butter. " +
                            "Spread the batter into the prepared pan. Bake for 35 to 40 minutes or until a toothpick inserted into the centre comes out with a few lumps and not completely clean. " + "Let cool in the pan for about 2 hours. Unmould and cut into squares " +
                            "Optional: Dust with icing sugar"

                        };

                        Recipe Cookies = new Recipe()
                        {
                            RecipeID = 102,

                            RecipeTitle = "Cookies",

                            RecipeDescription = "Beware of The Cookie Monster",


                            RecipeIngredients = "1 cup (16 tablespoons) unsalted butter, softened to room temperature, 1 cup light brown sugar, 2 teaspoons vanilla extract, 1 teaspoon molasses,1 / 2 cup granulated sugar" +
                            "1 large egg, 1 large egg yolk, 2 1 / 4 cups all - purpose flour, 1 teaspoon salt, 1 teaspoon baking soda,1 cup bittersweet chocolate chips, 1 / 2 cup coarsely chopped pecans,coarse sea salt to sprinkle on top ",

                            RecipeSteps = "Line two baking sheets with parchment paper and set aside. Place half the butter (8 tablespoons) in a medium skillet. Melt the butter over medium heat, swirling it in the pan occasionally. It’ll foam and froth as it cooks, and start to crackle and pop. Once the crackling stops, keep a close eye on the melted butter, continuing to swirl the pan often. The butter will start to smell nutty, and brown bits will form in the bottom. Once the bits are amber brown (about 2 1/2 to 3 minutes or so after the sizzling stops), remove the butter from the burner and immediately pour it into a small bowl, bits and all. This will stop the butter from cooking and burning.  Allow it to cool for 20 minutes. Beat the remaining 1/2 cup butter with the brown sugar for 3 to 5 minutes, until the mixture is very smooth. Beat in the vanilla extract and brown sugar. Pour the cooled brown butter into the bowl, along with the granulated sugar. Beat for 2 minutes, until smooth; the mixture will lighten in color and become fluffy. Add the egg and egg yolk, and beat for one minute more. Add the flour, salt, and baking soda, beating on low speed just until everything is incorporated. Use a spatula to fold in the chocolate chips and pecans and finish incorporating all of the dry flour bits into the dough. Scoop the dough onto a piece of parchment paper, waxed paper, or plastic wrap. Flatten it slightly into a thick disk, and refrigerate for at least 30 minutes. About 15 minutes before you’re ready to begin baking, place racks in the center and upper third of the oven and preheat your oven to 350°F. Scoop the dough in 2 tablespoon-sized balls onto the prepared baking sheets. Leave about 2″ between the cookies; they’ll spread as they bake. Bake the cookies for 12 to 15 minutes, until they’re golden brown. Remove them from the oven, and allow them to rest on the baking sheet for at least 5 minutes before moving them. Optional: Sprinkle with Sea Salt"
                        };

                        // Insert Recipes into the database
                         cxn.Insert(NutellaBrownies);
                        cxn.Insert(Cookies);
                        

                       
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            try
            {
                using (SQLiteConnection cxn = new SQLiteConnection(DBstore.DBLocation))
                {
                    IEnumerable<Recipe> recipes = cxn.Query<Recipe>("SELECT * FROM Recipes");

                    return recipes;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public Recipe GetRecipe_(int RecipeID)
        {
            try
            {
                using (SQLiteConnection cxn = new SQLiteConnection(DBstore.DBLocation))
                {
                    Recipe recipe = cxn.Get<Recipe>(RecipeID);

                    return recipe;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public IEnumerable<Recipe> GetRecipe(int RecipeID)
        {
            try
            {
                using (SQLiteConnection cxn = new SQLiteConnection(DBstore.DBLocation))
                {
                    IEnumerable<Recipe> recipes = cxn.Query<Recipe>("SELECT * FROM Recipe",
                                                                             RecipeID);

                    return recipes;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }//end class
    }//end NS
 