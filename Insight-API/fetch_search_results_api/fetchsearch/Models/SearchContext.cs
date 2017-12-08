using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ContentData;

namespace searchcontext{

    public class SearchContext:DbContext{

        public SearchContext(DbContextOptions<SearchContext> options): base(options){}

        //public DbSet<UserContentDetails> UserContentDetails  {get;set;}
        public DbSet<UserFileDetails> UserFileDetails  {get;set;}

        public DbSet<UserContentFileDetails> UserContentDetails{get;set;}
    }
}