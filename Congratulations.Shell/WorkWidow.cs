namespace Congratulations.Shell;

public class WorkWidow
{
    private readonly Thread _shell;
    private readonly Thread _input;

    public WorkWidow()
    {
        _shell = new Thread(Terminal.ShowMenuBar);
        _input = new Thread(Terminal.CheckingInput);
    }

    public void Run()
    {
        _shell.Start();
        _input.Start();
    }
}
