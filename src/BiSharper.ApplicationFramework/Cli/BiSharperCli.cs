using Terminal.Gui;

namespace BiSharper.ApplicationFramework.Cli;

public abstract class BiSharperCli<TBiSharperTool> : IDisposable where TBiSharperTool : IBiToolExecutor
{
    private bool _disposed;
    public readonly TBiSharperTool Tool;

    protected BiSharperCli(string[] arguments, TBiSharperTool tool, ColorScheme? colorScheme)
    {
        Tool = tool;
    }
    
    protected virtual void ReleaseUnmanagedResources()
    {
    }
    
    protected virtual void ReleaseManagedResources()
    {
    }


    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            _disposed = true;
            ReleaseUnmanagedResources();
            if (disposing) ReleaseManagedResources();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~BiSharperCli()
    {
        Dispose(false);
    }
}