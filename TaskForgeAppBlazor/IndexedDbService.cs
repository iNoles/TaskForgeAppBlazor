using System.Text.Json;
using Microsoft.JSInterop;

namespace TaskForgeAppBlazor;

public class IndexedDbService(IJSRuntime js)
{
    private readonly IJSRuntime _js = js;

    public async Task SaveItemAsync<T>(string store, string key, T item)
    {
        var json = JsonSerializer.Serialize(item);
        await _js.InvokeVoidAsync("localforage.setItem", key, json);
    }

    public async Task<T?> GetItemAsync<T>(string store, string key)
    {
        var json = await _js.InvokeAsync<string>("localforage.getItem", key);
        if (string.IsNullOrEmpty(json)) return default;
        return JsonSerializer.Deserialize<T>(json);
    }

    public async Task<List<T>> GetAllItemsAsync<T>(string store)
    {
        var listJson = await _js.InvokeAsync<string[]>("localforage.keys");
        var result = new List<T>();
        foreach (var key in listJson)
        {
            var item = await GetItemAsync<T>(store, key);
            if (item != null) result.Add(item);
        }
        return result;
    }

    public async Task RemoveItemAsync(string store, string key)
    {
        await _js.InvokeVoidAsync("localforage.removeItem", key);
    }
}