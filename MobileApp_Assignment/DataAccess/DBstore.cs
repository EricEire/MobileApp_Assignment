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

                            RecipeIngredients = "75g unbleached all-purpose flour " + "\n1/4 tsp salt" + "\n2 Eggs" + "\n250ml Nutella" + "\n105g Brown Sugar" + "\n1 tsp Vanilla Extract" + "\n125ml melted unsalted butter, cooled",

                            RecipeSteps = "\t\u2022With the rack in the middle position, preheat the oven to 170°C. \n\t\u2022Line the bottom of an 8-inch (20 cm) square baking pan with parchment paper, letting the paper hang over two sides. Butter the two other sides. " +
                            "\n\t\u2022In a bowl, combine the flour and salt. Set aside " + "\n\t\u2022In another bowl, beat the eggs, hazelnut spread, brown sugar and vanilla extract with an electric mixer until smooth, about 2 minutes. \n\t\u2022With the mixer on low speed, add the flour mixture alternately with the melted butter. " +
                            "\n\t\u2022Spread the batter into the prepared pan. \nBake for 35 to 40 minutes or until a toothpick inserted into the centre comes out with a few lumps and not completely clean. " + "\n\t\u2022Let cool in the pan for about 2 hours. Unmould and cut into squares " +
                            "\n\nOptional: Dust with icing sugar"

                        };

                        Recipe Cookies = new Recipe()
                        {
                            RecipeID = 102,

                            RecipeTitle = "Cookies",

                            RecipeDescription = "Beware of The Cookie Monster",


                            RecipeIngredients = "1 cup (16 tablespoons) unsalted butter softened to room temperature 1\n cup light brown sugar \n2 teaspoons vanilla extract \n1 teaspoon molasses, \n1 / 2 cup granulated sugar" +
                            "\n1 large egg \n1 large egg yolk, \n2.25 cups all - purpose flour \n1 teaspoon salt \n1 teaspoon baking soda \n1 cup bittersweet chocolate chips \n0.5 cup coarsely chopped pecans \ncoarse sea salt to sprinkle on top ",

                            RecipeSteps = "\t\u2022Line two baking sheets with parchment paper and set aside. \n\t\u2022Place half the butter (8 tablespoons) in a medium skillet.\n\t\u2022 Melt the butter over medium heat, swirling it in the pan occasionally. It’ll foam and froth as it cooks, and start to crackle and pop. Once the crackling stops, keep a close eye on the melted butter, continuing to swirl the pan often. The butter will start to smell nutty, and brown bits will form in the bottom. Once the bits are amber brown (about 2 1/2 to 3 minutes or so after the sizzling stops), remove the butter from the burner and immediately pour it into a small bowl, bits and all. This will stop the butter from cooking and burning.  Allow it to cool for 20 minutes. \n\t\u2022Beat the remaining 1/2 cup butter with the brown sugar for 3 to 5 minutes, until the mixture is very smooth. \n\t\u2022Beat in the vanilla extract and brown sugar. \n\t\u2022Pour the cooled brown butter into the bowl, along with the granulated sugar. \n\t\u2022Beat for 2 minutes, until smooth; the mixture will lighten in color and become fluffy. \n\t\u2022Add the egg and egg yolk, and beat for one minute more. \t\u2022Add the flour, salt, and baking soda, beating on low speed just until everything is incorporated. \n\t\u2022Use a spatula to fold in the chocolate chips and pecans and finish incorporating all of the dry flour bits into the dough. \t\u2022Scoop the dough onto a piece of parchment paper, waxed paper, or plastic wrap. \n\t\u2022Flatten it slightly into a thick disk, and refrigerate for at least 30 minutes. \t\u2022About 15 minutes before you’re ready to begin baking, place racks in the center and upper third of the oven and preheat your oven to 350°F. \n\t\u2022Scoop the dough in 2 tablespoon-sized balls onto the prepared baking sheets. Leave about 2″ between the cookies; they’ll spread as they bake. \t\u2022Bake the cookies for 12 to 15 minutes, until they’re golden brown. \n\t\u2022Remove them from the oven, and allow them to rest on the baking sheet for at least 5 minutes before moving them. \n\nOptional: Sprinkle with Sea Salt"
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
                    IEnumerable<Recipe> recipes = cxn.Query<Recipe>("SELECT * FROM Recipe");

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
 