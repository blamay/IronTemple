﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IronTemple.Models;

namespace IronTemple.Services
{
    public class MockDataStore : IDataStore<Workout>
    {
        List<Workout> items;

        public MockDataStore()
        {
            items = new List<Workout>();
            var mockItems = new List<Workout>
            {
                new Workout { Id = Guid.NewGuid().ToString(), Title = "Chest Day", Description="Back in the Gym!!!" },
                new Workout { Id = Guid.NewGuid().ToString(), Title = "Back Day", Description="Its Gains Day" },
                new Workout { Id = Guid.NewGuid().ToString(), Title = "Leg Day", Description="Time to get some mo GAINS" },
                new Workout { Id = Guid.NewGuid().ToString(), Title = "Shoulder Day", Description="This is an workout description." },
                new Workout { Id = Guid.NewGuid().ToString(), Title = "Arms Day", Description="This is an workout description." },
                new Workout { Id = Guid.NewGuid().ToString(), Title = "Sixth workout", Description="This is an workout description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Workout workout)
        {
            items.Add(workout);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Workout workout)
        {
            var oldItem = items.Where((Workout arg) => arg.Id == workout.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(workout);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Workout arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Workout> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Workout>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}