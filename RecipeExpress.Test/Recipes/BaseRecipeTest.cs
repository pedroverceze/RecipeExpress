using AutoFixture;
using Moq;
using RecipeExpressDomain.Recipes.Entities;
using RecipeExpressDomain.Recipes.Repositories;
using RecipeExpressDomain.Recipes.Services;
using System;
using System.Linq;

namespace RecipeExpress.Test.Recipes
{
    public abstract class BaseRecipeTest
    {
        private Fixture _fixture;
        protected Guid _recipeId;
        protected Mock<IRecipeEntityRepository> _recipeEntityRepository;
        protected RecipeService _recipeService;

        public BaseRecipeTest()
        {
            _fixture = new Fixture();
            _recipeId = _fixture.Create<Guid>();
            _recipeEntityRepository = new Mock<IRecipeEntityRepository>();
            _recipeService = new RecipeService(_recipeEntityRepository.Object);
        }

        protected Recipe CreateRecipe()
        {
            _fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));

            _fixture.Behaviors.Add(new OmitOnRecursionBehavior(recursionDepth: 2));

            return _fixture.Build<Recipe>()
               .With(r => r.RecipeId, _recipeId)
               .Create();

        }
    }
}
