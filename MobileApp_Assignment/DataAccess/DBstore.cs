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
                            RecipeSteps= "\t\u2022Preheat your oven to 100\u00B0C" +
                            "\n\t\u2022Separate the eggs one at a time, placing each white in a cup or small bowl before adding it to the whisking bowl. " +
                            "\n\t\u2022Start whisker on a slow speed and begin whisking for about two minutes, or until everything has become bubbly" +
                            "\n\t\u2022Then switch to a medium speed for a further minute, then whisk at the highest speed and continue whisking through the soft peak stage until stiff peaks are formed. The whites should be all cloudy and foamy at this stage." +
                            "\n\t\u2022Next, whisk the sugar in on fast speed, about a tablespoon at a time, until you have a stiff and glossy mixture with a satin sheen. Spoon onto baking sheets lined with baking parchment (or a liner) ready for baking." +
                            "\n\t\u2022Bake for 1 hour 30 minutes to 1 hour 45 minutes in a fan oven, 1 hour 15 minutes in a conventional or gas oven, until the meringues sound crisp when tapped underneath and are a pale coffee colour. " +
                            "\n\t\u2022Leave to cool on the trays or a cooling rack.  "


                        };

                        Recipe Cheesecake = new Recipe()
                        {
                            RecipeID = 105,
                            RecipeTitle = "Baileys Cheesecake",
                            RecipeDescription = "Just for the grown ups?...",
                            RecipeIngredients = "300g chocolate digestive biscuits, crushed \n125g butter \n50g milk chocolate \n200ml cream " +
                            "\n450g cream cheese \n125g icing sugar \n1 GENEROUS measure of Bailey's Irish Cream \n50g grated chocolate",
                            RecipeSteps = "\t\u2022Grease a 23cms/9” springform or loose bottomed cake tin with butter. " +
                            "\n\t\u2022Melt the rest of butter and mix with the biscuits until butter is absorbed. " +
                            "\n\t\u2022While still warm spread mixture into the base of the prepared tin and press down using the back of a spoon. " +
                            "\n\t\u2022Place in the fridge and allow to set for about an hour. " +
                            "\n\t\u2022In the meantime, grate the chocolate" +
                            "\n\t\u2022Whip the cream until thickened and in a separate bowl whisk the cream cheese until it is soft. Beat in the icing sugar and the Bailey's. " +
                            "\n\t\u2022Fold in the cream and chocolate until the mix is combined and spread evenly over the biscuit base. " +
                            "\n\t\u2022Place in the fridge for at least 2 hours, preferably overnight." +
                            "\n\t\u2022Decorate with a little grated chocolate"
                        };

                        Recipe Scone = new Recipe()
                        {
                            RecipeID = 106,
                            RecipeTitle = "Scones",
                            RecipeDescription = "Is it \"S-con\", or \"S-cone\"?",
                            RecipeIngredients = "225g Odlums Self Raising Flour \n150ml Milk \nPinch of Salt \n25g Golden Caster Sugar \n25g Butter ",
                            RecipeSteps = "\t\u2022Sieve flour and salt into a bowl, stir in sugar" +
                            "\n\t\u2022Rub in butter (Use your hands to mix it together!)" +
                            "\n\t\u2022Add sufficient milk to make a soft dough." +
                            "\n\t\u2022Turn onto a floured board and gently knead to remove any cracks. " +
                            "\n\t\u2022Roll out lightly to 1 inch in thickness. Cut into scones with a cutter dipped in flour." +
                            "\n\t\u2022Place on a floured preheated baking sheet/tray, glaze if liked with beaten egg or milk." +
                            "\n\t\u2022Bake in a preheated oven 220\u00B0C on upper shelf position for 10 mins approx." +
                            "\n\t\u2022Cool on a wire tray."
                        };

                        Recipe Cupcakes = new Recipe()
                        {
                            RecipeID = 107,
                            RecipeTitle = "Lemon Cupcakes",
                            RecipeDescription = "Great for parties!",
                            RecipeIngredients = "115g caster sugar \n115g butter \n1 egg \n115g self - raising flour \n2 drops lemon extract" +
                            "\n140g icing sugar, sifted \n85g butter \n1 drop lemon extract \n1 tbsp milk",
                            RecipeSteps = "\n\t\u2022Preheat oven 180°C/350°F/Gas mark 4." +
                            "\n\t\u2022Cream butter and sugar." +
                            "\n\t\u2022Add egg and beat together." +
                            "\n\t\u2022Sift flour and fold gently in." +
                            "\n\t\u2022Add lemon drops, milk and mix together." +
                            "\n\t\u2022Spoon the mixture into cases and bake for around 10 - 15 mins." +
                            "\n\t\u2022Remove from the oven and leave to cool before spreading the icing." +
                            "\n\n \t\t\t\t\tTo make our icing \n" +
                            "\n\t\u2022In a mixing bowl, beat togther icing sugar and butter." +
                            "\n\t\u2022Add lemon extract and milk." +
                            "\n\t\u2022Beat until smooth." +
                            "\n\t\u2022Enjoy!" +
                            "\n\nOptional: Decorate your cakes!"
                        };

                        Recipe BananaBread = new Recipe()
                        {
                            RecipeID = 108,
                            RecipeTitle = "Chocolate Banana Bread",
                            RecipeDescription = "Super simple, super tasty",
                            RecipeIngredients = "3 ripe bananas \n2 eggs \n120g Greek yogurt \n100g honey \n190g flour \n1 tsp vanilla extract " +
                            "\n1 tsp baking soda \n150g dark chocolate chips \n100g peanut butter" +
                            "\n20g cocoa powder" +
                            "\n60g honey \n1 tsp vanilla extract \n40ml milk",
                            RecipeSteps = "\n\t\u2022Heat the oven to 180˚C/350˚F. Grease and line a loaf pan. " +
                            "\n\t\u2022In a medium mixing bowl, mash the bananas, then add all the wet ingredients and mix." +
                            "\n\t\u2022Add all the dry ingredients,mix, then add the chocolate chips and stir to combine." +
                            "\n\t\u2022Pour the batter into the prepared pan.Bake for about 50 minutes or until a toothpick comes out clean." +
                            "\n\n   \t\t\t\t\tMeanwhile, make the frosting. \n" +
                            "\n\t\u2022In a food processor, add peanut butter, cocoa powder, honey, milk and vanilla and pulse." +
                            "\n\t\u2022Let the banana bread cool before frosting"
                        };

                        // Insert Recipes into the database
                        cxn.Insert(NutellaBrownies);
                        cxn.Insert(Cookies);
                        cxn.Insert(ApplePie);
                        cxn.Insert(Meringue);
                        cxn.Insert(Cheesecake);
                        cxn.Insert(Scone);
                        cxn.Insert(Cupcakes);
                        cxn.Insert(BananaBread);
                        

                       
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
 