namespace SwinAdventure;

public class CommandProcessor
{
    private List<Command> _commands;

    public CommandProcessor()
    {
        _commands = new List<Command>
        {
            new LookCommand(),
            new MoveCommand(),
            new TakeCommand(),
            new PutCommand()
        };
    }

    public string ExecuteCommand(Player player, string[] input)
    {
        if (input.Length == 0 || string.IsNullOrWhiteSpace(input[0]))
            return "No command given.";

        string commandWord = input[0].ToLower();

        foreach (Command cmd in _commands)
        {
            if (cmd.AreYou(commandWord))
                return cmd.Execute(player, input);
        }

        return $"I don't understand '{commandWord}'.";
    }
}
