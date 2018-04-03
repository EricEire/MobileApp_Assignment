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
                        //\n\t\u2022 created a new line with a bullet point
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

                        Recipe ApplePie = new Recipe()
                        {
                            RecipeID = 103,

                            RecipeTitle = "Apple Pie",

                            RecipeDescription = "An apple a day keeps the doctor away",

                            RecipeIngredients = "1kg Bramley Apples \n140g Golden Caster Sugar \n0.5 tsp cinnamon \n3tbsp flour  \nPastry(Store bought is fine)",

                            RecipeSteps = "\t\u2022Put a layer of paper towels on a large baking sheet. Quarter, core, peel and slice the apples about 5mm thick and lay evenly on the baking sheet. Put paper towels on top and set aside while you chill the pastry. " +
                            "\n\t\u2022Mix the 140g/5oz sugar, the cinnamon and flour for the filling in a large bowl(We need to add the apples also!) " +
                            "\n\t\u2022After the pastry has chilled, heat the oven to 190C/fan 170C/gas 5. " +
                            "Lightly beat the egg white with a fork. Cut off a third of the pastry and keep it wrapped while you roll out the rest, and use this to line a pie tin – 20-22cm round and 4cm deep – leaving a slight overhang. " +
                            "Roll the remaining third to a circle about 28cm in diameter. \n\t\u2022Pat the apples dry with kitchen paper, and tip them into the bowl with the cinnamon-sugar mix. Give a quick mix with your hands and immediately pile high into the pastry-lined tin. " +
                            "\n\t\u2022Brush a little water around the pastry rim and lay the pastry lid over the apples pressing the edges together to seal. Trim the edge with a sharp knife and make 5 little slashes on top of the lid for the steam to escape. (Can be frozen at this stage.) " +
                            "\n\t\u2022Brush it all with the egg white and sprinkle with caster sugar. Bake for 40-45 mins, until golden, then remove and let it sit for 5-10 mins." +
                            " \n\nSprinkle with more sugar and serve while still warm from the oven with softly whipped cream."
                        };

                        Recipe Meringue = new Recipe()
                        {
                            RecipeID = 104,
                            RecipeTitle = "Meringue",
                            RecipeDescription = "Crisy surface, chewy center...mmmm",
                            RecipeIngredients="3 Large Eggs \n175g Golden Caster Sugar",
                            RecipeSteps= "\t\u2022Preheat your oven to 100 \u00B0C Celcius" +
                            "\n\t\u2022Separate the eggs one at a time, placing each white in a cup or small bowl before adding it to the whisking bowl. " +
                            "\n\t\u2022Start whisker on a slow speed and begin whisking for about two minutes, or until everything has become bubbly" +
                            "\n\t\u2022Then switch to a medium speed for a further minute, then whisk at the highest speed and continue whisking through the soft peak stage until stiff peaks are formed. The whites should be all cloudy and foamy at this stage." +
                            "\n\t\u2022Next, whisk the sugar in on fast speed, about a tablespoon at a time, until you have a stiff and glossy mixture with a satin sheen. Spoon onto baking sheets lined with baking parchment (or a liner) ready for baking." +
                            "\n\t\u2022Bake for 1 hour 30 minutes to 1 hour 45 minutes in a fan oven, 1 hour 15 minutes in a conventional or gas oven, until the meringues sound crisp when tapped underneath and are a pale coffee colour. " +
                            "\n\t\u2022Leave to cool on the trays or a cooling rack.  "


                        };

                        // Insert Recipes into the database
                        cxn.Insert(NutellaBrownies);
                        cxn.Insert(Cookies);
                        cxn.Insert(ApplePie);
                        cxn.Insert(Meringue);
                        

                       
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
 