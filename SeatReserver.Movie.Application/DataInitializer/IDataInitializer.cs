﻿namespace SeatReserver.Movie.Application.DataInitializer
{
    public interface IDataInitializer
    {
        public int SortNumber { get; init; }
        Task InitializeData();
    }
}
