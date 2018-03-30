namespace RecipeService
{
    using System;
    using System.Collections.Generic;
    using RecipeShare;

    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service" dans le code, le fichier svc et le fichier de configuration.
    public class Service : InterfaceRecipeService
    {
        List<Recipe> InterfaceRecipeService.GetCommonRecipes(string p_ingredient)
        {
            throw new NotImplementedException();
        }

        void InterfaceRecipeService.AddRecipe(Recipe p_recipe)
        {
            throw new NotImplementedException();
        }

        public static void Main(string[] args)
        {
        }

    }
}