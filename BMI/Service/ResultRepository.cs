﻿namespace BMI.Service
{
    public interface IResultRepository
    {
        Task SaveResultAsync(BmiResult result);
    }

    public class ResultRepository : IResultRepository
    {
        public Task SaveResultAsync(BmiResult result)
        {
            return Task.CompletedTask;
        }
    }
}