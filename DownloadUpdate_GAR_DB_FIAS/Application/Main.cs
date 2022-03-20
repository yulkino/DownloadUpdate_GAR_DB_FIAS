namespace DownloadUpdate_GAR_DB_FIAS.Application;

public class Main
{
    private readonly IInputProvider _inputProvider;
    private readonly IOutputProvider _outputProvider;

    public Main(IInputProvider inputProvider, IOutputProvider outputProvider)
    {
        _inputProvider = inputProvider;
        _outputProvider = outputProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var data = await _inputProvider.GetInputAsync(cancellationToken);
        await _outputProvider.OutputAsync(data, cancellationToken);
    }
}
