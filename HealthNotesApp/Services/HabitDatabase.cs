using SQLite;
using HealthNotesApp.Models;

namespace HealthNotesApp.Services;

public class HabitDatabase
{
    private readonly SQLiteAsyncConnection _database;

    public HabitDatabase(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Habit>().Wait();
    }

    public Task<List<Habit>> GetHabitsAsync()
    {
        return _database.Table<Habit>().ToListAsync();
    }

    public Task<int> AddHabitAsync(Habit habit)
    {
        return _database.InsertAsync(habit);
    }

    public Task<int> DeleteHabitAsync(Habit habit)
    {
        return _database.DeleteAsync(habit);
    }

    public Task<int> UpdateHabitAsync(Habit habit)
    {
        return _database.UpdateAsync(habit);
    }
}