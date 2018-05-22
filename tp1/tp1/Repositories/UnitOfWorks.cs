using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using tp1.Models;

namespace tp1.Repositories
{
    public class UnitOfWork
    {
        public UnitOfWork()
        {
            this.context = new MyDbContext();
        }
        private readonly MyDbContext context;

        private GenericRepository<User> usersRepository;
        public GenericRepository<User> UsersRepository
        {
            get
            {
                if (this.usersRepository == null)
                {
                    this.usersRepository = new GenericRepository<User>(this.context);
                }
                return this.usersRepository;
            }
        }

        private GenericRepository<Post> postsRepository;
        public GenericRepository<Post> PostsRepository
        {
            get
            {
                if (this.postsRepository == null)
                {
                    this.postsRepository = new GenericRepository<Post>(this.context);
                }
                return this.postsRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}