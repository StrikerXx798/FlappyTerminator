public abstract class ManualSpawner<T> : BaseSpawner<T> where T : Element
{
    protected void Spawn()
    {
        SpawnItem();
    }
}