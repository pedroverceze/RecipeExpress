using AutoFixture;
using Moq;
using RecipeExpressDomain.Ingredients.Entities;
using RecipeExpressDomain.Ingredients.Repositories;
using RecipeExpressDomain.Ingredients.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RecipeExpress.Test.Ingredients
{
    public class IngredientServiceTests
    {
        private Fixture _fixture;
        private Mock<IIngredientEntityRepository> _ingredientRepository;
        private IngredientService _ingredientService;

        private Guid _id;

        public IngredientServiceTests()
        {
            _ingredientRepository = new Mock<IIngredientEntityRepository>();
            _ingredientService = new IngredientService(_ingredientRepository.Object);
            _fixture = new Fixture();

            _fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));

            _fixture.Behaviors.Add(new OmitOnRecursionBehavior(recursionDepth: 2));
        }

        [Fact]
        public async Task EnrollIingredient_ShouldBeSuccess()
        {
            var ing = CreateIngredient();
            _ingredientRepository.Setup(s => s.InsertIngredient(ing)).Returns(Task.CompletedTask);

            var result = await _ingredientService.EnrollIngredient(ing);

            Assert.Equal(ing, result);
        }

        private Ingredient CreateIngredient()
            => _fixture.Build<Ingredient>()
            .With(i => i.IngredientId, _id)
            .Create();
    }
}
