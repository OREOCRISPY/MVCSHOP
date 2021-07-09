using System;
using System.Collections.Generic;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        public List<MovieCardResponseModel> GetTopRevenueMovies()
        {
            throw new NotImplementedException();
        }
    }

    public class MovieService2 : IMovieService
    {
        public List<MovieCardResponseModel> GetTopRevenueMovies()
        {
            throw new NotImplementedException();
        }
    }
}

// DI

// method(int x, MovieService service)
// var service =  new MovieService();
// method(4,service )