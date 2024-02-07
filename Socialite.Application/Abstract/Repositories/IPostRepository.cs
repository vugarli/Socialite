using Socialite.Application.Specifications;
using Socialite.Domain.Entities.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Application.Abstract.Repositories
{
    public interface IPostRepository
    {
        public Task CreatePostAsync(Post post);

        public void UpdatePostAsync(Post post);

        public Task<Post> GetPostBySpecification(
            Specification<Post> specification);

        public Task<IEnumerable<Post>> GetPostsBySpecification(
            Specification<Post> specification);

        public Task<bool> CheckPostBySpecification(
            Specification<Post> specification);

        public Task<bool> CheckPostsBySpecification(
            Specification<Post> specification,
            int count);

        public Task<int> CountPostsBySpecification(
            Specification<Post> specification);
    }
}
