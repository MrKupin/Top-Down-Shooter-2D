using System;

public interface IHealth
{
    public event Action OnKill;
    public void Kill();
}
