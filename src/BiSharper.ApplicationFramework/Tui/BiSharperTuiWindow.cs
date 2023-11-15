using Terminal.Gui;
namespace BiSharper.ApplicationFramework.Tui;

public class BiSharperTuiWindow : IDisposable
{
    public readonly Window Window;
    public readonly string ToolName;
    public readonly ColorScheme? ColorScheme;
    private bool _disposed;


    protected BiSharperTuiWindow(string toolName, ColorScheme? colorScheme = null)
    {
        ToolName = toolName;
        ColorScheme = colorScheme;
        Window = new Window
        {
            Title = $"BiSharper: {ToolName}",
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill(),
            ColorScheme = ColorScheme
        };
    }

    public virtual void InitializeGui()
    {
        
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

    ~BiSharperTuiWindow()
    {
        Dispose(false);
    }
    
}