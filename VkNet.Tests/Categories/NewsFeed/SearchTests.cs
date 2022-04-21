using NUnit.Framework;
using System.Linq;
using FluentAssertions;
using VkNet.Model.RequestParams;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.NewsFeed
{
	[TestFixture]

	public class SearchTests : CategoryBaseTest
	{
		protected override string Folder => "NewsFeed";

		[Test]
		public void Search_NextFrom_NotNull()
		{
			Url = "https://api.vk.com/method/newsfeed.search";
			ReadCategoryJsonPath(nameof(Search_NextFrom_NotNull));

			var result = Api.NewsFeed.Search(new NewsFeedSearchParams());

			result.Should().NotBeNull();
			Assert.IsNotEmpty(result.NextFrom);
		}

		[Test]
		public void Search_Coordinates_Exception()
		{
			Url = "https://api.vk.com/method/newsfeed.search";
			ReadCategoryJsonPath(nameof(Search_Coordinates_Exception));

			var result = Api.NewsFeed.Search(new NewsFeedSearchParams{
				Query = "word",
				Extended = false,
				Count = 20
			});

			result.Should().NotBeNull();
			Assert.IsNotEmpty(result.NextFrom);
		}

		[Test]
		public void Search_PostSourceData_Parsing()
		{
			Url = "https://api.vk.com/method/newsfeed.search";
			ReadCategoryJsonPath(nameof(Search_PostSourceData_Parsing));

			var result = Api.NewsFeed.Search(new NewsFeedSearchParams()
			{
				Query = "word",
				Extended = false,
				Count = 20
			});

			result.Should().NotBeNull();

			var first = result.Items.First();
			first.PostSource.Data.Should().NotBeNull();

			var second = result.Items.Last();
			second.PostSource.Data.Should().BeNull();
		}
	}
}