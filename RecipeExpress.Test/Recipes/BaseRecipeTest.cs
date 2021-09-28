using AutoFixture;
using RecipeExpressDomain.Recipes.Documents;

namespace RecipeExpress.Test.Recipes
{
    public abstract class BaseRecipeTest
    {
        public Fixture _fixture;

        public BaseRecipeTest()
        {
            _fixture = new Fixture();
        }

        protected RecipeDocument CreateRecipeDocument()
        => _fixture.Create<RecipeDocument>();
    }
}
