using AutoFixture;
using Moq;
using RecipeExpressDomain.Recipes.Documents;
using RecipeExpressDomain.Recipes.Entities;
using RecipeExpressDomain.Recipes.Repositories;
using RecipeExpressDomain.Recipes.Services;
using System;
using System.Collections.Generic;

namespace RecipeExpress.Test.Recipes
{
    public abstract class BaseRecipeTest
    {
        private Fixture _fixture;
        protected Guid _recipeId;
        protected Mock<IRecipeMongoRepository> _recipeMongoRepository;
        protected Mock<IRecipeEntityRepository> _recipeEntityRepository;
        protected RecipeService _recipeService;

        public BaseRecipeTest()
        {
            _fixture = new Fixture();
            _recipeId = _fixture.Create<Guid>();
            _recipeMongoRepository = new Mock<IRecipeMongoRepository>();
            _recipeEntityRepository = new Mock<IRecipeEntityRepository>();
            _recipeService = new RecipeService(_recipeMongoRepository.Object, _recipeEntityRepository.Object);
        }

        protected RecipeDocument CreateRecipeDocument()
        => _fixture.Build<RecipeDocument>()
            .With(r => r.Id, _recipeId)
            .Create();

        protected Recipe CreateRecipe()
       => _fixture.Build<Recipe>()
           .With(r => r.RecipeId, _recipeId)
           .Create();

        protected IEnumerable<RecipeDocument> CreateRecipeListDocument()
        => _fixture.Build<RecipeDocument>()
            .With(r => r.Id, _recipeId)
            .CreateMany();

    }
}
