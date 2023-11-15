using BiSharper.ApplicationFramework.Cli;
using BiSharper.ApplicationFramework.Tui;
using Terminal.Gui;

namespace BiSharper.ApplicationFramework;

public abstract class BiSharperTool<TTui, TCli, TToolExecutor> : IDisposable 
    where TCli : BiSharperCli<TToolExecutor>
    where TTui : BiSharperTui<TToolExecutor>
    where TToolExecutor : IBiToolExecutor
{
    protected readonly TToolExecutor ToolExecutor;
    public string Name => ToolExecutor.ToolName;
    public string Description => ToolExecutor.ToolDescription;
    private bool _disposed;

    protected BiSharperTool(TToolExecutor executor)
    {
        ToolExecutor = executor;
    }
    
    public override string ToString() => $"{Name,-16} ({Description})";
    
    
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

    ~BiSharperTool()
    {
        Dispose(false);
    }
}