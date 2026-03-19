using SQLite;
using HealthNotesApp.Models;

namespace HealthNotesApp.Services;

public class HabitService : IHabitService
{
    private readonly SQLiteAsyncConnection _db;

    public HabitService(SQLiteAsyncConnection db)
    {
        _db = db;
    }

    public async Task InitAsync()
    {
        await _db.CreateTableAsync<Habit>();
    }

    public async Task<List<Habit>> GetHabitsAsync()
    {
        return await _db.Table<Habit>().ToListAsync();
    }

    public async Task AddHabitAsync(Habit habit)
    {
        await _db.InsertAsync(habit);
    }

    public async Task DeleteHabitAsync(Habit habit)
    {
        await _db.DeleteAsync(habit);
    }

    public async Task UpdateHabitAsync(Habit habit)
    {
        await _db.UpdateAsync(habit);
    }
}