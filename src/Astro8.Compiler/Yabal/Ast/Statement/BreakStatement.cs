﻿using Astro8.Instructions;

namespace Astro8.Yabal.Ast;

public record BreakStatement(SourceRange Range) : Statement(Range)
{
    public override void Build(YabalBuilder builder)
    {
        if (builder.Block.Break is null)
        {
            builder.AddError(ErrorLevel.Error, Range, ErrorMessages.BreakOutsideLoop);
            return;
        }

        builder.Jump(builder.Block.Break);
    }
}
