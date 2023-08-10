

using MvcRegistraion.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Microsoft.Win32;

namespace MvcRegistraion.Services;

public class RegisterServices
{
    private readonly IMongoCollection<RegistrationForm> _registerCollection;

    public RegisterServices(
        IOptions<RegistrationFormDatabaseSettings> registrationFormDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            registrationFormDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            registrationFormDatabaseSettings.Value.DatabaseName);

        _registerCollection = mongoDatabase.GetCollection<RegistrationForm>(
           registrationFormDatabaseSettings.Value.RegistrationFormCollectionName);
    }

    public async Task<List<RegistrationForm>> GetAsync() =>
        await _registerCollection.Find(_ => true).ToListAsync();

    public async Task<RegistrationForm?> GetAsync(string id) =>
        await _registerCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(RegistrationForm newRegistrationForm) =>
        await _registerCollection.InsertOneAsync(newRegistrationForm);

    public async Task UpdateAsync(string id, RegistrationForm updatedRegistrationForm) =>
        await _registerCollection.ReplaceOneAsync(x => x.Id == id, updatedRegistrationForm);

    public async Task RemoveAsync(string id) =>
        await _registerCollection.DeleteOneAsync(x => x.Id == id);
}