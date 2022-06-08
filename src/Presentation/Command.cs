using Exo3.Core;

namespace Exo3.Presentation;

public record Command(OperationWrapper Operation, string FilePath);