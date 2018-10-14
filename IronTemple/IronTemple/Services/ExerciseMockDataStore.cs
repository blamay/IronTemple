using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IronTemple.Models;

namespace IronTemple.Services
{
    public class ExerciseMockDataStore : IDataStore<Exercise>
    {
        List<Exercise> items;

        public ExerciseMockDataStore()
        {
            items = new List<Exercise>();
            var mockItems = new List<Exercise>
            {
                new Exercise { Id = Guid.NewGuid().ToString(), Title = "Bench Press", Description="Silver back action" },
                new Exercise { Id = Guid.NewGuid().ToString(), Title = "Deadlifts", Description="Don't snap yo shit up" },
                new Exercise { Id = Guid.NewGuid().ToString(), Title = "Dumbbell Squat", Description="Time to get some mo GAINS" },
                new Exercise { Id = Guid.NewGuid().ToString(), Title = "Shoulder Press", Description="This is an exercise description." },
                new Exercise { Id = Guid.NewGuid().ToString(), Title = "Tricep extensions", Description="Look at dem striations." },
                new Exercise { Id = Guid.NewGuid().ToString(), Title = "Sixth exercise", Description="This is an exercise description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Exercise exercise)
        {
            items.Add(exercise);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Exercise exercise)
        {
            var oldItem = items.Where((Exercise arg) => arg.Id == exercise.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(exercise);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Exercise arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Exercise> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Exercise>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}