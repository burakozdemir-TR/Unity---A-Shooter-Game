public interface IPooledObject
{
    bool IsAvailable { get; set; }
    void OnObjectSpawn();
    void Pool();
}
