namespace blog_api.Test;

using blog_api.Models;
using blog_api.Repository;

public class BlogApiTest
{

  [Theory]
  [InlineData("Title 1", "Content 1", "Author 1", "Author 1", "author@email.com")]
  public void ShouldCreateAPost(string title, string content, string authorName, string authorAbout, string authorEmail)
  {
    var _context = new BlogTestContext();
    var _repository = new BlogRepository(_context);

    var postTest = new Post() { Title = title, Content = content, Author = new Author() { Name = authorName, About = authorAbout, Email = authorEmail } };

    _repository.Add(postTest);
    _repository.GetAll<Post>().Count().Should().Be(1);
    _repository.GetAll<Post>().First().Should().Be(postTest);

  }

  [Theory]
  [InlineData(1)]
  public void ShouldDeleteAuthor(int postId)
  {
    var _context = new BlogTestContext();
    var _repository = new BlogRepository(_context);

    var postTest = new Post() { PostId = postId, Title = "title", Content = "content", Author = new Author() { Name = "authorName", About = "authorAbout", Email = "authorEmail" } };

    _repository.Add(postTest);
    _repository.GetAll<Post>().Count().Should().Be(1);
    _repository.GetAll<Post>().First().Should().Be(postTest);

    _repository.Delete(postTest);
    _repository.GetAll<Post>().Count().Should().Be(0);

  }
}
