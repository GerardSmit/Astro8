using Astro8.Instructions;
using Astro8.Yabal.Ast;

namespace Astro8.Yabal.Visitor;

public record Variable(Identifier Identifier, InstructionPointer Pointer, LanguageType Type, Expression? Initializer = null)
{
    public bool Constant { get; set; } = true;

    public int Usages { get; set; }

    public bool HasBeenUsed { get; set; }

    public bool CanBeRemoved => HasBeenUsed && Usages == 0;

    public List<IdentifierExpression> References { get; } = new();
}
